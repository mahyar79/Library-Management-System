using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;    

namespace Library_Management_System
{
    public  class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "library.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            //optionsBuilder.UseSqlite("Data Source=library.db");
        }


    }
}
