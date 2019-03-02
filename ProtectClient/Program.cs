using ProtectClient.Core.Controllers;
using ProtectClient.Core.MVC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtectClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //fixme
            String programDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\"+ Core.Info.programName;

            if (!Directory.Exists(programDir) ){
                
                var dirInfo = Directory.CreateDirectory(programDir);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(programDir));
            }


            if (File.Exists(programDir+ "\\data.json"))
            {
                using (StreamReader streamReader = new StreamReader(programDir + "\\data.json"))
                {
                    string line = streamReader.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            else
            {
                File.Create(programDir + "\\data.json");
            }

            // TODO: считать файл и проверить когда 


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppManager.Start<DefaultController>();
        }
    }
}
