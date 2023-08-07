namespace DataStructuresExercise.Trees
{
    using Contracts;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        private T value;
        private IAbstractBinaryTree<T> left;
        private IAbstractBinaryTree<T> right;

        public BinaryTree(T value) : this(value, default, default)
        { }

        public BinaryTree(T value, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public T Value => value;

        public IAbstractBinaryTree<T> LeftChild => left;

        public IAbstractBinaryTree<T> RightChild => right;

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder builder = new StringBuilder();

            IndentationHelper(builder, indent, this);

            return builder.ToString();
        }

        private void IndentationHelper(StringBuilder builder, int indent, IAbstractBinaryTree<T> binaryTree)
        {
            if (binaryTree is not null)
            {
                builder.Append(new string(' ', indent)).AppendLine(binaryTree.Value!.ToString());
                IndentationHelper(builder, indent + 2, binaryTree.LeftChild);
                IndentationHelper(builder, indent + 2, binaryTree.RightChild);
            }
        }

        public void ForEachInOrder(Action<T> action)
        {
            left?.ForEachInOrder(action);

            action.Invoke(Value);

            right?.ForEachInOrder(action);
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder() // Root, Left, Right
        {
            //List<IAbstractBinaryTree<T>> result = this.PreOrderHelper(new List<IAbstractBinaryTree<T>>(), this); // one way
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

            result.Add(this);
            if (left is not null)
            {
                result.AddRange(left.PreOrder());
            }
            if (right is not null)
            {
                result.AddRange(right.PreOrder());
            }

            return result;
        }

        private List<IAbstractBinaryTree<T>> PreOrderHelper(List<IAbstractBinaryTree<T>> list, IAbstractBinaryTree<T> binaryTree)
        {
            if (binaryTree is not null)
            {
                list.Add(binaryTree);
                PreOrderHelper(list, binaryTree.LeftChild);
                PreOrderHelper(list, binaryTree.RightChild);
            }

            return list;
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder() // Left, Root, Right
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

            if (left is not null)
            {
                result.AddRange(left.PreOrder());
            }

            result.Add(this);

            if (right is not null)
            {
                result.AddRange(right.PreOrder());
            }

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder() // Left, Right, Root
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

            if (left is not null)
            {
                result.AddRange(left.PreOrder());
            }
            if (right is not null)
            {
                result.AddRange(right.PreOrder());
            }
            result.Add(this);

            return result;
        }
    }
}
