using System;
using DDD.NetCore.Infrastructure.EfCore;
using DDD.NetCore.Test.TestData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DDD.NetCore.Test
{
    public class TestBase
    {
        public ApplicationDbContext InMemoryTestDbContext { get; }
        

        public TestBase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                // don't raise the error warning us that the in memory db doesn't support transactions
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            InMemoryTestDbContext = new ApplicationDbContext(options);
            GoodsTestData.Initialize(InMemoryTestDbContext);
            UsersTestData.CreateTestUser(InMemoryTestDbContext);
        }
    }
}