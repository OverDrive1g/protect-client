using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtectClient.Core.Protect;

namespace ProtectLib.Tests.KeyProtectRsaTest
{
    [TestClass]
    public class KeyRsaTest
    {
        [TestMethod]
        public void endTest1()
        {
            String textToEncrypt = "1 - 5u>0uaW2";
            
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            KeyProtectRsa keyProtect = new KeyProtectRsa();
            var productNum = keyProtect.getPublicKey();
            
            RSAParameters parameters = new RSAParameters();
            parameters.Exponent = new byte[]{1,0,1};
            parameters.Modulus = Convert.FromBase64String(productNum);
            rsa.ImportParameters(parameters);

            var dataToEncrypt = Encoding.Unicode.GetBytes(textToEncrypt);
            var encryptedData = rsa.Encrypt(dataToEncrypt, false);
            var encryptText = Convert.ToBase64String(encryptedData);
            
            var result = keyProtect.activate(encryptText);
            
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void endTest2()
        {
            String textToEncrypt = "1 - 12345678";
            
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            KeyProtectRsa keyProtect = new KeyProtectRsa();
            var productNum = keyProtect.getPublicKey();
            
            RSAParameters parameters = new RSAParameters();
            parameters.Exponent = new byte[]{1,0,1};
            parameters.Modulus = Convert.FromBase64String(productNum);
            rsa.ImportParameters(parameters);

            var dataToEncrypt = Encoding.Unicode.GetBytes(textToEncrypt);
            var encryptedData = rsa.Encrypt(dataToEncrypt, false);
            var encryptText = Convert.ToBase64String(encryptedData);
            
            var result = keyProtect.activate(encryptText);
            
            Assert.IsFalse(result);
        }
    }
}