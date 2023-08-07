namespace DataStructuresExercise.Contracts
{
    public interface IAbstractStack<T> : IEnumerable<T>
    {
        int Count { get; }

        bool Contains(T item);

        T Peek();

        T Pop();

        void Push(T item);
    }
}
