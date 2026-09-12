using DataAccess;
using Domain.Entities;

namespace BlogApi.Seed
{
    public static class DatabaseSeeder
    {
        public static void Seed(BlogDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new RoleEntity { Name = "User", CreatedAt = DateTime.UtcNow });
                context.Roles.Add(new RoleEntity { Name = "Admin", CreatedAt = DateTime.UtcNow });
                context.SaveChanges();
            }
            if (!context.UseCases.Any())
            {
                var names = new[]
                {
                    "get-categories",
                    "rate-post",
                    "create-post",
                    "get-posts",
                    "get-post",
                    "update-post",
                    "delete-post",
                    "get-comments",
                    "update-comment",
                    "delete-comment",
                    "create-comment",
                    "account-activate",
                    "get-users",
                    "delete-comment"
                };

                foreach (var name in names)
                {
                    context.UseCases.Add(new UseCaseEntity
                    {
                        Name = name,
                        CreatedAt = DateTime.UtcNow,
                    });
                }
                context.SaveChanges();
            }

            if(!context.Users.Any())
            {
                int userRoleId = context.Roles.First(r => r.Name == "User").Id;
                int adminRoleId = context.Roles.First(r => r.Name == "Admin").Id;

                context.Users.Add(new UserEntity
                {
                    Name = "Test",
                    Surname = "User",
                    Username = "user",
                    Email = "user@gmail.com",
                    Phone = "060000000",
                    Password = BCrypt.Net.BCrypt.HashPassword("Test1234"),
                    RoleId = userRoleId,
                    ActivatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                });

                context.Users.Add(new UserEntity
                {
                    Name = "Test",
                    Surname = "Admin",
                    Username = "admin",
                    Email = "admin@gmail.com",
                    Phone = "060000001",
                    Password = BCrypt.Net.BCrypt.HashPassword("Admin1234"),
                    RoleId = adminRoleId,
                    ActivatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                });

                context.SaveChanges();
            }

            if(!context.RoleUseCases.Any())
            {
                int RoleId(string name) => context.Roles.First(r => r.Name == name).Id;
                int UcId(string name) => context.UseCases.First(c => c.Name == name).Id;

                var userUseCases = new[] { "get-posts", "get-post", "get-comments", "get-categories", "rate-post", "create-post", "update-post", "delete-post", "create-comment", "delete-comment" };

                var adminUseCases = new[] { "get-categories",
                    "rate-post",
                    "create-post",
                    "get-posts",
                    "get-post",
                    "update-post",
                    "delete-post",
                    "get-comments",
                    "update-comment",
                    "delete-comment",
                    "create-comment",
                    "account-activate",
                    "get-users",
                    "delete-comment"
                };

                if (!context.Categories.Any())
                {
                    var categoryNames = new[] { "Tehnologija", "Sport", "Muzika", "Film", "Putovanja", "Hrana","Restorani" };
                    foreach (var name in categoryNames)
                    {
                        context.Categories.Add(new CategoryEntity { Name = name, CreatedAt = DateTime.UtcNow });
                    }
                    context.SaveChanges();
                }

                foreach (var uc in userUseCases)
                    context.RoleUseCases.Add(new RoleUseCaseEntity { RoleId = RoleId("User"), UseCaseId = UcId(uc) });

                foreach (var uc in adminUseCases)
                    context.RoleUseCases.Add(new RoleUseCaseEntity { RoleId = RoleId("Admin"), UseCaseId = UcId(uc) });

                context.SaveChanges();
            }
        }
    }
}
