namespace DataStructuresExercise.Contracts
{
    public interface IAbstractQueue<T> : IEnumerable<T>
    {
        int Count { get; }

        bool Contains(T item);

        void Enqueue(T item);

        T Dequeue();

        T Peek();
    }
}
