using LibraryV2.Entities;
using LibraryV2.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.DAL.Repositories
{
    public class BookFileTxtRepository : IBookRepository
    {
        public void AddBook(BookEntity item)
        {
            List<BookEntity> bookEntities = GetAllBooks();
            foreach (var curr in bookEntities)
            {
                if (curr.Id == item.Id)
                {
                    throw new Exception("код книги должен отличаться");
                }
            }
            using(var fileWriter = new StreamWriter("libraryBook.txt", true))
            {
                fileWriter.WriteLine(item.Id);
                fileWriter.WriteLine(item.Autor);
                fileWriter.WriteLine(item.Genre);
                fileWriter.WriteLine(item.Name);
                fileWriter.WriteLine(item.PublishingHouse);
                fileWriter.WriteLine(item.Year);
            }
        }

        public void DeleteBook(int id)
        {
            
            List<BookEntity> bookEntities = GetAllBooks();
            
            for (int i = 0; i < bookEntities.Count; i++)
            {
                if (bookEntities[i].Id == id)
                {
                    BookEntity bookEntity = bookEntities[i];
                    bookEntities.Remove(bookEntity);
                }
            }
            using (var fileWriter = new StreamWriter("libraryBook.txt", false))
            {
                for (int i = 0; i < bookEntities.Count; i++)
                {
                    fileWriter.WriteLine(bookEntities[i].Id);
                    fileWriter.WriteLine(bookEntities[i].Autor);
                    fileWriter.WriteLine(bookEntities[i].Genre);
                    fileWriter.WriteLine(bookEntities[i].Name);
                    fileWriter.WriteLine(bookEntities[i].PublishingHouse);
                    fileWriter.WriteLine(bookEntities[i].Year);
                }
            }
         
        }

        public List<BookEntity> GetAllBooks()
        {
            using (var fileReader = new StreamReader("libraryBook.txt"))
            {
                List<BookEntity> bookEntities = new List<BookEntity>();
                while (!fileReader.EndOfStream)
                {
                    BookEntity currentBook = new BookEntity();

                    currentBook.Id =Convert.ToInt32(fileReader.ReadLine());
                    currentBook.Autor = fileReader.ReadLine();
                    currentBook.Genre = fileReader.ReadLine();
                    currentBook.Name = fileReader.ReadLine();
                    currentBook.PublishingHouse = fileReader.ReadLine();
                    currentBook.Year = Convert.ToInt32(fileReader.ReadLine());

                    bookEntities.Add(currentBook);
                }
                return bookEntities;
            }
        }

        public BookEntity SearchBook(int id)
        {
            List<BookEntity> bookEntities = GetAllBooks();

            for (int i = 0; i < bookEntities.Count; i++)
            {
                if (bookEntities[i].Id == id)
                {
                    return bookEntities[i];                    
                }
            }
            return null;
        }
    }
}
