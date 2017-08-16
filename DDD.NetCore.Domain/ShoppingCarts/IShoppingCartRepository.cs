namespace DDD.NetCore.Domain.ShoppingCarts
{
    public interface IShoppingCartRepository
    {
        ShoppingCart Find(int cartId);

        void Add(ShoppingCart cart);

        void Update(ShoppingCart cart);
    }
}