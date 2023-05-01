using LibraryV2.Library.BLL.Services;
using LibraryV2.Library.Dal.Repositories;
using LibraryV2.Library.DAL.Repositories;
using LibraryV2.Library.WEB.Controllers;
using LibraryV2.Library.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryV2
{
    class Program
    {
        static void Main(string[] args)
        {
            BookController bookController = new BookController(new BookService(new BookFileBinaryRepository()));
            MagazineController magazineController = new MagazineController(new MagazineService(new MagazineFileTxtRepository()));

            string name, autor, genre, publishingHouse;
            int code, year, number;

            string choice;

            Console.WriteLine("выберите действие:" + '\n' + "-help - справочник,");

            while (true)
            {
                choice = Console.ReadLine();
                if (choice == "-end")
                {
                    break;
                }
                switch (choice)
                {
                    case "-help":
                        Console.WriteLine("-addB - добавить книгу " + '\n' + "-addM - добавить журнал" +
                            '\n' + "-deleteB - удалить книгу" + '\n' + "-deleteM - удалить журнал" + '\n' + "-printB - вывести на экран все книги" + '\n' +
                            "-printM - вывести все журналы на экран" + '\n' + "-searchB - поиск книги по коду" + '\n' + "-searchM - поиск журнала по коду" + '\n' +
                            "-changeB - изменить параметр книги" + '\n' +
                            "-changeB - изменить параметр журнала" + '\n' + "-end - закрыть");
                        break;
                    case "-addB":
                        Console.WriteLine("введите название: ");
                        name = Console.ReadLine();
                        Console.WriteLine("введите автора: ");
                        autor = Console.ReadLine();
                        Console.WriteLine("введите жанр: ");
                        genre = Console.ReadLine();
                        Console.WriteLine("введите издательство: ");
                        publishingHouse = Console.ReadLine();
                        Console.WriteLine("введите код: ");
                        code = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("введите год: ");
                        year = Convert.ToInt32(Console.ReadLine());

                        BookModel bookModel = new BookModel(name, code, autor, genre, year, publishingHouse);

                        bookController.AddBook(bookModel);

                        break;
                    case "-addM":
                        Console.WriteLine("введите название: ");
                        name = Console.ReadLine();
                        Console.WriteLine("введите номер: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("введите издательство: ");
                        publishingHouse = Console.ReadLine();
                        Console.WriteLine("введите код: ");
                        code = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("введите год: ");
                        year = Convert.ToInt32(Console.ReadLine());

                        MagazineModel magazineModel = new MagazineModel(code, name, number, year, publishingHouse);

                        magazineController.AddMagazine(magazineModel);
                        break;
                    case "-printB":
                        List<BookModel> bookModels = bookController.GetAllBooks();
                        foreach (var item in bookModels)
                        {
                            Console.WriteLine("название " + item.Name + '\n' + "код " + item.Code);
                        }
                        break;
                    case "-printM":
                        List<MagazineModel> magazineModels = magazineController.GetAllMagazines();
                        foreach (var item in magazineModels)
                        {
                            Console.WriteLine("название " + item.Name + '\n' + "код " + item.Code);
                        }
                        //librarian.Print();
                        break;
                    case "-deleteB":
                        int codeDeleteBook;

                        Console.WriteLine("введите код книги, которую хотите удалить");
                        codeDeleteBook = Convert.ToInt32(Console.ReadLine());

                        bookController.DeleteBook(codeDeleteBook);
                        break;
                    case "-deleteM":
                        int codeDeleteMagazine;

                        Console.WriteLine("введите код журнала, которую хотите удалить");
                        codeDeleteMagazine = Convert.ToInt32(Console.ReadLine());

                        magazineController.DeleteMagazine(codeDeleteMagazine);
                        break;
                    case "-searchB": //придумать куда сохранять и как применить найденную книгу
                        int codeSearchBook;

                        BookModel currentBook = new BookModel();
                        Console.WriteLine("введите код");
                        codeSearchBook = Convert.ToInt32(Console.ReadLine());

                        currentBook = bookController.SearchBook(codeSearchBook);

                        Console.WriteLine("название " + currentBook.Name + '\n' + "код " + currentBook.Code);

                        break;
                    case "-searchM": //придумать куда сохранять и как применить найденную книгу
                        int codeSearchMagazine;

                        MagazineModel currentMagazine = new MagazineModel();

                        Console.WriteLine("введите код");
                        codeSearchMagazine = Convert.ToInt32(Console.ReadLine());

                        currentMagazine = magazineController.SearchMagazine(codeSearchMagazine);

                        Console.WriteLine("название " + currentMagazine.Name + '\n' + "код " + currentMagazine.Code);

                        break;
                    //case "-changeB":

                    //    int choiceCodeBook;

                    //    Console.WriteLine("введите код книги");
                    //    choiceCodeBook = Convert.ToInt32(Console.ReadLine());

                    //    int parameterChangeBook;

                    //    Console.WriteLine("введите какой параметр хотите поменять: " + '\n' + "1 - имя" + '\n' + "2 - автор" + '\n' +
                    //        "3 - код" + '\n' + "4 - жанр" + '\n' + "5 - издательство" + '\n' + "6 - год" + '\n');
                    //    parameterChangeBook = Convert.ToInt32(Console.ReadLine());

                    //    string resultBook;
                    //    Console.WriteLine("на что хотите поменять");
                    //    resultBook = Console.ReadLine();

                    //    librarian.ChangeBook(choiceCodeBook, parameterChangeBook, resultBook);

                    //    break;
                    //case "-changeM":

                    //    int choiceCodeMagazine;

                    //    Console.WriteLine("введите код журнала");
                    //    choiceCodeMagazine = Convert.ToInt32(Console.ReadLine());

                    //    int parameterChangeMagazine;

                    //    Console.WriteLine("введите какой параметр хотите поменять: " + '\n' + "1 - имя" + '\n' + "2 - номер" + '\n' +
                    //       "3 - код" + '\n' + "4 - издательство" + '\n' + "5 - год" + '\n');
                    //    parameterChangeMagazine = Convert.ToInt32(Console.ReadLine());

                    //    string resultMagazine;
                    //    Console.WriteLine("на что хотите поменять");
                    //    resultMagazine = Console.ReadLine();

                    //    librarian.ChangeMagazine(choiceCodeMagazine, parameterChangeMagazine, resultMagazine);

                    //    break;
                    default:
                        break;
                }
            }

        }
    }
}
