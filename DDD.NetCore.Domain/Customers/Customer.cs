using System.Collections.Generic;
using DDD.NetCore.Domain.Authorization;
using DDD.NetCore.Domain.Entities;
using DDD.NetCore.Domain.ShoppingCarts;

namespace DDD.NetCore.Domain.Customers
{
    /// <summary>
    /// 客户
    /// </summary>
    public class Customer : AggregateRoot
    {
        public string NickName { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual List<Address> ShippingAddresses { get; set; }
    }
}
