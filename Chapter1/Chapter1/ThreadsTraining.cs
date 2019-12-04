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
        static void Main(string[] args)
        {

            ThreadsTraining t = new ThreadsTraining();
            t.Distributer();
        }

        private void Distributer()
        {
            CreateThread();
        }

        private void CreateThread()
        {
            Thread thread = new Thread(ThreadTest);
            Thread.Sleep(2000);
        }

        public void ThreadTest()
        {
            Console.WriteLine("Testerdetesttest");
            Thread.Sleep(2000);
        }
    }
}
