using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hafta2Masa
{
    internal class Program
    {
        class block
        {
            public int data;
            public block next;
            public block prev;
        }

        static block front = null;
        static block rear = null;

        static void enQueue(int data)
        {
            block tmp = new block();
            tmp.data = data;
            if (front == null) front = tmp;
            else
            {
                rear.next = tmp;
                tmp.prev = rear;
            }
            rear = tmp;
        }

        static int deQueue()
        {
            if (front == null)
            {
                Console.Write("Not Found ");
                return 404;
            }
            int data = front.data;
            front = front.next;
            if (front != null) front.prev = null;
            return data;
        }


        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                enQueue(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(deQueue());
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(deQueue());
            }

            Console.ReadKey();
        }
    }
}
