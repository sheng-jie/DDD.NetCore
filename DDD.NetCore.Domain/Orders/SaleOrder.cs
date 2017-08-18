using System;
using System.Collections.Generic;
using DDD.NetCore.Domain.Customers;
using DDD.NetCore.Domain.Entities;

namespace DDD.NetCore.Domain.Orders
{
    public class SaleOrder : AggregateRoot
    {
        public SaleOrder()
        {
            CreationTime = DateTime.Now;
            OrderStatus = SaleOrderStatus.Created;
        }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public SaleOrderStatus OrderStatus { get; set; }

        public int DeliveryAddressId { get; set; }
        public virtual Address DeliveryAddress { get; set; }

        public List<SaleOrderLine> SaleOrderLines { get; } = new List<SaleOrderLine>();

        public DateTime CreationTime { get; private set; }


    }

    public enum SaleOrderStatus
    {
        /// <summary>
        /// 表示销售订单的已创建状态 - 表明销售订单已被创建（未用）。
        /// </summary>
        Created = 0,
        /// <summary>
        /// 表示销售订单的已付款状态 - 表明客户已向销售订单付款。
        /// </summary>
        Paid,
        /// <summary>
        /// 表示销售订单的已拣货状态 - 表明销售订单中包含的商品已从仓库拣货（未用）。
        /// </summary>
        Picked,
        /// <summary>
        /// 表示销售订单的已发货状态。
        /// </summary>
        Dispatched,
        /// <summary>
        /// 表示销售订单的已派送状态。
        /// </summary>
        Delivered
    }

    public class SaleOrderLine : Entity
    {
        public int SaleOrderId { get; set; }
        public virtual SaleOrder SaleOrder { get; set; }
        public int GoodsId { get; set; }
        public virtual Goods.Goods Goods { get; set; }

    }
}