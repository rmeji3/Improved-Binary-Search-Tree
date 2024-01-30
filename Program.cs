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
            Console.WriteLine("\nNumber of trees: " + BST.GetNumTrees());

            BST t2 = new BST(t);
            
            Console.WriteLine("\nNumber of trees: " + BST.GetNumTrees());
            
            Console.WriteLine("\nTree 1 in Order: ");
            t.PrintTree();
            Console.WriteLine("\nTree 2 in Order: ");
            t2.PrintTree();

            Console.WriteLine();
            t2.DeleteNode(9);
            
            Console.WriteLine("\nTree 1 in Order: ");
            t.PrintTree();
            Console.WriteLine("\nTree 2 in Order: ");
            t2.PrintTree();
            
            t2.PrintPath(9);
            t2.PrintPath(18);
            
            t2.DeleteNode(1);
            t2.DeleteNode(3);

            
            t2.PrintInOrderTree();
            List<int>rangeList1 = t2.RangeSearch(1, 3);
            Console.WriteLine("Range List between 1 and 3: ");
            foreach (var x in rangeList1)
            {
                Console.Write(x + " ");
            }

            List<int>rangeList2 = t2.RangeSearch(5, 15);
            Console.WriteLine("Range List between 5 and 15: ");
            foreach (var x in rangeList2)
            {
                Console.Write(x + " ");
            }
            
            Console.WriteLine( "\ntree2 to string:\n" + t2.ToString() + "\n");

            BST t3 = t.Difference(t2);
            
            Console.WriteLine("\ntree 1:");
            t.PrintTree();
            Console.WriteLine("\ntree 2:");
            t2.PrintTree();
            Console.WriteLine("\ntree 3 set difference:");
            t3.PrintTree();
            
            BST t4 = t.Intersection(t2);
            
            Console.WriteLine("\ntree 1:");
            t.PrintTree();
            Console.WriteLine("\ntree 2:");
            t2.PrintTree();
            Console.WriteLine("\ntree 4 set difference:");
            t4.PrintTree();
            
            BST t5 = t.Union(t2);
            
            Console.WriteLine("\ntree 1:");
            t.PrintTree();
            Console.WriteLine("\ntree 2:");
            t2.PrintTree();
            Console.WriteLine("\ntree 5 set union:");
            t5.PrintTree();

            BST t6 = new BST();
            
            Console.WriteLine();
            t6.ImportCSV("numbers.csv");
            
            Console.WriteLine("\nNumber of elements in tree: " + t6.GetSize());
            t6.PrintTree();
            
            t3.ExportCsv("test.csv");
            Console.WriteLine();
            t3.PrintTree();
            BST t7 = new BST();
            t7.ImportCSV("test.csv");
            Console.WriteLine("\nNumber of elements in tree: " + t7.GetSize());
            t7.PrintTree();
            



        }
    }
}