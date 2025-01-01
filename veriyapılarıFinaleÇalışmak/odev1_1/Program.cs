using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_1
{
    internal class Program
    {
        // odev1 : 1 ve 0 dan oluşan bir stirng içindeki binary sayı 5'e bölünümp bölünmediğini kontrol eden programı yaz
        static void Main(string[] args)
        {

            string s = "101";
            int[,] q = new int[5, 2];
            int state = 0;

            q[0, 0] = 0; // yazmaya gerek yoktu
            q[0, 1] = 1;

            q[1, 0] = 2;
            q[1, 1] = 3;

            q[2, 0] = 4;
            q[2, 1] = 0;

            q[3, 0] = 1;
            q[3, 1] = 2;

            q[4, 0] = 2;
            q[4, 1] = 4;


            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, s[i] - '0'];
            }
            Console.WriteLine(state == 0 ? "Kabul" : "Red");


            Console.ReadKey();
        }
    }
}
