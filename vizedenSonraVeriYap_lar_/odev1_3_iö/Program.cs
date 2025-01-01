using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_3_iö
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //sonsuz uzubkuktaki 2lik sayı siteminde gelen bir sayının kalanı 3 mü otomata da final tadında bir soru

            int[,] q = new int[3, 2];
            q[0, 0] = 0;
            q[0, 1] = 1;

            q[1, 0] = 2;
            q[1, 1] = 0;

            q[2, 0] = 1;
            q[2, 1] = 2;
            string s = "101";
            int state = 0;

            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, s[i] - '0'];
            }

            Console.WriteLine($"{s} binary sisteminde 3'e bölümünden kalan = {state}");
            Console.ReadKey();
        }
    }
}
