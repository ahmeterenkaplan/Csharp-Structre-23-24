using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kuyrukBenimYontem
{
    internal class Program
    {

        static int[] kuyruk = new int[10];
        static int rear = 0;
        static int front = -1;
        static int elemanSayısı = 0;
        static void enKuyruk(int data)
        {
            if (elemanSayısı == kuyruk.Length)
            {
                Console.WriteLine("Dolu!");
                return;
            }

            if (rear >= kuyruk.Length)
            {
                if (front != -1)
                    rear = 0;
                else
                {
                    Console.WriteLine("dolu");
                    return;
                }
            }

            kuyruk[rear] = data;
            rear++;
            elemanSayısı++;
        }

        static int deKuyruk()
        {
            front++;
            if (elemanSayısı == 0)
            {
                front--;
                Console.Write("NOT FOUND ");
                return 404;
            }
            if (front >= kuyruk.Length)
            {
                front = 0;
            }
            if (front < kuyruk.Length && front > rear)
            {
                elemanSayısı--;
                return kuyruk[front];
            }
            elemanSayısı--;
            return kuyruk[front];
        } 

        static void yazdır(int[] x, int i = 0)
        {
            if (i >= x.Length) return;
            Console.WriteLine(x[i]);
            yazdır(x, ++i);
        }

        static void Main(string[] args)
        {

            for (int i = 1; i <= 10; i++)
            {
                enKuyruk(i);
            }
            for (int i = 10; i <= 20; i++)
            {
                enKuyruk(i);
            }

            deKuyruk();
            deKuyruk();
            deKuyruk();


            enKuyruk(-5);
            enKuyruk(-5);

            deKuyruk();
            deKuyruk();


            enKuyruk(-9);
            enKuyruk(-8);
            enKuyruk(-7);
            enKuyruk(-3); // dolu diye eklenmeyecek

            for (int i = 0; i < 12; i++) // kapasite zaten 10 ve kuyruk dolu demek 2 tane not found göreceğiz
            {
                Console.WriteLine(deKuyruk());
            }


            Console.ReadKey();
        }
    }
}
