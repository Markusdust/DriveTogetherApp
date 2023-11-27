using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTogetherApp.Shared
{
    public class Benutzer
    {
        public int BenutzerId { get; set; } //PK
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public string Passwort { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public string Telefonnummer { get; set; }
        public DateTime Registrierungsdatum { get; set; }

        /*
        // Foreign Key
        public int AdresseId { get; set; }

        // Navigationseigenschaften
        public virtual Adresse Adresse { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Buchung> Buchungen { get; set; }
        */
    }
}
