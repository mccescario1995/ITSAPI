using ITSAPI.Models;
using ITSAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ITSAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IssueController : ControllerBase
{
    private readonly ItsDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly ILogger<IssueController> _logger;

    public IssueController(ItsDbContext context, IConfiguration configuration, ILogger<IssueController> logger)
    {
        _context = context;
        _configuration = configuration;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIssueDetails(int id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var query = _context.ItsVIssues.Where(u => u.Status >= 1 && u.IsDelete == 0);

            var issue = query.FirstOrDefaultAsync(u => u.Id == id);

            return Ok(new
            {
                success= true,
                items = issue
            });
        }
        catch(Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateIssue([FromBody] CreateIssueDto createIssueDto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var newIssue = new ItsIssue
            {
                Isusedetails = createIssueDto.IssueDetails,
                Actionplan = createIssueDto.ActionPlan,
                Issuetypeid = createIssueDto.IssueTypeId,
                Responsiblegroupid = createIssueDto.ResponsibleGroupId,
                Responsibleempid = createIssueDto.ResponsibleEmpId,
                Status = createIssueDto.Status,
                Createdbyuserid = createIssueDto.CreatedByUserId,
            };

            _context.ItsIssues.Add(newIssue);
            await _context.SaveChangesAsync();

            var newIssueThread = new ItsIssuethread
            {
                Issueid = newIssue.Id,
                Messagedetail = "Issue created",
                Createdbyuserid = 0,
                Createddate = DateTime.Now
            };

            _context.ItsIssuethreads.Add(newIssueThread);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return Ok(new { success = true, message = "Issue created successfully" });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Error creating feedback");
            return StatusCode(500, new { success = false, message = "Internal server error" });
        }
    }

    // Get paginated list of issues with optional search
    [HttpGet("list")]
    public async Task<IActionResult> GetIssueLists(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? search = null)
    {
        try
        {
            var query = _context.ItsVIssues.Where(u => u.IsDelete == 0 && u.Status >= 1);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(u => u.Id.ToString().Contains( search )||         
                                         u.IssueDetails.ToLower().Contains(search) ||
                                         u.ActionPlan.ToLower().Contains(search) ||
                                         u.IssueType.ToLower().Contains(search) ||
                                         u.ResponsibleGroupName.ToLower().Contains(search) ||
                                         u.ResponsibleEmployee.ToLower().Contains(search));
            }

            var totalCount = await query.CountAsync();
            

            var issues = await query
                .OrderByDescending(u => u.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();


            return Ok(new
            {
                success = true,
                data = new
                {
                    items = issues,
                    pagination = new
                    {
                        totalCount,
                        currentPage = page,
                        pageSize,
                        totalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
                    }
                }
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
        }
    }

    [HttpPost("update/{id}")]
    public async Task<IActionResult> UpdateIssue(
        int id,
        [FromBody] UpdateIssueDto updateIssueDto
    )
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var issue = await _context.ItsIssues
                .FirstOrDefaultAsync(u => u.Id == id && u.Isdelete == 0);

            if (issue == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Issue not found"
                });
            }

            issue.Isusedetails = updateIssueDto.IssueDetails;
            issue.Actionplan = updateIssueDto.ActionPlan;
            issue.Issuetypeid = updateIssueDto.IssueTypeId;
            issue.Responsiblegroupid = updateIssueDto.ResponsibleGroupId;
            issue.Responsibleempid = updateIssueDto.ResponsibleEmpId;
            issue.Status = updateIssueDto.Status;

            issue.Modifiedbyuserid = updateIssueDto.ModifiedByUserId;
            issue.Modifieddate = DateTime.Now;

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok(new
            {
                success = true,
                message = "Issue updated successfully",
            });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();

            return StatusCode(500, new
            {
                success = false,
                message = "An error occurred while updating the issue",
                error = ex.Message
            });
        }
    }


    [HttpPost("delete/{id}")]
    public async Task<IActionResult> DeleteIssue(int id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var issue = await _context.ItsIssues.FirstOrDefaultAsync(u => u.Id == id &&  u.Isdelete == 0);

            if (issue == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Issue not found."
                });
            }

            issue.Isdelete = 1;
            //issue.Modifiedbyuserid = *insert user ID*
            issue.Modifieddate = DateTime.Now;

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return Ok(new
            {
                success = true,
                message = "Issue deleted successfully."
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                success = false,
                message = "An error occurred while deleting the issue.",
                error = ex.Message
            });
        }
    }

    // GET: api/issue/{issueId}/messages
    [HttpGet("{issueId}/messages")]
    public async Task<IActionResult> GetMessages(int issueId)
    {
        var messages = await _context.ItsVIssueThreads
            .Where(m => m.IssueId == issueId)
            .OrderBy(m => m.CreatedDate)
            .Select(m => new ItsVIssueThread
            {
                Id = m.Id,
                IssueId = m.IssueId,
                MessageDetail = m.MessageDetail,
                CreatedByUserId = m.CreatedByUserId,
                CreatedBy = m.CreatedBy,
                CreatedDate = m.CreatedDate,
            })
            .ToListAsync();

        return Ok( new
        {
            success = true,
            items = messages
        });
    }

    // POST: api/issue/{issueId}/messages
    [HttpPost("{issueId}/messages")]
    public async Task<IActionResult> AddMessage(
        int issueId,
        [FromBody] CreateIssueMessageDto dto
    )
    {
        if (string.IsNullOrWhiteSpace(dto.MessageDetail))
            return BadRequest("Message is required.");

        // Get userId from session FIRST
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
            return Unauthorized("User not logged in.");

        // Fetch user info AFTER userId is validated
        var user = await _context.CoreVUsers
            .Where(u => u.UserId == userId.Value)
            .Select(u => new
            {
                u.Firstname,
                u.Lastname
            })
            .FirstOrDefaultAsync();

        if (user == null)
            return Unauthorized("User not found.");

        // Check issue exists
        var issue = await _context.ItsIssues
            .FirstOrDefaultAsync(x => x.Id == issueId);

        if (issue == null)
            return NotFound("Issue not found.");

        //Default message (normal reply)
        var message = new ItsIssuethread
        {
            Issueid = issueId,
            Messagedetail = dto.MessageDetail,
            Createdbyuserid = userId.Value,
            Createddate = DateTime.Now
        };

        _context.ItsIssuethreads.Add(message);

        //If status is being updated, override message content
        if (dto.StatusId > 0 && dto.StatusId != dto.OldStatusId)
        {
            var oldStatusName = _context.ItsStatuses
                .Where(s => s.Id == dto.OldStatusId)
                .Select(s => s.Name)
                .FirstOrDefault() ?? $"#{dto.OldStatusId}";

            var newStatusName = _context.ItsStatuses
                .Where(s => s.Id == dto.StatusId)
                .Select(s => s.Name)
                .FirstOrDefault() ?? $"#{dto.StatusId}";

            message.Messagedetail =
                $"{user.Firstname} {user.Lastname} updated status from {oldStatusName} to {newStatusName}";

            message.Createdbyuserid = 0;
            message.Createddate = DateTime.UtcNow;

            var message2 = new ItsIssuethread
            {
                Issueid = issueId,
                Messagedetail = dto.MessageDetail,
                Createdbyuserid = userId.Value,
                Createddate = DateTime.UtcNow
            };

            //Update issue status
            issue.Status = dto.StatusId;
            issue.Modifiedbyuserid = userId.Value;
            issue.Modifieddate = DateTime.UtcNow;

            _context.ItsIssuethreads.Add(message2);
        }


        await _context.SaveChangesAsync();

        return Ok(new
        {
            success = true,
            messageId = message.Id
        });
    }


}
