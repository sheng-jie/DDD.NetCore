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
            var result = InMemoryTestDbContext.Database.EnsureCreated();
            Assert.Equal(true, InMemoryTestDbContext.Goods.Any());

        }

        [Fact]
        public void Test2()
        {
            using (var trasnaction = InMemoryTestDbContext.Database.BeginTransaction())
            {
                var user = InMemoryTestDbContext.Users.FirstOrDefault();
                var customer = new Customer() { ApplicationUserId = user.Id };
                InMemoryTestDbContext.Customers.Add(customer);
                InMemoryTestDbContext.SaveChanges();

                var cart = new ShoppingCart() { CustomerId = customer.Id };
                InMemoryTestDbContext.ShoppingCarts.Add(cart);
                InMemoryTestDbContext.SaveChanges();

                customer.ShoppingCartId = cart.Id;
                InMemoryTestDbContext.Entry(customer).State=EntityState.Modified;
                InMemoryTestDbContext.SaveChanges();

                trasnaction.Commit();
            }
            Assert.Equal(1,InMemoryTestDbContext.ShoppingCarts.Count());
        }
    }
}
