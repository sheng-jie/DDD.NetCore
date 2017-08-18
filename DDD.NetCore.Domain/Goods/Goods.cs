using System;
using DDD.NetCore.Domain.Entities;

namespace DDD.NetCore.Domain.Goods
{
    public class Goods : AggregateRoot
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int GoodsCategoryId { get; set; }

        public virtual GoodsCategory GoodsCategory { get; set; }

        public DateTime CreateTime { get; private set; }

        public Goods()
        {
            CreateTime = DateTime.Now;
        }


    }
}