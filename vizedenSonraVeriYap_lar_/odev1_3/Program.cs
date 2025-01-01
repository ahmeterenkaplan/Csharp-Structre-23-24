using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ödev2 : harflerden oluşan bir dizi olacak dizi string olacak zaten ab bulunca

            string s = "hajsabgd";

            int[,] q = new int[2, 26];
            q[0, 0] = 1;
            q[1, 1] = 2;


            int state = 0;
            bool bulundu = false;
            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, s[i] - 'a'];
                if (state == 2)
                {
                    bulundu = true;
                    break;
                }
            }

            Console.WriteLine(bulundu ? "Bulundu" : "Bulunamadı");
            Console.ReadKey();
        }
    }
}
