using Dapper;
using Model.BookModels;
using Repository.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class Book(DapperContext context) : IBook
    {
        private readonly DapperContext _context = context;

        public async Task<bool> AddBook(BookAddModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Title", model.Title, DbType.String);
            parameters.Add("Description", model.Description, DbType.String);
            parameters.Add("Author", model.Author, DbType.String);
            parameters.Add("BookImage", model.BookImage, DbType.String);
            parameters.Add("Quantity", model.Quantity, DbType.Int64);
            parameters.Add("Price", model.Price, DbType.Decimal);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync("spAddBook", parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<IEnumerable<Entities.Book>> GetAllBook()
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Entities.Book>("spGetAllBooks", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
