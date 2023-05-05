using LibraryV2.Entities;
using LibraryV2.Interfaces;
using LibraryV2.Library.BLL.DTO;
using LibraryV2.Library.BLL.Interfaces;
using LibraryV2.Library.BLL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.BLL.Services
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepository;

        public BookService(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }
        public void AddBook(BookDTO item)
        {
            bookRepository.AddBook(item.MapBookDtoToEntity());
        }

        public void DeleteBook(int id)
        {
            bookRepository.DeleteBook(id);
        }

        public List<BookDTO> GetAllBooks()
        {

            return bookRepository.GetAllBooks().MapBookListEntityToDto();

        }

        public BookDTO SearchBook(int id)
        {
            return bookRepository.SearchBook(id).MapBookEntityToDto();
        }
    }
}
