namespace DataStructuresExercise.Trees
{
    using Contracts;
    using DataStructuresExercise;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private Tree<T>? parent;
        private List<Tree<T>> children;

        public Tree(T value)
        {
            this.value = value;
            parent = default;
            children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public T Value => value;

        public Tree<T>? Parent => parent;

        public IReadOnlyCollection<Tree<T>> Children => children.AsReadOnly();

        public void AddChild(T parent, Tree<T> child)
        {
            Tree<T> parentNode = GetByValue(parent);

            if (parentNode is null)
            {
                throw new ArgumentNullException();
            }

            parentNode.children.Add(child);
            child.parent = parentNode;
        }

        private Tree<T> GetByValue(T value)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            Tree<T> current = this;

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                current = queue.Peek();
                if (current.value!.Equals(value))
                {
                    return current;
                };

                foreach (var child in current.children)
                {
                    queue.Enqueue(child);
                }
                queue.Dequeue();
            }

            return null;
        }

        public IEnumerable<T> OrderBfs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> result = new List<T>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                foreach (var child in queue.Peek().Children)
                {
                    queue.Enqueue(child);
                }

                result.Add(queue.Dequeue().value);
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var result = RecursiveDfs(new List<T>(), this);
            return result;
        }

        private List<T> RecursiveDfs(List<T> values, Tree<T> tree)
        {
            foreach (var child in tree.children)
            {
                RecursiveDfs(values, child);
            }

            values.Add(tree.value);
            return values;
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> node = GetByValue(nodeKey);

            if (node is null)
            {
                throw new ArgumentNullException();
            }

            if (node.parent is null) // node is the root
            {
                throw new ArgumentException();
            }

            node.parent?.children.Remove(node);
            node.parent = null;
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstChild = GetByValue(firstKey);
            Tree<T> secondChild = GetByValue(secondKey);

            if (firstChild is null || secondChild is null)
            {
                throw new ArgumentNullException();
            }

            if (firstChild.parent is null || secondChild.parent is null)
            {
                throw new ArgumentException();
            }

            Tree<T> firstParent = firstChild.parent;
            Tree<T> secondParent = secondChild.parent;

            int firstChildIndex = firstParent.children.IndexOf(firstChild);
            int secondChildIndex = secondParent.children.IndexOf(secondChild);

            firstParent.children[firstChildIndex] = secondChild;
            secondParent.children[secondChildIndex] = firstChild;

            firstChild.parent = secondParent;
            secondChild.parent = firstParent;
        }

        private bool RemoveIfDescendant(Tree<T> node, Tree<T> descendantToRemove)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(node);
            Tree<T>? current = default;

            while (queue.Count > 0)
            {
                current = queue.Peek();
                foreach (var child in current.children)
                {
                    if (child.Equals(descendantToRemove))
                    {
                        current.children.Remove(child);
                        return true;
                    }

                    queue.Enqueue(child);
                }

                queue.Dequeue();
            }

            return false;
        }
    }
}
