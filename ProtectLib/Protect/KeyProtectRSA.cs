using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace ProtectLib.Protect
{
    /// <summary>
    /// Защита с помощью ключа активации(RSA)
    /// </summary>
    public class KeyProtectRsa : IBaseProtect
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

        public void init()
        {
            var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var programFolder = $"{userFolder}/.protect-program";

            if (!Directory.Exists(programFolder))
            {
                Directory.CreateDirectory(programFolder);
            }

            if (checkFile()) return;
            
            var json = new JavaScriptSerializer().Serialize(new {activate = false});
            initFile(json);

        }

        public bool validate()
        {
            var payload = getFilePayload();
            var result = new JavaScriptSerializer().Deserialize<Dictionary<string,object>>(payload);

            return (bool) result["activate"];
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

        /// <summary>
        /// Проверка на существование файла
        /// </summary>
        /// <returns></returns>
        public bool checkFile()
        {
            return File.Exists(getFilePath());
        }

        private string getProgramFolder()
        {
            var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return $"{userFolder}/.protect-program";
        }
        
        private string getFilePath()
        {
            return $"{getProgramFolder()}/file.dat";
        }
        
        private void createFile()
        {
            File.WriteAllText(getFilePath(), "");
        }

        private void initFile(String payload)
        {
            File.WriteAllText(getFilePath(), payload);
        }

        private string getFilePayload()
        {
            string result = "";
            try
            {
                using (StreamReader sr = new StreamReader(getFilePath()))
                {
                    String line = sr.ReadToEnd();
                    result = result + line + "\n";
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return result;
        }
    }
}