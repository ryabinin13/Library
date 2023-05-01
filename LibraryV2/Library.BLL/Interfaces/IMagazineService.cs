using LibraryV2.Entities;
using LibraryV2.Library.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.BLL.Interfaces
{
    public interface IMagazineService
    {
        List<MagazineDTO> GetAllMagazines();
        MagazineDTO SearchMagazine(int code);
        void AddMagazine(MagazineDTO item);
        void DeleteMagazine(int code);
    }
}
