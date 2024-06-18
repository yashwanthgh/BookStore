using Model.BookModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class Book(IBook book) : Business.Interfaces.IBook
    {
        private readonly Repository.Interfaces.IBook _book = book;

        public async Task<bool> AddBook(BookAddModel model)
        {
           return await _book.AddBook(model);
        }

        public async Task<IEnumerable<Repository.Entities.Book>> GetAllBook()
        {
            return await _book.GetAllBook();
        }
    }
}
