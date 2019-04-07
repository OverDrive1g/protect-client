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
            _authProtect = new AuthProtect(0);
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
            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void validateRequest_validData_true()
        {
            AuthProtect testingClass = new AuthProtect(1);
            
            String login = "bpodd0";
            String password = "notValidPassword";
            
            testingClass.login(login, password);
            var result = testingClass.validateRequest();
            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void validateRequest_invalidData_false()
        {
            AuthProtect testingClass = new AuthProtect(123456);
            
            String login = "bpodd0";
            String password = "notValidPassword";
            
            testingClass.login(login, password);
            var result = testingClass.validateRequest();
            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void validateRequest_withoutLogin_false()
        {
            AuthProtect testingClass = new AuthProtect(1);
            var result = testingClass.validateRequest();
            
            Assert.IsFalse(result);
        }
    }
}