using DDD.NetCore.Domain.ShoppingCarts;

namespace DDD.NetCore.Application.ShoppingCarts
{
    public interface IShoppingCartService
    {
        void AddGoodsToCart(string userId, int goodsId, int qty);
        void ChangeItmeQty(int cartId, int cartLineId, int qty);
        void ClearCart(int cartId);
        void RemoveItemFromCart(int cartId, int cartLineId);

        ShoppingCart GetShoppingCart(int cartId);
    }
}