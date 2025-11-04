using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chess.LoginSignUp.Application.Helpers
{
    public static class PasswordHasher
    {
        private const int SaltSize = 128 / 8;
        private const int HashSize = 256 / 8;
        private const int IterationCount = 10000;

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pdkdf2 = new Rfc2898DeriveBytes(password, salt, IterationCount, HashAlgorithmName.SHA256))
            {
                byte[] hash = pdkdf2.GetBytes(HashSize);

                return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
            }
        }

        public static bool VerifyPassword(string hasedPassword, string providedPassword)
        {
            var parts = hasedPassword.Split('.');
            if (parts.Length != 2 ) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] storedHash = Convert.FromBase64String(parts[1]);

            using (var pdkdf2 = new Rfc2898DeriveBytes(providedPassword, salt, IterationCount, HashAlgorithmName.SHA256))
            {
                byte[] providedHash = pdkdf2.GetBytes(HashSize);
                return storedHash.SequenceEqual(providedHash);
            }
        }
    }
}