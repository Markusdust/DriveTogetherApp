using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTogetherApp.Shared.Model
{
    public class Adresse
    {
        public int AdresseId { get; set; } //PK
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
        public string PLZ { get; set; }
        public string Stadt { get; set; }
        public string Land { get; set; }

        /*
        // Navigationseigenschaften
        public virtual ICollection<Benutzer> Benutzer { get; set; }
        */
    }

}
