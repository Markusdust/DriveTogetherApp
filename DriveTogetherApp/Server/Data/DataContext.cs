using DriveTogetherApp.Shared.Model;

namespace DriveTogetherApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>().HasData(
                new Auto
                {
                    AutoId = 1,
                    Fahrtenanbieter = "Markus Transporte",
                    Marke = "Volkswagen",
                    Modell = "Golf",
                    Farbe = "Blau",
                    Kennzeichen = "B-MK 1234",
                    Baujahr = new DateTime(2018, 1, 1), // 1. Januar 2018 als Beispiel für das Baujahr
                    Typ = "Kompakt"
                },

               new Auto
               {
                   AutoId = 2,
                   Fahrtenanbieter = "Markus Transporte",
                   Marke = "Volkswagen",
                   Modell = "Golf",
                   Farbe = "Blau",
                   Kennzeichen = "B-MK 1234",
                   Baujahr = new DateTime(2018, 1, 1), // 1. Januar 2018 als Beispiel für das Baujahr
                   Typ = "Kompakt"
               }
           );
        }

        public DbSet<Auto> Autos { get; set; }
        public DbSet<Benutzer> Benutzers { get; set; }
    }
}
