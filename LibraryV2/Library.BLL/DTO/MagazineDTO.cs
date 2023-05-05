using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.BLL.DTO
{
    public class MagazineDTO
    {
        public MagazineDTO()
        {

        }

        public MagazineDTO(int id, string name, int number, int year, string publishingHouse)
        {
            Id = id;
            Name = name;
            Number = number;
            Year = year;
            PublishingHouse = publishingHouse;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public int Year { get; set; }

        public string PublishingHouse { get; set; }
    }
}
