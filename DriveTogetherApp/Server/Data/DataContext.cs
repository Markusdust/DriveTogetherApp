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
            // Definieren der Beziehung
            modelBuilder.Entity<Benutzer>()
                .HasMany(b => b.Autos)
                .WithOne()
                .HasForeignKey(a => a.BenutzerId);

            modelBuilder.Entity<Fahrt>()
               .HasOne<Benutzer>()
               .WithMany()
               .HasForeignKey(f => f.BenutzerId)
               .OnDelete(DeleteBehavior.NoAction); // Keine Kaskadenlöschung;

            modelBuilder.Entity<Fahrt>()
                .HasOne<Auto>()
                .WithMany()
                .HasForeignKey(f => f.AutoId)
                .OnDelete(DeleteBehavior.NoAction); // Keine Kaskadenlöschung;;

            modelBuilder.Entity<Benutzer>().HasData(
               new Benutzer
               {
                   BenutzerId = 1,
                   Vorname = "Max",
                   Nachname = "Mustermann",
                   Email = "max.mustermann@example.com",
                   PasswortHash = new byte[0], // veransshaulichung
                   PasswortSalt = new byte[0], // veransshaulichung
                   Geburtsdatum = new DateTime(1990, 1, 1),
                   Telefonnummer = "0123456789",
                   Registrierungsdatum = DateTime.Now
               }
           );

            modelBuilder.Entity<Auto>().HasData(
                new Auto
                {
                    AutoId = 1,
                    BenutzerId = 1,
                    Marke = "Volkswagen",
                    Modell = "Polo",
                    Farbe = "Rot",
                    Kennzeichen = "B-MK 1234",
                    Baujahr = new DateTime(2018, 1, 1), // 1. Januar 2018 als Beispiel für das Baujahr
                    Typ = "SUV",

                },

               new Auto
               {
                   AutoId = 2,
                   BenutzerId = 1,
                   Marke = "Volkswagen",
                   Modell = "Golf",
                   Farbe = "Blau",
                   Kennzeichen = "B-MK 1234",
                   Baujahr = new DateTime(2018, 1, 1), // 1. Januar 2018 als Beispiel für das Baujahr
                   Typ = "Limousine"
               }
           );
        }

        public DbSet<Auto> Autos { get; set; }
        public DbSet<Benutzer> Benutzers { get; set; }
    }
}
