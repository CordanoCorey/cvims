using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;
using CVIMS.Api.Features.Products;

namespace CVIMS.Api.Features.CartItems
{
    public interface ICartItemsService
    {
        IEnumerable<CartItemModel> GetCartItems(string userId);
        CartItemModel AddCartItem(CartItemModel model);
        CartItemModel UpdateCartItem(CartItemModel model);
        void DeleteCartItem(int cartItemId);
    }

    public class CartItemsService : ICartItemsService
    {
        private readonly ICartItemsRepository _repo;
        private readonly IProductsService _products;

        public CartItemsService(ICartItemsRepository repo, IProductsService products)
        {
            _repo = repo;
            _products = products;
        }

        public CartItemModel AddCartItem(CartItemModel model)
        {
            model.OrderId = model.OrderId == 0 ? null : model.OrderId;
            return _repo.Insert(model);
        }

        public void DeleteCartItem(int cartItemId)
        {
            _repo.Delete(cartItemId);
        }

        public IEnumerable<CartItemModel> GetCartItems(string userId)
        {
            return _repo.FindByUser(userId);
        }

        public CartItemModel UpdateCartItem(CartItemModel model)
        {
            model.OrderId = model.OrderId == 0 ? null : model.OrderId;
            var cartItem = _repo.Update(model);
            cartItem.Product = _products.GetProduct(cartItem.ProductId);
            return cartItem;
        }
    }
}
