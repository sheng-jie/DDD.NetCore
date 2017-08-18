using System.Linq;
using DDD.NetCore.Domain.Authorization;
using DDD.NetCore.Infrastructure.EfCore;

namespace DDD.NetCore.Test.TestData
{
    public static class UsersTestData
    {
        public static void CreateTestUser(ApplicationDbContext context)
        {
            var user = context.Users.FirstOrDefault(u => u.UserName == "Admin");
            if (user==null)
            {
                user =new ApplicationUser()
                {
                    UserName = "Adminn",
                    Email = "admin@netcore.com",
                    PasswordHash = "123qwe"
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}