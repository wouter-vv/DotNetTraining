using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter1
{
    class BlockingCollection
    {
        public void StartBlockingCollectionTest()
        {
            // Blocking collection that can hold 5 items
            BlockingCollection<int> data = new BlockingCollection<int>(5);

            Task.Run(() =>
            {
                // attempt to add 10 items to the collection - blocks after 5th
                for (int i = 0; i < 11; i++)
                {
                    data.Add(i);
                    Console.WriteLine("Data {0} added sucessfully.", i);
                }
                // indicate we have no more to add
                data.CompleteAdding();
            });

            Console.ReadKey();
            Console.WriteLine("Reading collection");

            Task.Run(() =>
            {
                while (!data.IsCompleted)
                {
                    try
                    {
                        int v = data.Take();
                        Console.WriteLine("Data {0} taken sucessfully.", v);
                    }
                    catch (InvalidOperationException) { }
                }
            });

            Console.ReadKey();
        }

        static object sharedTotalLock = new object();
        static long sharedTotal;
        // make an array that holds the values 0 to 5000000
        static int[] items = Enumerable.Range(0, 500001).ToArray();

        static void test()
        {
            List<Task> tasks = new List<Task>();

            int rangeSize = 1000;
            int rangeStart = 0;

            while (rangeStart < items.Length)
            {
                int rangeEnd = rangeStart + rangeSize;

                if (rangeEnd > items.Length)
                    rangeEnd = items.Length;

                // create local copies of the parameters
                int rs = rangeStart;
                int re = rangeEnd;

                tasks.Add(Task.Run(() => lockingWithSubtotal(rs, re)));
                rangeStart = rangeEnd;
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("The total is: {0}", sharedTotal);
            Console.ReadKey();
        }

        public static void lockingWithSubtotal(int start, int end)
        {
            //add subtotal because otherwise the parallelism is nullified by the lock
            long subTotal = 0;

            while (start < end)
            {
                subTotal = subTotal + items[start];
                start++;
            }

            while (start < end)
            {
                lock (sharedTotalLock)
                {
                    sharedTotal = sharedTotal + items[start];
                }
                start++;
            }
        }
    }

}

