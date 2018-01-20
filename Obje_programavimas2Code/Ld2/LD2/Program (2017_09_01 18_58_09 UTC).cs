using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2
{
    // Pirmo uždavinio testavimas
    // Antro uždavinio testavimas
    class Program
    {
        public static ulong opMcout;
        static long F1(int n)
        {
            if (n > 1) { opMcout = opMcout + 1; return F1(n - 1) + 8 * F1(n - 4) + 9 * F1(n - 5) + (n ^ 4) / 3; }
            else { opMcout = opMcout + 1; return 5; }
        }
        static ulong F2(ulong n)
        {
            opMcout = 0;
            if (n > 1)
            {
                ulong[] f = new ulong[n + 1];
                f[0] = f[1] = 5;
                for (ulong i = 2; i < n + 1; i++)
                {
                    if (i == 2 || i == 3)
                    { opMcout = opMcout + 1;  f[i] = f[i - 1] + 8 * 5 + 9 * 5 + (i ^ 4) / 3; }
                    else if (i == 4)
                    { opMcout = opMcout + 1;  f[i] = f[i - 1] + 8 * f[i - 4] + 9 * 5 + (i ^ 4) / 3; }
                    else if (i >= 5)
                    { opMcout = opMcout + 1;  f[i] = f[i - 1] + 8 * f[i - 4] + 9 * f[i - 5] + (i ^ 4) / 3; }
                }
                opMcout = opMcout + 3;
                return f[n];
            }
            else { opMcout = opMcout + 1; return 5; }
        }
        static int FTriu(int n)
        {
            if (n > 4)
                { opMcout = opMcout + 1; return FTriu(n - 2) + FTriu(n - 3); }
            else if (n == 1 || n == 0) { opMcout = opMcout + 1; return 0; }
            else { opMcout = opMcout + 1; return 1; }
        }
        static int Ftriu2(int n)
        {
            opMcout = 0;
            if (n == 0 || n == 1)
                { opMcout = opMcout + 1; return 0; }
            else if (n < 5)
                { opMcout = opMcout + 1; return 1; }
            int[] numbers = new int[n + 1];
            numbers[0] = 0;
            numbers[1] = 0;
            numbers[2] = 1;
            numbers[3] = 1;
            numbers[4] = 1;
            for (int i = 5; i <= n; i++)
            {
                numbers[i] = numbers[i - 2] + numbers[i - 3];
                opMcout = opMcout + 1;
            }
            return numbers[n];
        }
        static void Main(string[] args)
        {
            long f1;
            ulong f2;

            int n = 10;
            ulong n1 = 1;
            Console.WriteLine("\n Rekursinės funkcijos \n       N                Skaičius        RUN  Time          Op M Count\n");
            for (int i = 0; i < 6; i++)
            {
                Stopwatch myTimer = new Stopwatch();
                myTimer.Start();
                f1 = F1(n);
                myTimer.Stop();
                Console.WriteLine(" {0,7:N0}  {1,22}   {2,20} {3,14}", n, f1, myTimer.Elapsed, opMcout);
                //n = n + 7;
            }
            //n1 = 10;
            //Console.WriteLine("\n Dinaminis programavimas \n       N              Skaičius        RUN  Time          Op M Count\n");
            //for (int i = 0; i < 10; i++)
            //{
            //    Stopwatch myTimer = new Stopwatch();
            //    myTimer.Start();
            //    f2 = F2(n1);
            //    myTimer.Stop();
            //    Console.WriteLine(" {0,7:N0}   {1,22}   {2,20} {3,13}", n1, f2, myTimer.Elapsed, opMcout);
            //    n1 = n1 * 2;
            //}

            //int f;
            //n = 10;
            //Console.WriteLine("\n Rekursinės funkcijos \n       N      Laiptelių skaičius        RUN  Time          Op M Count\n");
            //for (int i = 0; i < 7; i++)
            //{
            //    Stopwatch myTimer = new Stopwatch();
            //    myTimer.Start();
            //    f = FTriu(n);
            //    myTimer.Stop();
            //    Console.WriteLine(" {0,7:N0}  {1,22}   {2,20} {3,14}", n, f, myTimer.Elapsed, opMcout);
            //    n = n + 7;
            //}

            //n = 10;
            //Console.WriteLine("\n Dinaminis programavimas \n       N       Laiptelių skaičius        RUN  Time          Op M Count\n");
            //for (int i = 0; i < 10; i++)
            //{
            //    Stopwatch myTimer = new Stopwatch();
            //    myTimer.Start();
            //    f = Ftriu2(n);
            //    myTimer.Stop();
            //    Console.WriteLine(" {0,7:N0}   {1,22}   {2,20} {3,13}", n, f, myTimer.Elapsed, opMcout);
            //    n = n * 2;
            //}
            Console.WriteLine("FTriu(8) = " + FTriu(8));
            //Console.WriteLine("Ftriu2(8) = " + Ftriu2(8));
        }
    }
}
