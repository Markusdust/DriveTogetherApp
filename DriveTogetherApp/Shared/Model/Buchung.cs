using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTogetherApp.Shared.Model
{
    public class Buchung
    {
        public int BuchungId { get; set; } //PK
        public DateTime Buchungsdatum { get; set; }

        public int FahrtId { get; set; } //FK
        public int BenutzerId { get; set; } //FK

        public bool Storniert {  get; set; }
    }
}
