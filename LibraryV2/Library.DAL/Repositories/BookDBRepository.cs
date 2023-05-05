using LibraryV2.Entities;
using LibraryV2.Interfaces;
using LibraryV2.Library.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.DAL.Repositories
{
    public class BookDBRepository : IBookRepository
    {
        private LibraryContext db;

        //public BookDBRepository(LibraryContext context)
        //{
        //    this.db = context;
        //}
        public void AddBook(BookEntity item)
        {
            db.bookEntities.Add(item);
        }

        public void DeleteBook(int id)
        {

            BookEntity b = db.bookEntities.Find(id);
            db.bookEntities.Remove(b);
        }

        public List<BookEntity> GetAllBooks()
        {
            return db.bookEntities.ToList();
        }

        public BookEntity SearchBook(int id)
        {
            return db.bookEntities.Find(id);
        }
    }
}
