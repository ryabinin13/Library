using LibraryV2.Entities;
using LibraryV2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.DAL.Repositories
{
    public class MagazineRepository : IMagazineRepository
    {
        private List<MagazineEntity> magazines = new List<MagazineEntity>();


        public List<MagazineEntity> GetAllMagazines()
        {
            return magazines;
        }

        public MagazineEntity SearchMagazine(int id)
        {
            foreach (var item in magazines)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }

        public void AddMagazine(MagazineEntity magazine)
        {
            foreach (var item in magazines)
            {
                if (item.Id == magazine.Id)
                {
                    throw new Exception("код журнала должен отличаться");
                }
            }
            magazines.Add(magazine);
        }

        public void DeleteMagazine(int id)
        {
            var m = magazines.Find(x => x.Id == id);

            magazines.Remove(m);
        }
    }
}
