using Business.Interfaces;
using Model.CartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class Cart(Repository.Interfaces.ICart cart) : ICart
    {
        private readonly Repository.Interfaces.ICart _cart = cart;

        public async Task<int> AddCart(AddToCartModel model)
        {
            return await _cart.AddCart(model);
        }

        public async Task<IEnumerable<CartResponse>> GetCartByUserId(int id)
        {
            return await _cart.GetCartByUserId(id);
        }

        public async Task UnCart(int cartId, int userId)
        {
            await _cart.UnCart(cartId, userId);
        }

        public async Task UpdateCartOrder(int cartId, bool isOrdered)
        {
            await _cart.UpdateCartOrder(cartId, isOrdered);
        }

        public async Task UpdateCartquantity(int cartId, int quantity)
        {
            await _cart.UpdateCartquantity(cartId, quantity);
        }
    }
}
