using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ders2_3
{
    // kuyruk

    internal class Program
    {
        // kuyruk ve stack hataları yönetilmez;
        // hata olunca program kırılmalıdır

        static int[] queue = new int[100];
        static int[] destek = new int[100];
        static int front = 0; // hizmet alacak olan kısmı 
        static int rear = -1; // hizmete girecek olanları

        // dequeu ve enqueue

        static void enqueu(int data)
        {
            rear++;
            rear = rear % queue.Length;
            queue[rear] = data;
            destek[rear] = 1;
        }

        static int dqueue() // yeni bir dizi eklemesi bitmap ta kullanırsak hoca kulağımızı çeker ):  daha basit bir çözümü var diye ; bu gereksiz bir çözüm çünküs
        {
            int data = queue[front];
            destek[front] = 0;
            front++;
            front = front % queue.Length;// linked list ile çözersek daha performanslı olacağını düşünüyorum
            return data;
        } // bu çözümü geliştirmemiz gerek 

        static void Main(string[] args)
        {
            // kuyruk
            // adil bir sistem
            // FIFO veya LILO
            // stack ın tam tersidir
            // işletim sisremlerin içerisindeki mesajlaşmada çalışır
            // gelen mesjalar kuyruğa atılıyor
            // kuyruk stack ın kardeşidir
            // siminasiyon dersi nedir ?
            // hoca sisminasiyon ile ilgili staj verebilir.

            // hizmet bölümü vardır
            // sıraya dahil olma bölümü

            enqueu(20);
            enqueu(30);
            enqueu(40);

            Console.WriteLine(dqueue());
            Console.WriteLine(dqueue());
            Console.WriteLine(dqueue());


            for (int i = 0; i < 60; i++)
            {
                enqueu(i);
            }


            for (int i = 0; i < 60; i++)
            {
                Console.WriteLine(dqueue());
            }

            // bu aşağıdaki kod yazınca kod patlayacak 
            // sebebi front hep atıyor yani dequeue çağırınca çıkarmıyor sadece getiriyor 
            // patlar eğer eski çözüm ama hoca güncelledi ve patlamaz artık ):
            for (int i = 0; i < 60; i++)
            {
                enqueu(i);
            }

            for (int i = -60; i < 0; i++)
            {
                enqueu(i);
            }

            for (int i = 0; i < 60; i++)
            {
                Console.WriteLine(dqueue());
            }



            // sınavda çıktısı sorusu sorabilir
            Console.ReadKey();
        }
    }
}
