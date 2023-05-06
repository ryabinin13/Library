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
        
        public void AddBook(BookEntity item)
        {
            using (LibraryContext db = new LibraryContext())
            {
                db.bookEntities.Add(item);
                db.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            using (LibraryContext db = new LibraryContext())
            {
                var b = db.bookEntities.Find(id);
                db.Remove(b);
                db.SaveChanges();
            }
            
        }

        public List<BookEntity> GetAllBooks()
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.bookEntities.ToList();
            }
        }

        public BookEntity SearchBook(int id)
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.bookEntities.Find(id);
            }
        }
    }
}
