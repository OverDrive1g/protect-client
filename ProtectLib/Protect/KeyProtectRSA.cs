using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ProtectClient.Core.Protect;

namespace ProtectLib.Protect
{
    /// <summary>
    /// Защита с помощью ключа активации(RSA)
    /// </summary>
    public class KeyProtectRsa : BaseProtect
    {
        private RSAParameters _privateKey; 
        private readonly byte[] _recognizedData;

        public KeyProtectRsa(RSAParameters privateKey)
        {
            _privateKey = privateKey;
            const string instanceNumber = "1"; //Порядковый номер прогарммы
            const string randomString = "5u>0uaW2"; //последовательность слайчаных символов

            _recognizedData = Encoding.Unicode.GetBytes($"{instanceNumber} - {randomString}");
        }

        public override void init()
        {
            var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var programFolder = $"{userFolder}/.protect-program";

            if (!Directory.Exists(programFolder))
            {
                Directory.CreateDirectory(programFolder);
            }
            
        }

        public override bool validate()
        {
            throw new NotImplementedException();
        }

        public string getPublicKey()
        {
            return Convert.ToBase64String(_privateKey.Modulus);
        }

        public bool activate(string encryptedText)
        {
            var encryptedData = Convert.FromBase64String(encryptedText);
            
            var cryptoProvider = new RSACryptoServiceProvider();
            cryptoProvider.ImportParameters(_privateKey);
            
            var decryptedString = cryptoProvider.Decrypt(encryptedData, false);
            
            return Encoding.Unicode.GetString(decryptedString) == Encoding.Unicode.GetString(_recognizedData);
        }

        public bool checkFile()
        {
            
            var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var programFolder = $"{userFolder}/.protect-program";

            return File.Exists($"{programFolder}/file.dat");
        }
    }
}