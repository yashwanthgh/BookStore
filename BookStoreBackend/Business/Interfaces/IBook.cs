using Model.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBook
    {
        public Task<bool> AddBook(BookAddModel model);
        public Task<IEnumerable<Repository.Entities.Book>> GetAllBook();
    }
}
