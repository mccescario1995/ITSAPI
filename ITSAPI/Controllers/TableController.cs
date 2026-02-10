using ITSAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ITSAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TableController : ControllerBase
{
    private readonly ItsDbContext _context;
    private readonly IConfiguration _configuration;

    public TableController(ItsDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    // Get all issue type
    [HttpGet("get-issue-type")]
    public async Task<IActionResult> GetIssueLists()
    {
        try
        {
            var query = _context.ItsIssuetypes.Where(u => u.Isdelete == 0 || u.Status == 1);
            
            var data = await query
                .OrderByDescending(u => u.Id)
                .ToListAsync();


            return Ok(new
            {
                success = true,
                data = new
                {
                    items = data,
                }
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
        }
    }

    // Get all group
    [HttpGet("get-group")]
    public async Task<IActionResult> GetGroup()
    {
        try
        {
            var query = _context.ItsVGroups.Where(u => u.IsDelete == 0 || u.Status == 1);

            var data = await query
                .OrderByDescending(u => u.Id)
                .ToListAsync();


            return Ok(new
            {
                success = true,
                data = new
                {
                    items = data,
                }
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
        }
    }

    // Get all employee
    [HttpGet("get-employee")]
    public async Task<IActionResult> GetEmployee(
        [FromQuery] string? search = null)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(search))
                return Ok(new List<object>());

            var query = _context.CoreVEmployeeDetails.Where(u => u.Employeename.ToLower().Contains(search.ToLower()));

            var data = await query
                .OrderBy(u => u.Lname)
                .Take(15)
                .Select(u => new {
                    u.EmplId,
                    u.Employeename
                })
                .ToListAsync();

            return Ok(new
            {
                success = true,
                data = new
                {
                    items = data
                }
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
        }
    }

    // Get all status
    [HttpGet("get-status")]
    public async Task<IActionResult> GetStatus()
    {
        try
        {
            var query = _context.ItsStatuses.Where(u => u.Isdelete == 0 || u.Status == 1);

            var data = await query
                .OrderBy(u => u.Id)
                .ToListAsync();


            return Ok(new
            {
                success = true,
                data = new
                {
                    items = data,
                    
                }
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
        }
    }

}
