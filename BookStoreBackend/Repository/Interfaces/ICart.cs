using Repository.Entities;
using Model.CartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICart
    {
        public Task<int> AddCart(AddToCartModel model);
        public Task<IEnumerable<CartResponse>> GetCartByUserId(int id);
        public Task UnCart(int cartId, int userId);
        public Task UpdateCartOrder(int cartId, bool isOrdered);
        public Task UpdateCartquantity(int cartId, int quantity);
    }
}
