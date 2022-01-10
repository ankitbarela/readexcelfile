using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileWatcherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var watchFile = new WatchFile();
            watchFile.FileWatch();
        }
    }
}
