using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soru1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // bir stringin alfabatik sıralamasına göre sıralamak her kelime ayrı sıralanacaktır
            string st = "merhaba world";
            string r = "";
            Stack<int> stack = new Stack<int>();// sınavda .net'in stackını kullanmak yasaktı

            for (int i = 0; i < st.Length; i++)
            {
                int harf = st[i];
                if (harf == ' ')
                {
                    while (stack.Count > 0)
                    {
                        r += (char)stack.Pop();
                    }
                    r += ' ';
                    continue;
                }
                if (stack.Count > 0)
                {
                    if (harf < stack.Peek())
                    {
                        int tmp = stack.Pop();
                        stack.Push(harf);
                        stack.Push(tmp);
                    }
                    else
                        stack.Push(harf);
                }
                else
                    stack.Push(harf);

            }
            while (stack.Count > 0)
            {
                r += (char)stack.Pop();
            }
            Console.WriteLine(r);
            Console.ReadKey();
        }
    }
}
