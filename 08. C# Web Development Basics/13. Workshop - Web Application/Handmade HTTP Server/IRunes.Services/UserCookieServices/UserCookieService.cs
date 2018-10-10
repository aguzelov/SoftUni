﻿using SIS.HTTP.Cookies;
using SIS.HTTP.Cookies.Contracts;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IRunes.Services.UserCookieServices
{
    public class UserCookieService : IUserCookieService
    {
        private const string EncryptKey = "E546C8DF278CD5931069B522E695D4F2";

        public HttpCookie GetUserCookie(string username)
        {
            var cookieContent = EncryptString(username, EncryptKey);

            var cookie = new HttpCookie(HttpCookie.AuthenticeKey, cookieContent);

            return cookie;
        }

        public string GetUsername(IHttpCookieCollection cookies)
        {
            if (!cookies.ContainsCookie(HttpCookie.AuthenticeKey))
            {
                return null;
            }

            var cookie = cookies.GetCookie(HttpCookie.AuthenticeKey);
            var cookieContent = cookie.Value;
            var username = DecryptString(cookieContent, EncryptKey);

            return username;
        }

        private static string EncryptString(string text, string keyString)
        {
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        private static string DecryptString(string cipherText, string keyString)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }
    }
}