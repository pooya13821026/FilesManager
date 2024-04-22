﻿namespace FilesManager.Application.Models.SiteSetting;
public class UserSeed
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string StudentNumber { get; set; } = string.Empty;
}
