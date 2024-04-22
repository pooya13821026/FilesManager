using FilesManager.Application.Contracts.Data;
using FilesManager.Domain.Common;
using FilesManager.Domain.Entities.AppUser;
using FilesManager.Domain.Entities.Dastresi;
using FilesManager.Domain.Entities.Eshterak;
using FilesManager.Domain.Entities.File;
using FilesManager.Domain.Entities.Link;
using FilesManager.Domain.Entities.StorageManager;
using Microsoft.EntityFrameworkCore;


namespace FilesManager.Infrastructure.Data;

public class ApplicationContext : DbContext, IApplicationContext

{
    public ApplicationContext() { }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    #region DbSets

    public DbSet<Link> Link { get; set; }
    public DbSet<Dastresi> Dastresi { get; set; }
    public DbSet<Eshterak> Eshterak { get; set; }
    public DbSet<AppFile> File { get; set; }
    public DbSet<StorageManager> StorageManager { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }

    #endregion

    #region Configuration
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase<Guid>>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.ModifiedAt = entry.Entity.CreatedAt;
                    entry.Entity.IsDeleted = false;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedAt = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
    #endregion
}

#region CodeComments

//public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
//{
//    public ApplicationContext CreateDbContext(string[] args)
//    {
//        var configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//            .AddEnvironmentVariables()
//            .Build();

//        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
//        optionsBuilder.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:SqlServer"));

//        return new ApplicationContext(optionsBuilder.Options);
//    }
//}

#endregion