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
    class MagazineFileTxtRepository : IMagazineRepository
    {
        public void AddMagazine(MagazineEntity item)
        {
            List<MagazineEntity> magazineEntities = GetAllMagazines();
            foreach (var curr in magazineEntities)
            {
                if (curr.Id == item.Id)
                {
                    throw new Exception("код журнала должен отличаться");
                }
            }
            using (var fileWriter = new StreamWriter("libraryMagazine.txt", true))
            {
                fileWriter.WriteLine(item.Id);
                fileWriter.WriteLine(item.Number);
                fileWriter.WriteLine(item.Name);
                fileWriter.WriteLine(item.PublishingHouse);
                fileWriter.WriteLine(item.Year);
            }
        }

        public void DeleteMagazine(int id)
        {
            List<MagazineEntity> magazineEntities = GetAllMagazines();

            for (int i = 0; i < magazineEntities.Count; i++)
            {
                if (magazineEntities[i].Id == id)
                {
                    MagazineEntity magazineEntity = magazineEntities[i];
                    magazineEntities.Remove(magazineEntity);
                }
            }
            using (var fileWriter = new StreamWriter("libraryMagazine.txt", false))
            {
                for (int i = 0; i < magazineEntities.Count; i++)
                {
                    fileWriter.WriteLine(magazineEntities[i].Id);
                    fileWriter.WriteLine(magazineEntities[i].Number);
                    fileWriter.WriteLine(magazineEntities[i].Name);
                    fileWriter.WriteLine(magazineEntities[i].PublishingHouse);
                    fileWriter.WriteLine(magazineEntities[i].Year);
                }
            }
        }

        public List<MagazineEntity> GetAllMagazines()
        {
            using (var fileReader = new StreamReader("libraryMagazine.txt"))
            {
                List<MagazineEntity> magazineEntities = new List<MagazineEntity>();
                while (!fileReader.EndOfStream)
                {
                    MagazineEntity currentMagazine = new MagazineEntity();

                    currentMagazine.Id = Convert.ToInt32(fileReader.ReadLine());
                    currentMagazine.Number = Convert.ToInt32(fileReader.ReadLine());
                    currentMagazine.Name = fileReader.ReadLine();
                    currentMagazine.PublishingHouse = fileReader.ReadLine();
                    currentMagazine.Year = Convert.ToInt32(fileReader.ReadLine());

                    magazineEntities.Add(currentMagazine);
                }
                return magazineEntities;
            }
        }

        public MagazineEntity SearchMagazine(int id)
        {
            List<MagazineEntity> magazineEntities = GetAllMagazines();

            for (int i = 0; i < magazineEntities.Count; i++)
            {
                if (magazineEntities[i].Id == id)
                {
                    return magazineEntities[i];
                }
            }
            return null;
        }
    }
}
