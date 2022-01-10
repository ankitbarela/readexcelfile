using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileWatcherApp
{
    public class WatchFile
    {
        public void FileWatch()
        {

            var watcher = new FileSystemWatcher(@"C:\ankit\my folder");
            {
                watcher.NotifyFilter = NotifyFilters.Attributes
                                   | NotifyFilters.CreationTime
                                   | NotifyFilters.DirectoryName
                                   | NotifyFilters.FileName
                                   | NotifyFilters.LastAccess
                                   | NotifyFilters.LastWrite
                                   | NotifyFilters.Security
                                   | NotifyFilters.Size;
                watcher.Filter = "*.*";
                watcher.EnableRaisingEvents = true;

            }


            //watcher.Changed += OnRun;
            watcher.Created += OnRun;
            //watcher.Deleted += OnRun;
            watcher.Renamed += OnRenamed;



            Console.WriteLine("Press enter to exit.");

            Console.ReadLine();
        }

        public  void OnRun(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.ChangeType);
            Console.WriteLine(e.Name);
            string dir = @"C:\ankit\my folder\";
            string filename = e.Name;
            string fullPath = Path.Combine(dir, filename);
            ReadExcal readExcal = new ReadExcal();
            readExcal.ReadExcalData(fullPath);
        }


        public void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine(".......... file name changed");
            Console.WriteLine($"old file name => {e.OldName}");
            Console.WriteLine($"new file name => {e.Name}");
        }
    }
}
    