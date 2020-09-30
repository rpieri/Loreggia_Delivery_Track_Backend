using System;
using System.Security.Cryptography;
using System.Text;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Helper.Encryptions
{
    public static class EncryptionHelper
    {
        public static string Encrypty(this string value)
        {
            var provider = new SHA1CryptoServiceProvider();
            var enconding = new UnicodeEncoding();
            return BitConverter.ToString(provider.ComputeHash(enconding.GetBytes(value)));
        }
    }
}
