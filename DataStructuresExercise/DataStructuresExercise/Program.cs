namespace DataStructuresExercise
{
    using Trees;
    using Contracts;
    using System.Text;

    internal class Program
    {
        public void Trees()
        {
            // Tree
            Tree<int> tree = new Tree<int>(1,
                                    new Tree<int>(2,
                                        new Tree<int>(4),
                                        new Tree<int>(5,
                                            new Tree<int>(8)),
                                        new Tree<int>(6)),
                                    new Tree<int>(3,
                                        new Tree<int>(7)));

            tree.AddChild(5, new Tree<int>(9));
            //tree.RemoveNode(5);

            string bfs = string.Join(", ", tree.OrderBfs());
            string dfs = string.Join(", ", tree.OrderDfs());

            Console.WriteLine(bfs);
            Console.WriteLine(dfs);

            tree.Swap(2, 8);
        }

        public void BinaryTrees()
        {
            //Binary Tree
            IAbstractBinaryTree<int> tree = new BinaryTree<int>(1,
                                                new BinaryTree<int>(2),
                                                new BinaryTree<int>(3,
                                                    null,
                                                    new BinaryTree<int>(4)));
            var preOrder = tree.PreOrder().Select(t => t.Value);
            var inOrder = tree.InOrder().Select(t => t.Value); ;
            var postOrder = tree.PostOrder().Select(t => t.Value);
            var indentedPreOrder = tree.AsIndentedPreOrder(0);

            StringBuilder sb = new StringBuilder();
            tree.ForEachInOrder(key => sb.Append(key).Append(", "));

            Console.WriteLine(string.Join(", ", preOrder));
            Console.WriteLine(string.Join(", ", inOrder));
            Console.WriteLine(string.Join(", ", postOrder));
            Console.Write(indentedPreOrder);
            Console.WriteLine(sb.Remove(sb.Length - 2, 1).ToString());
        }

        public void BinarySearchTrees()
        {
            IBinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(5);
            tree.Insert(4);

            tree.EachInOrder(Console.WriteLine);

            IBinarySearchTree<int> four = tree.Search(4);
            tree.Search(6);

            bool result = tree.Contains(4);
            result = tree.Contains(5);
            result = tree.Contains(8);
        }

        private void Heaps()
        {
            //MaxHeap<int> maxHeap = new MaxHeap<int>();
            //maxHeap.Add(10);
            //maxHeap.Add(3);
            //maxHeap.Add(6);
            //maxHeap.Add(2);
            //maxHeap.Add(5);
            //maxHeap.Add(7);
            //maxHeap.Add(12);

            //maxHeap.Add(25);
            //maxHeap.Add(16);
            //maxHeap.Add(17);
            //maxHeap.Add(12);
            //maxHeap.ExtractMax();
            //maxHeap.ExtractMax();
            //maxHeap.ExtractMax();
            //maxHeap.ExtractMax();

            MinHeap<int> minHeap = new MinHeap<int>();
            minHeap.Add(3);
            minHeap.Add(9);
            minHeap.Add(5);
            minHeap.Add(15);
            minHeap.Add(17);
            minHeap.Add(25);
            minHeap.Add(24);
            Console.WriteLine(minHeap.ExtractMin());
            Console.WriteLine(minHeap.ExtractMin());
            Console.WriteLine(minHeap.ExtractMin());
            Console.WriteLine(minHeap.ExtractMin());
        }

        static void Main(string[] args)
        {

        }
    }
}