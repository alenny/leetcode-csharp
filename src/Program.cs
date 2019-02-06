using System;
using Alenny.LeetCode.Utilities;
using Alenny.LeetCode.Problems;

namespace Alenny.LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var heap = new Heap((x, y) => y - x);
            heap.Insert(1);
            heap.Insert(5);
            heap.Insert(2);
            heap.Insert(4);
            heap.Insert(3);
            Console.WriteLine(heap.Pop());
            Console.WriteLine(heap.Pop());
            Console.WriteLine(heap.Pop());
            Console.WriteLine(heap.Pop());
            Console.WriteLine(heap.Pop());
        }
    }
}