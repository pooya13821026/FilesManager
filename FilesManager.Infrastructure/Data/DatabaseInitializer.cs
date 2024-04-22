using FilesManager.Application.Contracts.Data;
using Microsoft.EntityFrameworkCore;


namespace FilesManager.Infrastructure.Data;
public class DatabaseInitializer : IDatabaseInitializer
{
    //private static readonly string[] ValidateUsers =
    //{
    //    RoleEnum.Administrator.ToString(),
    //    RoleEnum.Admin.ToString()
    //};

    private readonly ApplicationContext _context;
    //private readonly SiteSettings _siteSettings;
    //private readonly UserManager<User> _userManager;
    //private readonly RoleManager<Role> _roleManager;
    //private readonly IMapper _mapper;

    public DatabaseInitializer(
        ApplicationContext context
        /*IOptionsSnapshot<SiteSettings> siteSettings,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        IMapper mapper*/)
    {
        _context = context;
        /*_siteSettings = siteSettings.Value;
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper*/;
    }

    public void Initialize()
    {
        _context.Database.Migrate();
    }

    //public async Task SeedRoleDataAsync()
    //{
    //    foreach (var role in Enum.GetValues(typeof(RoleEnum)))
    //    {
    //        try
    //        {
    //            var existRole = await _roleManager.FindByNameAsync(role.ToString() ?? string.Empty);
    //            if (existRole != null) continue;
    //            await _roleManager.CreateAsync(new Role()
    //            {
    //                Name = role.ToString(),
    //                NormalizedName = role.ToString()?.ToUpper()
    //            });
    //        }
    //        catch { return; }
    //    }
    //}

    //async Task SeedRoleDataAsync(string roleName)
    //{
    //    try
    //    {
    //        var existRole = await _roleManager.FindByNameAsync(roleName);
    //        if (existRole != null) return;
    //        await _roleManager.CreateAsync(new Role()
    //        {
    //            Name = roleName,
    //            NormalizedName = roleName.ToUpper()
    //        });
    //    }
    //    catch { return; }
    //}

    //public async Task SeedUserDataAsync()
    //{
    //    foreach (var user in _siteSettings.DefaultUsers)
    //    {
    //        try
    //        {
    //            var existUser = await _userManager.FindByNameAsync(user.UserName);
    //            if (existUser != null) continue;
    //            var userModel = _mapper.Map<User>(user);
    //            if (ValidateUsers.Contains(user.RoleName))
    //            {
    //                userModel.EmailConfirmed = true;
    //                userModel.PhoneNumberConfirmed = true;
    //                userModel.DateOfBirth = DateTime.Now;
    //                userModel.IsConfirm = true;
    //            }
    //            if (await _userManager.CreateAsync(userModel, user.Password) != IdentityResult.Success) continue;
    //            await SeedRoleDataAsync(user.RoleName);
    //            await _userManager.AddToRoleAsync(userModel, user.RoleName);
    //        }
    //        catch { return; }
    //    }
    //}
}
