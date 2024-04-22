using FilesManager.Domain.Common;

namespace FilesManager.Domain.Entities.AppUser;
public class User : IEntityBase<Guid>
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? DisplayName => $"{FirstName} {LastName}";
    public DateTime? BirthDate { get; set; }
    public bool IsConfirm { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpirationTime { get; set; }
    public string? EmailOtp { get; set; }
    public DateTime? EmailOtpExpirationTime { get; set; }
    public bool IsDeleted { get; set; }
}
