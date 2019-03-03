using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtectClient.Core.Protect;
using ProtectLib.Protect;

namespace ProtectLib.Tests.KeyProtectRsaTest
{
    [TestClass]
    public class KeyRsaTest
    {
        private KeyProtectRsa _keyProtect;
        [TestInitialize]
        public void testInitialize()
        {
            _keyProtect = new KeyProtectRsa();
        }
        [TestMethod]
        public void endTest1()
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
        public void endTest2()
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
    }
}