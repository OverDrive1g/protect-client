using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtectLib.Storage;

namespace ProtectLib.Tests.Storage
{
    [TestClass]
    public class InMemoryStorageTest
    {
        [TestInitialize]
        public void testInitialize()
        {
        }

        [TestMethod]
        public void get_withSet_true()
        {
            var payload = new Payload {ID = 1, Name = "test"};
            var inMemoryStorage = new InMemoryStorage<Payload>();
            inMemoryStorage.set(payload);

            var storagePayload = inMemoryStorage.get();
            
            Assert.AreEqual(storagePayload, payload);

        }
    }
}