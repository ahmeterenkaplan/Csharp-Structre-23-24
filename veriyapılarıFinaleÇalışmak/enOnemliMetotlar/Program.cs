using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enOnemliMetotlar
{
    internal class Program
    {
        // ------------------ DİZİ METOTLARI ------------------ 

        static int[] bt = new int[100];

        // bir seviyenin en büyük elemanını döndürür
        static int seviyeninEnBuyugu(int[] bt, int seviye, int indis = 0) 
        {
            if (indis >= bt.Length) return 0;

            if (seviye <= 0) return bt[indis];

            int a = seviyeninEnBuyugu(bt, seviye - 1, indis * 2 + 1);
            int b = seviyeninEnBuyugu(bt, seviye - 1, indis * 2 + 2);

            return a > b ? a : b;
        }
        // bir ağacın uzunluğunu döndürür
        static int heightOfNode(int indis = 0)
        {
            if (indis >= bt.Length || bt[indis] == 0) return -1; // çünkü ağacın ilk düğümü 0 saydık

            int sol = 1 + heightOfNode(indis * 2 + 1);
            int sağ = 1 + heightOfNode(indis * 2 + 2);

            return sağ > sol ? sağ : sol;
        }
        // iki ağacın aynı olup olmadığını kontrol eder
        static int isIdentical(int[] bt1, int[] bt2, int indis = 0)
        {
            if (bt1.Length != bt2.Length) return 1;
            if (bt1[indis] == 0 && bt2[indis] == 0) return 0; // ağacın yapısı doğru olduğunu varsayarak yani bir kesinti olmadığını varsayarak yazdım yani mesela 0 olan bir node 10 valuelu bir çocuğu olmaz, olursa bu kontrolü yazmayacağız
            if (indis >= bt1.Length || indis >= bt2.Length) return 0;

            if (bt1[indis] != bt2[indis]) return 1;

            return isIdentical(bt1, bt2, indis * 2 + 1) + isIdentical(bt1, bt2, indis * 2 + 2); // eğer aynı 0, değilse 1 döndürür
        }

        // ------------------ GRAPH METOTLARI ------------------


        class tree
        {
            public int value;
            public tree right;
            public tree left;
        }

        // bir node silmek için 
        static tree nodeSil(tree root, int value) // yöntem 2 (right*1 + left*∞)
        {
            if (root == null) return null;

            else if (root.value < value) // aranan value daha büyük
            {
                root.right = nodeSil(root.right, value);
            }
            else if (root.value > value) // aranan value daha küçük
            {
                root.left = nodeSil(root.left, value);
            }
            else // aranan value eşit, node u bulduk yani
            {
                if (root.left == null)
                {
                    return root.right;
                }
                else if (root.right == null)
                {
                    return root.left;
                }
                else
                {
                    tree tmp = root.right;
                    while (tmp.left != null)
                    {
                        tmp = tmp.left;
                    }

                    root.value = tmp.value;
                    root.right = nodeSil(root.right, tmp.value);
                }
            }

            return root;
        }

        // bir ağacın aynıya bakar gibi tersini almak
        static tree mirror(tree node) // çok sevdim 
        {
            if (node == null) return null;

            node.left = mirror(node.left);
            node.right = mirror(node.right);

            tree tmp = node.left;
            node.left = node.right;
            node.right = tmp;

            return node;
        }

        // bir ağacın simetrik olup olmadığını kontrol ediyor ( binary ağaç değildir )
        static int simetrikMi(tree node1, tree node2)
        {
            if (node1 == null && node1 == null) return 0; // sorun değil

            if (node1 == null || node2 == null) return 1; // simetrik değil demek çünkü ikisinden biri null diğer null değildir ( ikisi null olasaydı yukarıdakine girerdi )

            if (node1.value != node2.value) return 1; // eğer eşit değilse demek simetrik değil çünkü her biri diğer tarafından aldık aynı konuları değil biri righttan başlattık diğeri leftten

            return simetrikMi(node1.left, node2.right) + simetrikMi(node1.right, node2.left);
        }

        // bir ağaç dengeli olup olmadığını kontrol eder
        static int heightOfTree(tree node) // bu bir ağacın uzunluğunu getirir ( aşağıdaki metot için yazdım )
        {
            if (node == null) return 0;

            int sol = heightOfTree(node.left) + 1;
            int sağ = heightOfTree(node.right) + 1;

            return sağ > sol ? sağ : sol;
        }

        static int isBalanced(tree node)
        {
            if (node == null) return 1;

            int lh = heightOfTree(node.left);
            int rh = heightOfTree(node.right);

            int r = lh - rh;
            r = r < 0 ? -r : r;

            int a = isBalanced(node.left);
            int b = isBalanced(node.right);

            if (r <= 1 && a == 1 && b == 1)
                return 1;

            return 0;
        }

        // en derindeki nodeun valuesunu yazdırır

        static int val = 0; // private olur
        static int derinlik = 0; // private olur
        static int diameter(tree node, int der = 0) // private olur
        {
            if (node == null) return -1;

            int sol = diameter(node.left, der + 1) + 1;
            if (der > derinlik)
            {
                derinlik = der;
                val = node.value;
            }
            int sağ = diameter(node.right, der + 1) + 1;
            if (der > derinlik)
            {
                derinlik = der;
                val = node.value;
            }
            return sağ > sol ? sağ : sol;
        }
        static int enDerinNode(tree node) // bu public olur
        {
            diameter(node);
            return val;
        }

        // bir node un iki çocuğunun toplamı onun valuesu kadar mı
        static int ÇK(tree node) 
        {
            if (node == null) return 0;

            if (node.left == null && node.right == null) return 0;

            if (node.left == null && node.right.value != node.value) return 1;

            if (node.right == null && node.left.value != node.value) return 1;
            if (node.left != null && node.right != null)
                if (node.left.value + node.right.value != node.value) return 1;

            return ÇK(node.left) + ÇK(node.right);
        }

        // elemanları rastgele bir dizi dengeli bir binary tree yaptırmak
        static tree toBinary(int[] bt, int start, int end) 
        {

            if (start > end)
                return null;

            int mid = (start + end) / 2;

            tree node = new tree();
            node.value = bt[mid];

            node.left = toBinary(bt, start, mid - 1);
            node.right = toBinary(bt, mid + 1, end);

            return node;
        }

        static tree sortedArrayToBinary(int[] bt)
        {
            int n = bt.Length - 1;

            bubbleRecursive(bt);

            return toBinary(bt, 0, n);
        }

   
        static void bubbleRecursive(int[] x, int a = 0, int b = 0) // bubble sortun recursive hali
        {
            if (b >= x.Length - 1 - a)
            {
                b = 0;
                a++;
            }

            if (a >= x.Length - 1) return;


            if (x[b] > x[b + 1])
            {
                x[b] += x[b + 1];
                x[b + 1] = x[b] - x[b + 1];
                x[b] -= x[b + 1];
            }

            bubbleRecursive(x, a, ++b);
        }

        // noraml bir dizi eklemek
        static tree diziEkle(tree node, int[] bt, int indis = 0, tree tr = null)
        {
            if (indis >= bt.Length) return tr;

            if (tr == null) tr = node;

            tree tmp = new tree();
            tmp.value = bt[indis];

            if (node == null) node = tmp;

            if (node.value < bt[indis])
            {
                if (node.right == null)
                {
                    node.right = tmp;
                }
                else
                    diziEkle(node.right, bt, indis, tr);
            }

            if (node.value > bt[indis])
            {
                if (node.left == null)
                {
                    node.left = tmp;
                }
                else
                    diziEkle(node.left, bt, indis, tr);
            }

            if (tr == null)
                return diziEkle(node, bt, indis + 1, tr);
            else
                return diziEkle(tr, bt, indis + 1, tr);
        }

        // bir seviyenin en büyük elemanını döndürür
        static int seviyeninEnBuyugu(tree node, int seviye)
        {
            if (node == null) return 0;

            if (seviye <= 0) return node.value;

            int a = seviyeninEnBuyugu(node.left, seviye - 1);
            int b = seviyeninEnBuyugu(node.right, seviye - 1);

            return a > b ? a : b;
        }

        // bir ağacın en büyük k. eleman
        static int kt = 0;
        static void KthMax(tree node, ref int max) // in order olarak 
        {
            if (node == null) return;


            KthMax(node.right, ref max);

            if (--kt == 0)
                max = node.value;

            KthMax(node.left, ref max);

        }
        static int getKthMax(tree node, int kth)
        {
            kt = kth;
            int max = 0;
            KthMax(node, ref max);
            return max;
        }
        // bir ağacın en büyük k. elemanı 2. yöntem
        static int getEnBuyuk(tree node, int k) // diziler referans olduğu için ref yazmama gerek yoktur
        {
            int[] bt = new int[k];
            getTmp(node, bt);
            return bt[k - 1];
        }

        static void getTmp(tree node, int[] bt)
        {
            if (node == null) return;

            getTmp(node.left, bt);
            getTmp(node.right, bt);

            for (int i = 0; i < bt.Length; i++)
            {
                if (node.value > bt[i])
                {
                    for (int j = bt.Length - 1; j > i; j--)
                    {
                        bt[j] = bt[j - 1];
                    }
                    bt[i] = node.value;
                    break;
                }
            }
        }
        // bir ağacın en büyük k. elemanı döndürür ( recursive olmayan hali )
        static int getKaçıncıMax(tree node, int kaçıncı)
        {
            if (node == null) return 0;

            int[] maxes = new int[kaçıncı];
            for (int i = 0; i < maxes.Length; i++)
            {
                maxes[i] = int.MinValue; // ince ayar olarak
            }

            Stack<tree> st = new Stack<tree>();
            st.Push(node);
            tree tmp;

            while (st.Count > 0)
            {
                tmp = st.Pop();
                for (int i = 0; i < maxes.Length; i++)
                {
                    if (maxes[i] < tmp.value)
                    {
                        for (int j = maxes.Length - 1; j > i; j--)
                        {
                            maxes[j] = maxes[j - 1];
                        }
                        maxes[i] = tmp.value;
                        break;
                    }
                }
                if (tmp.left != null)
                    st.Push(tmp.left);
                if (tmp.right != null)
                    st.Push(tmp.right);
            }

            return maxes[kaçıncı - 1];
        }

        // bir ağacın diğer ağacın alt ağacı mıdır
        static int altKümesiMi(tree node, tree alt)
        {
            if (node == null) return 0;

            if (node.value > alt.value)
                return altKümesiMi(node.left, alt);
            else if (node.value < alt.value)
                return altKümesiMi(node.right, alt);
            else
                return aynıMı(node, alt);
        }
        static int aynıMı(tree node1, tree node2)
        {
            if (node1 == null && node2 == null) return 0;

            if (node1 == null) return 1;
            if (node2 == null) return 1;

            if (node1.value != node2.value) return 1;

            return aynıMı(node1.left, node2.left) + aynıMı(node1.right, node2.right);
        }

        // bir ağacın elemanlarını toplamı
        static int elemanlarınToplamı(tree node)
        {
            if (node == null) return 0;
            return node.value + elemanlarınToplamı(node.left) + elemanlarınToplamı(node.right);
        }

        // bir seviyenin elemanılarını toplamı
        static int seviyeToplamı(tree node, int seviye)
        {
            if (node == null) return 0;
            if (--seviye <= 0) return node.value;
            return seviyeToplamı(node.left, seviye) + seviyeToplamı(node.right, seviye);
        }

        // bir ağacın içindeki node ların sayısını döndürür
        static int elemanSayısı(tree node)
        {
            if (node == null) return 0;
            return 1 + elemanSayısı(node.left) + elemanSayısı(node.right);
        }

        // n. seviyenin en büyük k. elemanı (: ( recursive )
        static int getirBirMutluluk(tree node, int seviye, int eleman) // seviye: kaçıncı seviye, eleman: kaçınca eleman diye bunu <summer> <param> açıkllama olarak yazarım (:
        {
            int[] bt = new int[eleman];

            getirTmp(node, bt, seviye);

            return bt[eleman - 1];
        }

        static void getirTmp(tree node, int[] bt, int seviye) // gizli olacak (private)
        {
            if (node == null) return;
            getirTmp(node.left, bt, seviye - 1);
            getirTmp(node.right, bt, seviye - 1);
            if (seviye == 0)
            {
                for (int i = 0; i < bt.Length; i++)
                {
                    if (node.value > bt[i])
                    {
                        for (int j = bt.Length - 1; j > i; j--)
                        {
                            bt[j] = bt[j - 1];
                        }
                        bt[i] = node.value;
                        break;
                    }
                }
            }
        }

        // n. seviyenin k. en büyük elemanını döndürür ( recursive olmayan hali )
        static int seviyeninEnBuyugu(tree node, int seviye, int eleman)
        {
            seviye++;

            if (node == null || seviye <= 0 || eleman <= 0)
                return -1;

            Queue<tree> queue = new Queue<tree>();
            queue.Enqueue(node);

            while (queue.Count > 0 && seviye > 0)
            {
                int levelSize = queue.Count; // forun içinde count değişieceği için şimdiden tutmam gerekti

                int[] maxes = new int[Math.Min(levelSize, eleman)];



                for (int i = 0; i < levelSize; i++)
                {
                    tree current = queue.Dequeue();

                    for (int j = 0; j < maxes.Length; j++)
                    {
                        if (current.value > maxes[j])
                        {
                            for (int k = maxes.Length - 1; k > j; k--)
                            {
                                maxes[k] = maxes[k - 1];
                            }
                            maxes[j] = current.value;
                            break;
                        }
                    }

                    if (current.left != null)
                        queue.Enqueue(current.left);
                    if (current.right != null)
                        queue.Enqueue(current.right);
                }

                seviye--;
                if (seviye == 0)
                    return maxes[maxes.Length - 1];
            }

            return -1;
        }

        // n valuelu olan nodeun leveli kaçtır

        static int heightOfValue(tree node, int value)
        {
            if (node == null) return 0;

            int a = 0;

            if (node.value > value)
                a = heightOfValue(node.left, value) + 1;
            else if (node.value < value)
                a = heightOfValue(node.right, value) + 1;
            else
                return 0;

            return a;
        }

        // her seviyenin en büyük elemanını döndürür
        static void herSevniyeninEnBuyugu(tree node)
        {
            if (node == null) return;

            Queue<tree> queue = new Queue<tree>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                tree current = null;
                for (int i = 0; i < levelSize; i++)
                {
                    current = queue.Dequeue();

                    if (current.left != null)
                        queue.Enqueue(current.left);
                    if (current.right != null)
                        queue.Enqueue(current.right);
                }

                Console.Write(current.value + ", ");
            }
        }

        // bir tree den diziye aktarmak ( çok önemliii )
        static int[] BSTtoDizi(tree node, int[] bt = null, int indis = 0)
        {
            if (node == null) return null;

            if (bt == null)
            {
                int height = heightOfTree(node);
                int length = 0;
                int tmp = 1;
                for (int i = 0; i < height; i++)
                {
                    length += tmp;
                    tmp *= 2;
                }
                bt = new int[length];
                bt[0] = node.value;
            }

            if (indis >= bt.Length) return null;

            BSTtoDizi(node.left, bt, indis * 2 + 1);
            BSTtoDizi(node.right, bt, indis * 2 + 2);

            bt[indis] = node.value;
            return bt;
        }

        static void Main(string[] args)
        {
        }
    }
}
