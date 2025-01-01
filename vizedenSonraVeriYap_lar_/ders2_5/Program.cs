using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ders2_5
{
    internal class Program
    {
        // kuyruğu linked list ile geliştirmek

        class block
        {
            public int data;
            public block next;
            public block prev;
        }

        static int[] queue = new int[100];
        static int[] destek = new int[100];
        static int front = 0; // hizmet alacak olan kısmı 
        static int rear = -1; // hizmete girecek olanları
        static int count()
        {
            return rear - front + 1;
        }
        // dequeu ve enqueue

        // bu çözüm dolu olanın üzerine yazar galiba 
        static void veriHareketi()
        {
            for (int i = 0; i < count(); i++)
            {
                queue[i] = queue[i + front];
            }
            rear -= count();
            front = 0;
        }
        static void enqueu(int data)
        {
            // bir şart yazmamız gerek,
            // eleman sayısı 

            if (count() == queue.Length)
            {
                Console.WriteLine("Hata");
                return; // hata yönetilmez dedik, programı patlatırız hemen kullancının yüzüne hata veririz ):
                // veir hareketiyle bu problemi çözünüz
            }
            if (rear == queue.Length - 1)
            {
                veriHareketi();
            }
            rear++;
            queue[rear] = data;
        }
        // bu çözüm de iyi bir önceki çözüm de iyi Atilla hoca bir önce ki çözümü tercih eder
        static int dqueue()// yeni bir dizi eklemesi bitmap ta kullanırsak hoca kulağımızı çeker ):  daha basit bir çözümü var diye ; bu gereksiz bir çözüm çünküs
        {
            int data = queue[front];
            destek[front] = 0;
            front++;
            return data;
        }// bu çözümü geliştirmemiz gerek 


        static block Front = null;
        static block Rear = null;


        static void bişey(int data)
        {
            block bl = new block();
            bl.data = data;

            if (Front==null)
            {
                Front = bl;
                Rear = bl;
                return;
            }
            bl.prev = Rear;
            Rear.next = bl;
            Rear = bl;
        }

        static int getirLinked()
        {
            int data = Front.data;
            Front = Front.next;
            Front.prev = null;
            return data;
        }

        // gelecek hafta uygulama örnekler çözeceğiz 

        // sağ yukarıdan en sol aşağıya inerim ve en fazla sayı toplamak istiyorum
        static void Main(string[] args)
        {

        }
    }
}
