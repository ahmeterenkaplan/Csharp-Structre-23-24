using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soru2
{
    internal class Program
    {
        class block
        {
            public int data;
            public block next;
        }


        static block oluştur(int s, int e)
        {
            block head = null;
            block last = null;

            for (int i = s; i < e; i++)
            {
                birEkle(ref head, ref last, i);
            }

            return head;
        }
        static block rasgeleOluştur(int[] values)
        {
            block head = null;
            block last = null;

            for (int i = 0; i < values.Length; i++)
            {
                birEkle(ref head, ref last, values[i]);
            }

            return head;
        }
        static void birEkle(ref block thrid, ref block last, int data)
        {
            block tmp = new block();
            tmp.data = data;
            if (thrid == null) thrid = tmp;
            else last.next = tmp;
            last = tmp;
        }
        static void Main(string[] args)
        {
            // 2 tane aynı boyuttan linked list var içerisinde sıralı sayılar var 
            // bu iki linked listi 3. bir linked liste sıralı bir şekilde aktarılması isteniyor


            block first = rasgeleOluştur(new int[] { 1, 3, 4, 6, 9, 12, 15, 16, 17 }); // 5,6,7,8,9
            block secound = rasgeleOluştur(new int[] { 4, 5, 8, 12, 15, 16, 17, 21, 23 }); // 2,3,4,5,6

            block thrid = null;
            block last = null;
            while (first != null || secound != null)
            {
                while (secound != null && first.data > secound.data)
                {
                    birEkle(ref thrid, ref last, secound.data);
                    secound = secound.next;
                }
                while (first != null && secound.data > first.data)
                {
                    birEkle(ref thrid, ref last, first.data);
                    first = first.next;
                }
                while (first != null && secound != null && first.data == secound.data)
                {
                    birEkle(ref thrid, ref last, first.data);
                    birEkle(ref thrid, ref last, secound.data);
                    first = first.next;
                    secound = secound.next;
                }
                while (first == null && secound != null)
                {
                    birEkle(ref thrid, ref last, secound.data);
                    secound = secound.next;
                }
                while (secound == null && first != null)
                {
                    birEkle(ref thrid, ref last, first.data);
                    first = first.next;
                }
            }
        }
    }
}
