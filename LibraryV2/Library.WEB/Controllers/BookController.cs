using LibraryV2.Entities;
using LibraryV2.Library.BLL.DTO;
using LibraryV2.Library.BLL.Interfaces;
using LibraryV2.Library.BLL.Mappers;
using LibraryV2.Library.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.WEB.Controllers
{
    public class BookController
    {
        private IBookService bookService;
        public BookController(IBookService _bookService)
        {
            bookService = _bookService;
        }
        public void AddBook(BookModel bookModel)
        {
            bookService.AddBook(bookModel.MapBookModelToDto());
        }
        public List<BookModel> GetAllBooks()
        {

            return bookService.GetAllBooks().MapBookListDtoToModel();
        }

        public BookModel SearchBook(int code)
        {
            return bookService.SearchBook(code).MapBookDtoToModel();
        }
        public void DeleteBook(int code)
        {
            bookService.DeleteBook(code);
        }
    }
}
