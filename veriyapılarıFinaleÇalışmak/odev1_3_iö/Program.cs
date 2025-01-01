using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_3_iö
{
    internal class Program
    {
        //sonsuz uzubkuktaki 2lik sayı siteminde gelen bir sayının kalanı 3 mü otomata da final tadında bir soru
        static void Main(string[] args)
        {
            int[,] q = new int[3, 2];

            q[0, 0] = 0; // bunu yazmamıza gerek yoktu çünkü .NET'te varsayılan integer dizilerde sıfır atanır ilk oluşturulduğunda
            q[0, 1] = 1;

            q[1, 0] = 2;
            q[1, 1] = 0; // gerek yoktur buna

            q[2, 0] = 1;
            q[2, 1] = 2;

            int state = 0;
            string s = "10101";
            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, s[i] - '0'];
            }

            Console.WriteLine($" bu [{s}] binary sisteminde 3'e bölümünden kalan = {state}");
            Console.ReadKey();

        }
    }
}
