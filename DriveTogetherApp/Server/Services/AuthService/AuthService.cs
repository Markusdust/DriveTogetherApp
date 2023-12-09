using DriveTogetherApp.Shared.Model;
using System.Security.Cryptography;

namespace DriveTogetherApp.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<int>> Register(Benutzer benutzer, string password)
        {
            if(await UserExists(benutzer.Email))
            {
                return new ServiceResponse<int> 
                {
                  Success = false,
                  Message= "User already exists."  
                };
            }

            CreatePasswordHash(password, out byte[] passswordHash, out byte[] passwortSalt);

            benutzer.PasswortHash = passswordHash;
            benutzer.PasswortSalt = passwortSalt;

            _context.Benutzers.Add(benutzer);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = benutzer.BenutzerId };
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Benutzers.AnyAsync(benutzer => benutzer.Email.ToLower()
                .Equals(email.ToLower())))
            {
                return true;
            }
            return false;  
        }

        private void CreatePasswordHash(string password , out byte[] passwordHash, out byte[] passwordSalt) 
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
    }
}
