using System;
using System.Linq;
using DDD.NetCore.Domain.Customers;
using DDD.NetCore.Domain.Goods;
using DDD.NetCore.Domain.ShoppingCarts;

namespace DDD.NetCore.Application.ShoppingCarts
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IGoodsRepository _goodsRepository;
        private readonly ICustomerRepository _customerRepository;
        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository,
            IGoodsRepository goodsRepository,  ICustomerRepository customerRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _goodsRepository = goodsRepository;
            _customerRepository = customerRepository;
        }
        public void AddGoodsToCart(string userId, int goodsId, int qty)
        {
            var customer = _customerRepository.GetCustomerByUserId(userId);
            var cart = _shoppingCartRepository.Find(customer.ShoppingCartId);
            var goods = _goodsRepository.Find(goodsId);

            cart.AddGoods(goods, qty);
            _shoppingCartRepository.Update(cart);
            
        }

        public void RemoveItemFromCart(int cartId, int cartLineId)
        {
            var cart = _shoppingCartRepository.Find(cartId);
            var cartLine = cart.ShoppingCartLines.FirstOrDefault(c => c.Id == cartLineId);
            cart.RemoveItem(cartLine);
        }

        public ShoppingCart GetShoppingCart(int cartId)
        {
            return _shoppingCartRepository.Find(cartId);
        }

        public void ChangeItmeQty(int cartId, int cartLineId, int qty)
        {
            var cart = _shoppingCartRepository.Find(cartId);
            var cartLine = cart.ShoppingCartLines.FirstOrDefault(c => c.Id == cartLineId);
            cart.ChangeItmeQty(cartLine, qty);
        }

        public void ClearCart(int cartId)
        {
            var cart = _shoppingCartRepository.Find(cartId);
            cart.Clear();
        }
    }
}
