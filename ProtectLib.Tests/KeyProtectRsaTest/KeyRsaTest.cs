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
        public byte[] Encrypt(byte[] data, RSAParameters rsaKey, bool doPadding)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(rsaKey);
                var endData = rsa.Encrypt(data, doPadding);
                return endData;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public byte[] Decrypt(byte[] data, RSAParameters rsaKey, bool doPadding)
        {
            try
            {   
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(rsaKey);
                var decryptData = rsa.Decrypt(data, doPadding);
                return decryptData;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        
        [TestMethod]
        public void endTest()
        {
            String textToEncrypt = "1 - 5u>0uaW2";
            
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            KeyProtectRsa keyProtect = new KeyProtectRsa();
            var productNum = keyProtect.getPublicKey();
            
            rsa.ImportParameters(productNum);

            var dataToEncrypt = Encoding.Unicode.GetBytes(textToEncrypt);
            var encryptedData = rsa.Encrypt(dataToEncrypt, false);
            
            var result = keyProtect.activate(encryptedData);
            
            Assert.IsTrue(result);
        }
    }
}