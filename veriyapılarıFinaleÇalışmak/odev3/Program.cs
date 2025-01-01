using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] q = new int[2, 26];
            q[0, 0] = 1;
            q[1, 0] = 1;
            q[1, 1] = 2;

            int state = 0;
            string s = "jshfjhdkfjkab";

            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, s[i] - 'a'];
                if (state == 2) break;
            }

            Console.WriteLine((state == 2) ? "ab Bulundu" : "ab Bulunamadı");
            Console.ReadKey();
        }
    }
}
