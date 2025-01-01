using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_4
{
    internal class Program
    {

        // ödev4: 
        // string s = "alanboyualanboyualanyüksekalanboyuboyu"
        // string s = "alan-boyu-en-yüksek" en çok kullanılan kelime bulmak hem normal hem revurisve yaz

        static void Main(string[] args)
        {
            int state = 0;
            int[,] q = new int[16, 26];
            int[] tekrarlanan = new int[4]; // 0 alan, 1 boyu, 3 yuksek, 4 en

            string s = "alanyuksekalanboyuenalan";



            for (int i = 'a'; i <= 'z'; i++) Console.WriteLine($"{(char)i}: {i - 'a'}");

            Console.ReadKey();
        }
    }
}
