using LibraryV2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Interfaces
{
    public interface IMagazineRepository
    {
        List<MagazineEntity> GetAllMagazines();
        MagazineEntity SearchMagazine(int code);
        void AddMagazine(MagazineEntity item);
        void DeleteMagazine(int code);
    }
}
