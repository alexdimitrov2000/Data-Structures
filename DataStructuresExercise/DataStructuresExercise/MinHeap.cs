namespace DataStructuresExercise
{
    using Contracts;

    /// <summary>
    /// Every parent's value is less than its children's.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinHeap<T> : Heap<T>, IAbstractMinHeap<T> where T : IComparable<T>
    {
        public MinHeap() : base(new System.Collections.Generic.List<T>())
        { }

        public MinHeap(System.Collections.Generic.List<T> elements) : base(elements)
        { }

        public override void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        private void HeapifyUp(int elementIndex)
        {
            int parentIndex = this.GetParentIndex(elementIndex);

            while (this.IsIndexValid(parentIndex) && this.IsGreater(parentIndex, elementIndex))
            {
                this.Swap(parentIndex, elementIndex);
                elementIndex = parentIndex;
                parentIndex = this.GetParentIndex(elementIndex);
            }
        }

        public T ExtractMin()
        {
            T minElement = this.elements[0];

            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.elements.Count - 1);
            this.HeapifyDown(0);

            return minElement;
        }

        private void HeapifyDown(int elementIndex)
        {
            int indexOfSmallerChild = this.GetSmallerChildIndex(elementIndex);

            while (this.IsIndexValid(indexOfSmallerChild) && 
                   this.IsGreater(elementIndex, indexOfSmallerChild))
            {
                this.Swap(elementIndex, indexOfSmallerChild);

                elementIndex = indexOfSmallerChild;
                indexOfSmallerChild = this.GetSmallerChildIndex(elementIndex);
            }
        }

        /// <summary>
        /// Returns the index of the element's, found at the specified index, smaller child. If the element does not have children, returns -1;
        /// </summary>
        /// <param name="elementIndex"></param>
        /// <returns></returns>
        private int GetSmallerChildIndex(int elementIndex)
        {
            int leftChildIndex = this.GetLeftChildIndex(elementIndex);
            int rightChildIndex = this.GetRightChildIndex(elementIndex);

            if (!this.IsIndexValid(leftChildIndex) && !this.IsIndexValid(rightChildIndex))
            {
                return -1;
            }

            if (!this.IsIndexValid(rightChildIndex))
            {
                return leftChildIndex;
            }

            return this.IsGreater(leftChildIndex, rightChildIndex) ? rightChildIndex : leftChildIndex;
        }
    }
}
