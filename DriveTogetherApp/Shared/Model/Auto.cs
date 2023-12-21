using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTogetherApp.Shared.Model
{
    public class Auto
    {
        public int AutoId { get; set; } //  PK' 
       

        // Fremdschlüssel für Benutzer
        public int BenutzerId { get; set; }

        public string Marke { get; set; }
        public string Modell { get; set; }
        public string Farbe { get; set; }
        public string Kennzeichen { get; set; }
        public DateTime Baujahr { get; set; }
        public string Typ { get; set; }

        // Navigationseigenschaften
        //public virtual ICollection<Fahrt> Fahrten { get; set; }
    }
}
