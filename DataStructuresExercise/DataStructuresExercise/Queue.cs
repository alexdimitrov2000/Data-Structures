namespace DataStructuresExercise
{
    using Contracts;
    using System.Collections;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Value { get; set; }

            public Node Next { get; set; }

            public Node(T value) : this(value, null)
            { }

            public Node(T value, Node next)
            {
                Value = value;
                Next = next;
            }
        }

        private Node top;
        private int count;

        public int Count => this.count;

        public bool Contains(T item)
        {
            Node current = this.top;

            while (current != null)
            {
                if (current.Value!.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Enqueue(T item)
        {
            Node newNode = new Node(item);
            this.count++;

            if (this.top is null)
            {
                this.top = newNode;
                return;
            }

            Node current = this.top;
            while (current.Next is not null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        public T Dequeue()
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

        public T Peek()
        {
            if (this.top is null)
            {
                throw new InvalidOperationException();
            }

            return this.top.Value;
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
