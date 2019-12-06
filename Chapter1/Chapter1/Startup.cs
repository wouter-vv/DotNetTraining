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

            ParallelProgramming p = new ParallelProgramming();
           // p.Distributer();
            
            ThreadsTraining t = new ThreadsTraining();
            t.Distributer();


            BlockingCollection bc = new BlockingCollection();
            bc.StartBlockingCollectionTest();

            Events e = new Events();
            e.EventsStart();
        }
    }
}
