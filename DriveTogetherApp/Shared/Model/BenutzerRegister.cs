using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTogetherApp.Shared.Model
{
    public class BenutzerRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(100, MinimumLength =6)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage ="the password does not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
