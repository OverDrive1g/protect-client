using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtectClient.Core.Protect;

namespace ProtectLib.Tests.KeyProtectRsaTest
{
    [TestClass]
    public class KeyRsaTest
    {
        [TestMethod]
        public void endTest()
        {
            String textToEncrypt = "1 - 5u>0uaW2";
            
            KeyProtectRsa keyProtect = new KeyProtectRsa();
            var productNum = keyProtect.getProductNum();
            
            //создаеться криптопровайдер и зашифровывается textToEncrypt
            //зашифрованый текст передается в класс
            var encryptedText = "";
            var result = keyProtect.activate(encryptedText);

            Assert.IsTrue(result);
        }
    }
}