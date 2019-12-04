using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    class ThreadsTraining
    {

        public void Distributer()
        {

            Console.WriteLine("Start Threads");
            Console.ReadLine();
            Console.WriteLine("Create");
            CreateThread();
            Console.ReadLine();
        }

        private void CreateThread()
        {
            Thread thread = new Thread(ThreadTest);
            Thread.Sleep(2000);
        }

        private void ThreadTest()
        {
            Console.WriteLine("Testerdetesttest");
            Thread.Sleep(2000);
        }
    }
}
