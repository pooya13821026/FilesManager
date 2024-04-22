using FilesManager.Domain.Enum.DataBase;
using Microsoft.AspNetCore.Identity;

namespace FilesManager.Application.Models.SiteSetting;
public class SiteSettings
{
    public List<PaymentSettings> Payment { get; set; } = null!;
    public JwtSettings Jwt { get; set; } = null!;
    //public List<UserSeed> DefaultUsers { get; set; } = null!;
    public SmsSettings Sms { get; set; } = null!;
    public SmtpSettings Smtp { get; set; } = null!;
    public ConnectionStrings ConnectionStrings { get; set; } = null!;
    public TimeSpan EmailConfirmationTokenProviderLifespan { get; set; }
    public PasswordOptions PasswordOptions { get; set; } = null!;
    public ActiveDatabaseEnum ActiveDatabase { get; set; }
    public LockoutOptions LockoutOptions { get; set; } = null!;
}
