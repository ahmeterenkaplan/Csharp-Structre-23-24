using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soru3
{
    internal class Program
    {
        // 3 boyutlu bir dizinin kullanıcı istediği en büyük elemanı bulmak ( dizi elemanlarını sort etmek yasaktır)
        // yani kullanıcı 2. en büyük elemanı bul derse bulacaksın veya 20 en büyük elamnı olabilir, kullanıcıya ait

        static int max(int[,,] x, int kaçıncı, int[] maxes = null, int indis = 0)
        {
            if (kaçıncı >= x.Length) return -1; // eleman bulunamaz
            // indis < 0 gibi durumları da kontrol edilebilir ancak bunlar bir program yazarken private olarak tanımlanacak oop kullanarak bundan dolayı ona ait ince ayarlarını yazmam

            if (indis == 0 || maxes == null) maxes = new int[kaçıncı]; // maxes yine private olarak kullanıcı girmeyecek genele ondan dolayı onu da kullanabiliriz

            if (indis >= x.Length) return maxes[kaçıncı - 1];

            int aSize = x.GetLength(1);
            int bSize = x.GetLength(2);

            int a = indis / (aSize * bSize);
            int b = (indis / bSize) % aSize;
            int c = indis % bSize;


            for (int i = 0; i < maxes.Length; i++)
            {
                if (x[a, b, c] > maxes[i])
                {
                    for (int j = maxes.Length - 1; j > i; j--)
                    {
                        maxes[j] = maxes[j - 1];
                    }
                    maxes[i] = x[a, b, c];
                    break;
                }
            }

            return max(x, kaçıncı, maxes, ++indis);


        }

        static void Main(string[] args)
        {
            int[,,] x = {
                {
                    {1, 2, 3},
                    {4, 52, 6},
                    {7, 8, 9}
                },
                {
                    {10, 11, 12},
                    {123, 50, 915},
                    {16, 17, 858}
                },
                {
                    {19, 20, 21},
                     {262, 523, 24},
                  {25, 26, 272}
                }
            };

            Console.WriteLine(max(x, 20)); // dinamik olarak hangi en büyük elemanı ister kullanıcı bulabilir sort etmeden
            Console.ReadKey();
        }
    }
}
