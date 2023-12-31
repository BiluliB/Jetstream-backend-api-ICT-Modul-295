﻿using JetstreamApi.Data;
using JetstreamApi.Interfaces;
using JetstreamApi.Models;

namespace JetstreamApi.Services
{
    /// <summary>
    /// Service for user operations like login and registration
    /// </summary>
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="username">username of the user</param>
        /// <param name="password">password of the user</param>
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
        /// <summary>
        /// verifies the password of a user
        /// </summary>
        /// <param name="username">username of the user</param>
        /// <param name="password">password of the user</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
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

            //Successful password entry 
            user.PasswordInputAttempt = 0;
            _context.SaveChanges();
            return true;
        }
        /// <summary>
        /// creates a password hash for a user
        /// </summary>
        /// <param name="password">password of the user</param>
        /// <param name="passwordHash">password hash of the user</param>
        /// <param name="passwordSalt">password salt of the user</param>
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
