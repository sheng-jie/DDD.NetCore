using System;
using DDD.NetCore.Infrastructure.EfCore;
using DDD.NetCore.Test.TestData;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace DDD.NetCore.Test
{
    public class TestBase
    {
        /// <summary>
        /// 内存数据库，用于测试关系型数据库
        /// </summary>
        public ApplicationDbContext InMemoryTestDbContext { get; set; }

        /// <summary>
        /// 内存数据库，用于测试非关系型数据库
        /// </summary>
        public ApplicationDbContext InMemorySqliteTestDbContext { get; set; }
        

        public TestBase()
        {
            GetInMemoryDbContext();
            GetSqliteInMemoryDbContext();
        }

        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                // don't raise the error warning us that the in memory db doesn't support transactions
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            InMemoryTestDbContext = new ApplicationDbContext(options);
            GoodsTestData.Initialize(InMemoryTestDbContext);
            UsersTestData.CreateTestUser(InMemoryTestDbContext);
            return InMemoryTestDbContext;
        }

        public ApplicationDbContext GetSqliteInMemoryDbContext()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;

            InMemorySqliteTestDbContext = new ApplicationDbContext(options);
            InMemorySqliteTestDbContext.Database.EnsureCreated();

            GoodsTestData.Initialize(InMemorySqliteTestDbContext);
            UsersTestData.CreateTestUser(InMemorySqliteTestDbContext);

            return InMemorySqliteTestDbContext;

        }
    }
}