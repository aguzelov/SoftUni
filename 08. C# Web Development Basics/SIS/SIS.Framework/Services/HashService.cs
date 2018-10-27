using System;
using System.Security.Cryptography;
using System.Text;

namespace IRunes.Services.PasswordServices
{
    public class HashService : IHashService
    {
        public string GenerateHash(string plainText)
        {
            SHA256Managed sha256Managed = new SHA256Managed();
            Encoding u16LE = Encoding.Unicode;
            string hash = string.Empty;
            byte[] hashed = sha256Managed.ComputeHash(u16LE.GetBytes(plainText), 0, u16LE.GetByteCount(plainText));

            return Convert.ToBase64String(hashed);
        }
    }
}