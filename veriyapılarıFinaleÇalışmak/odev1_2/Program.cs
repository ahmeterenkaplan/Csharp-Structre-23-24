using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] q = new int[6, 26];
            string s = "jhabmdfabfgdef";

            q[0, 0] = 1;
            q[1, 0] = 1;
            q[1, 1] = 2;
            for (int i = 0; i < 26; i++)
            {
                q[2, i] = 2;
                q[3, i] = 2;
                q[4, i] = 2;
                q[5, i] = 2;
            }
            q[2, 0] = 5;
            q[2, 3] = 3;
            q[3, 3] = 3;
            q[3, 4] = 4;
            q[3, 0] = 5;
            q[4, 5] = 0;
            q[4, 0] = 5;
            q[5, 0] = 5;
            q[5, 1] = 6; // ab'den sonra def gelmeden tekrar ab gelmiş demek
            q[5, 3] = 3;

            int state = 0;
            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, s[i] - 'a'];
                if (state == 6) break; // state 6 olunca hemen çıkacağı için dizide onun için bir yer tahsil etmedim (:
            }
            Console.WriteLine((state == 0 || state == 1) ? "Kabul" : "Red");
            Console.ReadKey();
        }
    }
}
