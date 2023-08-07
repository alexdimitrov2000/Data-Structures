namespace DataStructuresExercise.Contracts
{
    public interface IAbstractBinaryTree<T>
    {
        T Value { get; }
        IAbstractBinaryTree<T> LeftChild { get; }
        IAbstractBinaryTree<T> RightChild { get; }

        string AsIndentedPreOrder(int indent);
        void ForEachInOrder(Action<T> action);
        IEnumerable<IAbstractBinaryTree<T>> PreOrder();
        IEnumerable<IAbstractBinaryTree<T>> InOrder();
        IEnumerable<IAbstractBinaryTree<T>> PostOrder();
    }
}
