using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ders3_2
{
    internal class Program
    {
        class block
        {
            public int data;
            public block next;
            public block prev;
        }


        static void Main(string[] args)
        {
            block b1 = new block();
            block b2 = new block();

            block b3 = null;
            block last = null;


            int a = 0;
            int b = 0;
            int yon = 0;
            int data = 0;
            while (b1 != null || b2 != null)
            {
                if (b1 != null)
                {
                    a = b1.data;
                    yon = 0;
                    if (b2 == null)
                    {
                        b = b2.data;
                        if (a > b)
                        {
                            data = b;
                            yon = 1;
                        }
                        else
                        {
                            data = a;
                            yon = 0;
                        }
                    }
                }
                else
                {
                    yon = 1;
                    data = b2.data;
                }

                if (yon == 0)
                {
                    b1 = b1.next;
                }
                else
                {
                    b2 = b2.next;
                }
            }
            block tmp = new block();
            tmp.data = data;
            if (b3==null)
            {
                b3 = tmp;
                last = tmp;
            }
            else
            {
                last.next=b3;
                tmp.prev=last;
                last = tmp;
            }

            Console.ReadKey();

        }
    }
}
