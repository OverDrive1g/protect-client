using Microsoft.Win32;
using ProtectLib.Exception;

namespace ProtectLib.Protect
{
    /// <summary>
    /// Класс проверки регистра
    /// </summary>
    public class RegProtect: IBaseProtect
    {
        private readonly string _regName;
        private RegistryKey localMachineKey;
        public RegProtect(string regName)
        {
            _regName = regName;
            localMachineKey = Registry.LocalMachine;
        }

        public void init()
        {
            if (isInit())
            {
                return;
            }

            RegistryKey currentUserKey = Registry.CurrentUser;

            var programKey = currentUserKey.CreateSubKey(_regName);

            programKey.SetValue("initial_date", "01-01-2001");
            programKey.SetValue("password", "12345");
            programKey.Close();
        }

        public bool validate()
        {
            if (!isInit())
            {
                throw new NotInitProtectException();
            }

            return true;
        }

        private bool isInit()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            var programKey = currentUserKey.OpenSubKey(_regName);

            return programKey != null;
        }
    }
}