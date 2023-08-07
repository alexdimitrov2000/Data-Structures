namespace DataStructuresExercise
{
    using Contracts;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        public class Node
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

        public void AddFirst(T item)
        {
            Node newNode = new Node(item, this.top);
            this.top = newNode;
            this.count++;
        }

        public void AddLast(T item)
        {
            if (this.top is null)
            {
                this.top = new Node(item);
                this.count++;
                return;
            }

            Node current = this.top;

            while (current.Next is not null)
            {
                current = current.Next;
            }

            current.Next = new Node(item);
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

            Node oldTop = this.top;
            this.top = this.top.Next;
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

            while (current.Next.Next is not null)
            {
                current = current.Next;
            }

            Node lastElement = current.Next;
            current.Next = null;

            this.count--;

            return lastElement.Value;
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
