using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ЛР7._3
{
    class Program
    {
        class Node<T>
        {
            public T Value;
            public Node<T> Next;
        }
        class Stack<T>
        {
            public int Size { get; internal set; } 
            public Node<T> Head { get; set; } 
            public void Push(T value) 
            {
                Node<T> node = new Node<T>() { Value = value, Next = Head };
                Head = node; 
                Size++; 
            }
            public T Pop() 
            {
                if (Head != null)
                {
                    Node<T> Temp = Head; 
                    Head = Head.Next; 
                    Size--; 
                    return Temp.Value; 
                }
                else
                {
                    throw new System.Exception("Попытка вытолкнуть из пустого стека"); }
                }
            public void PrintNodes(string Title)
            {
                Node<T> Temp = Head;
                Console.Write(Title + " ");
                while (Temp != null)
                {
                    Console.Write(" " + Temp.Value);
                    Temp = Temp.Next;
                }
                Console.WriteLine();
            }
        }
        static bool Func(string n)
        {
            var dict = new Dictionary<char, char>()
            {
                {'(', ')' },
                {'[', ']' },
                {'{', '}' },
                {'<', '>' }
            };
            Stack<char> stack = new Stack<char>();
            foreach (char c in n)
            {
                if (dict.ContainsKey(c))
                    stack.Push(dict[c]);
                else if (dict.ContainsValue(c))
                {
                    Node<char> temp = stack.Head;
                    if (temp.Value == c)
                        stack.Pop();
                    else
                        return false;
                }
                else { Console.WriteLine("Введена не скобка"); return false; }
            }
            return true;
        }
        static void Main(string[] args)
        {
            string n = "([]<{}>)";
            Console.WriteLine(Func(n));
        }
    }
}
