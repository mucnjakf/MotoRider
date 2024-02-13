using System;
using System.Security.Cryptography;
using System.Text;

namespace MotoRider.Core.Services
{
    public static class EncryptionService
    {
        public static string CreatePasswordHashWithSaltFromDb(string inputPassword, string passwordSaltFromDb)
        {
            string inputPasswordHash;
            byte[] data = Encoding.UTF8.GetBytes(inputPassword + passwordSaltFromDb);

            SHA256 sha256hash = SHA256.Create();
            data = sha256hash.ComputeHash(data);

            inputPasswordHash = Convert.ToBase64String(data);

            return inputPasswordHash;
        }

        public static Tuple<string, string> CreatePasswordHashAndSalt(string inputPassword)
        {
            string passwordSalt = PasswordSalt();

            byte[] data = Encoding.UTF8.GetBytes(inputPassword + passwordSalt);

            SHA256 sha256hash = SHA256.Create();

            data = sha256hash.ComputeHash(data);

            string passwordHash = Convert.ToBase64String(data);

            return new Tuple<string, string>(passwordHash, passwordSalt);
        }

        private static string PasswordSalt()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] buff = new byte[25];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }
    }
}
