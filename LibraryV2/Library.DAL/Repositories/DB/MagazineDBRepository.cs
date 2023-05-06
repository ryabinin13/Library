using LibraryV2.Entities;
using LibraryV2.Interfaces;
using LibraryV2.Library.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.DAL.Repositories
{
    public class MagazineDBRepository : IMagazineRepository
    {
        public void AddMagazine(MagazineEntity item)
        {
            using (LibraryContext db = new LibraryContext())
            {
                db.magazineEntities.Add(item);
                db.SaveChanges();
            }
        }

        public void DeleteMagazine(int id)
        {
            using (LibraryContext db = new LibraryContext())
            {
                var m = db.magazineEntities.Find(id);
                db.magazineEntities.Remove(m);
                db.SaveChanges();
            }
        }

        public List<MagazineEntity> GetAllMagazines()
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.magazineEntities.ToList();
            }
        }

        public MagazineEntity SearchMagazine(int id)
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.magazineEntities.Find(id);
            }
        }
    }
}
