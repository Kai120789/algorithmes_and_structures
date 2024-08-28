using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР10._1
{
    class Program
    {
        public class BinNode<T>
        {
            public T Value; // Ключевое поле
            public BinNode<T> Left;
            public BinNode<T> Right;
            public BinNode(T value, BinNode<T> left = null, BinNode<T> right = null)
            { Value = value; Left = left; Right = right; }
        }
        public class BinTree<T> where T : IComparable<T>
        {
            public BinNode<T> Root; // корень дерева
            public BinTree() { }
            public BinTree(T root) { Add(root); }
            public BinTree(T[] items)
            {
                foreach (T item in items) Add(item);
            }
            public void Add(T value)
            {
                Root = Add(Root, value);
            }
            public BinNode<T> Add(BinNode<T> node, T value)
            {
                if (node == null) node = new BinNode<T>(value);
                else
                {
                    if (node.Value.CompareTo(value) > 0)
                        node.Left = Add(node.Left, value); // value <
                    else node.Right = Add(node.Right, value); // value >=
                }
                return node;
            }
            public void TraverseBreadthFirst() // Обход в ширину
            {
                var list = new List<BinNode<T>> { Root };
                TraverseBreadthFirst(list);
            }
            private void TraverseBreadthFirst(List<BinNode<T>> list)
            {
                if (list.Count == 0) return;
                var children = new List<BinNode<T>>();
                foreach (BinNode<T> node in list)
                {
                    if (node != null)
                    {
                        Console.Write(node.Value + " ");
                        children.Add(node.Left);
                        children.Add(node.Right);
                    }
                }
                Console.WriteLine();
                TraverseBreadthFirst(children);
            }
            public bool IsSymEqual(BinNode<T> left, BinNode<T> right)
            {
                int c1 = 0, c2 = 0;
                if (left.Left != null) c1++;
                if (left.Right != null) c1--;
                if (right.Left != null) c2--;
                if (right.Right != null) c2++;
                return c1 == c2;
            }
            public bool IsSym(BinNode<T> left, BinNode<T> right)
            {
                if (IsSymEqual(left, right))
                {
                    if (left.Left != null && left.Right != null) return IsSym(left.Left, right.Right) && IsSym(left.Right, right.Left);
                    if (left.Left != null) return IsSym(left.Left, right.Right);
                    if (left.Right != null) return IsSym(left.Right, right.Left);
                    return true;
                }
                return false;
            }
            public int GetHeight(BinNode<T> node, int l = 0)
            {
                if (node == null) return l;
                ++l;
                return Math.Max(GetHeight(node.Left, l), GetHeight(node.Right, l));
            }
            public bool IsFull(BinNode<T> node)
            {
                if ((node.Left == null && node.Right != null) || (node.Left != null && node.Right == null)) // 1 ребенок
                    return false;
                if (node.Left != null && node.Right != null) // 2 ребенка
                    return IsFull(node.Left) && IsFull(node.Right);
                return true; // нет детей, т.е. дошли до конца
            }
            public bool IsIdeal(BinNode<T> node)
            {
                if (IsFull(node))
                    return IsIdeal(node.Left, node.Right);
                return false;
            }
            private bool IsIdeal(BinNode<T> left, BinNode<T> right)
            {
                if (GetHeight(left) == GetHeight(right))
                {
                    if (left.Left == null) 
                        return true;
                    return IsIdeal(left.Left, left.Right) && IsIdeal(right.Left, right.Right);
                }
                return false;
            }
        }
        static void Main(string[] args)
        {
            var lst = new BinTree<int>();

            //1
            //lst.Add(29); lst.Add(65); lst.Add(25); lst.Add(30); lst.Add(60); lst.Add(81); lst.Add(27); lst.Add(20); lst.Add(82); lst.Add(26); lst.Add(19); //lst.Add(28); //lst.Add(29);
            //Console.WriteLine(lst.IsSym(lst.Root.Left, lst.Root.Right));
            //Console.ReadKey();

            //3
            //lst.Add(10); lst.Add(8); lst.Add(17); lst.Add(7); lst.Add(9); lst.Add(23); lst.Add(25); lst.Add(20); lst.Add(24); lst.Add(26);// lst.Add(123);
            //Console.WriteLine(lst.GetHeight(lst.Root));
            //Console.ReadKey();

            //4
            //lst.Add(20); lst.Add(12); lst.Add(7); lst.Add(15); lst.Add(40); lst.Add(30); lst.Add(48); lst.Add(49); lst.Add(42); lst.Add(41);// lst.Add(43);
            //Console.WriteLine(lst.IsFull(lst.Root));
            //Console.ReadKey();

            //5
            //lst.Add(30); lst.Add(15); lst.Add(45); lst.Add(10); lst.Add(20); lst.Add(38); lst.Add(60); lst.Add(9); lst.Add(11); lst.Add(19); lst.Add(21); lst.Add(37); lst.Add(39);
            //lst.Add(59); lst.Add(61);
            //Console.WriteLine(lst.IsIdeal(lst.Root));
            //lst.TraverseBreadthFirst();
            //Console.ReadKey();
        }
    }
}
