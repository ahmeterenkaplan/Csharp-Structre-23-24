using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace masa
{
    internal class Program
    {
        class block
        {
            public int data;
            public block next;
            public block prev;
        }

        static block Block()
        {
            block first = new block();
            block last = new block();
            last = first;
            for (int i = 1; i < 10; i++)
            {
                block tmp = new block();
                tmp.data = i;
                last.next = tmp;
                tmp.prev = last;
                last = tmp;
            }
            return first;
        }

        static void arayaEkle(block first, int data)
        {
            if (first == null) return;

            if (first.next.data == 3)
            {
                block yeni = new block();
                yeni.data = 4;
                first.next.prev = yeni;
                yeni.next = first.next;
                yeni.prev = first;
                first.next = yeni;
                return;
            }
            arayaEkle(first.next, data);
        }
        class tree
        {
            public int value;
            public tree right;
            public tree left;
        }
        static tree mirror(tree node)
        {
            if (node == null) return null;

            node.left = mirror(node.left);
            node.right = mirror(node.right);

            tree tmp = node.left;
            node.left = node.right;
            node.right = tmp;

            return node;
        }
        static tree nodeEkle(tree node, int value)
        {
            tree tmp = new tree();
            tmp.value = value;

            if (node == null)
            {
                node = tmp;
                return node;
            }

            if (node.value < value)
            {
                if (node.right == null)
                    node.right = tmp;
                else
                    nodeEkle(node.right, value);
            }

            if (node.value > value)
            {
                if (node.left == null)
                    node.left = tmp;
                else
                    nodeEkle(node.left, value);
            }

            return node;
        }
        static void yazdir(tree node)
        {
            if (node == null) return;

            yazdir(node.left);
            yazdir(node.right);
            Console.WriteLine(node.value);
        }

        static int simetrikMi(tree node1, tree node2)
        {
            if (node1 == null && node2 == null) return 0; // sorun değil

            if (node1 == null || node2 == null) return 1; // simetrik değil demek, çünkü ikisinden biri null diğer null değildir ( ikisi null olasaydı yukarıdakine girerdi )

            if (node1.value != node2.value) return 1; // eğer eşit değilse demek simetrik değil çünkü her biri diğer tarafından aldık aynı konuları değil biri righttan başlattık diğeri leftten

            return simetrikMi(node1.left, node2.right) + simetrikMi(node1.right, node2.left);
        }
        static void Main(string[] args)
        {
            // Ağaç yapısını oluşturma
            tree root = new tree() { value = 9 };
            root.left = new tree() { value = 7 };
            root.right = new tree() { value = 7 };
            root.left.left = new tree() { value = 3 };
            root.left.right = new tree() { value = 2 };
            root.right.left = new tree() { value = 2 };
            root.right.right = new tree() { value = 3 };

            // simetrik metodu kullanımı
            if (simetrikMi(root, root) == 0)
                Console.WriteLine("simetriktir");
            else
                Console.WriteLine("simetrik değildir");

            Console.ReadKey();
        }
    }
}
