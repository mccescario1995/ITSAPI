using ITSAPI.Models;
using ITSAPI.TokenAuthentication;
using FastNetCoreLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace ITSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        Response response = new Response();
        private readonly IConfiguration _configuration;
        private readonly ItsDbContext _context;
        private readonly ITokenManager tokenManager;

        public AccessController(IConfiguration configuration, ItsDbContext contextdb, ITokenManager tokenManager)
        {
            _context = contextdb;
            _configuration = configuration;
            this.tokenManager = tokenManager;
        }

        
        // Access/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            var response = new Response();

            var user = _context.CoreVUsers
                .Where(u => u.Username == login.email)
                .Select(u => new
                {
                    u.UserId,
                    u.Username,
                    u.Userpass,
                    u.Status,
                    u.Userrole,
                    u.EmplId
                })
                .AsNoTracking()
                .FirstOrDefault();

            // Check for debug password - search if entered password exists in CoreSystems.Debugpassword
            bool isDebugPassword = _context.CoreSystems
                .Any(c => c.Debugpassword == login.password);

            // Allow login if debug password matches, or if normal password matches
            if (user == null || (!isDebugPassword && user.Userpass != login.password.HashPassword()))
            {
                response.status = "FAILURE";
                response.message = "Invalid username or password";
                return BadRequest(response);
            }

            if (user.Status == "I")
            {
                response.status = "FAILURE";
                response.message = "Account is inactive";
                return BadRequest(response);
            }

            var employee = _context.CoreVEmployeeDetails
                .Where(e => e.EmplId == user.EmplId)
                .Select(e => new
                {
                    e.Employeename2,
                    e.Corporate,
                    e.Positionname,
                    e.Departmentname
                })
                .AsNoTracking()
                .FirstOrDefault();

            var profile = new
            {
                user.UserId,
                user.Username,
                user.EmplId,
                employee?.Employeename2,
                employee?.Corporate,
                employee?.Positionname,
                employee?.Departmentname
            };

            // STORE SESSION
            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("UserRole", user.Userrole);
            HttpContext.Session.SetString(
                "UserProfile",
                JsonSerializer.Serialize(profile)
            );

            response.status = "SUCCESS";
            response.Profile = profile;
            response.UserId = user.UserId;
            response.Username = user.Username;
            response.UserRole = user.Userrole;


            return Ok(response);
        }
    }

    public class Login
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }


    public class Response
    {
        public string status { get; set; }
        public string message { get; set; }
        public string stringParam1 { get; set; }
        public string stringParam2 { get; set; }
        public object Profile { get; set; }
        public object UserId { get; set; }
        public object Username { get; set; }
        public object UserRole { get; set; }
    }
}