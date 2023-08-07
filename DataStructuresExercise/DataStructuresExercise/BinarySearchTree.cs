namespace DataStructuresExercise
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
                this.Value = value;
                this.Left = left;
                this.Right = right;
            }

            public T Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }

        private Node current;

        public BinarySearchTree()
        {
            this.current = default;
        }

        public BinarySearchTree(T value)
        {
            this.current = new Node(value);
        }

        private BinarySearchTree(Node node)
        {
            this.current = node;
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
                return this.FindNodeByValue(value, current.Right);
            }

            return this.FindNodeByValue(value, current.Left);
        }

        public bool Contains(T element)
        {
            if (this.current is null)
            {
                throw new InvalidOperationException();
            }

            return this.FindNodeByValue(element, this.current) is not null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.current);
        }

        private void EachInOrder(Action<T> action, Node current)
        {
            if (current is null)
            {
                return;
            }

            this.EachInOrder(action, current.Left);
            action.Invoke(current.Value);
            this.EachInOrder(action, current.Right);
        }

        public void Insert(T element)
        {
            this.current = this.InsertHelper(this.current, element);
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
                node.Right = this.InsertHelper(node.Right, element);
            }
            else if (node.Value.CompareTo(element) > 0)
            {
                node.Left = this.InsertHelper(node.Left, element);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node node = this.FindNodeByValue(element, this.current);
            return node is null ? default : new BinarySearchTree<T>(node);
        }
    }
}
