namespace DataStructuresExercise.Contracts
{
    public interface IAbstractMaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        T ExtractMax();
    }
}
