using System;
using Alenny.LeetCode.Problems;

namespace Alenny.LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new LongestTurbulentSubarray();
            var ret = sol.MaxTurbulenceSize(new int[] { 0, 8, 45, 88, 48, 68, 28, 55, 17, 24 });
            Console.WriteLine(ret);
        }
    }
}
