using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soru1
{
    internal class Program
    {
        // bubble sort recurisve hali

        static void bubbleSort(int[] x)
        {
            int swap = 0;
            for (int i = 0; i < x.Length - 1; i++)
            {
                for (int j = 0; j < x.Length - i - 1; j++)
                {
                    if (x[j] < x[j + 1])
                    {
                        x[j] += x[j + 1];
                        x[j + 1] = x[j] - x[j + 1];
                        x[j] -= x[j + 1];
                        swap = 1;
                    }
                }
                if (swap == 0) return; // Eğer iç içe döngüde hiç takas yapılmamışsa, dizi zaten sıralıdır.
            }
        }


        static void bubbleRecursive(int[] x, int a = 0, int b = 0, int swap = 0)
        {
            if (b >= x.Length - a - 1)
            {
                b = 0;
                a++;
                if (swap == 0) return;
                swap = 0;
            }

            if (a >= x.Length) return;

            if (x[b] < x[b + 1])
            {
                x[b] += x[b + 1];
                x[b + 1] = x[b] - x[b + 1];
                x[b] -= x[b + 1];
                swap = 1; // kullanınca mantıkken daha hılzı olması gerek ancak hesapladığımda fazla değişmez yine de ekledim
            }

            bubbleRecursive(x, a, ++b, swap) ;
        }

        static void Main(string[] args)
        {
            int[] x = { 3, 2, 5, 4, 1, 34, 234, 534, 654, 757, 345, 52, 234, 2, 342, 5, 436, 5, 63,
                    12, 45, 67, 23, 89, 234, 789, 56, 12, 567, 234, 987, 543, 76, 45, 23, 90, 12,
                    34, 78, 345, 98, 23, 567, 123, 456, 789, 234, 567, 890, 123, 456, 789 };


            Stopwatch sw = new Stopwatch();
            sw.Start();
            bubbleRecursive(x);

            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);
            //for (int i = 0; i < x.Length; i++)
            //{
            //    Console.WriteLine(x[i]);
            //}

            Console.ReadKey();

        }
    }
}
