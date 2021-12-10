using System;
using System.Collections.Generic;

namespace PrimeAlgorithem
{
    public class MinHeap<T> where T : IComparable<T>
    {
        #region Fields

        private readonly List<T> _elements;

        #endregion

        #region C'tor

        public MinHeap()
        {
            _elements = new List<T>();
        }

        public MinHeap(IEnumerable<T> elements): this()
        {
            foreach (T element in elements)
                Add(element);
        }

        #endregion

        #region Public methods

        public bool IsEmpty()
        {
            return _elements.Count == 0;
        }

        public T Peek()
        {
            if (_elements.Count == 0)
                throw new IndexOutOfRangeException();

            return _elements[0];
        }

        public T Pop()
        {
            if (_elements.Count == 0)
                throw new IndexOutOfRangeException();

            var result = _elements[0];
            _elements[0] = _elements[_elements.Count - 1];
            //_elements.RemoveAt(_elements.Count - 1);

            ReCalculateDown();
            _elements.RemoveAt(_elements.Count - 1);

            return result;
        }

        public void Add(T element)
        {
            _elements.Add(element);

            ReCalculateUp();
        }

        public void ForceHeapUpdate()
        {
            this.ReCalculateUp();
        }

        public bool Contains(T elemant)
        {
            return _elements.Contains(elemant);
        }

        #endregion

        #region Private methods

        private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _elements.Count;
        private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _elements.Count;

        private T GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
        private T GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
        private T GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        private void ReCalculateDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index).CompareTo(GetLeftChild(index)) < 0)
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (_elements[smallerIndex].CompareTo(_elements[index]) >= 0)
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        private void ReCalculateUp()
        {
            var index = _elements.Count - 1;
            while (!IsRoot(index) && _elements[index].CompareTo(GetParent(index)) < 0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        #endregion

        #region Static methods

        private static int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private static int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private static int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;
        private static bool IsRoot(int elementIndex) => elementIndex == 0;

        #endregion
    }
}