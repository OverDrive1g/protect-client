namespace ProtectLib.Protect
{
    /// <summary>
    /// Класс проверки регистра
    /// </summary>
    public class RegProtect: IBaseProtect
    {
       
        public RegProtect(string regName)
        {
        }

        public void init()
        {
        }

        public bool validate()
        {
            return false;
        }

        private bool isInit()
        {
            return false;
        }
    }
}