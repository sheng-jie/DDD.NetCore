using System;
using System.Linq;
using DDD.NetCore.Domain.Customers;
using DDD.NetCore.Domain.ShoppingCarts;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DDD.NetCore.Test
{
    public class UnitTest1 : TestBase
    {
        [Fact]
        public void Test1()
        {
            var result = InMemorySqliteTestDbContext.Database.EnsureCreated();
            Assert.Equal(true, InMemorySqliteTestDbContext.Goods.Any());

        }

        [Fact]
        public void Test2()
        {
            var customerCount = InMemorySqliteTestDbContext.Customers.Count();
            var shoppingCartCount  = InMemorySqliteTestDbContext.ShoppingCarts.Count();
            using (var trasnaction = InMemorySqliteTestDbContext.Database.BeginTransaction())
            {
                var user = InMemorySqliteTestDbContext.Users.FirstOrDefault();
                var customer = new Customer() { ApplicationUserId = user.Id };
                InMemorySqliteTestDbContext.Customers.Add(customer);
                InMemorySqliteTestDbContext.SaveChanges();

                var cart = new ShoppingCart() { CustomerId = customer.Id };
                InMemorySqliteTestDbContext.ShoppingCarts.Add(cart);
                InMemorySqliteTestDbContext.SaveChanges();

                customer.ShoppingCartId = cart.Id;
                InMemorySqliteTestDbContext.Entry(customer).State = EntityState.Modified;
                InMemorySqliteTestDbContext.SaveChanges();

                trasnaction.Commit();
            }
            Assert.Equal(customerCount + 1, InMemorySqliteTestDbContext.Customers.Count());
            Assert.Equal(shoppingCartCount + 1, InMemorySqliteTestDbContext.ShoppingCarts.Count());
        }

        [Fact]
        public void Test3()
        {
            var customerCount = InMemorySqliteTestDbContext.Customers.Count();
            var shoppingCartCount = InMemorySqliteTestDbContext.ShoppingCarts.Count();
            using (var trasnaction = InMemorySqliteTestDbContext.Database.BeginTransaction())
            {
                try
                {
                    var user = InMemorySqliteTestDbContext.Users.FirstOrDefault();
                    var customer = new Customer() { ApplicationUserId = user.Id };
                    InMemorySqliteTestDbContext.Customers.Add(customer);
                    InMemorySqliteTestDbContext.SaveChanges();

                    var cart = new ShoppingCart();//{ CustomerId = customer.Id };
                    InMemorySqliteTestDbContext.ShoppingCarts.Add(cart);
                    InMemorySqliteTestDbContext.SaveChanges();

                    customer.ShoppingCartId = cart.Id;
                    InMemorySqliteTestDbContext.Entry(customer).State = EntityState.Modified;
                    InMemorySqliteTestDbContext.SaveChanges();

                    trasnaction.Commit();
                }
                catch (System.Exception)
                {
                    trasnaction.Rollback();
                }
            }
            Assert.Equal(customerCount, InMemorySqliteTestDbContext.Customers.Count());
            Assert.Equal(shoppingCartCount, InMemorySqliteTestDbContext.ShoppingCarts.Count());
        }
    }
}
