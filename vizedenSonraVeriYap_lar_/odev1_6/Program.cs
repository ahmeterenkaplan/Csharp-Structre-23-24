using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ödev3 : infixten postfixe dönüştürürken a ve b gerçek değişkenler olacak yani bir a ve b string olacak değil
            // yani char yerine stirng kullanılacak
            // yani 
            // en+yüksek-bir*boyu
            // enyüksek+birboyu*-
            string infix = "yuksek+boyu-(en*alan)";
            string ops = "#(*/+-)";
            int[] val = { 0, 0, 2, 2, 1, 1 };
            Stack<int> st = new Stack<int>();
            st.Push(0);
            string postfix = "";
            for (int i = 0; i < infix.Length; i++)
            {
                while (ops.IndexOf(infix[i]) == -1)
                {
                    postfix += infix[i];
                    i++;
                    if (i == infix.Length) break;
                }
                if (i == infix.Length) break;
                if (infix[i] == '(')
                {
                    st.Push(ops.IndexOf('('));
                    i++;
                    if (i == infix.Length) break;
                    while (ops.IndexOf(infix[i]) == -1)
                    {
                        postfix += infix[i];
                        i++;
                    }
                    if (i == infix.Length) break;
                }
                if (infix[i] == ')')
                {
                    while (st.Peek() != 1)
                    {
                        postfix += ops[st.Pop()];
                    }
                    st.Pop();
                    continue;
                }
                if (val[st.Peek()] >= val[ops.IndexOf(infix[i])])
                {
                    postfix += ops[st.Pop()];
                    st.Push(ops.IndexOf(infix[i]));
                }
                else
                    st.Push(ops.IndexOf(infix[i]));
            }
            while (st.Count > 1)
            {
                postfix += ops[st.Pop()];
            }
            Console.WriteLine(postfix);
            Console.ReadKey();
        }
    }
}
