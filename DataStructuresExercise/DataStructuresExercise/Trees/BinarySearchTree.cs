namespace DataStructuresExercise.Trees
{
    using Contracts;
    using System.Xml.Linq;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value) : this(value, default, default)
            { }

            public Node(T value, Node left, Node right)
            {
                Value = value;
                Left = left;
                Right = right;
            }

            public T Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }

        private Node current;

        public BinarySearchTree()
        {
            current = default;
        }

        public BinarySearchTree(T value)
        {
            current = new Node(value);
        }

        private BinarySearchTree(Node node)
        {
            current = node;
        }

        private Node FindNodeByValue(T value, Node current)
        {
            if (current is null)
            {
                return null;
            }

            int comparison = current.Value.CompareTo(value);

            if (comparison == 0)
            {
                return current;
            }

            if (comparison < 0)
            {
                return FindNodeByValue(value, current.Right);
            }

            return FindNodeByValue(value, current.Left);
        }

        public bool Contains(T element)
        {
            if (current is null)
            {
                throw new InvalidOperationException();
            }

            return FindNodeByValue(element, current) is not null;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action, current);
        }

        private void EachInOrder(Action<T> action, Node current)
        {
            if (current is null)
            {
                return;
            }

            EachInOrder(action, current.Left);
            action.Invoke(current.Value);
            EachInOrder(action, current.Right);
        }

        public void Insert(T element)
        {
            current = InsertHelper(current, element);
            return;
        }

        private Node InsertHelper(Node node, T element)
        {
            if (node is null)
            {
                node = new Node(element);
                return node;
            }

            if (node.Value.CompareTo(element) < 0)
            {
                node.Right = InsertHelper(node.Right, element);
            }
            else if (node.Value.CompareTo(element) > 0)
            {
                node.Left = InsertHelper(node.Left, element);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node node = FindNodeByValue(element, current);
            return node is null ? default : new BinarySearchTree<T>(node);
        }
    }
}
