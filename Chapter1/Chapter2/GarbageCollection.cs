using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    class GarbageCollection
    {
        public void start()
        {
            for (long i = 0; i < 100000000000; i++)
            {
                Person p = new Person();
                System.Threading.Thread.Sleep(3);
            }
        }
    }

    class Person
    {
        long[] personArray = new long[1000000];
    }
}
