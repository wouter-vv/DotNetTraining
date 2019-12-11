using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Drives
    {
        public void GetDrivesInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.Write("Name:{0} ", drive.Name);
                if (drive.IsReady)
                {
                    Console.Write("  Type:{0}", drive.DriveType);
                    Console.Write("  Format:{0}", drive.DriveFormat);
                    Console.Write("  Free space:{0}", drive.TotalFreeSpace);
                }
                else
                {
                    Console.Write("  Drive not ready");
                }
                Console.WriteLine();
            }
        }
        static void FindFiles(DirectoryInfo dir, string searchPattern)
        {
            foreach (DirectoryInfo directory in dir.GetDirectories())
            {
                FindFiles(directory, searchPattern);
            }

            FileInfo[] matchingFiles = dir.GetFiles(searchPattern);
            foreach (FileInfo fileInfo in matchingFiles)
            {
                Console.WriteLine(fileInfo.FullName);
            }
        }

        internal void SearchFile()
        {
        
            DirectoryInfo startDir = new DirectoryInfo(@"..\..\..\..");
            string searchString = "*.cs";

            FindFiles(startDir, searchString);

            Console.ReadKey();
        }
    }
}
