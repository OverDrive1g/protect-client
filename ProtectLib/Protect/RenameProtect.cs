using System.Diagnostics;
using System.IO;

namespace ProtectLib.Protect
{
    /// <summary>
    /// "Защита" от переименования
    /// В рантайме проверка на то что файл был переименован
    /// </summary>
    public class RenameProtect: IBaseProtect
    {
        private readonly string _programName;
        
        public RenameProtect(string programName)
        {
            _programName = programName;
        }

        public void init()
        {
            //не требует какой либо инициализации
        }

        public bool validate()
        {
            Process ps = Process.GetCurrentProcess();
            return Path.GetFileNameWithoutExtension(ps.ProcessName) != _programName;
        }
    }
}