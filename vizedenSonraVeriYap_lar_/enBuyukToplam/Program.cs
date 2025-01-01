using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enBuyukToplam
{
    internal class Program
    {
        static Stack<int> st = new Stack<int>();
        static void toplayan(int[,] arr, int i = 0, int j = 0, int toplam = 1)
        {
            if (i + 1 == arr.GetLength(0) && j + 1 == arr.GetLength(1)
             || j + 1 == arr.GetLength(1) && arr[i + 1, j] == 0
             || i + 1 == arr.GetLength(0) && arr[i, j + 1] == 0)
            {
                st.Push(toplam);
                return;
            }

            //sağ
            if (j + 1 < arr.GetLength(1))
            {
                if (arr[i, j + 1] == 1)
                {
                    toplayan(arr, i, j + 1, toplam + 1);
                }
            }

            // çapraz
            if (i + 1 < arr.GetLength(0) && j + 1 < arr.GetLength(1))
            {
                if (arr[i + 1, j + 1] == 1)
                {
                    toplayan(arr, i + 1, j + 1, toplam + 1);
                }
            }

            // aşağı
            if (i + 1 < arr.GetLength(0))
            {
                if (arr[i + 1, j] == 1)
                {
                    toplayan(arr, i + 1, j, toplam + 1);
                }
            }
        }

        static int enBuyuk(int max = 0)
        {
            if (st.Count <= 1)
                return max;

            int tmp = st.Pop();

            if (tmp < max)
                return enBuyuk(max);
            else
                return enBuyuk(tmp);
        }

        static int enBuyukToplam(int[,] arr)
        {
            toplayan(arr);
            return enBuyuk();
        }

        static void Main(string[] args)
        {

            int[,] arr = {
                { 1, 0, 1, 1 },
                { 1, 0, 1, 0 },
                { 1, 1, 1, 0 },
                { 0, 1, 1, 1 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 1 } };

            int max = enBuyukToplam(arr);

            Console.WriteLine(max);
            Console.ReadKey();
        }
    }
}
