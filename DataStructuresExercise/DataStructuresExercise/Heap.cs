namespace DataStructuresExercise
{
    using Contracts;

    public abstract class Heap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        protected System.Collections.Generic.List<T> elements;

        protected Heap() : this(new System.Collections.Generic.List<T>())
        { }

        protected Heap(System.Collections.Generic.List<T> elements)
        {
            this.elements = elements;
        }

        public int Size => this.elements.Count;

        protected void Swap(int firstIndex, int secondIndex)
        {
            T temp = this.elements[firstIndex];
            this.elements[firstIndex] = this.elements[secondIndex];
            this.elements[secondIndex] = temp;

            //(this.elements[firstIndex], this.elements[secondIndex]) = (this.elements[secondIndex], this.elements[firstIndex]); // equivalent swap
        }

        /// <summary>
        /// Checks whether the given index is within the heap's bounds.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected bool IsIndexValid(int index)
        {
            return index >= 0 && index < this.elements.Count;
        }

        /// <summary>
        /// Checks whether the left operand is greater than the right operand.
        /// </summary>
        /// <param name="leftOperandIndex"></param>
        /// <param name="rightOperandIndex"></param>
        /// <returns></returns>
        public bool IsGreater(int leftOperandIndex, int rightOperandIndex)
        {
            return this.elements[leftOperandIndex].CompareTo(this.elements[rightOperandIndex]) > 0;
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
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }
    }
}
