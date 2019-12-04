using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    class ParallelProgramming
    {
        public void Distributer() {
            Console.Write("Start");
            //Console.ReadLine();
            //Console.Write("ParallelFor");
            //ParallelFor();
            //Console.ReadLine();
            //Console.WriteLine("ParallelInvoke");
            //ParallelInvoke();
            //Console.ReadLine();
            //Console.WriteLine("ParallelLoopStop");
            //ParallelLoopStop();
            Console.ReadLine();
            Console.WriteLine("PLINQ");
            PLINQ();
            Console.ReadLine();
            Console.WriteLine("Tasks");
            Tasks();
            Console.ReadLine();
        }

        private void Tasks()
        {
            Task task = Task.Run(() => Task1(1));
            task.ContinueWith((prevTask) => Task2(2), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) => Task2(3), TaskContinuationOptions.OnlyOnFaulted);

            Console.ReadLine();

            //attach child tasks (these will run independant of the parent tasks but parent wont complete unless
            // all the childs have completed)

            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent starts");
                for (int i = 0; i < 10; i++)
                {
                    int iterationCount = i;
                    Task.Factory.StartNew(
                        (x) => DoChild(x), iterationCount, TaskCreationOptions.AttachedToParent);

                }
            });


        }

        /// <summary>
        /// Wont stop at exactly 200 iterations
        /// </summary>
        private void ParallelLoopStop()
        {
            var items = Enumerable.Range(0, 500).ToArray();

            ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState pls) =>
            {
                Task1(items[i]);
                if (i == 200)
                    pls.Stop();
            });
        }

        /// <summary>
        /// Invoke 2 functions at once
        /// </summary>
        private void ParallelInvoke()
        {
            Parallel.Invoke(()=>Task1(4), ()=>Task2(5));
        }

        /// <summary>
        /// 
        /// </summary>
        private void ParallelFor ()
        {
            var items = Enumerable.Range(0, 500).ToArray();
            Parallel.For(0, items.Length, i =>
            {
                Task1(items[i]);
            });
        }


        /// <summary>
        /// parallel linq queries
        /// </summary>
        private void PLINQ()
        {
            Person[] people = new Person[] {
                new Person { Name = "Alan", City = "Hull" },
                new Person { Name = "Beryl", City = "Seattle" },
                new Person { Name = "Charles", City = "London" },
                new Person { Name = "David", City = "Seattle" },
                new Person { Name = "Eddy", City = "Paris" },
                new Person { Name = "Fred", City = "Berlin" },
                new Person { Name = "Gordon", City = "Hull" },
                new Person { Name = "Henry", City = "Seattle" },
                new Person { Name = "Isaac", City = "Seattle" },
                new Person { Name = "James", City = "London" }};

            //order will be random, add sequential cancels out the as parallel
            var result = (from person in people.AsParallel()
                         //.WithDegreeOfParallelism(4) //executed with a maximum of 4 processors
                         //.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                         where person.City == "Seattle"
                         select new
                         {
                             Name = person.Name
                         })
                         .AsSequential();

            foreach(var p in result) {
                Console.WriteLine(p);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        private void Task1(int i)
        {
            Console.WriteLine(i);
        }

        ///
        private void Task2(int i)
        {
            Console.WriteLine(i);
        }

        private static void DoChild(object state)
        {
            Console.WriteLine("Child {0} starting", state);
            Thread.Sleep(2000);
            Console.WriteLine("Child {0} finished", state);
        }
    }

}
