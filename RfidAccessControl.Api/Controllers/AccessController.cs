using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RfidAccessControl.Api.Models;

namespace RfidAccessControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccessController : ControllerBase
{
    private readonly AppDbContext _db;

    public AccessController(AppDbContext db) => _db = db;

    [HttpPost("scan")]
    public async Task<IActionResult> ScanCard([FromBody] ScanRequest request)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.TagId == request.TagId);
        bool granted = user != null && user.IsActive;
        string message = user == null 
            ? "Unknown Card Tag" 
            : (user.IsActive ? $"Welcome, {user.FullName}!" : "Access Denied: Card Inactive");

        var log = new AccessLog
        {
            TagId = request.TagId,
            Timestamp = DateTime.UtcNow,
            AccessGranted = granted,
            Message = message
        };

        _db.AccessLogs.Add(log);
        await _db.SaveChangesAsync();

        return Ok(new { Granted = granted, Message = message, Timestamp = log.Timestamp });
    }
}