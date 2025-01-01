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
            // ödev2: 1 ve 0 dan oluşan bir dizi olacak dizi string olacak bundan 6 e bölünebilecek
            // otomata ile çözüm

            string s = "110";

            int state = 0;
            int[,] q = new int[6, 2];

            q[0, 1] = 1;
            q[1, 0] = 2;
            q[1, 1] = 3;
            q[2, 0] = 4;
            q[2, 1] = 5;
            q[3, 0] = 0;
            q[3, 1] = 1;
            q[4, 0] = 2;
            q[4, 1] = 3;
            q[5, 0] = 4;
            q[5, 1] = 5;


            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, s[i] - '0'];
            }

            Console.WriteLine(state == 0 ? "Kabul ediyoruz" : "Red ediyoruz");
            Console.ReadKey();
        }
    }
}
