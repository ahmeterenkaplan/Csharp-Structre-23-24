using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enÇokTekrarEdenSubstring
{
    internal class Program
    {
        // her hangi bir string içinde en çok tekrar eden substring
        static string normalEnÇokKelime(string cumle)
        {
            string uzun = "";
            int tekrar = int.MinValue;
            for (int m = 0; m < cumle.Length; m++)
            {
                string kelime = "";
                for (int n = m; n < cumle.Length; n++)
                {
                    kelime += cumle[n];
                    if (kelime.Length < 2) continue;
                    int tmpTekrar = 0;
                    for (int i = 0; i < cumle.Length; i++)
                    {
                        string tmp = "";
                        for (int j = i; j < i + kelime.Length && j < cumle.Length; j++)
                        {
                            tmp += cumle[j];
                        }
                        if (tmp == kelime)
                        {
                            tmpTekrar++;
                            if (tekrar < tmpTekrar || (tekrar == tmpTekrar && kelime.Length > uzun.Length))
                            {
                                tekrar = tmpTekrar;
                                uzun = kelime;
                            }
                        }
                    }
                }
            }
            return uzun;
        }
        static void Main(string[] args)
        {

            normalEnÇokKelime("alanyuksekalanalanenyuksekaalan");
            Console.ReadKey();
        }
    }
}
