using System;
using System.Security.Cryptography;
using System.Text;

namespace WinTicket.Util
{
    public class Security
    {
        public static string Encrypt(string text)
        {
            var encryptedText = Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(text)));
            return encryptedText;
        }
    }
}
