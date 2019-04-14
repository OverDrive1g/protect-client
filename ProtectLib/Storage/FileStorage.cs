using System.Runtime.Serialization;

namespace ProtectLib.Storage
{
    public class FileStorage
    {
        public string FolderName { get; set; }
        public string FileName { get; set; }
        public IFormatter Formatter { get; set; }
    }
}