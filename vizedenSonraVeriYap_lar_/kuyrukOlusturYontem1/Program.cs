using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kuyrukOlusturYontem1
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

        static void veriHareketi()
        {
            for (int i = 0; i < count(); i++)
            {
                queue[i] = queue[i + front];
            }
            rear = rear - count();
            front = 0;
        }

        static void enqueue(int data)
        {
            if (count() == queue.Length)
            {
                Console.WriteLine("hata");
                return;
            }
            if (rear == queue.Length - 1)
            {
                veriHareketi();
            }
            rear++;
            queue[rear] = data;
        }
        static int dequeue()
        {
            if (count() == 0)
            {
                Console.Write("Not Found ");
                return 404;
            }
            int data = queue[front];
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
