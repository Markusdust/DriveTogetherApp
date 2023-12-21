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

        

        /*
        // Navigationseigenschaften
        public virtual Auto Auto { get; set; }
        public virtual ICollection<Buchung> Buchungen { get; set; }
        */
    }
}
