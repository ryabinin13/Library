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
    public class BookFileBinaryRepository : IBookRepository
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
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(@"libraryBookBin.bin", FileMode.Append), Encoding.GetEncoding(1251)))
            {
                binaryWriter.Write(item.Id);
                binaryWriter.Write(item.Autor);
                binaryWriter.Write(item.Genre);
                binaryWriter.Write(item.Name);
                binaryWriter.Write(item.PublishingHouse);
                binaryWriter.Write(item.Year);
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
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(@"libraryBookBin.bin", FileMode.Open), Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < bookEntities.Count; i++)
                {
                    binaryWriter.Write(bookEntities[i].Id);
                    binaryWriter.Write(bookEntities[i].Autor);
                    binaryWriter.Write(bookEntities[i].Genre);
                    binaryWriter.Write(bookEntities[i].Name);
                    binaryWriter.Write(bookEntities[i].PublishingHouse);
                    binaryWriter.Write(bookEntities[i].Year);
                }
            }
        }

        public List<BookEntity> GetAllBooks()
        {
            using (BinaryReader binaryReader = new BinaryReader(new FileStream(@"libraryBookBin.bin", FileMode.Open),Encoding.GetEncoding(1251)))
            {
                List<BookEntity> bookEntities = new List<BookEntity>();
                while (binaryReader.PeekChar() > -1)
                {
                    BookEntity currentBook = new BookEntity();

                    currentBook.Id = binaryReader.ReadInt32();
                    currentBook.Autor = binaryReader.ReadString();
                    currentBook.Genre = binaryReader.ReadString();
                    currentBook.Name = binaryReader.ReadString();
                    currentBook.PublishingHouse = binaryReader.ReadString();
                    currentBook.Year = Convert.ToInt32(binaryReader.ReadInt32());

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
