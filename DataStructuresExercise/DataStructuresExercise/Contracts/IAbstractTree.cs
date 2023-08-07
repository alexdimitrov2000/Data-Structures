namespace DataStructuresExercise.Contracts
{
    public interface IAbstractTree<T>
    {
        IEnumerable<T> OrderBfs();

        IEnumerable<T> OrderDfs();

        void AddChild(T parent, Tree<T> child);

        void RemoveNode(T nodeKey);

        void Swap(T firstKey, T secondKey);
    }
}
