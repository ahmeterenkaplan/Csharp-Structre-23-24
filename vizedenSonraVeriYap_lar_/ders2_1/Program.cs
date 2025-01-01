using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ders2_1
{
    internal class Program
    {
        class block
        {
            public int data;
            public block next;
            public block prev;
        }
        // commenet satırları çok önemli (:
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
                if (tmp.next == null)
                {
                    flag = 1;
                    break;
                }
                tmp = tmp.next;
            }
            if (flag == 0) // araya eklerim
            {
                b1.next = tmp;
                b1.prev = tmp.prev;

                tmp.prev.next = b1;
                tmp.prev = b1;
            }
            else // en sona eklerim
            {
                tmp.next = b1;
                b1.prev = tmp;
            }
        }


        static void eklemeBenim(ref block first, int data)
        {
            block yeni = new block();
            yeni.data = data;
            if (first.data > data)
            {
                yeni.next = first;
                first.prev = yeni;
                first = yeni;
            }
            else
            {
                block tmp = first;
                while (tmp.data <= data && tmp.next != null)
                {
                    tmp = tmp.next;
                }

                if (tmp.data > data)
                {
                    yeni.next = tmp;
                    yeni.prev = tmp.prev;

                    tmp.prev.next = yeni;
                    tmp.prev = yeni;
                }
                else
                {
                    tmp.next = yeni;
                    yeni.prev = tmp;
                }
            }
        }

        static void eklemeBenim(ref block first, int[] dataler, int i = 0)
        {
            if (i == dataler.Length) return;
            int data = dataler[i];
            block yeni = new block();
            yeni.data = data;
            if (first.data > data)
            {
                yeni.next = first;
                first.prev = yeni;
                first = yeni;
            }
            else
            {
                block tmp = first;
                while (tmp.data <= data && tmp.next != null)
                {
                    tmp = tmp.next;
                }

                if (tmp.data > data)
                {
                    yeni.next = tmp;
                    yeni.prev = tmp.prev;

                    tmp.prev.next = yeni;
                    tmp.prev = yeni;
                }
                else
                {
                    tmp.next = yeni;
                    yeni.prev = tmp;
                }
            }
            eklemeBenim(ref first, dataler, ++i);
        }


        static void Main(string[] args)
        {
            // 5 8 10 20

            block first = null;
            for (int i = 0; i < 10; i++)
            {
                ekleme(ref first, 20 - i);
            }

            ekleme(ref first, -6);
            ekleme(ref first, 6);
            ekleme(ref first, 16); // sorted bir list tekrar eden kayıtları bul

            while (first!=null)
            {
                Console.WriteLine(first.data);
                first=first.next;
            }


            Console.ReadKey();
        }
    }
}
