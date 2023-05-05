using LibraryV2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.BLL.DTO
{
    public class BookDTO
    {
        public BookDTO()
        {

        }
        public BookDTO(string name, int id, string autor, string genre, int year, string publishingHouse)
        {
            Id = id;
            Name = name;
            Autor = autor;
            Genre = genre;
            Year = year;
            PublishingHouse = publishingHouse;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Autor { get; set; }


        public string Genre { get; set; }

        public int Year { get; set; }

        public string PublishingHouse { get; set; }
    }
}
