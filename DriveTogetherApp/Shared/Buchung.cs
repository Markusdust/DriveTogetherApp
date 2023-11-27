using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTogetherApp.Shared
{
    public class Buchung
    {
        public int BuchungId { get; set; } //PK
        public DateTime Buchungsdatum { get; set; }
        public string Zahlungsstatus { get; set; }
        public string Zahlungsmethode { get; set; }

        /*
        // Foreign Keys
        public int FahrtId { get; set; }
        public int BenutzerId { get; set; }

        // Navigationseigenschaften
        public virtual Fahrt Fahrt { get; set; }
        public virtual Benutzer Benutzer { get; set; }
        */
    }
}
