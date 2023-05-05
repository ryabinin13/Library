using LibraryV2.Entities;
using LibraryV2.Library.BLL.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryV2.Library.BLL.Services
{
    public class LibraryContext : DbContext
    {
        public DbSet<BookEntity> bookEntities { get; set; }
        public DbSet<MagazineEntity> magazineEntities { get; set; }

        public LibraryContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=librarydb;Username=postgres;Password=stud");
        }
    }
}
