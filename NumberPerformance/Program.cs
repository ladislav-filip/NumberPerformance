using System;
using System.Diagnostics;

namespace NumberPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            var repeat = 1000000;
            var repeatDividers = new float[] { 4.56f, 5.21f, 3.87f, 6.01f };            

            for (var i = 0; i < repeatDividers.Length; i++)
            {
                //repeat = repeat * i;
                var divider = repeatDividers[i];

                var watch = new Stopwatch();

                Console.WriteLine($"Divide repeat: {repeat}");
                watch.Start();
                CalcFloat(repeat, divider);
                watch.Stop();
                Console.WriteLine($"Float elapsed: {watch.Elapsed.TotalSeconds} sec");
                var referenceElapsed = watch.Elapsed.TotalSeconds;

                watch.Start();
                CalcDouble(repeat, divider);
                watch.Stop();
                Console.WriteLine(
                    $"Double elapsed: {watch.Elapsed.TotalSeconds} sec. [{Math.Round(watch.Elapsed.TotalSeconds / referenceElapsed, 1)}x]");

                watch.Start();
                CalcDecimal(repeat, divider);
                watch.Stop();
                Console.WriteLine(
                    $"Decimal elapsed: {watch.Elapsed.TotalSeconds} sec.[{Math.Round(watch.Elapsed.TotalSeconds / referenceElapsed, 1)}x]");

                Console.WriteLine();                
            }

            Console.WriteLine("Finnish. Press any key...");
            Console.ReadKey();
        }

        static void CalcFloat(int repeat, float divider)
        {
            float nr1, nr2, nr3;
            for (var i = 0; i < repeat; i++)
            {
                nr1 = 1.23f;
                nr2 = divider;
                nr3 = nr1 / nr2;
            }
        }

        static void CalcDouble(int repeat, float divider)
        {
            double nr1, nr2, nr3;
            var dv = (double) divider;
            for (var i = 0; i < repeat; i++)
            {
                nr1 = 1.23d;
                nr2 = dv;
                nr3 = nr1 / nr2;
            }
        }

        static void CalcDecimal(int repeat, float divider)
        {
            decimal nr1, nr2, nr3;
            var dv = (decimal)divider;
            for (var i = 0; i < repeat; i++)
            {
                nr1 = 1.23m;
                nr2 = dv;
                nr3 = nr1 / nr2;
            }
        }
    }
}
