using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace odev1_1
{
    internal class Program
    {
        static int ConvertFromBinary(string sayı, int carpan = 1, int indis = 0)
        {
            if (indis >= sayı.Length) return 0;
            int s = (sayı[sayı.Length - indis - 1] - '0');
            return carpan * s + ConvertFromBinary(sayı, carpan * 2, ++indis);
        }
        static string ConvertToBinary(int sayı)
        {
            if (sayı <= 0) return "";

            return ConvertToBinary(sayı / 2) + sayı % 2;
        }

        static void Main(string[] args)
        {
            // ödev1: 1 ve 0 dan oluşan bir dizi olacak dizi string olacak bundan 5 e bölünebilecek
            // otomata ile çözüm

            int state = 0;
            int[,] q = new int[5, 2];

            string s = "1010";

            q[0, 1] = 1;
            q[1, 0] = 2;
            q[1, 1] = 3;
            q[2, 0] = 4;
            q[2, 1] = 0;
            q[3, 0] = 1;
            q[3, 1] = 2;
            q[4, 0] = 3;
            q[4, 1] = 4;

            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, s[i] - '0'];
            }

            Console.WriteLine(state == 0 ? "Kabul ediyoruz" : "Red ediyoruz");
            Console.ReadKey();
        }
    }
}
