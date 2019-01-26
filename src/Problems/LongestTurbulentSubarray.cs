using System;

namespace Alenny.LeetCode.Problems
{
    public class LongestTurbulentSubarray
    {
        public int MaxTurbulenceSize(int[] A)
        {
            if (A.Length <= 1)
            {
                return A.Length;
            }
            var ret = 1;
            var prevComp = Compare(A[0], A[1]);
            var currLen = prevComp == 0 ? 1 : 2;
            for (var i = 2; i < A.Length; ++i)
            {
                var currComp = Compare(A[i - 1], A[i]);
                var multi = currComp * prevComp;
                if (multi == -1)
                {
                    currLen += 1;
                }
                else
                {
                    ret = Math.Max(ret, currLen);
                    currLen = currComp != 0 ? 2 : 1;
                }
                prevComp = currComp;
            }
            return Math.Max(ret, currLen);
        }

        private int Compare(int x, int y)
        {
            return x > y ? 1 : (x < y ? -1 : 0);
        }
    }
}

