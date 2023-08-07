namespace DataStructuresExercise.Heaps
{
    using Contracts;

    public abstract class Heap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        protected List<T> elements;

        protected Heap() : this(new List<T>())
        { }

        protected Heap(List<T> elements)
        {
            this.elements = elements;
        }

        public int Size => elements.Count;

        protected void Swap(int firstIndex, int secondIndex)
        {
            T temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;

            //(this.elements[firstIndex], this.elements[secondIndex]) = (this.elements[secondIndex], this.elements[firstIndex]); // equivalent swap
        }

        /// <summary>
        /// Checks whether the given index is within the heap's bounds.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected bool IsIndexValid(int index)
        {
            return index >= 0 && index < elements.Count;
        }

        /// <summary>
        /// Checks whether the left operand is greater than the right operand.
        /// </summary>
        /// <param name="leftOperandIndex"></param>
        /// <param name="rightOperandIndex"></param>
        /// <returns></returns>
        public bool IsGreater(int leftOperandIndex, int rightOperandIndex)
        {
            return elements[leftOperandIndex].CompareTo(elements[rightOperandIndex]) > 0;
        }

        protected int GetLeftChildIndex(int elementIndex)
        {
            return elementIndex * 2 + 1;
        }

        protected int GetRightChildIndex(int elementIndex)
        {
            return elementIndex * 2 + 2;
        }

        protected int GetParentIndex(int elementIndex)
        {
            return (elementIndex - 1) / 2;
        }

        public abstract void Add(T element);

        public T Peek()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return elements[0];
        }
    }
}
