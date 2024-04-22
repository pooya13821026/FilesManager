namespace FilesManager.Infrastructure.Implementation.Services.StorageManager.Utils;
public static class GeneratePassword
{
    public static string GeneratePasswordHandle(int length)
    {
        // Random password generation
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
