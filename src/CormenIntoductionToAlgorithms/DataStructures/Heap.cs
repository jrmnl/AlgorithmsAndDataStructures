using System;
using System.Collections.Generic;
using System.Linq;

namespace CormenIntoductionToAlgorithms.DataStructures
{
    public class Heap
    {
        private readonly OrderType _order;
        private List<int> _elements;

        public Heap(IEnumerable<int> elements, OrderType order)
        {
            if (elements is null) throw new ArgumentNullException();
            _order = order;

            _elements = elements.ToList();
            for (int i = (_elements.Count - 1) / 2; i >= 0; i--)
            {
                HeapifyRecursively(i);
            }
        }

        private static int Left(int i) => ((i + 1) * 2) - 1;
        private static int Right(int i) => (i + 1) * 2;

        private void HeapifyRecursively(int index)
        {
            Func<int, int, bool> more = (x, y) => x > y;
            Func<int, int, bool> less = (x, y) => x < y;
            var compare = _order == OrderType.Max
                ? more
                : less;

            var left = Left(index);
            var right = Right(index);
            var largest = index;
            if (left < _elements.Count && compare(_elements[left], _elements[largest]))
            {
                largest = left;
            }
            if (right < _elements.Count && compare(_elements[right], _elements[largest]))
            {
                largest = right;
            }
            if (largest != index)
            {
                var temp = _elements[index];
                _elements[index] = _elements[largest];
                _elements[largest] = temp;
                HeapifyRecursively(largest);
            }
        }

        public int Pop()
        {
            if (_elements.Count == 0) throw new InvalidOperationException();

            var temp = _elements[0];
            _elements[0] = _elements[_elements.Count - 1];
            _elements.RemoveAt(_elements.Count - 1);
            HeapifyRecursively(0);
            return temp;
        }

        public enum OrderType
        {
            Max,
            Min
        }
    }
}
