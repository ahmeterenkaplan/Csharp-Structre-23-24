using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev1_4_iö
{
    internal class Program
    {
        static int Priority(char c)
        {
            if (c == '-' || c == '+')
                return 1;
            else if (c == '*' || c == '/')
                return 2;
            else if (c == '^')
                return 3;
            else
                return 0;
        }
        static string infix_to_postfix(string exp)
        {
            Stack<char> stk = new Stack<char>();
            string output = "";
            //-------------------------
            string op = "*/+-";
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == ' ') continue;
                if (exp[i] == '(')
                    stk.Push('(');
                else if (exp[i] == ')')
                {
                    while (stk.Peek() != '(')
                    {
                        output += stk.Peek();
                        stk.Pop();
                    }
                    stk.Pop();
                }
                else if (op.IndexOf(exp[i]) == -1)
                    output += exp[i];
                else
                {
                    try
                    {
                        while (stk.Count != 0 && Priority(exp[i]) <= Priority(stk.Peek()))
                        {
                            output += stk.Peek();
                            stk.Pop();
                        }
                    }
                    catch { }
                    finally { stk.Push(exp[i]); }
                }
            }
            try
            {
                // Eğer while in şartı true yazarsam hata fırlatılıyor ve aynı işlem olacak
                // true yazarsam daha hızlı oluyor mu
                while (stk.Count != 0)
                {
                    output += stk.Pop();
                }
            }
            catch { }
            return output;
        }
        static void Main(string[] args)
        {
            string s = "a^b-c*d";// yanlışlık var kodda
            Console.WriteLine(infix_to_postfix(s));

            Console.ReadKey();
        }
    }
}
