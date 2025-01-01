using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hafta3Masa
{
    internal class Program
    {

        class tree
        {
            public tree right;
            public int value;
            public tree left;
        }

        static tree nodeEkle(tree root, int value)
        {
            tree tmp = new tree();
            tmp.value = value;

            if (root == null)
            {
                root = tmp;
                return root;
            }

            if (root.value < value)
            {
                if (root.right != null)
                    nodeEkle(root.right, value);
                else
                    root.right = tmp;
            }

            if (root.value > value)
            {
                if (root.left != null)
                    nodeEkle(root.left, value);
                else
                    root.left = tmp;
            }

            return root;
        }

        static void treeYazdir(tree root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.value);

            treeYazdir(root.left);
            treeYazdir(root.right);

        }

        static int isBST(tree root) // onda gönderilen yapının içindeki valuelar binary tree yapısına göre sorted mi yoksa rastgele mi atanmış
        {
            if (root == null)
                return 0;

            if (root.left != null && root.left.value > root.value)
                return 1;

            if (root.right != null && root.right.value < root.value)
                return 1;

            int data = isBST(root.left) + isBST(root.right);
            return data == 0 ? 0 : 1;
        }


        static tree nodeSearch(tree root, int value) // bir node arıyor bulduğunda onu döndürüyor fakat bulmadıysa -1 valuesu olan bir node döndürür
        {
            if (root == null) return new tree() { value = -1 };

            if (root.value < value)
                return nodeSearch(root.right, value);
            else if (root.value > value)
                return nodeSearch(root.left, value);
            else
                return root;
        }

        static tree nodeSil(tree root, int value) // doğru düzgün çalışmıyor
        {

            if (root == null) return new tree() { value = -1 };

            tree temp = null;
            if (root.right != null && root.right.value == value)
                temp = root.right;
            else if (root.left != null && root.left.value == value)
                temp = root.left;
            if (temp != null)
            {
                if (temp.right == null && temp.left == null) // hiç çocuğu yok
                {
                    if (root.left != null && root.left.value == temp.value)
                        root.left = null;
                    if (root.right != null && root.right.value == temp.value)
                        root.right = null;
                    return root;
                }

                if (temp.right == null) // sadece solda çocukları var
                {
                    temp = temp.left;
                    return root;
                }

                if (temp.left == null) // sadece sağda çocukları var
                {
                    root.right = temp.right;
                    return root;
                }
                tree tmp = temp.right;

                if (tmp.left == null)
                {
                    root.right.value = tmp.value;
                    if (tmp.right != null) root.right.right = tmp.right;
                    return root;
                }
                while (tmp.left.left != null)
                {
                    tmp = tmp.left;
                }

                root.right.value = tmp.left.value;
                tmp.left = null;
                return root;
            }

            if (root.value < value)
                nodeSil(root.right, value);
            else if (root.value > value)
                nodeSil(root.left, value);

            return root;
        }




        //static tree treeFix(tree root, int op = 0)
        //{
        //    if (root == null)
        //        return root;
        //    if (op == 0)
        //    {
        //        if (root.left != null && root.left.value > root.value)
        //            return treeFix(root.left, 1);

        //        if (root.right != null && root.right.value < root.value)
        //            return treeFix(root.right, 1);

        //        isBST(root.left);
        //        isBST(root.right);
        //    }
        //    else
        //    {

        //    }

        //}

        static void Main(string[] args)
        {
            tree root = null;

            root = nodeEkle(root, 5);
            root = nodeEkle(root, 2);
            root = nodeEkle(root, 8);
            root = nodeEkle(root, 1);
            root = nodeEkle(root, 3);
            root = nodeEkle(root, 9);
            root = nodeEkle(root, 4);
            root = nodeEkle(root, 10);
            root = nodeEkle(root, 12);
            root = nodeEkle(root, 11);
            root = nodeEkle(root, 7);
            root = nodeEkle(root, 6);
            Console.WriteLine("treeYazdir()");
            treeYazdir(root);
            Console.WriteLine("------------\n");

            Console.WriteLine("isBST()");
            Console.WriteLine(isBST(root) == 0 ? "Binary Tree" : "Bianry Tree Değildir");
            Console.WriteLine("------------\n");

            Console.WriteLine("nodeSearch()");
            tree dokuz = nodeSearch(root, 9);
            Console.WriteLine(dokuz.value);
            Console.WriteLine("------------\n");

            Console.WriteLine("nodeSil()");
            root = nodeSil(root, 12);
            treeYazdir(root);

            Console.ReadKey();
        }
    }
}
