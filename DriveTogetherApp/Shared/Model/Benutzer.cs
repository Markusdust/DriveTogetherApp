using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTogetherApp.Shared.Model
{
    public class Benutzer
    {
        public int BenutzerId { get; set; } //PK

        public string Vorname { get; set; } = string.Empty;

        public string Nachname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswortHash { get; set; }
        public byte[] PasswortSalt { get; set; }

        public DateTime? Geburtsdatum { get; set; }

        public string Telefonnummer { get; set; } = string.Empty;
        public DateTime Registrierungsdatum { get; set; } =DateTime.Now;

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
