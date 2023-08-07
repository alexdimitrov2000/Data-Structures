namespace DataStructuresExercise.Contracts
{
    public interface IBinarySearchTree<T> where T : IComparable<T>
    {
        bool Contains(T element);

        void EachInOrder(Action<T> action);

        void Insert(T element);

        IBinarySearchTree<T> Search(T element);
    }
}
