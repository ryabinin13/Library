using LibraryV2.Entities;
using LibraryV2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.Dal.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<BookEntity> books = new List<BookEntity>();

        public List<BookEntity> GetAllBooks()
        {
            return books;
        }

        public BookEntity SearchBook(int code)
        {
            foreach (var item in books)
            {
                if (code == item.Code)
                {
                    return item;
                }
            }
            return null;
        }

        public void AddBook(BookEntity book)
        {
            foreach (var item in books)
            {
                if (item.Code == book.Code)
                {
                    throw new Exception("код книги должен отличаться");
                }
            }
            books.Add(book);
        }

        public void DeleteBook(int code)
        {
            foreach (var item in books)
            {
                if (code == item.Code)
                {
                    books.Remove(item);
                }
            }
        }
    }
}
