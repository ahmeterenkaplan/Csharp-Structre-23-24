using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFormBinary
{
    internal class Program
    {
        static int ConvertFromBinary(string sayı, int carpan = 1, int indis = 0)
        {
            if (indis >= sayı.Length) return 0;
            int s = (sayı[sayı.Length - indis - 1] - '0');
            return carpan * s + ConvertFromBinary(sayı, carpan * 2, ++indis);
        }
        static void Main(string[] args)
        {
            string s = "000000101";
            Console.WriteLine(ConvertFromBinary(s));
            Console.ReadKey();
        }
    }
}
