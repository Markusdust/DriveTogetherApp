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
        public DateTime Startdatum { get; set; }
        public DateTime Enddatum { get; set; }
        public int AnzahlSitzplaetze { get; set; }
        public decimal Preis { get; set; }

        /*
        // Foreign Keys
        public int FahrtenanbieterId { get; set; }
        public int AutoId { get; set; }

        // Navigationseigenschaften
        public virtual Auto Auto { get; set; }
        public virtual ICollection<Buchung> Buchungen { get; set; }
        */
    }
}
