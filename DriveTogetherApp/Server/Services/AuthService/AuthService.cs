using DriveTogetherApp.Client.Pages;
using DriveTogetherApp.Shared.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Xml;

namespace DriveTogetherApp.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AuthService(DataContext context, IConfiguration configuration, IEmailService emailService)
        {
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var user  = await _context.Benutzers
                .FirstOrDefaultAsync(x=>x.Email.ToLower().Equals(email.ToLower()));

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if(!VerifyPasswordHash(password, user.PasswortHash, user.PasswortSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                response.Data = CreateToken(user);
            }

                
            
            return response;
        }

        public async Task<ServiceResponse<int>> Register(Benutzer user, string password)
        {
            if(await UserExists(user.Email))
            {
                return new ServiceResponse<int> 
                {
                  Success = false,
                  Message= "User already exists."  
                };
            }

            CreatePasswordHash(password, out byte[] passswordHash, out byte[] passwortSalt);

            user.PasswortHash = passswordHash;
            user.PasswortSalt = passwortSalt;

            //sende Email an neuen Benutzer
            var email = new Email
            {
                To = user.Email,
                Subject = "Willkommen bei DriveTogether!",
                Body = EmailText.registerMail
            };
            await _emailService.SendEmailAsync(email);


            _context.Benutzers.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = user.BenutzerId, Message ="Registration successful!" };
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Benutzers.AnyAsync(user => user.Email.ToLower()
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

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(Benutzer user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.BenutzerId.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
        {
            var user = await _context.Benutzers.FindAsync(userId);
            if(user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Benutzer nicht gefunden."
                };
            }

            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordsalt);

            user.PasswortHash   = passwordHash;
            user.PasswortSalt = passwordsalt;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "Password wurde geändert" };
        }

        public async Task<ServiceResponse<string>> GetUserEmailById(int userId)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Benutzers.Where(u => u.BenutzerId == userId).FirstOrDefaultAsync();
            
            if(user != null)
            {
                response.Data = user.Email;
            }

            return response;
        }

    }

}
