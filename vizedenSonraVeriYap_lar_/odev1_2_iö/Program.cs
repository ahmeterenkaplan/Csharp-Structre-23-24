using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_2_iö
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // sonsuz bir string için her ab den sonra def gelmeli (hemen gelmek zorunda değil) 
            // abjhjkdef    kabul
            // abdefkjhj    kabul
            // hdgfabjdf    red
            // habjdhejf    red

            int[,] q = new int[6, 26];
            q[0, 0] = 1;
            q[1, 1] = 2;
            for (int i = 0; i < 26; i++)
            {
                q[2, i] = 2;
            }
            q[2, 3] = 3;
            for (int i = 0; i < 26; i++)
            {
                q[3, i] = 2;
            }
            q[3, 4] = 4;
            for (int i = 0; i < 26; i++)
            {
                q[4, i] = 2;
            }
            q[4, 5] = 5;

            int state = 0;
            string s = "hdgfabjdef";
            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, s[i] - 'a'];
            }

            Console.WriteLine(state != 2 || state == 0 ? "Kabul" : "Red");

            Console.ReadKey();

        }
    }
}
