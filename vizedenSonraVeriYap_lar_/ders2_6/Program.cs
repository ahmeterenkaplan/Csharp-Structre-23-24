using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ders2_6
{
    internal class Program
    {
        // kombinsayonu hesaplayan programı yazınız n ve r değerleri alarak sonucu döndüren metot yaz (benden)

        static float faktöriyel(int sayı)
        {
            if (sayı <= 0) return 1;
            return sayı * faktöriyel(sayı - 1);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("C(n, r) için");
                Console.Write("n = ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Write("r = ");
                int r = Convert.ToInt32(Console.ReadLine());
             
                float sonuç = faktöriyel(n) / (faktöriyel(r) * faktöriyel(n - r));

                Console.WriteLine($"C({n}, {r}) = {sonuç}");
                Console.WriteLine();
            }
        }
    }
}
