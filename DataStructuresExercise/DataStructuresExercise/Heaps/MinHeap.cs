namespace DataStructuresExercise.Heaps
{
    using Contracts;

    /// <summary>
    /// Every parent's value is less than its children's.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinHeap<T> : Heap<T>, IAbstractMinHeap<T> where T : IComparable<T>
    {
        public MinHeap() : base(new List<T>())
        { }

        public MinHeap(List<T> elements) : base(elements)
        { }

        public override void Add(T element)
        {
            elements.Add(element);
            HeapifyUp(elements.Count - 1);
        }

        private void HeapifyUp(int elementIndex)
        {
            int parentIndex = GetParentIndex(elementIndex);

            while (IsIndexValid(parentIndex) && IsGreater(parentIndex, elementIndex))
            {
                Swap(parentIndex, elementIndex);
                elementIndex = parentIndex;
                parentIndex = GetParentIndex(elementIndex);
            }
        }

        public T ExtractMin()
        {
            T minElement = elements[0];

            Swap(0, elements.Count - 1);
            elements.RemoveAt(elements.Count - 1);
            HeapifyDown(0);

            return minElement;
        }

        private void HeapifyDown(int elementIndex)
        {
            int indexOfSmallerChild = GetSmallerChildIndex(elementIndex);

            while (IsIndexValid(indexOfSmallerChild) &&
                   IsGreater(elementIndex, indexOfSmallerChild))
            {
                Swap(elementIndex, indexOfSmallerChild);

                elementIndex = indexOfSmallerChild;
                indexOfSmallerChild = GetSmallerChildIndex(elementIndex);
            }
        }

        /// <summary>
        /// Returns the index of the element's, found at the specified index, smaller child. If the element does not have children, returns -1;
        /// </summary>
        /// <param name="elementIndex"></param>
        /// <returns></returns>
        private int GetSmallerChildIndex(int elementIndex)
        {
            int leftChildIndex = GetLeftChildIndex(elementIndex);
            int rightChildIndex = GetRightChildIndex(elementIndex);

            if (!IsIndexValid(leftChildIndex) && !IsIndexValid(rightChildIndex))
            {
                return -1;
            }

            if (!IsIndexValid(rightChildIndex))
            {
                return leftChildIndex;
            }

            return IsGreater(leftChildIndex, rightChildIndex) ? rightChildIndex : leftChildIndex;
        }
    }
}
