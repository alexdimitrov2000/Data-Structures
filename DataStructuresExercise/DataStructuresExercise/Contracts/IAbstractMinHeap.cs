namespace DataStructuresExercise.Contracts
{
    public interface IAbstractMinHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        T ExtractMin();
    }
}
