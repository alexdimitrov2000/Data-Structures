namespace DataStructuresExercise.Lists
{
    using Contracts;
    using System.Collections;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;
        private int count;

        public List() : this(DEFAULT_CAPACITY)
        { }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            items = new T[capacity];
            count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                items[index] = value;
            }
        }

        public int Count => count;

        public void Add(T item)
        {
            if (count == items.Length)
            {
                Grow();
            }

            items[count++] = item;
        }

        private void Grow()
        {
            T[] newList = new T[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                newList[i] = items[i];
            }

            //Array.Copy(this.items, newList, this.count); // equivalent to the loop above

            items = newList;
        }

        public bool Contains(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException();
            }

            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < count; i++)
            {
                if (items[i]!.Equals(item)) // the symbol ! assures the compiler that this.items[i] is not null
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            if (item is null)
            {
                throw new ArgumentNullException();
            }

            if (count == items.Length)
            {
                Grow();
            }

            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            count++;
        }

        public bool Remove(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException();
            }

            int itemIndex = IndexOf(item);

            if (itemIndex < 0)
            {
                return false;
            }

            RemoveAt(itemIndex);

            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[--count] = default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
