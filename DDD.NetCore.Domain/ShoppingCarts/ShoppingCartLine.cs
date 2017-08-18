using System.ComponentModel.DataAnnotations;
using DDD.NetCore.Domain.Entities;

namespace DDD.NetCore.Domain.ShoppingCarts
{
    public class ShoppingCartLine : Entity
    {
        public int ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        public int GoodsId { get; set; }

        public virtual Goods.Goods Goods { get; set; }

        public int Qty { get; set; }
    }
}