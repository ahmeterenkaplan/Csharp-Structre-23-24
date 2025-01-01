using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_4
{
    internal class Program
    {
        // otomata recursive
        static int enÇokKullanılanSayısı(string s, int[,] q, int[] tekrarlanan, int indis = 0, int max = 0, int state = 0)
        {
            if (indis * -1 >= tekrarlanan.Length)
                return max;

            if (indis < 0)
            {
                if (tekrarlanan[(indis * -1) - 1] > max)
                {
                    max = tekrarlanan[(indis * -1) - 1];
                }
                return enÇokKullanılanSayısı(s, q, tekrarlanan, --indis, max);
            }

            if (indis >= s.Length)
            {
                return enÇokKullanılanSayısı(s, q, tekrarlanan, -1, max);
            }

            state = q[state, s[indis] - 'a'];
            if (state == 4)
            {
                tekrarlanan[0]++;
                state = 0;
            }
            else if (state == 8)
            {
                tekrarlanan[1]++;
                state = 0;
            }
            else if (state == 14)
            {
                tekrarlanan[2]++;
                state = 0;
            }
            else if (state == 16)
            {
                tekrarlanan[3]++;
                state = 0;
            }

            return enÇokKullanılanSayısı(s, q, tekrarlanan, ++indis, max, state);
        }

        // otomata normal
       
        static void Main(string[] args)
        {


            // ödev4: 
            // string s = "alanboyualanboyualanyüksekalanboyuboyu"
            // string s = "alan-boyu-en-yüksek" en çok kullanılan kelime bulmak hem normal hem revurisve yaz

            int state = 0;
            int[,] q = new int[16, 26];
            int[] tekrarlanan = new int[4]; // 0 alan, 1 boyu, 3 yuksek, 4 en

            string s = "alanyuksekalanboyuenalan";


            q[0, 0] = 1;
            q[1, 11] = 2;
            q[2, 0] = 3;
            q[3, 11] = 2;
            q[3, 13] = 4;


            q[0, 1] = 5;
            q[5, 14] = 6;
            q[6, 24] = 7;
            q[7, 20] = 8;


            q[0, 24] = 9;
            q[9, 20] = 10;
            q[10, 10] = 11;
            q[11, 18] = 12;
            q[12, 4] = 13;
            q[13, 13] = 16;
            q[13, 10] = 14;


            q[0, 4] = 15;
            q[15, 13] = 16;

            for (int i = 0; i < s.Length; i++)
            {
                state = q[state, s[i] - 'a'];
                if (state == 4)
                {
                    tekrarlanan[0]++;
                    state = 0;
                }
                else if (state == 8)
                {
                    tekrarlanan[1]++;
                    state = 0;
                }
                else if (state == 14)
                {
                    tekrarlanan[2]++;
                    state = 0;
                }
                else if (state == 16)
                {
                    tekrarlanan[3]++;
                    state = 0;
                }
            }
            Console.WriteLine($"alan: {tekrarlanan[0]}\nboyu: {tekrarlanan[1]}\nyuksek: {tekrarlanan[2]}\nen: {tekrarlanan[3]}");



            Console.WriteLine(enÇokKullanılanSayısı(s, q, tekrarlanan));



            Console.ReadKey();

        }
    }
}
