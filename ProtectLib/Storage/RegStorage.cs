using System.Web.Script.Serialization;
using Microsoft.Win32;

namespace ProtectLib.Storage
{
    public class RegStorage<T>:IStorage<T>
    {
        private string _registerName;
        private T _payload;

        public RegStorage(string registerName)
        {
            _registerName = registerName;
        }

        public void init()
        {
            if (!IsInit())
            {
                RegistryKey currentUserKey = Registry.CurrentUser;

                var programKey = currentUserKey.CreateSubKey(_registerName);
                programKey?.Close();
            }
        }

        public T get()
        {
            return _payload;
        }

        public void set(T value)
        {
            _payload = value;
        }

        public void update()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            var programKey = currentUserKey.OpenSubKey(_registerName);
            programKey.SetValue("main", GetPayload());
            programKey.Close();
        }

        public void save()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            var programKey = currentUserKey.OpenSubKey(_registerName);
            var payload = programKey.GetValue("main");
            
            _payload = new JavaScriptSerializer().Deserialize<T>((string)payload);
        }

        private bool IsInit()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            var programKey = currentUserKey.OpenSubKey(_registerName);

            return programKey != null;
        }

        private string GetPayload()
        {
            return new JavaScriptSerializer().Serialize(_payload);
        }
    }
}