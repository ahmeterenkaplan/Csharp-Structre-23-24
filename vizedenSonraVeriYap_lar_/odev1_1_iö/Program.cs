using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_1_iö
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // sonsuz bir string için her ab den sonra def gelmeli (hemen gelmek zorunda) 
            // abjhjkdef    red
            // abdefkjhj    kabul

            int[,] q = new int[6, 26];

            q[0, 0] = 1;
            q[1, 1] = 2;
            q[2, 3] = 3;
            q[3, 4] = 4;
            q[4, 5] = 5;

            int state = 0;
            string s = "abdefdjhfabdefg";
            int flag = 1;
            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, s[i] - 'a'];
                if (state == 2 && s.Length != i + 1)
                {
                    i++;
                    state = q[state, s[i] - 'a'];
                    if (state != 3)
                    {
                        flag = 0;
                        break;
                    }
                }
            }
            Console.WriteLine(flag == 1 ? "Kabul" : "Red");

            Console.ReadKey();
        }
    }
}
