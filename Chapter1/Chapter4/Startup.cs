using Chapter4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    class Startup
    {
        static void Main(string[] args)
        {

            Drives drives = new Drives();
            drives.GetDrivesInfo();
            drives.SearchFile();


            Console.ReadLine();


        }
    }
}
