namespace DataStructuresExercise
{
    using Contracts;
    using System.Collections;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T Value { get; set; }

            public Node Next { get; set; }

            public Node(T value) : this(value, null)
            { }

            public Node(T value, Node next)
            {
                this.Value = value;
                this.Next = next;
            }
        }

        private Node top;
        private int count;

        public int Count => this.count;

        public bool Contains(T item)
        {
            Node current = this.top;

            while (current is not null)
            {
                if (current.Value!.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Peek()
        {
            if (this.top is null)
            {
                throw new InvalidOperationException();
            }

            return this.top.Value;
        }

        public T Pop()
        {
            if (this.top is null)
            {
                throw new InvalidOperationException();
            }

            Node currentTop = this.top;
            this.top = this.top.Next;
            this.count--;

            return currentTop.Value;
        }

        public void Push(T item)
        {
            Node newNode = new Node(item, this.top);
            this.count++;
            this.top = newNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = this.top;

            while (current is not null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
