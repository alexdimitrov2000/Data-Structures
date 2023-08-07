namespace DataStructuresExercise.Lists
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

        public int Count => count;

        public void AddFirst(T item)
        {
            Node newNode = new Node(item, null, top);
            if (top is not null)
            {
                top.Previous = newNode;
            }
            top = newNode;
            count++;
        }

        public void AddLast(T item)
        {
            if (top is null)
            {
                top = new Node(item);
            }
            else
            {
                Node current = top;

                while (current.Next is not null)
                {
                    current = current.Next;
                }

                current.Next = new Node(item, current, null);
            }
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

            if (top.Next is null)
            {
                T value = top.Value;
                top = null;
                count--;

                return value;
            }

            Node oldTop = top;
            top = top.Next;
            oldTop.Next = null;
            top.Previous = null;
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
            while (current.Next is not null)
            {
                current = current.Next;
            }

            current.Previous.Next = null;
            current.Previous = null;
            count--;

            return current.Value;
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
