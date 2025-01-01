using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ders3_1
{
    internal class Program
    {
        // sınavdaki soruya benzer bir soru çözdü
        // dizinin 2. en büyük elemanı bulmak
        static int max2bul(int[] x, int indis, int max1, int max2)
        {
            if (indis >= x.Length)
            {
                return max2;
            }

            //int a = indis / 200;
            //int b = indis - a * 200 / 20;
            //int c = indis - a * 200 - b * 20;

            if (x[indis] > max1)
            {
                max2 = max1;
                max1 = x[indis];
            }
            else if (x[indis] > max2)
            {
                max2 = x[indis];
            }

            return max2bul(x, +indis, max1, max2);
        }
        static void Main(string[] args)
        {
        }
    }
}
