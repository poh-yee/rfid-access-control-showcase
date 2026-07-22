namespace RfidAccessControl.Api.Models;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string TagId { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public class AccessLog
{
    public int Id { get; set; }
    public string TagId { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public bool AccessGranted { get; set; }
    public string Message { get; set; } = string.Empty;
}

public record ScanRequest(string TagId);