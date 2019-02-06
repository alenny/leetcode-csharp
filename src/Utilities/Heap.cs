using System;
using System.Collections.Generic;

namespace Alenny.LeetCode.Utilities
{
    public class Heap
    {
        private readonly List<int> _heap = new List<int>();

        private readonly Func<int, int, int> _comparer = (x, y) => x - y;

        public Heap() { }

        public Heap(Func<int, int, int> comparer)
        {
            _comparer = comparer;
        }

        public int Size { get; private set; }

        public int? Top => Size > 0 ? _heap[0] : (int?)null;

        public void Insert(int val)
        {
            if (_heap.Count > Size)
            {
                _heap[Size] = val;
            }
            else
            {
                _heap.Add(val);
            }
            var idx = Size++;
            while (idx > 0)
            {
                var pIdx = GetParentIndex(idx);
                if (_comparer(_heap[pIdx], _heap[idx]) <= 0)
                {
                    break;
                }
                Swap(idx, pIdx);
                idx = pIdx;
            }
        }

        public int? Pop()
        {
            if (Size == 0)
            {
                return null;
            }
            var ret = _heap[0];
            _heap[0] = _heap[--Size];
            var idx = 0;
            while (idx < Size)
            {
                var left = GetLeftChildIndex(idx);
                var right = GetRightChildIndex(idx);
                var compToLeft = left < Size ? _comparer(_heap[idx], _heap[left]) : -1;
                var compToRight = right < Size ? _comparer(_heap[idx], _heap[right]) : -1;
                if (compToLeft <= 0 && compToRight <= 0)
                {
                    break;
                }
                var compLeftToRight = right < Size ? _comparer(_heap[left], _heap[right]) : -1;
                var target = compToLeft > 0 && compLeftToRight <= 0 ? left : right;
                Swap(idx, target);
                idx = target;
            }
            return ret;
        }

        private int GetLeftChildIndex(int idx)
        {
            return (idx << 1) + 1;
        }

        private int GetRightChildIndex(int idx)
        {
            return (idx << 1) + 2;
        }

        private int GetParentIndex(int idx)
        {
            return (idx - 1) >> 1;
        }

        private void Swap(int i0, int i1)
        {
            var tmp = _heap[i0];
            _heap[i0] = _heap[i1];
            _heap[i1] = tmp;
        }
    }
}
