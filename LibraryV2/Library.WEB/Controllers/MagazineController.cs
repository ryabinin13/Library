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
    public class MagazineController
    {
        private IMagazineService magazineService;

        public MagazineController(IMagazineService _magazineService)
        {
            magazineService = _magazineService;
        }
        public void AddMagazine(MagazineModel magazineModel)
        {
            magazineService.AddMagazine(magazineModel.MapMagazineModelToDto());
        }
        
        public List<MagazineModel> GetAllMagazines()
        {

            return magazineService.GetAllMagazines().MapMagazineListDtoToModel();
        }

        public MagazineModel SearchMagazine(int id)
        {
            return magazineService.SearchMagazine(id).MapMagazineDtoToModel();
        }
        public void DeleteMagazine(int id)
        {
            magazineService.DeleteMagazine(id);
        }
    }
}
