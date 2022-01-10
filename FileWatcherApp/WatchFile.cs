using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileWatcherApp
{
    public class WatchFile
    {
        string temp = "";
        public void FileWatch()
        {

            var watcher = new FileSystemWatcher(@"C:\ankit\excel folder")
            {

                //watcher.NotifyFilter = NotifyFilters.Attributes
                //                   | NotifyFilters.CreationTime
                //                   | NotifyFilters.DirectoryName
                //                   | NotifyFilters.FileName
                //                   | NotifyFilters.LastAccess
                //                   | NotifyFilters.LastWrite
                //                   | NotifyFilters.Security
                //                   | NotifyFilters.Size;
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size,


                Filter = "*.*",
                EnableRaisingEvents = true
            };




            //watcher.Changed += OnRun;
            watcher.Created += OnRun;
            //watcher.Deleted += OnRun;
            watcher.Renamed += OnRenamed;



            Console.WriteLine("Press enter to exit.");

            Console.ReadLine();
        }

        public  void OnRun(object sender, FileSystemEventArgs e)
        {
            string dir = @"C:\ankit\excel folder\";
            string filename = e.Name;
            string fullPath = Path.Combine(dir, filename);
            if (temp == "")
            {
                ReadExcal readExcal = new();
                readExcal.ReadExcalData(fullPath);
                File.SetAttributes(fullPath, FileAttributes.Normal);
                File.Delete(fullPath);
                temp = fullPath; 
             }
            else if (temp != "" && temp != fullPath)
            {
                temp = ""; 
             }
            else
            {
                //second fire ignored.
            }
                //Console.WriteLine(e.ChangeType);
                //Console.WriteLine(e.Name);
                //string dir = @"C:\ankit\excel folder\";
                //string filename = e.Name;
                //string fullPath = Path.Combine(dir, filename);
                //ReadExcal readExcal = new();
                //readExcal.ReadExcalData(fullPath);
                //File.SetAttributes(fullPath, FileAttributes.Normal);
                //File.Delete(fullPath);

        }


        public void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine(".......... file name changed");
            Console.WriteLine($"old file name => {e.OldName}");
            Console.WriteLine($"new file name => {e.Name}");
        }
    }
}
    