using System.Collections.Generic;

namespace Alenny.LeetCode.Problems
{

    public class UniquePaths3
    {
        private static readonly int[][] Deltas = {
            new int[] { -1, 0 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { 0, 1 }
        };

        public int UniquePathsIII(int[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            int[] start = null;
            int[] end = null;
            int zeros = 0;
            for (var r = 0; r < rows; ++r)
            {
                for (var c = 0; c < cols; ++c)
                {
                    switch (grid[r][c])
                    {
                        case 0:
                            zeros += 1;
                            break;
                        case 1:
                            start = new int[] { r, c };
                            break;
                        case 2:
                            end = new int[] { r, c };
                            break;
                    }
                }
            }
            return Dfs(start[0], start[1], grid, zeros, end, new HashSet<string>());
        }

        private int Dfs(int r, int c, int[][] grid, int zeros, int[] end, HashSet<string> path)
        {
            if (zeros == path.Count)
            {
                foreach (var delta in Deltas)
                {
                    var r1 = r + delta[0];
                    var c1 = c + delta[1];
                    if (r1 == end[0] && c1 == end[1])
                    {
                        return 1;
                    }
                }
                return 0;
            }
            var rows = grid.Length;
            var cols = grid[0].Length;
            var ret = 0;
            foreach (var delta in Deltas)
            {
                var r1 = r + delta[0];
                var c1 = c + delta[1];
                if (r1 < 0 || r1 >= rows || c1 < 0 || c1 >= cols
                   || grid[r1][c1] != 0)
                {
                    continue;
                }
                var key = GetKey(r1, c1);
                if (path.Contains(key))
                {
                    continue;
                }
                path.Add(key);
                ret += Dfs(r1, c1, grid, zeros, end, path);
                path.Remove(key);
            }
            return ret;
        }

        private string GetKey(int r, int c)
        {
            return $"{r},{c}";
        }
    }
}