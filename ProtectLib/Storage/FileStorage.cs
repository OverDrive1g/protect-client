using System;
using System.IO;
using System.Runtime.Serialization;

namespace ProtectLib.Storage
{
    public class FileStorage<T>: IStorage<T>
    {
        public string FolderName { get; set; }
        public string FileName { get; set; }
        public IFormatter Formatter { get; set; }

        private T _payload;

        public FileStorage(string folderName, string fileName, IFormatter formatter)
        {
            FolderName = folderName;
            FileName = fileName;
            Formatter = formatter;
        }

        public void init()
        {
            if (!Directory.Exists(GetProgramFolder()))
            {
                Directory.CreateDirectory(GetProgramFolder());
            }

            if (CheckFile())
            {
                File.WriteAllText(GetFilePath(), "");
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
            var stream = new FileStream(GetFilePath(), FileMode.Open, FileAccess.Read);
            var newVal = (T) Formatter.Deserialize(stream);
            _payload = newVal;
        }

        public void save()
        {
            var stream = new FileStream(GetFilePath(), FileMode.Create, FileAccess.Write);
            Formatter.Serialize(stream, _payload);
            stream.Close();
        }

        private string GetUserFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        private string GetProgramFolder()
        {
            return $"{GetUserFolder()}/${FolderName}";
        }
        
        private bool CheckFile()
        {
            return File.Exists(GetFilePath());
        }
        
        private string GetFilePath()
        {
            return $"{GetProgramFolder()}/{FileName}";
        }
    }
}