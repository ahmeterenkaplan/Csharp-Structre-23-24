using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ders2_2
{
    internal class Program
    {
        class block
        {
            public int data;
            public block next;
            public block prev;
        }
        static void ekleme(ref block first, int data) // önemli bir algoritma onun türevlerinden soru sorabilir finalde
        {
            block b1 = new block();
            b1.data = data;
            if (first == null) // liste boş ilk kayıt yapılıyor
            {
                first = b1;
                return;
            }
            if (data <= first.data) // daha küçük olma durumunda
            {
                b1.next = first;
                first.prev = b1;
                first = b1;
                return;
            }
            block tmp = first;
            int flag = 0;
            while (data > tmp.data)
            {
                flag = 1;
                if (tmp.next == null)
                {
                    flag = 2;
                    break;
                }
                tmp = tmp.next;
            }
            if (flag == 1) // araya eklerim
            {
                b1.next = tmp;
                b1.prev = tmp.prev;

                tmp.prev.next = b1;
                tmp.prev = b1;
            }
            else if (flag == 2) // en sona eklerim
            {
                tmp.next = b1;
                b1.prev = tmp;
            }
            else if (flag == 0) // en başta ekleyeceğim
            {
                b1.next = tmp;
                first.prev = b1;
                first = b1;
                return; // doğru yazmamış olabilirim
            }
        }
        static void Main(string[] args)
        {



            Console.ReadKey();
        }
    }
}
