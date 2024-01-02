using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTogetherApp.Shared.Model
{
    public class Fahrt
    {
        public int FahrtId { get; set; } //PK
        public int BenutzerId { get; set; } //FK
        public int AutoId { get; set; } //FK
        public DateTime Startdatum { get; set; }
        public int AnzahlSitzplaetze { get; set; }
        public decimal Preis { get; set; }
        public bool Storniert { get; set; }

        // Referenzen auf die Adresse-Entität
        public int AbfahrtAdresseId { get; set; }
        public Adresse AbfahrtAdresse { get; set; }

        public int AnkunftAdresseId { get; set; }
        public Adresse AnkunftAdresse { get; set; }
    }
}
