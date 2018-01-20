using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ld3
{
    class CustomData
    {
        public int TNum;
        public int TResult;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count;
            int n = 1000;
            //int fibnum = 0;
            var stopWatch = new Stopwatch();
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            //for (int i = 0; i < 7; i++)
            //{
            //    Array myarray = new Array(n, seed);
            //    stopWatch.Start();
            //    count = InsertionSort(myarray);
            //    stopWatch.Stop();
            //    Console.WriteLine("Time in milliseconds for sequential loop: {0,6:N0}", stopWatch.ElapsedMilliseconds);
            //    Console.WriteLine("N: {0,6:N0} ",myarray.Length);
            //    n = n * 2;
            //}
            n = 1000;
            for (int i = 0; i < 7; i++)
            {
                Array myarray = new Array(n, seed);
                stopWatch.Reset();
                stopWatch.Start();
                count = ParallelTaskLoop(myarray);
                stopWatch.Stop();
                Console.WriteLine("Time in milliseconds for parallel loop: {0,6:N0}", stopWatch.ElapsedMilliseconds);
                Console.WriteLine("N: {0,6:N0} ", myarray.Length);
                n = n * 2;
            }


            //Antro uzdavinio
            //n = 10;
            //for (int i = 0; i < 5; i++)
            //{
            //    stopWatch.Start();
            //    fibnum = F1(n);
            //    stopWatch.Stop();
            //    Console.WriteLine("Time in milliseconds for sequential loop: {0,6:N0}", stopWatch.ElapsedMilliseconds);
            //    Console.WriteLine("F( {0,4:N0} ) = {1,9:N0}", n, fibnum);
            //    n = n + 10;
            //}
            //n = 10;
            //fibnum = 0;
            //for (int i = 0; i < 5; i++)
            //{                
            //    stopWatch.Reset();
            //    stopWatch.Start();
            //    fibnum = F2(n);
            //    stopWatch.Stop();
            //    Console.WriteLine("Time in milliseconds for parallel loop: {0,6:N0}", stopWatch.ElapsedMilliseconds);
            //    Console.WriteLine("F( {0,4:N0} ) = {1,9:N0}", n, fibnum);
            //    n = n + 10;
            //}

        }
        public static int InsertionSort(DataArray items)
        {
            int count = 0;
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (items[j - 1] > items[j])
                    {
                        double temp = items[j - 1];
                        items.Swap(j, items[j], temp);
                        
                    }
                    count++;
                }
            }
            return count;
        }

        // nezinau kaip padaryti 
        private static int ParallelTaskLoop(DataArray items)
        {
            int countCPU = 4 / 2;
            Task<int>[] tasks = new Task<int>[countCPU];
            for (var j = 0; j < countCPU; j++)
                tasks[j] = Task<int>.Factory.StartNew(
                    (object p) =>
                    {
                        int count = 0;
                        for (int i = (int)p; i < items.Length - 1; i += countCPU)
                        {
                            for (int m = i + 1; m > 0; m--)
                            {
                                if (items[m - 1] > items[m])
                                {
                                    double temp = items[m - 1];
                                    items.Swap(m, items[m], temp);                                    
                                }
                                count++;
                            }                            
                        }
                        return count;
                    }, j);
            int total = 0;
            for (var i = 0; i < countCPU; i++) total += tasks[i].Result;
            return total;
        }
        static int F1(int n)
        {
            if (n > 1) return F1(n - 1) + 8 * F1(n - 4) + 9 * F1(n - 5) + (n ^ 4) / 3;
            else return 5;
        }
        static int F2(int n)
        {
            int fnum = 0;
            if (n < 2) fnum = F1(n);
            else
            {
                //fnum = F1(n - 1) + 8 * F1(n - 4) + 9 * F1(n - 5) + (n ^ 4) / 3;
                int countCPU = 4;
                Task[] tasks = new Task[countCPU];
                tasks[0] = Task.Factory.StartNew(
                    (Object p) =>
                    {
                        var data = p as CustomData; if (data == null) return;
                        data.TResult = F1(n - 1);
                    },
                    new CustomData());
                for (int j = 1; j < countCPU - 1; j++)
                    tasks[j] = Task.Factory.StartNew(
                        (Object p) =>
                        {
                            var data = p as CustomData; if (data == null) return;
                            data.TResult = F1(n - data.TNum - 1);
                        },
                            new CustomData() { TNum = j + 2});
                tasks[3] = Task.Factory.StartNew(
                    (Object p) =>
                    {
                        var data = p as CustomData; if (data == null) return;
                        data.TResult = (n ^ 4) / 3;
                    },
                    new CustomData());
                Task.WaitAll(tasks);
                fnum = (tasks[0].AsyncState as CustomData).TResult
                    + 8 * (tasks[1].AsyncState as CustomData).TResult
                    + 9 * (tasks[2].AsyncState as CustomData).TResult
                    + (tasks[3].AsyncState as CustomData).TResult;
                //Task tasks1 = new Task();
                //tasks = Task.Factory.StartNew(
                //    (Object p) =>
                //    {
                //        var data = p as CustomData; if (data == null) return;
                //        data.TResult = F1(n - data.TNum - 1);
                //    },
                //        new CustomData() { TNum = 4 }); 
            }
            return fnum;
        }
    }
    abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract double this[int index] { get; }
        public abstract void Swap(int j, double a, double b);
        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" {0:F5}", this[i]);
            Console.WriteLine();
        }
    }
}
