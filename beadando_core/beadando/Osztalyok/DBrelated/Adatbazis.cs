using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace beadando.Osztalyok.DBrelated
{
    //https://www.youtube.com/watch?v=TC5mCIGwDyA&t=1s
    //Add-Migration InitialCreate
    // kitoltesek -> table.PrimaryKey("PK_kitoltesek", x => new { x.email, x.Kutatas });
    internal class Adatbazis : DbContext
    {
        private string connctionstring;
        public Adatbazis()
        {
            connctionstring = "server=SERVERIP,3306;uid=SERVERUNAME;pwd=SERVERPW;database=kerdoivek";
        }
        public DbSet<Kutatas> kutatasok { get; set; }
        public DbSet<Kerdes> kerdesek { get; set; }
        public DbSet<Valasz> valaszok { get; set; }

        public DbSet<Kitoltesek> kitoltesek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connctionstring);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kitoltesek>(e => e.HasKey(x => new { x.email, x.KerdesID }));
        }
      
    }

}
