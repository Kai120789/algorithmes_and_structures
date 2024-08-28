using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР14._1
{
    class Node
    {
        public uint Dist; // от объекта до родителя
        public string Name;
        public List<(uint, Node)> Children = new List<(uint, Node)>();
    }
    class Program
    {
        // ЕСТЬ ВАРИАНТ, ЧТО В РЕЗУЛЬТАТЕ МЫ ДОЛЖЫ ПОЛУЧАТЬ НЕ ТУПО ВСЕ ПУТИ, А НАИМЕНЬШИЕ ОТ А ДО КАЖДОЙ ИЗ ОСТАЛЬНЫХ
        // ДЛЯ ЭТОГО СДЕЛАЕМ ИТОГ. КОЛЛЕКЦИЮ, ГДЕ КАЖДЫЙ ЭЛЕМЕНТ ЭТО ПУТЬ (СТРОКА) ДО ТОЧКИ И РАССТОЯНИЕ
        // ДАЛЕЕ ПО ДЕЙКСТРУ ДЕЛАЕМ ВСЁ БАЗОВО, ПО НАШЕМУ РЕКУРСИВНОМУ АЛГОРИТМУ, КОГДА МЕНЯЕМ ЗНАЧЕНИЕ В ВЕРШИНЕ НА МЕНЬШЕЕ
        // ТО И МЕНЯЕМ В ИТОГОВОЙ КОЛЛЕКЦИИ ПУТЬ ДО ЭТОЙ ВЕРШИНЫ.
        // В РЕКУРСИЮ В ПАРАМЕТРЫ ДАЁМ СТРОКУ ПУТИ И РАССТОЯНИЕ ТАК ЖЕ. 
        // В КОНЦЕ ВЫВОДИМ ИТОГОВУЮ КОЛЛЕКЦИЮ
        static List<(string, uint)> res = new List<(string, uint)>();
        static void Foo(string str, uint rasst, Node node)
        {
            foreach ((uint, Node) couple in node.Children) {
                Console.WriteLine(str + couple.Item2.Name + $" {rasst + couple.Item1}");
                res.Add((str + couple.Item2.Name, rasst + couple.Item1));
            }

            foreach ((uint, Node) couple in node.Children)
                Foo(str + couple.Item2.Name, rasst + couple.Item1, couple.Item2);
        }
        static void Main(string[] args)
        {
            Node a = new Node() { Name = "a" };
            Node b = new Node() { Name = "b" };
            Node c = new Node() { Name = "c" };
            Node d = new Node() { Name = "d" };
            Node e = new Node() { Name = "e" };
            Node f = new Node() { Name = "f" };
            a.Children.Add((14,b)); a.Children.Add((9,c)); a.Children.Add((7,d));
            b.Children.Add((9,e)); b.Children.Add((2,c));
            e.Children.Add((6,f));
            c.Children.Add((10,d)); c.Children.Add((11,f));
            d.Children.Add((15,f));
            Foo("a", 0, a);
            Console.ReadLine();
        }
    }
}
