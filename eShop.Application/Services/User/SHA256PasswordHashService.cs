
using eShop.Application.Dtos;
using eShop.Application.Interfaces;
using eShop.Application.Interfaces.Services;
using eShop.Application.Interfaces.Services.Shared;
using System.Security.Cryptography;

namespace eShop.Application.Services
{
    public class SHA256PasswordHashService : IPasswordHashService
    {
        public  PasswordDto GetPasswordHash(string password)
        {
            // Generate a 16-byte salt
            using var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);

            // Derive a 32-byte key using PBKDF2
            using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100000, HashAlgorithmName.SHA256);
            var hashBytes = pbkdf2.GetBytes(32);

            string hash = Convert.ToBase64String(hashBytes);
            string salt = Convert.ToBase64String(saltBytes);

            return new PasswordDto(hash, salt);
        }

        public  bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var hashBytes = Convert.FromBase64String(storedHash);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100000, HashAlgorithmName.SHA256);
            var computedHash = pbkdf2.GetBytes(32);

            return computedHash.SequenceEqual(hashBytes);
        }
    }
}
