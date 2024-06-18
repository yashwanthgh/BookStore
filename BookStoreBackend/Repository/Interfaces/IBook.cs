using Model.BookModels;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IBook
    {
        public Task<bool> AddBook(BookAddModel model);
        public Task<IEnumerable<Book>> GetAllBook();
    }
}
