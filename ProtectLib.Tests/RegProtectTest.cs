using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using ProtectLib.Protect;

namespace ProtectLib.Tests
{
    [TestClass]
    public class RegProtectTest
    {
        private const string RegisterName = "register_test";
        private RegProtect _regProtect;
        
        [TestInitialize]
        public void TestInitialize()
        {
            _regProtect = new RegProtect(RegisterName);
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            currentUserKey.DeleteSubKey(RegisterName);
        }

        [TestMethod]
        public void init_true()
        {
            string initialDate = "01-01-2001";
            string password = "12345";
            
            _regProtect.init();
            
            RegistryKey currentUserKey = Registry.CurrentUser;
            var programKey = currentUserKey.OpenSubKey(RegisterName);
            
            Assert.IsNotNull(programKey);
            
            var regInitDate = programKey.GetValue("initial_date");
            Assert.AreEqual(regInitDate, initialDate);
            
            var regPassword = programKey.GetValue("password");
            Assert.AreEqual(regPassword, password);
        }

        [TestMethod]
        public void validate_WithoutInit_false()
        {
            var result = _regProtect.validate();
            
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void validate_WithInit_true()
        {
            _regProtect.init();
            var result = _regProtect.validate();
            
            Assert.IsTrue(result);
        }
    }
}