using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ders1_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // ilk ders sohbet mahabet
            // sonra infix postfix ile ilgili anlattı


            // psotfixten value ya nasıl dönüştürelim

            // A+B*C A=1, B=2, C=3
            // ABC*+
            // 123*+

            /*
             * 1
             * 2
             * 3
             * 
             * sonra 3 ile 2 çarp geri stacka at
             * sonra 1 ile topla (:
             * 
             * 
             */


            string s = "123*+";

            Stack<int> st = new Stack<int>();
            string op = "/*+-";
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (op.IndexOf(s[i]) == -1)
                {
                    st.Push(s[i] - '0'); // IndexOf() sınavda kullanmak yasak değildir
                    continue;
                }
                int op2 = st.Pop();
                int op1 = st.Pop();
                result = 0;
                if (s[i] == '*')
                {
                    result = op1 * op2;
                }
                if (s[i] == '/')
                {
                    result = op1 / op2;
                }
                if (s[i] == '+')
                {
                    result = op1 + op2;
                }
                if (s[i] == '-')
                {
                    result = op1 - op2;
                }
                st.Push(result);
            }
            Console.WriteLine(result);
            Console.WriteLine(st.Pop());



            Console.ReadKey();
        }
    }
}
