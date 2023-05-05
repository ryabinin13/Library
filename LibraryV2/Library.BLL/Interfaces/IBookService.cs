using LibraryV2.Entities;
using LibraryV2.Library.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.BLL.Interfaces
{
    public interface IBookService
    {
        List<BookDTO> GetAllBooks();
        BookDTO SearchBook(int id);
        void AddBook(BookDTO item);
        void DeleteBook(int id);
    }
}
