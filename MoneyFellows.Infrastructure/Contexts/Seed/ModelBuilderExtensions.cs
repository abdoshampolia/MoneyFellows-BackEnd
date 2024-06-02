using Microsoft.EntityFrameworkCore;
using MoneyFellows.Core.Entities;

namespace MoneyFellows.Infrastructure.Contexts.Seed
{
    public static class ModelBuilderExtensions
    {
        static readonly Guid adminRole = new("F1B8B59F-6CD7-4074-B481-1F1C7859070F");
        static readonly Guid userRole = new("0B311A9B-07B6-423C-A67E-65AE06E5FEBB");


        public static void RoleSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                    new
                    {
                        Id = adminRole,
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                    }
                    ,
                    new
                    {
                        Id = userRole,
                        Name = "User",
                        NormalizedName = "USER",
                    }
              );

        }

    }
}
