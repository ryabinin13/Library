using LibraryV2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Interfaces
{
    public interface IBookRepository
    {
        List<BookEntity> GetAllBooks();
        BookEntity SearchBook(int code);
        void AddBook(BookEntity item);
        void DeleteBook(int code);
    }
}
