using LibraryV2.Entities;
using LibraryV2.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.DAL.Repositories
{
    class MagazineFileBinaryRepository : IMagazineRepository
    {
        public void AddMagazine(MagazineEntity item)
        {
            List<MagazineEntity> magazineEntities = GetAllMagazines();
            foreach (var curr in magazineEntities)
            {
                if (curr.Code == item.Code)
                {
                    throw new Exception("код журнала должен отличаться");
                }
            }
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(@"libraryMagazineBin.bin", FileMode.Append), Encoding.GetEncoding(1251)))
            {
                binaryWriter.Write(item.Code);
                binaryWriter.Write(item.Number);
                binaryWriter.Write(item.Name);
                binaryWriter.Write(item.PublishingHouse);
                binaryWriter.Write(item.Year);
            }
        }

        public void DeleteMagazine(int code)
        {
            List<MagazineEntity> magazineEntities = GetAllMagazines();

            for (int i = 0; i < magazineEntities.Count; i++)
            {
                if (magazineEntities[i].Code == code)
                {
                    MagazineEntity magazineEntity = magazineEntities[i];
                    magazineEntities.Remove(magazineEntity);
                }
            }
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(@"libraryMagazineBin.bin", FileMode.Open), Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < magazineEntities.Count; i++)
                {
                    binaryWriter.Write(magazineEntities[i].Code);
                    binaryWriter.Write(magazineEntities[i].Number);
                    binaryWriter.Write(magazineEntities[i].Name);
                    binaryWriter.Write(magazineEntities[i].PublishingHouse);
                    binaryWriter.Write(magazineEntities[i].Year);
                }
            }
        }

        public List<MagazineEntity> GetAllMagazines()
        {
            using (BinaryReader binaryReader = new BinaryReader(new FileStream(@"libraryMagazineBin.bin", FileMode.Open), Encoding.GetEncoding(1251)))
            {
                List<MagazineEntity> magazineEntities = new List<MagazineEntity>();
                while (binaryReader.PeekChar() > -1)
                {
                    MagazineEntity magazineEntity = new MagazineEntity();

                    magazineEntity.Code = binaryReader.ReadInt32();
                    magazineEntity.Number = binaryReader.ReadInt32();
                    magazineEntity.Name = binaryReader.ReadString();
                    magazineEntity.PublishingHouse = binaryReader.ReadString();
                    magazineEntity.Year = Convert.ToInt32(binaryReader.ReadInt32());

                    magazineEntities.Add(magazineEntity);
                }
                return magazineEntities;
            }
        }

        public MagazineEntity SearchMagazine(int code)
        {
            List<MagazineEntity> magazineEntities = GetAllMagazines();

            for (int i = 0; i < magazineEntities.Count; i++)
            {
                if (magazineEntities[i].Code == code)
                {
                    return magazineEntities[i];
                }
            }
            return null;
        }
    }
}
