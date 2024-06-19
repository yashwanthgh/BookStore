using Repository.Interfaces;
using Model.CartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Context;
using Dapper;

namespace Repository.Services
{
    public class Cart(DapperContext context) : ICart
    {
        private readonly DapperContext _context = context;

        public async Task<int> AddCart(AddToCartModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Quantity", model.Quantity, System.Data.DbType.Int64);
            parameters.Add("UserId", model.UserId, System.Data.DbType.Int64);
            parameters.Add("BookId", model.BookId, System.Data.DbType.Int64);
            parameters.Add("IsOrdered", model.IsOrdered, System.Data.DbType.Boolean);
            parameters.Add("IsUnCarted", model.IsUnCarted, System.Data.DbType.Boolean);

            using(var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync("spAddToCart", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<CartResponse>> GetCartByUserId(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<CartResponse>("spAddToCart", new {UserId = id}, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task UnCart(int cartId, int userId)
        {
            using(var connection = _context.CreateConnection())
            {
                 await connection.ExecuteAsync("spUncart", new { CartId = cartId, UserId = userId }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task UpdateCartOrder(int cartId, bool isOrdered)
        {
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync("spUpdateCartOrder", new { CartId = cartId, IsOrdered = isOrdered }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task UpdateCartquantity(int cartId, int quantity)
        {
            using( var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync("spUpdateCartQuantity", new { CartId = cartId, Quantity = quantity }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
