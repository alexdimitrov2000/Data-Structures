namespace DataStructuresExercise
{
    using Contracts;

    /// <summary>
    /// Every parent's value is greater than its children's.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MaxHeap<T> : Heap<T>, IAbstractMaxHeap<T> where T : IComparable<T>
    {
        public MaxHeap() : base(new System.Collections.Generic.List<T>())
        { }

        public MaxHeap(System.Collections.Generic.List<T> elements) : base(elements)
        { }

        public override void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        private void HeapifyUp(int elementIndex)
        {
            int parentIndex = this.GetParentIndex(elementIndex);

            while (this.IsIndexValid(parentIndex) && this.IsGreater(elementIndex, parentIndex))
            {
                this.Swap(parentIndex, elementIndex);
                elementIndex = parentIndex;
                parentIndex = this.GetParentIndex(elementIndex);
            }
        }

        public T ExtractMax()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T maxElement = this.elements[0];

            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.elements.Count - 1);
            this.HeapifyDown(0);

            return maxElement;
        }

        private void HeapifyDown(int elementIndex)
        {
            int indexOfBiggerChild = this.GetGreaterChildIndex(elementIndex);

            while (this.IsIndexValid(indexOfBiggerChild) && this.IsGreater(indexOfBiggerChild, elementIndex))
            {
                this.Swap(elementIndex, indexOfBiggerChild);

                elementIndex = indexOfBiggerChild;
                indexOfBiggerChild = this.GetGreaterChildIndex(elementIndex);
            }
        }

        /// <summary>
        /// Returns the index of the element's, found at the specified index, greter child. If the element does not have children, returns -1;
        /// </summary>
        /// <param name="parentIndex"></param>
        /// <returns></returns>
        private int GetGreaterChildIndex(int parentIndex)
        {
            int leftChildIndex = this.GetLeftChildIndex(parentIndex);
            int rightChildIndex = this.GetRightChildIndex(parentIndex);

            if (!this.IsIndexValid(leftChildIndex) && !this.IsIndexValid(rightChildIndex))
            {
                return -1;
            }

            if (!this.IsIndexValid(rightChildIndex))
            {
                return leftChildIndex;
            }

            return this.IsGreater(leftChildIndex, rightChildIndex) ? leftChildIndex : rightChildIndex;
        }
    }
}
