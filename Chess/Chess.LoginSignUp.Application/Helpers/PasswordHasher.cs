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

        //public static string HashPassword(string password)
        public static byte[] HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pdkdf2 = new Rfc2898DeriveBytes(password, salt, IterationCount, HashAlgorithmName.SHA256))
            {
                byte[] hash = pdkdf2.GetBytes(HashSize);

                //return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
                // Kết hợp salt và hash thành một mảng byte duy nhất
                byte[] hashBytes = new byte[SaltSize + HashSize];
                Buffer.BlockCopy(salt, 0, hashBytes, 0, SaltSize);
                Buffer.BlockCopy(hash, 0, hashBytes, SaltSize, HashSize);

                return hashBytes;  // Trả về mảng byte chứa salt + hash
            }
        }

        public static bool VerifyPassword(byte[] storedHash, string providedPassword)
        {
            byte[] salt = new byte[SaltSize];
            byte[] storePasswordHash = new byte[HashSize];

            Buffer.BlockCopy(storedHash, 0, salt, 0, SaltSize);
            Buffer.BlockCopy(storedHash, SaltSize, storePasswordHash, 0, HashSize);

            using (var pdkdf2 = new Rfc2898DeriveBytes(providedPassword, salt, IterationCount, HashAlgorithmName.SHA256))
            {
                byte[] providedHash = pdkdf2.GetBytes(HashSize);

                return storePasswordHash.SequenceEqual(providedHash);
            }
        }
    }
}