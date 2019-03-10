using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtectLib.Protect;

namespace ProtectLib.Tests
{
    [TestClass]
    public class AuthProtectTest
    {
        private AuthProtect _authProtect;
        [TestInitialize]
        public void testInitialize()
        {
            _authProtect = new AuthProtect();
        }

        [TestMethod]
        public void login_validLogin_true()
        {
            String login = "bpodd0";
            String password = "xEkCbqBM";
            
            var result = _authProtect.login(login, password);
            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void login_invalidLogin_false()
        {
            String login = "bpodd0";
            String password = "notValidPassword";
            
            var result = _authProtect.login(login, password);
            
            Assert.IsTrue(result);
        }
    }
}