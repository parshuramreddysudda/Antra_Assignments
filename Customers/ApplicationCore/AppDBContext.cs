using ApplicationCore.Entities;
using ApplicationCore.Entities.ApplicationUser;
using Claim.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore;

public class AppDbContext:IdentityDbContext<ApplicationUser,IdentityRole<int>,int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<AppUserClaim>().HasData(
            new AppUserClaim() { Id = 1, ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.ADD_MANAGER_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
            new AppUserClaim() { Id = 2, ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.EDIT_MANAGER_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
            new AppUserClaim() { Id = 3, ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.DELETE_MANAGER_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
            new AppUserClaim() { Id = 4, ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.GET_MANAGER_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
            
            new AppUserClaim() { Id = 5, ClaimType = Constants.ROLE_MANAGER, ClaimValue = Constants.ADD_EMPLOYEE_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
            new AppUserClaim() { Id = 6, ClaimType = Constants.ROLE_MANAGER, ClaimValue = Constants.EDIT_EMPLOYEE_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
            new AppUserClaim() { Id = 7, ClaimType = Constants.ROLE_MANAGER, ClaimValue = Constants.DELETE_EMPLOYEE_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
            new AppUserClaim() { Id = 8, ClaimType = Constants.ROLE_MANAGER, ClaimValue = Constants.GET_EMPLOYEE_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow }
        );
        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>()
                { Id = 1, Name = Constants.ROLE_ADMIN, NormalizedName = Constants.ROLE_ADMIN.ToUpper() },
            new IdentityRole<int>()
                { Id = 2, Name = Constants.ROLE_MANAGER, NormalizedName = Constants.ROLE_MANAGER.ToUpper() },
            new IdentityRole<int>()
                { Id = 3, Name = Constants.ROLE_EMPLOYEE, NormalizedName = Constants.ROLE_EMPLOYEE.ToUpper() }
        );

        var adminUser = new ApplicationUser()
        {
            Id = 1,
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            UserName = "Admin",
            SecurityStamp = "124524543645756ascaaf",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            FirstName = "Administrator",
            LastName = "Reddy",
            UserId = Guid.NewGuid().ToString(),
            DateCreated = DateTime.UtcNow
        };
        adminUser.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(adminUser, "12345678");
        builder.Entity<ApplicationUser>().HasData(adminUser);

        builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>()
            {
                UserId = 1, RoleId = 1
            });
        builder.Entity<IdentityUserClaim<int>>().HasData(
            new IdentityUserClaim<int>()
                { Id = 1,UserId = 1,ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.ADD_MANAGER_CLAIM_VALUE },
            new IdentityUserClaim<int>()
                { Id = 2, UserId = 1,ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.EDIT_MANAGER_CLAIM_VALUE },
            new IdentityUserClaim<int>()
                { Id = 3, UserId = 1,ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.DELETE_MANAGER_CLAIM_VALUE },
            new IdentityUserClaim<int>()
                { Id = 4, UserId = 1,ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.GET_MANAGER_CLAIM_VALUE },

            new IdentityUserClaim<int>()
                { Id = 5, UserId = 1,ClaimType = Constants.ROLE_MANAGER, ClaimValue = Constants.ADD_EMPLOYEE_CLAIM_VALUE },
            new IdentityUserClaim<int>()
                { Id = 6, UserId = 1,ClaimType = Constants.ROLE_MANAGER, ClaimValue = Constants.EDIT_EMPLOYEE_CLAIM_VALUE },
            new IdentityUserClaim<int>()
                { Id = 7,UserId = 1, ClaimType = Constants.ROLE_MANAGER, ClaimValue = Constants.DELETE_EMPLOYEE_CLAIM_VALUE },
            new IdentityUserClaim<int>()
                { Id = 8, UserId = 1,ClaimType = Constants.ROLE_MANAGER, ClaimValue = Constants.GET_EMPLOYEE_CLAIM_VALUE }
        );
        
        base.OnModelCreating(builder);
    }
    
    public virtual DbSet<AppUserClaim> AppUserClaim { get; set; }
}