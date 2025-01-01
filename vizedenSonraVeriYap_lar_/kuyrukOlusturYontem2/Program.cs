using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kuyrukOlusturYontem2
{
    internal class Program
    {
        static int[] queue = new int[100];
        static int front = 0;
        static int rear = -1;

        static int count()
        {
            return rear - front + 1;
        }
        static void enqueue(int data)
        {
            if (count() == queue.Length)
            {
                Console.WriteLine("hata");
                return;
            }
            rear++;
            queue[rear % queue.Length] = data;
        }
        static int dequeue()
        {
            if (count() == 0)
            {
                Console.Write("Not Found ");
                return 404;
            }
            int data = queue[front % queue.Length];
            front++;
            return data;
        }

        static void Main(string[] args)
        {
            enqueue(1);
            enqueue(2);
            enqueue(3);
            Console.WriteLine(dequeue());
            Console.WriteLine(dequeue());
            Console.WriteLine(dequeue());

            for (int i = 0; i < 60; i++)
            {
                enqueue(i);
            }

            for (int i = 0; i < 60; i++)
            {
                Console.WriteLine(dequeue());
            }

            for (int i = 0; i < 60; i++)
            {
                enqueue(i);
            }

            for (int i = 0; i < 60; i++)
            {
                Console.WriteLine(dequeue());
            }

            Console.WriteLine(dequeue()); // kuyrukta eleman olmayacağı için not found 404 yazacaktır


            Console.ReadKey();
        }
    }
}
