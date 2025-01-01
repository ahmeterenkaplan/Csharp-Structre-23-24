using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace sorular
{
    internal class Program
    {
        // ------------------ DİZİ METOTLARI ------------------ 

        static int[] bt = new int[100];

        static void nodeEkle(int data, int indis = 0)
        {
            if (bt[indis] == 0)
            {
                bt[indis] = data;
                return;
            }

            if (bt[indis] > data)
                nodeEkle(data, indis * 2 + 1);
            else if (bt[indis] < data)
                nodeEkle(data, indis * 2 + 2);
        }

        static void nodeEkle(int[] bt, int data, int indis = 0)
        {
            if (bt[indis] == 0)
            {
                bt[indis] = data;
                return;
            }

            if (bt[indis] > data)
                nodeEkle(bt, data, indis * 2 + 1);
            else if (bt[indis] < data)
                nodeEkle(bt, data, indis * 2 + 2);
        }

        static int seviyeninEnBuyugu(int[] bt, int seviye, int indis = 0) // bir seviyenin en büyük elemanını döndürür
        {
            if (indis >= bt.Length) return 0;

            if (seviye <= 0) return bt[indis];

            int a = seviyeninEnBuyugu(bt, seviye - 1, indis * 2 + 1);
            int b = seviyeninEnBuyugu(bt, seviye - 1, indis * 2 + 2);

            return a > b ? a : b;
        }



        static void nodeSil(int value, int indis = 0) // bir data silmek için kullanılır ( yanlış )
        {
            if (indis >= bt.Length) return;

            if (bt[indis] == value)
            {
                if (indis * 2 + 1 >= bt.Length)
                {
                    bt[indis] = 0;
                }
                else
                {
                    int tmpIndex = (indis * 2 + 1) * 2 + 2;
                    while (tmpIndex < bt.Length && bt[tmpIndex] != 0)
                    {
                        tmpIndex = tmpIndex * 2 + 2;
                    }
                    tmpIndex = (tmpIndex - 2) / 2;
                    bt[indis] = bt[tmpIndex];
                    bt[tmpIndex] = 0;
                }
                return;
            }
            else if (bt[indis] < value)
                nodeSil(value, indis * 2 + 2);
            else if (bt[indis] > value)
                nodeSil(value, indis * 2 + 1);
            return;
        }

        static void treeYazdir(int indis = 0)
        {
            if (indis >= bt.Length) return;
            if (bt[indis] != 0) // çünkü sıfır olan node ler yok hukmunda
                Console.WriteLine(bt[indis]);

            treeYazdir(indis * 2 + 1);
            treeYazdir(indis * 2 + 2);
        }

        static int getMaxVlaue(int indis = 0)
        {
            if (indis >= bt.Length) return 0;

            if (indis * 2 + 2 >= bt.Length || bt[indis * 2 + 2] == 0) return bt[indis];
            return getMaxVlaue(indis * 2 + 2);
        }

        static int getMinVlaue(int indis = 0)
        {
            if (indis >= bt.Length) return 0;

            if (indis * 2 + 1 >= bt.Length || bt[indis * 2 + 1] == 0) return bt[indis];
            return getMinVlaue(indis * 2 + 1);
        }

        static int getSumNodes(int indis = 0)
        {
            if (indis >= bt.Length || bt[indis] == 0) return 0;

            return bt[indis] + getSumNodes(indis * 2 + 1) + getSumNodes(indis * 2 + 2);
        }

        static int heightOfNode(int indis = 0)
        {

            int sol = 1 + heightOfNode(indis * 2 + 1);
            int sağ = 1 + heightOfNode(indis * 2 + 2);

            return sağ > sol ? sağ : sol;
        }

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

        static void yazdir(tree node) // biz genelde pre order olarak yazdırıyoruz
        {
            if (node == null) return;

            Console.WriteLine(node.value);
            yazdir(node.left);
            yazdir(node.right);
        }

        //static void yazdir(tree node) // in order olarak yazdırıyoruz
        //{
        //    if (node == null) return;

        //    yazdir(node.left);
        //    Console.WriteLine(node.value);
        //    yazdir(node.right);
        //}

        //static void yazdir(tree node) // post order olarak yazdırıyoruz ( aşağıdan yukarıya doğru yazıyor )
        //{
        //    if (node == null) return;

        //    yazdir(node.left);
        //    yazdir(node.right);
        //    Console.WriteLine(node.value);
        //}

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


        static int simetrikMi(tree node1, tree node2)
        {
            if (node1 == null && node2 == null) return 0; // sorun değil

            if (node1 == null || node2 == null) return 1; // simetrik değil demek, çünkü ikisinden biri null diğer null değildir ( ikisi null olasaydı yukarıdakine girerdi )

            if (node1.value != node2.value) return 1; // eğer eşit değilse demek simetrik değil çünkü her biri diğer tarafından aldık aynı konuları değil biri righttan başlattık diğeri leftten

            return simetrikMi(node1.left, node2.right) + simetrikMi(node1.right, node2.left);
        }

        static int heightOfTree(tree node)
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


        static int val = 0;
        static int derinlik = 0;
        static int diameter(tree node, int der = 0)
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

        static int enDerinNode(tree node)
        {
            diameter(node);
            return val;
        }

        static int ÇK(tree node) // bir node un iki çocuğunun toplamı onun valuesu kadar mı
        {
            if (node == null) return 0;

            if (node.left == null && node.right == null) return 0;

            if (node.left == null && node.right.value != node.value) return 1;

            if (node.right == null && node.left.value != node.value) return 1;
            if (node.left != null && node.right != null)
                if (node.left.value + node.right.value != node.value) return 1;

            return ÇK(node.left) + ÇK(node.right);
        }

        static tree arrayToBST(tree node, int[] bt, tree last = null, int indis = 0)
        {
            if (indis >= bt.Length) return node;

            tree tmp = new tree();
            tmp.value = bt[indis];

            if (node == null) node = tmp;
            else if (last.value > tmp.value) last.left = tmp;
            else if (last.value < tmp.value) last.right = tmp;
            else if (last.value == tmp.value) { } // bunu yazmamıza gerek yok çünkü BST nin elemanları benzersiz olması gerek bu yüzden tekrar eklemiyorum aynı elemanı
            last = tmp;
            return arrayToBST(node, bt, last, indis + 1);
        }

        static int aynıMı(tree node1, tree node2)
        {
            if (node1 == null && node2 == null) return 0;

            if (node1 == null) return 1;
            if (node2 == null) return 1;

            if (node1.value != node2.value) return 1;

            return aynıMı(node1.left, node2.left) + aynıMı(node1.right, node2.right);

        }

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

        static tree fix(tree node)
        {
            if (node == null) return null;

            node.left = fix(node.left);
            node.right = fix(node.right);

            int lh = heightOfTree(node.left);
            int rh = heightOfTree(node.right);

            int bf = lh - rh;

            if (bf > 1)
            {
                tree left = node.left;
                tree right2 = left.right;
                left.right = right2.left;

                right2.left = left;
                right2.right = node;
                node = right2;


            }

            return node;

        }


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


        static void bubbleRecursive(int[] x, int a = 0, int b = 0)
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


        static int seviyeninEnBuyugu(tree node, int seviye)
        {
            if (node == null) return 0;

            if (seviye <= 0) return node.value;

            int a = seviyeninEnBuyugu(node.left, seviye - 1);
            int b = seviyeninEnBuyugu(node.right, seviye - 1);

            return a > b ? a : b;
        }


        static int herSeviyeninEnBuyugu(tree node, int seviye = 0, int level = 0) // bu metot çalışmıyor
        {
            if (node == null) return int.MinValue;

            if (seviye == level)
            {
                seviye = -1;
                level++;
                return node.value;
            }

            int a = herSeviyeninEnBuyugu(node.left, seviye + 1, level);
            int b = herSeviyeninEnBuyugu(node.right, seviye + 1, level);

            int c = a > b ? a : b;
            Console.WriteLine(c);
            return c;
        }

        static void helper(List<int> res, tree root, int d)
        {
            if (root == null)
                return;

            if (d == res.Count)
                res.Add(root.value);

            else
                res[d] = Math.Max(res[d], root.value);

            helper(res, root.left, d + 1);
            helper(res, root.right, d + 1);
        }

        // function to find largest values 
        static List<int> largestValues(tree root)
        {
            List<int> res = new List<int>();
            helper(res, root, 0);
            return res;
        }

        static tree KthLargestUsingMorrisTraversal(tree curr, int k)
        {
            tree Klargest = null;

            int count = 0;

            while (curr != null)
            {
                if (curr.right == null)
                {
                    if (++count == k)
                        Klargest = curr;

                    curr = curr.left;
                }
                else
                {
                    tree succ = curr.right;

                    while (succ.left != null && succ.left != curr)
                        succ = succ.left;

                    if (succ.left == null)
                    {
                        succ.left = curr;
                        curr = curr.right;
                    }
                    else
                    {
                        succ.left = null;
                        if (++count == k)
                            Klargest = curr;


                        curr = curr.left;
                    }
                }
            }
            return Klargest;
        }
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

        static int elemanlarınToplamı(tree node)
        {
            if (node == null) return 0;
            return node.value + elemanlarınToplamı(node.left) + elemanlarınToplamı(node.right);
        }

        static int seviyeToplamı(tree node, int seviye)
        {
            if (node == null) return 0;
            if (--seviye <= 0) return node.value;
            return seviyeToplamı(node.left, seviye) + seviyeToplamı(node.right, seviye);
        }

        static int elemanSayısı(tree node)
        {
            if (node == null) return 0;
            return 1 + elemanSayısı(node.left) + elemanSayısı(node.right);
        }

        static int getEnBuyuk(tree node, int k) // diziler referans olduğu için ref yazmama gerek yoktur
        {
            int[] bt = new int[k];
            for (int i = 0; i < bt.Length; i++)
            {
                bt[i] = int.MinValue;
            }
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
        // n. seviyenin en büyük k. elemanı (:
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

        static void ornek2(tree bt) // tüm elemanları ekrana yazdırıyor 
        {
            Stack<tree> st = new Stack<tree>();

            st.Push(bt);
            while (st.Count > 0)
            {
                tree indis = st.Pop();
                Console.WriteLine(indis.value);

                if (indis.left != null)
                    st.Push(indis.left);

                if (indis.right != null)
                    st.Push(indis.right);
            }
        }

        static int normalHeight(tree root)
        {
            if (root == null)
                return 0;

            int height = 0;
            Queue<tree> queue = new Queue<tree>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    tree current = queue.Dequeue();

                    if (current.left != null)
                        queue.Enqueue(current.left);

                    if (current.right != null)
                        queue.Enqueue(current.right);
                }

                height++;
            }

            return height;
        }


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



        static int binarySearch(tree node, int value)
        {
            if (node == null) return 0;
            Stack<tree> st = new Stack<tree>();
            st.Push(node);
            while (st.Count() > 0)
            {
                tree tmp = st.Pop();
                if (tmp.value > value && tmp.left != null)
                    st.Push(tmp.left);
                else if (tmp.value < value && tmp.right != null)
                    st.Push(tmp.right);
                else if (tmp.value == value)
                    return 1;
                else
                    return 0; // eğer bulamadan null olursa
            }
            return 0;
        }

        static int BinarySearch(tree node, int value)
        {
            if (node == null) return 0;
            while (node != null)
            {
                if (node != null && node.value > value)
                    node = node.left;
                if (node != null && node.value < value)
                    node = node.right;
                if (node != null && node.value == value)
                    return 1;
            }
            return 0;
        }

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

        static void leafYazdır(tree node)
        {
            if (node == null) return;

            if (node.left == null && node.right == null) Console.WriteLine(node.value);

            leafYazdır(node.left);
            leafYazdır(node.right);
        }


        static int leafToplamı(tree node)
        {
            if (node == null) return 0;

            if (node.left == null && node.right == null) return node.value;

            return leafToplamı(node.left) + leafToplamı(node.right);
        }

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

        static void yazdir(int[] bt, int indis = 0)
        {
            if (indis >= bt.Length) return;
            if (bt[indis] != 0) // çünkü sıfır olan node ler yok hukmunda
                Console.WriteLine(bt[indis]);

            yazdir(bt,indis * 2 + 1);
            yazdir(bt, indis * 2 + 2);
        }

        static void Main(string[] args)
        {
            tree node = null;

            node = nodeEkle(node, 9);
            node = nodeEkle(node, 7);
            node = nodeEkle(node, 6);
            node = nodeEkle(node, 8);
            node = nodeEkle(node, 3);
            node = nodeEkle(node, 4);
            node = nodeEkle(node, 5);
            node = nodeEkle(node, 2);
            node = nodeEkle(node, 12);
            node = nodeEkle(node, 11);
            node = nodeEkle(node, 14);
            node = nodeEkle(node, 10);
            node = nodeEkle(node, 13);
            node = nodeEkle(node, 15);

            tree mir = mirror(node);

            node = null;

            node = nodeEkle(node, 9);
            node = nodeEkle(node, 7);
            node = nodeEkle(node, 6);
            node = nodeEkle(node, 8);
            node = nodeEkle(node, 3);
            node = nodeEkle(node, 12);
            node = nodeEkle(node, 11);
            node = nodeEkle(node, 14);
            node = nodeEkle(node, 10);
            node = nodeEkle(node, 13);
            node = nodeEkle(node, 15);


            tree yeni1 = new tree();
            yeni1.value = 10;

            tree yeni2 = new tree();
            yeni2.value = 8;

            tree yeni3 = new tree();
            yeni3.value = 2;

            tree yeni4 = new tree();
            yeni4.value = 3;

            tree yeni5 = new tree();
            yeni5.value = 5;

            tree yeni6 = new tree();
            yeni6.value = 2;


            yeni1.left = yeni2;
            yeni1.right = yeni3;

            yeni2.left = yeni5;
            yeni2.right = yeni4;

            yeni3.left = yeni6;



            //yazdir(mir);

            Console.WriteLine(simetrikMi(node, mir) > 0 ? "simetrik değildir" : "simetriktir");

            Console.WriteLine("düğüm uzunluğu : " + heightOfTree(node));
            diameter(node);
            Console.WriteLine("en son düğüm: " + val);
            Console.WriteLine(ÇK(yeni1) == 0 ? "Çocukların toplamıdır" : "değildir");

            int[] bt =
            {

                9,
                7,
                6,
                8,
                3,
                4,
                5,
                2,
                12,
                11,
                14,
                10,
                13
            };

            tree node1 = null;
            tree node2 = null;

            node2 = nodeEkle(node2, 9);
            node2 = nodeEkle(node2, 7);
            node2 = nodeEkle(node2, 6);
            node2 = nodeEkle(node2, 8);
            node2 = nodeEkle(node2, 3);
            node2 = nodeEkle(node2, 4);
            node2 = nodeEkle(node2, 5);
            node2 = nodeEkle(node2, 2);
            node2 = nodeEkle(node2, 12);
            node2 = nodeEkle(node2, 11);
            node2 = nodeEkle(node2, 14);
            node2 = nodeEkle(node2, 10);
            node2 = nodeEkle(node2, 13);
            node2 = nodeEkle(node2, 15);


            node1 = diziEkle(node1, bt);
            Console.WriteLine("Aynı olup olmadığını: " + (aynıMı(node1, node2) == 0 ? "aynı" : "değil"));

            //tree karar = null;
            //karar = nodeEkle(karar, 6);
            //karar = nodeEkle(karar, 3);
            //karar = nodeEkle(karar, 5);
            //karar = nodeEkle(karar, 2);
            //karar = nodeEkle(karar, 4);

            //karar = fix(karar); // yapamadım

            //yazdir(karar);



            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };



            tree nodeA = sortedArrayToBinary(sortedArray);

            Console.WriteLine(isBalanced(nodeA));

            Console.WriteLine("3. seviyenin en büyük nodeun valuesu: " + seviyeninEnBuyugu(node1, 3));

            List<int> l = largestValues(node1);

            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
            int k = 3;
            Console.WriteLine("en büyük {0}. eleman: {1}", k, KthLargestUsingMorrisTraversal(node1, k).value);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("en küçük {0}. eleman: {1}", k, getEnBuyuk(node1, k));

            tree alt = new tree();
            alt.value = 10;
            alt.left = new tree()
            {
                value = 3
            };
            alt.right = new tree() { value = 17 };

            Console.WriteLine(altKümesiMi(node1, alt) > 0 ? "değil" : "Alt küme");

            Console.WriteLine("Tüm elemanların toplamı: " + elemanlarınToplamı(alt));

            k = 3;
            Console.WriteLine("{0}. seviyenin toplamı: {1}", k, seviyeToplamı(node1, k));

            Console.WriteLine("Bu ağacın eleman sayısı: " + elemanSayısı(node1));

            int seviye = 3;
            int eleman = 2;

            Console.WriteLine("{0}. seviyenin {1}. elemanı: {2}", seviye, eleman, getirBirMutluluk(node1, seviye, eleman));
            Console.WriteLine("{0}. seviyenin {1}. elemanı: {2}", seviye, eleman, seviyeninEnBuyugu(node1, seviye, eleman));

            int value = 6;
            Console.WriteLine("{0}. valuelu olan nodeun seviyesi: {1}", value, heightOfValue(node1, value));

            //ornek2(node1);

            Console.WriteLine(BinarySearch(node1, 99));

            Console.WriteLine(getKaçıncıMax(node1, 3));


            Console.WriteLine(normalHeight(node1));
            Console.WriteLine(heightOfTree(node1));

            Console.Write("her seviyenin en büyük elemanını: ");
            herSevniyeninEnBuyugu(node1);
            Console.WriteLine();

            Console.WriteLine(isBalanced(node1) == 1 ? "Dengelidir" : "Dengesizdir");

            Console.WriteLine("En derin Node: " + enDerinNode(node1));

            leafYazdır(node1);

            Console.WriteLine("Leaf node ların toplamı : " + leafToplamı(node1));

            int[] x = BSTtoDizi(node1);
            Console.WriteLine("dizi elemanları: ");
            yazdir(x);
            // bir node dan başka bir node a gitmek için kaç tane yol harcanması gerek
            //yazdir(node1);
            //yazdir(nodeA);



            // ----------------------------------------------------------------
            //nodeEkle(9);
            //nodeEkle(7);
            //nodeEkle(6);
            //nodeEkle(8);
            //nodeEkle(3);
            //nodeEkle(4);
            //nodeEkle(5);
            //nodeEkle(2);
            //nodeEkle(12);
            //nodeEkle(11);
            //nodeEkle(14);
            //nodeEkle(10);
            //nodeEkle(13);
            //nodeEkle(15);


            //Console.WriteLine("dizinin en büyük elemanı : " + getMaxVlaue()); // en büyük elemanını döndürür
            //Console.WriteLine("dizinin en küçük elemanı : " + getMinVlaue()); // en küçük elemanını döndürür
            //Console.WriteLine("Tüm düğümlerin toplamı : " + getSumNodes());
            //Console.WriteLine("Ağacın Yüksekliği : " + heightOfNode());
            //int[] bt1 = new int[100];
            //int[] bt2 = new int[100];

            //nodeEkle(bt1, 9);
            //nodeEkle(bt1, 7);
            //nodeEkle(bt1, 6);
            //nodeEkle(bt1, 8);
            //nodeEkle(bt1, 3);
            //nodeEkle(bt1, 4);
            //nodeEkle(bt1, 5);
            //nodeEkle(bt1, 2);
            //nodeEkle(bt1, 12);
            //nodeEkle(bt1, 11);
            //nodeEkle(bt1, 14);
            //nodeEkle(bt1, 10);
            //nodeEkle(bt1, 13);
            //nodeEkle(bt1, 15);

            //nodeEkle(bt2, 9);
            //nodeEkle(bt2, 7);
            //nodeEkle(bt2, 6);
            //nodeEkle(bt2, 8);
            //nodeEkle(bt2, 3);
            //nodeEkle(bt2, 4);
            //nodeEkle(bt2, 5);
            //nodeEkle(bt2, 2);
            //nodeEkle(bt2, 12);
            //nodeEkle(bt2, 11);
            //nodeEkle(bt2, 14);
            //nodeEkle(bt2, 10);
            //nodeEkle(bt2, 13);
            //nodeEkle(bt2, 19);


            //Console.WriteLine("İki ağacın aynı olup olmadığını: " + isIdentical(bt1, bt2));

            //treeYazdir();

            Console.ReadKey();
        }
    }
}
