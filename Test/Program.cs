
using AVLTreeLibrary;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();
            tree.Insert(10);
            tree.Insert(1);
            tree.Insert(11);
            tree.Insert(303);
            tree.Insert(12);
            tree.Insert(89);
            tree.Insert(156);
            bool found = tree.Find(10);
            Console.WriteLine("Tree print:");
            tree.Print();
            tree.Delete(10);
            Console.WriteLine("Tree Print after delete");
            tree.Print();

            tree += 1;
            Console.WriteLine("Tree after +1");
            tree.Print();

            AVLTree tree2 = new AVLTree();
            tree2.Insert(10);
            tree2.Insert(1);
            tree2.Insert(11);
            tree2.Insert(25);
            Console.WriteLine("Second tree");
            tree2.Print();
            AVLTree mergedTree = tree + tree2;
            Console.WriteLine("Merget trees");
            mergedTree.Print();
        }
    }
}