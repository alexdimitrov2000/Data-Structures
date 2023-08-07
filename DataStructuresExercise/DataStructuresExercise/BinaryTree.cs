namespace DataStructuresExercise
{
    using Contracts;
    using System;
    using System.Collections.Generic;
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

        public T Value => this.value;

        public IAbstractBinaryTree<T> LeftChild => this.left;

        public IAbstractBinaryTree<T> RightChild => this.right;

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder builder = new StringBuilder();

            this.IndentationHelper(builder, indent, this);

            return builder.ToString();
        }

        private void IndentationHelper(StringBuilder builder, int indent, IAbstractBinaryTree<T> binaryTree)
        {
            if (binaryTree is not null)
            {
                builder.Append(new string(' ', indent)).AppendLine(binaryTree.Value!.ToString());
                this.IndentationHelper(builder, indent + 2, binaryTree.LeftChild);
                this.IndentationHelper(builder, indent + 2, binaryTree.RightChild);
            }
        }

        public void ForEachInOrder(Action<T> action)
        {
            if (this.left is not null)
            {
                this.left.ForEachInOrder(action);
            }
            
            action.Invoke(this.Value);

            if (this.right is not null)
            {
                this.right.ForEachInOrder(action);
            }
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder() // Root, Left, Right
        {
            //List<IAbstractBinaryTree<T>> result = this.PreOrderHelper(new List<IAbstractBinaryTree<T>>(), this); // one way
            System.Collections.Generic.List<IAbstractBinaryTree<T>> result = new System.Collections.Generic.List<IAbstractBinaryTree<T>>();

            result.Add(this);
            if (this.left is not null)
            {
                result.AddRange(this.left.PreOrder());
            }
            if (this.right is not null)
            {
                result.AddRange(this.right.PreOrder());
            }

            return result;
        }

        private List<IAbstractBinaryTree<T>> PreOrderHelper(List<IAbstractBinaryTree<T>> list, IAbstractBinaryTree<T> binaryTree)
        {
            if (binaryTree is not null)
            {
                list.Add(binaryTree);
                this.PreOrderHelper(list, binaryTree.LeftChild);
                this.PreOrderHelper(list, binaryTree.RightChild);
            }

            return list;
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder() // Left, Root, Right
        {
            System.Collections.Generic.List<IAbstractBinaryTree<T>> result = new System.Collections.Generic.List<IAbstractBinaryTree<T>>();

            if (this.left is not null)
            {
                result.AddRange(this.left.PreOrder());
            }

            result.Add(this);

            if (this.right is not null)
            {
                result.AddRange(this.right.PreOrder());
            }

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder() // Left, Right, Root
        {
            System.Collections.Generic.List<IAbstractBinaryTree<T>> result = new System.Collections.Generic.List<IAbstractBinaryTree<T>>();

            if (this.left is not null)
            {
                result.AddRange(this.left.PreOrder());
            }
            if (this.right is not null)
            {
                result.AddRange(this.right.PreOrder());
            }
            result.Add(this);

            return result;
        }
    }
}
