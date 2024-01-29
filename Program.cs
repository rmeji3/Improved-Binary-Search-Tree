using System;
using BinarySearchTree;
namespace Program
{
    class Test
    {
        static void Main(string[] args)
        {
            BST t = new BST();
            t.AddNode(10);
            t.AddNode(5);
            t.AddNode(15);
            t.AddNode(3);
            t.AddNode(1);
            t.AddNode(4);
            t.AddNode(7);
            t.AddNode(6);
            t.AddNode(9);
            t.AddNode(13);
            t.AddNode(12);
            t.AddNode(14);
            t.AddNode(17);
            t.AddNode(16);
            t.AddNode(18);
            Console.WriteLine("Tree: ");
            t.PrintTree();
            Console.WriteLine("\nTree in Order: ");
            t.PrintInOrderTree();
            Console.WriteLine("\nThe tree's max height:  " + t.GetMaxHeight());
            List<int> l = t.GetLeaves();
            Console.WriteLine("Tree leaves:");
            foreach (var x in l)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Total Number of Nodes: " + t.GetSize());
            var j = 10;
            var h = 20;
            if (t.Find(j))
            {
                Console.WriteLine("The value " + j + " is in the tree!");
            }
            else
            {
                Console.WriteLine("The value " + j + " is not in the tree!");
            }
            if (t.Find(h))
            {
                Console.WriteLine("The value " + h + " is in the tree!");
            }
            else
            {
                Console.WriteLine("The value " + h + " is not in the tree!");
            }
            // t.DeleteNode(1);
            // t.PrintInOrderTree();
            // Console.WriteLine("\nDeleted 1 from the tree, there are now: " + t.GetSize() + " nodes");
            Console.WriteLine("The min value in the tree is: " + t.GetMin());
            Console.WriteLine("The max value in the tree is: " + t.GetMax());
            var rootNum = t.GetRoot();
            t.DeleteNode(rootNum);
            Console.WriteLine("\nDeleted " + rootNum + " from the tree, there are now: " + t.GetSize() + " nodes");
            Console.WriteLine("new root: " + t.GetRoot());
            t.PrintInOrderTree();
            
            
            
        }
    }
}