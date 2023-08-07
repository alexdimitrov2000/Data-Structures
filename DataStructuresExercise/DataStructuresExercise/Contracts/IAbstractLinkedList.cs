namespace DataStructuresExercise.Contracts
{
    public interface IAbstractLinkedList<T> : IEnumerable<T>
    {
        int Count { get; }

        void AddFirst(T item);

        void AddLast(T item);

        T GetFirst();

        T GetLast();

        T RemoveFirst();

        T RemoveLast();
    }
}
