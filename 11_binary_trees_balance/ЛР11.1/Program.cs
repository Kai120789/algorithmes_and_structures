using System.Xml.Linq;

namespace Test
{
    internal class Program
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
            private BinNode<T> Add(BinNode<T> node, T value)
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
                if (left == null || right == null) return false;
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
                if ((node.Left == null && node.Right != null) || (node.Left != null && node.Right == null))
                    return false;
                if (node.Left != null && node.Right != null)
                    return IsFull(node.Left) && IsFull(node.Right);
                return true;
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
            public bool IsAVLBalanced(BinNode<T> node)
            {
                if (node.Left == null && node.Right == null) return true;
                if (node.Left == null && node.Right != null) 
                {
                    if (Math.Abs(0 - GetHeight(node.Right)) > 1)
                        return false;
                    else return true;
                }
                if (node.Left != null && node.Right == null)
                {
                    if (Math.Abs(0 - GetHeight(node.Left)) > 1)
                        return false;
                    else return true;
                }
                if (Math.Abs(GetHeight(node.Left) - GetHeight(node.Right)) > 1)
                    return false;
                else return IsAVLBalanced(node.Left) && IsAVLBalanced(node.Right);
            }
            public int FindMin(BinNode<T> node, int l = 0)
            {
                if (node == null) return l;
                ++l;
                return Math.Min(GetHeight(node.Left, l), GetHeight(node.Right, l));
            }
            public bool IsBalanced(BinTree<T> tree)
            {
                return Math.Abs(GetHeight(tree.Root) - FindMin(tree.Root)) <= 1;
            }
            public bool IsRBBalanced(BinNode<T> node)
            {
                if (node.Left == null && node.Right == null) return true;
                if ((node.Left == null && node.Right != null) || (node.Left != null && node.Right == null))
                {
                    if ((FindMin(node) * 2) < GetHeight(node))
                        return false;
                    else return true;
                }
                if ((FindMin(node) * 2) < GetHeight(node))
                    return false;
                else return IsRBBalanced(node.Left) && IsRBBalanced(node.Right);
            }
        }
        static void Main(string[] args)
        {
            BinTree<int> tree = new BinTree<int>();
            tree.Add(40); tree.Add(25); tree.Add(20); tree.Add(30); tree.Add(50); tree.Add(18);// tree.Add(19);
            Console.WriteLine(tree.IsRBBalanced(tree.Root));
        }
    }
}