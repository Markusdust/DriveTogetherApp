using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTogetherApp.Shared
{
    public class Feedback
    {
        public int FeedbackId { get; set; } //PK
        public string Kommentar { get; set; }
        public DateTime FeedbackDatum { get; set; }

        /*
        // Foreign Keys
        public int BenutzerId { get; set; }

        // Navigationseigenschaften
        public virtual Benutzer Benutzer { get; set; }
        */
    }
}
