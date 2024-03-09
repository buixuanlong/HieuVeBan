using System.Security.Cryptography;
using System.Text;

namespace HieuVeBan.Services.Extensions
{
    internal static class StringPasswordExtension
    {
        public static async Task<string> EncryptToBase64StringAsync(this string input, string passphrase)
        {
            var bytes = await EncryptAsync(input, passphrase);

            return Convert.ToBase64String(bytes);
        }

        public static async Task<byte[]> EncryptAsync(this string input, string passphrase)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(passphrase);
            aes.IV = IV;

            using MemoryStream output = new();
            using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);

            await cryptoStream.WriteAsync(Encoding.Unicode.GetBytes(input));
            await cryptoStream.FlushFinalBlockAsync();

            return output.ToArray();
        }

        public static async Task<string> DecryptFromBase64StringAsync(this string encrypted, string passphrase)
        {
            var base64 = Convert.FromBase64String(encrypted);

            return await DecryptAsync(base64, passphrase);
        }

        public static async Task<string> DecryptAsync(this byte[] encrypted, string passPhrase)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(passPhrase);
            aes.IV = IV;

            using MemoryStream input = new(encrypted);
            using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);

            using MemoryStream output = new();
            await cryptoStream.CopyToAsync(output);

            return Encoding.Unicode.GetString(output.ToArray());
        }

        private static byte[] IV =
        {
            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
        };

        private static byte[] DeriveKeyFromPassword(string password)
        {
            var emptySalt = Array.Empty<byte>();
            var iterations = 1000;
            var desiredKeyLength = 16; // 16 bytes equal 128 bits.
            var hashMethod = HashAlgorithmName.SHA384;

            return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(password),
                                             emptySalt,
                                             iterations,
                                             hashMethod,
                                             desiredKeyLength);
        }
    }
}
