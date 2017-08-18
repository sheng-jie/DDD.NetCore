using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.NetCore.Domain.Goods;
using DDD.NetCore.Infrastructure.EfCore;

namespace DDD.NetCore.Test.TestData
{
    public class GoodsTestData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Goods.Any())
            {
                return; ;
            }
            var mobileCategory = new GoodsCategory() { Name = "手机" };
            var tvGoodsCategoryCategory = new GoodsCategory() { Name = "电视" };
            var computerCategory = new GoodsCategory() { Name = "电脑" };

            context.GoodsCategories.Add(mobileCategory);
            context.GoodsCategories.Add(tvGoodsCategoryCategory);
            context.GoodsCategories.Add(computerCategory);
            context.SaveChanges();

            context.Goods.AddRange(
                new Goods { GoodsCategoryId = mobileCategory.Id, Name = "iphone5s 64G", Description = "iphone5s 64G 黑色", Price = 3000, Stock = 10 },
                new Goods { GoodsCategoryId = mobileCategory.Id, Name = "iphone5s 128G", Description = "iphone5s 128G 黑色", Price = 3999, Stock = 10 },
                new Goods { GoodsCategoryId = mobileCategory.Id, Name = "iphone6 64G", Description = "iphone6 64G 白色", Price = 4299, Stock = 10 },
                new Goods { GoodsCategoryId = mobileCategory.Id, Name = "iphone6s 128G", Description = "iphone6s 128G 黑色", Price = 4999, Stock = 10 },
                new Goods { GoodsCategoryId = mobileCategory.Id, Name = "iphone7 64G", Description = "iphone7 64G 银色", Price = 4599, Stock = 10 },
                new Goods { GoodsCategoryId = mobileCategory.Id, Name = "iphone7 128G", Description = "iphone7 128G 银色", Price = 5299, Stock = 10 }
            );
            context.SaveChanges();
        }
    }
}
