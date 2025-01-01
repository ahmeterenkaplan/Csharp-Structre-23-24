using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_1_iö
{
    internal class Program
    {
        // sonsuz bir string için her ab den sonra def gelmeli (hemen gelmek zorunda) 
        // abjhjkdef    red
        // abdefkjhj    kabul

        static void Main(string[] args)
        {

            int[,] q = new int[5, 26]; // en son state 5 olabilir ancak olur olmaz döngüden çıkacağım için ona dizide bir yer ayarlamadım

            q[0, 0] = 1;
            q[1, 0] = 1;
            q[1, 1] = 2;

            for (int i = 0; i < 26; i++)
            {
                q[2, i] = 5;
                q[3, i] = 5;
                q[4, i] = 5;
            }

            q[2, 3] = 3;
            q[3, 4] = 4;
            q[4, 5] = 0;

            int state = 0;
            string s = "mnabdefjkabdef";
            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, s[i] - 'a'];
                if (state == 5) break;
            }

            Console.WriteLine((state == 0 || state == 1) ? "Kabul" : "Red");


            Console.ReadKey();
        }
    }
}
