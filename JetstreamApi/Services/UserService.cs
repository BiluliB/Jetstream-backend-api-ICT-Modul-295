using JetstreamApi.Data;
using JetstreamApi.Interfaces;
using JetstreamApi.Models;

namespace JetstreamApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateUser(string username, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                UserName = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool VerifyPassword(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null) throw new ArgumentException("Benutzername nicht gefunden.");

            if (user.IsLocked)
            {
                throw new InvalidOperationException("Benutzerkonto ist gesperrt.");
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                user.PasswordInputAttempt += 1;
                if (user.PasswordInputAttempt >= 3)
                {
                    user.IsLocked = true;
                    _context.SaveChanges();
                    throw new InvalidOperationException("Benutzerkonto wurde wegen zu vieler fehlgeschlagener Versuche gesperrt.");
                }

                _context.SaveChanges();
                throw new ArgumentException("Falsches Passwort.");
            }

            // Erfolgreiche Passworteingabe
            user.PasswordInputAttempt = 0;
            _context.SaveChanges();
            return true;
        }



        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
