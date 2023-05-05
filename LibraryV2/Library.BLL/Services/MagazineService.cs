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
    public class MagazineService : IMagazineService
    {
        private IMagazineRepository magazineRepository;

        public MagazineService(IMagazineRepository _magazineRepository)
        {
            magazineRepository = _magazineRepository;
        }

        public void AddMagazine(MagazineDTO item)
        {
            magazineRepository.AddMagazine(item.MapMagazineDtoToEntity());
        }

        public void DeleteMagazine(int id)
        {
            magazineRepository.DeleteMagazine(id);
        }

        public List<MagazineDTO> GetAllMagazines()
        {
            return magazineRepository.GetAllMagazines().MapMagazineListEntityToDto();
        }

        public MagazineDTO SearchMagazine(int id)
        {
            return magazineRepository.SearchMagazine(id).MapMagazineEntityToDto();
        }
    }
}
