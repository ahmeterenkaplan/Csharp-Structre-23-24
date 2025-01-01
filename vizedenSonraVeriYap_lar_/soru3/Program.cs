using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soru3
{
    internal class Program
    {
        // 3 boyutlu bir dizinin en büyük 2 sayıyı bulunuz
        static int max(int[,,] x, int indis = 0, int max1 = 0, int max2 = 0)
        {
            if (indis >= x.Length) return max2;

            int a = indis / (x.GetLength(1) * x.GetLength(2));
            int b = (indis / x.GetLength(2)) % x.GetLength(1);
            int c = indis % x.GetLength(2);

            if (x[a, b, c] > max1)
            {
                max2 = max1;
                max1 = x[a, b, c];
            }
            else if (max2 < x[a, b, c])
                max2 = x[a, b, c];

            return max(x, ++indis, max1, max2);
        }
        static void Main(string[] args)
        {
            int[,,] x = {
                {
                    {1, 2, 3},
                    {4, 52, 6},
                    {7, 8, 9}
                },
                {
                    {10, 11, 12},
                    {123, 50, 915},
                    {16, 17, 858}
                },
                {
                    {19, 20, 21},
                     {262, 523, 24},
                  {25, 26, 272}
                }
            };
            Console.WriteLine(max(x));
            Console.ReadKey();


        }
    }
}
