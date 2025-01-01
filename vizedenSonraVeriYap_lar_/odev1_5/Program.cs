using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ödev 5 : string s = "def;mdf;ref" bunları sadece ekrana yazdırmak


            string s = "def;mdf;ref";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ';')
                    Console.WriteLine();
                else
                    Console.Write(s[i]);
            }

            Console.ReadKey();
        }
    }
}
