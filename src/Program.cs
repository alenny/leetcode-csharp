using System;
using Alenny.LeetCode.Problems;

namespace Alenny.LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new UniquePaths3();
            var param = new int[][] {
                new int[] {1,0,0,0},
                new int[] {0,0,0,0},
                new int[] {0,0,2,-1}
            };
            var ret = sol.UniquePathsIII(param);
            Console.WriteLine(ret);
        }
    }
}