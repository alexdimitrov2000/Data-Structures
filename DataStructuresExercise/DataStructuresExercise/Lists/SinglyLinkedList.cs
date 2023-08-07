namespace DataStructuresExercise.Lists
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
                Value = value;
                Next = next;
            }
        }

        private Node top;
        private int count;

        public int Count => count;

        public void AddFirst(T item)
        {
            Node newNode = new Node(item, top);
            top = newNode;
            count++;
        }

        public void AddLast(T item)
        {
            if (top is null)
            {
                top = new Node(item);
                count++;
                return;
            }

            Node current = top;

            while (current.Next is not null)
            {
                current = current.Next;
            }

            current.Next = new Node(item);
            count++;
        }

        public T GetFirst()
        {
            if (top is null)
            {
                throw new InvalidOperationException();
            }

            return top.Value;
        }

        public T GetLast()
        {
            if (top is null)
            {
                throw new InvalidOperationException();
            }

            Node current = top;

            while (current.Next is not null)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public T RemoveFirst()
        {
            if (top is null)
            {
                throw new InvalidOperationException();
            }

            Node oldTop = top;
            top = top.Next;
            count--;

            return oldTop.Value;
        }

        public T RemoveLast()
        {
            if (top is null)
            {
                throw new InvalidOperationException();
            }

            if (top.Next is null)
            {
                T value = top.Value;
                top = null;
                count--;

                return value;
            }

            Node current = top;

            while (current.Next.Next is not null)
            {
                current = current.Next;
            }

            Node lastElement = current.Next;
            current.Next = null;

            count--;

            return lastElement.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = top;

            while (current is not null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
