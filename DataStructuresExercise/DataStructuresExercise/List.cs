namespace DataStructuresExercise
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

            this.items = new T[capacity];
            this.count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException();
                }

                this.items[index] = value;
            }
        }

        public int Count => this.count;

        public void Add(T item)
        {
            if (this.count == this.items.Length)
            {
                this.Grow();
            }

            this.items[this.count++] = item;
        }

        private void Grow()
        {
            T[] newList = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                newList[i] = this.items[i];
            }

            //Array.Copy(this.items, newList, this.count); // equivalent to the loop above

            this.items = newList;
        }

        public bool Contains(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException();
            }

            return this.IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < this.count; i++)
            {
                if (this.items[i]!.Equals(item)) // the symbol ! assures the compiler that this.items[i] is not null
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException();
            }

            if (item is null)
            {
                throw new ArgumentNullException();
            }

            if (this.count == this.items.Length)
            {
                this.Grow();
            }

            for (int i = this.count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.count++;
        }

        public bool Remove(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException();
            }

            int itemIndex = this.IndexOf(item);

            if (itemIndex < 0)
            {
                return false;
            }

            this.RemoveAt(itemIndex);

            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < this.count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[--this.count] = default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
