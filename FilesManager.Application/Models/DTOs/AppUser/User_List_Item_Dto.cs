namespace FilesManager.Application.Models.DTOs.AppUser;
public class User_List_Item_Dto
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public string? Email { get; set; }
    public bool Deleted { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool IsConfirm { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}
