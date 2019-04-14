using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtectLib.Storage;

namespace ProtectLib.Tests.Storage
{
    [TestClass]
    public class FileStorageTest
    {
        [TestInitialize]
        public void testInitialize()
        {
        }

        [TestMethod]
        public void get_withSet_true()
        {
            var payload = new Payload {ID = 1, Name = "test"};
            var folderName = "testFolder";
            var fileName = "testFile";
            var fileFormatter = new BinaryFormatter();
            var fileStorage = new FileStorage<Payload>(folderName, fileName, fileFormatter);
            
            fileStorage.set(payload);
            var storagePayload = fileStorage.get();

            Assert.AreEqual(storagePayload, payload);
        }
    }
}