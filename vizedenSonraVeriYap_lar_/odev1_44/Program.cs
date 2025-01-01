using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_44
{
    internal class Program
    {
  
        static string enÇokTekrarEdenNormal(string s1, string s2)
        {
            int max = int.MinValue;
            string kelime = "";

            for (int m = 0; m < s2.Length;)
            {
                string tmpKelime = "";
                for (; m < s2.Length; m++)
                {
                    if (s2[m] == '-')
                    {
                        m++;
                        break;
                    }
                    tmpKelime += s2[m];
                }

                int tmpMax = 0;
                for (int j = 0; j < s1.Length; j++)
                {
                    string tmp = "";
                    for (int n = j; n < j + tmpKelime.Length && n < s1.Length; n++)
                    {
                        tmp += s1[n];
                    }

                    if (tmp == tmpKelime)
                    {
                        j += tmp.Length - 1;
                        tmpMax++;
                    }

                    if (max < tmpMax)
                    {
                        max = tmpMax;
                        kelime = tmpKelime;
                    }
                }
            }

            return kelime;
        }
        static void Main(string[] args)
        {
            string s1 = "alanboyualanyuksekboyualanenalan";
            string s2 = "alan-boyu-yuksek-en";

            Console.WriteLine(enÇokTekrarEdenNormal(s1, s2));

            Console.ReadKey();



        }
    }
}
