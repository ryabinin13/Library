using LibraryV2.Entities;
using LibraryV2.Library.BLL.DTO;
using LibraryV2.Library.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.BLL.Mappers
{
    public static class CommonMapper
    {
        public static BookDTO MapBookEntityToDto(this BookEntity bookEntity)
        {
            return new BookDTO()
            {
              Autor = bookEntity.Autor,
              Id = bookEntity.Id,
              Genre = bookEntity.Genre,
              Name = bookEntity.Name,
              PublishingHouse = bookEntity.PublishingHouse,
              Year = bookEntity.Year
            };

        }
        public static MagazineDTO MapMagazineEntityToDto(this MagazineEntity magazineEntity)
        {
            return new MagazineDTO()
            {
                Id = magazineEntity.Id,
                Name = magazineEntity.Name,
                Number = magazineEntity.Number,
                PublishingHouse = magazineEntity.PublishingHouse,
                Year = magazineEntity.Year
            };
        }

        public static BookEntity MapBookDtoToEntity(this BookDTO bookDTO)
        {
            return new BookEntity()
            {
                Autor = bookDTO.Autor,
                Id = bookDTO.Id,
                Genre = bookDTO.Genre,
                Name = bookDTO.Name,
                PublishingHouse = bookDTO.PublishingHouse,
                Year = bookDTO.Year
            };

        }
        public static MagazineEntity ToEntity(this MagazineDTO magazineDTO)
        {
            return new MagazineEntity
            {
                Name = magazineDTO.Name,
                Id = magazineDTO.Id,
                Number = magazineDTO.Number,
                PublishingHouse = magazineDTO.PublishingHouse,
                Year = magazineDTO.Year
            };
        }
        public static MagazineEntity MapMagazineDtoToEntity(this MagazineDTO magazineDTO)
        {
            return new MagazineEntity()
            {
                Id = magazineDTO.Id,
                Name = magazineDTO.Name,
                Number = magazineDTO.Number,
                PublishingHouse = magazineDTO.PublishingHouse,
                Year = magazineDTO.Year
            };
        }
        public static BookDTO MapBookModelToDto(this BookModel bookModel)
        {
            return new BookDTO()
            {
                Autor = bookModel.Autor,
                Id = bookModel.Id,
                Genre = bookModel.Genre,
                Name = bookModel.Name,
                PublishingHouse = bookModel.PublishingHouse,
                Year = bookModel.Year
            };

        }
        public static MagazineDTO MapMagazineModelToDto(this MagazineModel magazineModel)
        {
            return new MagazineDTO()
            {
                Id = magazineModel.Id,
                Name = magazineModel.Name,
                Number = magazineModel.Number,
                PublishingHouse = magazineModel.PublishingHouse,
                Year = magazineModel.Year
            };
        }
        public static BookModel MapBookDtoToModel(this BookDTO bookDTO)
        {
            return new BookModel()
            {
                Autor = bookDTO.Autor,
                Id = bookDTO.Id,
                Genre = bookDTO.Genre,
                Name = bookDTO.Name,
                PublishingHouse = bookDTO.PublishingHouse,
                Year = bookDTO.Year
            };

        }
        public static MagazineModel MapMagazineDtoToModel(this MagazineDTO magazineDTO)
        {
            return new MagazineModel()
            {
                Id = magazineDTO.Id,
                Name = magazineDTO.Name,
                Number = magazineDTO.Number,
                PublishingHouse = magazineDTO.PublishingHouse,
                Year = magazineDTO.Year
            };
        }
        public static List<BookDTO> MapBookListEntityToDto(this List<BookEntity> bookEntities)
        {
            List<BookDTO> bookDTOs = new List<BookDTO>();
            foreach (var item in bookEntities)
            {
                bookDTOs.Add(item.MapBookEntityToDto());
            }
            return bookDTOs;
        }
        public static List<MagazineDTO> MapMagazineListEntityToDto(this List<MagazineEntity> magazineEntities)
        {
            List<MagazineDTO> magazineDTOs = new List<MagazineDTO>();
            foreach (var item in magazineEntities)
            {
                magazineDTOs.Add(item.MapMagazineEntityToDto());
            }
            return magazineDTOs;
        }
        public static List<BookModel> MapBookListDtoToModel(this List<BookDTO> bookDTOs)
        {
            List<BookModel> bookModels = new List<BookModel>();
            foreach (var item in bookDTOs)
            {
                bookModels.Add(item.MapBookDtoToModel());
            }
            return bookModels;
        }
        public static List<MagazineModel> MapMagazineListDtoToModel(this List<MagazineDTO> magazineDTOs)
        {
            List<MagazineModel> magazineModels = new List<MagazineModel>();
            foreach (var item in magazineDTOs)
            {
                magazineModels.Add(item.MapMagazineDtoToModel());
            }
            return magazineModels;
        }
        
    }
}
