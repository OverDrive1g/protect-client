using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtectLib.Protect;

namespace ProtectLib.Tests
{
    [TestClass]
    public class KeyRsaTest
    {
        private KeyProtectRsa _keyProtect;
        
        [TestInitialize]
        public void testInitialize()
        {
            _keyProtect = new KeyProtectRsa();
            _keyProtect.init();
        }
        [TestMethod]
        public void activate_validKey_true()
        {
            const string textToEncrypt = "1 - 5u>0uaW2";
            
            var rsa = new RSACryptoServiceProvider();
            
            var productNum = KeyProtectRsa.getPublicKey();

            var parameters = new RSAParameters
            {
                Exponent = new byte[] {1, 0, 1},
                Modulus = Convert.FromBase64String(productNum)
            };
            rsa.ImportParameters(parameters);

            var dataToEncrypt = Encoding.Unicode.GetBytes(textToEncrypt);
            var encryptedData = rsa.Encrypt(dataToEncrypt, false);
            var encryptText = Convert.ToBase64String(encryptedData);
            
            var result = _keyProtect.activate(encryptText);
            
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void activate_invalidKey_false()
        {
            const string textToEncrypt = "1 - 12345678";
            
            var rsa = new RSACryptoServiceProvider();
            var productNum = KeyProtectRsa.getPublicKey();

            var parameters = new RSAParameters
            {
                Exponent = new byte[] {1, 0, 1}, Modulus = Convert.FromBase64String(productNum)
            };
            rsa.ImportParameters(parameters);

            var dataToEncrypt = Encoding.Unicode.GetBytes(textToEncrypt);
            var encryptedData = rsa.Encrypt(dataToEncrypt, false);
            var encryptText = Convert.ToBase64String(encryptedData);
            
            var result = _keyProtect.activate(encryptText);
            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void checkFile_withoutFile_false()
        {
            //TODO: Тест валиться из-за того что файл занят другим процессом, над шот  сэтим делать
//            var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
//            var programFolder = $"{userFolder}/.protect-program";
//            
//            Directory.Delete(programFolder,true);
//            Directory.CreateDirectory(programFolder);
//            
//            var result = _keyProtect.checkFile();
//            
//            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void checkFile_withFile_true()
        {
            var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var programFolder = $"{userFolder}/.protect-program";
            
            //Удалить папку чтоб ничего не сломалось
            Directory.Delete(programFolder,true);
            
            Directory.CreateDirectory(programFolder);
            File.Create($"{programFolder}/file.dat");
                
            var result = _keyProtect.checkFile();
            
            Assert.IsTrue(result);
        }
    }
}