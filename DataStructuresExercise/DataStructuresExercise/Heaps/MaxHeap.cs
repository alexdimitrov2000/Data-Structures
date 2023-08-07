namespace DataStructuresExercise.Heaps
{
    using Contracts;

    /// <summary>
    /// Every parent's value is greater than its children's.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MaxHeap<T> : Heap<T>, IAbstractMaxHeap<T> where T : IComparable<T>
    {
        public MaxHeap() : base(new List<T>())
        { }

        public MaxHeap(List<T> elements) : base(elements)
        { }

        public override void Add(T element)
        {
            elements.Add(element);
            HeapifyUp(elements.Count - 1);
        }

        private void HeapifyUp(int elementIndex)
        {
            int parentIndex = GetParentIndex(elementIndex);

            while (IsIndexValid(parentIndex) && IsGreater(elementIndex, parentIndex))
            {
                Swap(parentIndex, elementIndex);
                elementIndex = parentIndex;
                parentIndex = GetParentIndex(elementIndex);
            }
        }

        public T ExtractMax()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T maxElement = elements[0];

            Swap(0, elements.Count - 1);
            elements.RemoveAt(elements.Count - 1);
            HeapifyDown(0);

            return maxElement;
        }

        private void HeapifyDown(int elementIndex)
        {
            int indexOfBiggerChild = GetGreaterChildIndex(elementIndex);

            while (IsIndexValid(indexOfBiggerChild) && IsGreater(indexOfBiggerChild, elementIndex))
            {
                Swap(elementIndex, indexOfBiggerChild);

                elementIndex = indexOfBiggerChild;
                indexOfBiggerChild = GetGreaterChildIndex(elementIndex);
            }
        }

        /// <summary>
        /// Returns the index of the element's, found at the specified index, greter child. If the element does not have children, returns -1;
        /// </summary>
        /// <param name="parentIndex"></param>
        /// <returns></returns>
        private int GetGreaterChildIndex(int parentIndex)
        {
            int leftChildIndex = GetLeftChildIndex(parentIndex);
            int rightChildIndex = GetRightChildIndex(parentIndex);

            if (!IsIndexValid(leftChildIndex) && !IsIndexValid(rightChildIndex))
            {
                return -1;
            }

            if (!IsIndexValid(rightChildIndex))
            {
                return leftChildIndex;
            }

            return IsGreater(leftChildIndex, rightChildIndex) ? leftChildIndex : rightChildIndex;
        }
    }
}
