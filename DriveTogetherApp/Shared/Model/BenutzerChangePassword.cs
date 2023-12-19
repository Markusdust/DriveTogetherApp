using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTogetherApp.Shared.Model
{
    public class BenutzerChangePassword
    {
        [Required, StringLength(100, MinimumLength =6)]
        public string Passwort { get; set; } = string.Empty;

        [Compare("Passwort", ErrorMessage ="Das Passwort stimmt nicht überein.")]
        public string ConfirmPasswort { get; set; } = string.Empty;
    }
}
