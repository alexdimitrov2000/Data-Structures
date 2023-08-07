namespace DataStructuresExercise
{
    using Contracts;
    using System.Collections;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Value { get; set; }

            public Node Previous { get; set; }

            public Node Next { get; set; }

            public Node(T value) : this(value, null, null)
            { }

            public Node(T value, Node previous, Node next)
            {
                Value = value;
                Previous = previous;
                Next = next;
            }
        }

        private Node top;
        private int count;

        public int Count => this.count;

        public void AddFirst(T item)
        {
            Node newNode = new Node(item, null, this.top);
            if (this.top is not null)
            {
                this.top.Previous = newNode;
            }
            this.top = newNode;
            this.count++;
        }

        public void AddLast(T item)
        {
            if (this.top is null)
            {
                this.top = new Node(item);
            }
            else
            {
                Node current = this.top;

                while (current.Next is not null)
                {
                    current = current.Next;
                }

                current.Next = new Node(item, current, null);
            }
            this.count++;
        }

        public T GetFirst()
        {
            if (this.top is null)
            {
                throw new InvalidOperationException();
            }

            return this.top.Value;
        }

        public T GetLast()
        {
            if (this.top is null)
            {
                throw new InvalidOperationException();
            }

            Node current = this.top;

            while (current.Next is not null)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public T RemoveFirst()
        {
            if (this.top is null)
            {
                throw new InvalidOperationException();
            }

            if (this.top.Next is null)
            {
                T value = this.top.Value;
                this.top = null;
                this.count--;

                return value;
            }

            Node oldTop = this.top;
            this.top = this.top.Next;
            oldTop.Next = null;
            this.top.Previous = null;
            this.count--;

            return oldTop.Value;
        }

        public T RemoveLast()
        {
            if (this.top is null)
            {
                throw new InvalidOperationException();
            }

            if (this.top.Next is null)
            {
                T value = this.top.Value;
                this.top = null;
                this.count--;

                return value;
            }

            Node current = this.top;
            while (current.Next is not null)
            {
                current = current.Next;
            }

            current.Previous.Next = null;
            current.Previous = null;
            this.count--;

            return current.Value;
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
