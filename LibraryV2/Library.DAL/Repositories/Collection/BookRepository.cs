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

        public BookEntity SearchBook(int id)
        {

            foreach (var item in books)
            {
                if (id == item.Id)
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
                if (item.Id == book.Id)
                {
                    throw new Exception("код книги должен отличаться");
                }
            }
            books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var b = books.Find(x => x.Id == id);

            books.Remove(b);

        }
    }
}
