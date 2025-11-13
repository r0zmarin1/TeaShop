using System.Security.Cryptography;
using System.Text;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Services
{
    public static class EncryptionService
    {
        public static string Encrypt(string item)
        {
            var result = "";

            var bytes = Encoding.UTF8.GetBytes(item);

            for (int i = 0; i < 1742; i++)
                bytes = SHA256.HashData(bytes);

            result = Convert.ToHexString(bytes).ToLower();

            return result;
        }
    }
}
