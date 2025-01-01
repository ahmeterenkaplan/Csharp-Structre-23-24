using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ders3_3
{
    internal class Program
    {

        // BİNARY TREE DEMEK RECURİSVE DEMEK
        static int[] binaryTree = new int[100];

        static void yazarmısınız(int[] bt, int indis)
        {
            if (indis >= bt.Length)
                return;

            if (bt[indis] != 0) // çünkü sıfır olanlar bu düğüm yok demek
                Console.WriteLine(bt[indis]);

            yazarmısınız(bt, indis * 2 + 1); 
            yazarmısınız(bt, indis * 2 + 2);

            // bir metot kendini 2 defa çağırırsa çok dekatli olmamız gerek çünkü çok tehlikeli
            // stack daha hızlı patlıyor diye herhalde 
        }
        static void Main(string[] args)
        {
            // tree yapıları
            // binary tree
            // comlex veriyapıları
            // değişkenler diziler

            // block lardan oluşur ve genellikle dizilerden oluşur
            // her block max seviyede eleman bulunabilir
            // her bir item bir adet pointer barındırır
            // özellikle sort ve search amaçlı kullanılır 

            // block - node - düğüm

            // en üstteki block adı ROOT NODE (KÖK DÜĞÜM)
            // en alttaki blocklara leaf denir 
            // pointer olmazsa tree olmaz
            // genelde veriler sıralı olur

            // dosya tek boyutlu bir dizidir ( ne dosyası farketmez, hepsi tek dizi )

            // biz binary tree ile ilgilieneceğiz
            // binary olmasının sebebi 2 tane linki olmasıdır
            // KODALMADIĞIMIZ VERİ BİZİM VERİMİZ DEĞİLDİR

            // işletim sistemleri dersi için fat32 dan bir soru gelecek

            // biz kodda düğümün olmayana 0 değer atacağız
            // 0 değerlerin arasında kullanacaksam negatif sayı ayarlarım eğer oda olmazsa gidip aynı length ten yeni bir dizi tanımlayıp
            // flag olarak kullanırım eğer dolu ise true bu düğün yoksa flag dizisinde flase yazarım



            for (int i = 0; i < 12; i++)
            {
                binaryTree[i] = i;
            }

            binaryTree[7] = 0; // demek 3 ün sol çocuğu iptal ettik


            yazarmısınız(binaryTree, 0);
            Console.ReadKey();
        }
    }
}
