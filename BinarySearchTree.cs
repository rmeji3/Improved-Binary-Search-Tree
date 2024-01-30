namespace BinarySearchTree;

/*
 * Author: Rafael Mejia
 * Date: 1/29/2024
 * Description: A binary search tree implementation with helpful methods 
 */

using System.IO;
using System.Text;
public class BST
{
    private static int numTrees = 0;

    public static int GetNumTrees()
    {
        return numTrees;
    }
    class Node
    {
        public int value;
        public Node left{get;set;}
        public Node right {get;set;}

        public Node(int input)
        {
            left = null;
            right = null;
            value = input;

        }
    }

    private Node root;
    private int size;

    public BST()
    {
        numTrees++;
        root = null;
        size = 0;
    }

    private void CopyHelper(Node original)
    {
        if (original == null)
        {
            return;
        }

        AddNode(original.value);
        CopyHelper(original.left);
        CopyHelper(original.right);

    }
    
    public BST(BST other)
    {
        CopyHelper(other.root);
    }
    
    //==============================private helper methods below====================================
    
    private void TravTree(Node curr, int input)
    {
        if (curr == null)
        {
            return;
        }
        if (input < curr.value && curr.left == null)
        {
            curr.left = new Node(input);
        }
        else if (input > curr.value && curr.right == null)
        {
            curr.right = new Node(input);
        }
        else if (input < curr.value)
        {
            TravTree(curr.left, input);
        }
        else if (input > curr.value)
        {
            TravTree(curr.right, input);
        }
         
        
    }
    
    private void leaf(Node curr, ref List<int> l)
    {
        if (curr == null)
        {
            return;
        }

        if (curr.left == null && curr.right == null)
        {
            l.Add(curr.value);
        }
        leaf(curr.left, ref l);
        leaf(curr.right, ref l);
        
    }

    private int depth(Node curr)
    {
        if (curr == null)
        {
            return 0;
        }

        return int.Max(depth(curr.left), depth(curr.right)+1);
    }

    private void print(Node curr)
    {
        if (curr == null)
        {
            return;
        }
        
        Console.Write(curr.value + " ");
        print(curr.left);
        print(curr.right);
    }
    private void PrintOrder(Node curr)
    {
        if (curr == null)
        {
            return;
        }
        
        
        PrintOrder(curr.left);
        Console.Write(curr.value + " ");
        PrintOrder(curr.right);
    }
    
    
    private void Del(Node curr, Node parent, int target, ref bool deleted)
    {
        if (curr == null)
        {
            return;
        }

        if (curr.value == target)
        {
            deleted = true;

            if (root == curr)
            {
                if (curr.left != null)
                {
                    Node tempNode = curr.left;
                    while (tempNode.right != null)
                    {
                        tempNode = tempNode.right;
                    }

                    tempNode.right = curr.right;
                    root = curr.left;
                    
                }
                else
                {
                    root = curr.right;
                }
            }
            else
            {
                if (parent.left == curr)
                {
                    if (curr.left != null)
                    {
                        Node tempNode = curr.left;
                        while (tempNode.right != null)
                        {
                            tempNode = tempNode.right;
                        }
                        parent.left = curr.left;
                        tempNode.right = curr.right;

                    }
                    else
                    {
                        parent.left = curr.right;
                    }
                    
                }
                else
                {
                    if (curr.left != null)
                    {
                        Node tempNode = curr.left;
                        while (tempNode.right != null)
                        {
                            tempNode = tempNode.right;
                        }
                        parent.right = curr.left;
                        tempNode.right = curr.right;

                    }
                    else
                    {
                        parent.right = curr.right;
                    }
                }
            }
            
            
        }
        else if (target < curr.value)
        {
            Del(curr.left, curr, target, ref deleted);
        }
        else if (target > curr.value)
        {
            Del(curr.right, curr, target, ref deleted);
        }
        
        
        
        
    }

    private void GANPreO(Node curr, ref List<int> l)
    {
        if (curr == null)
        {
            return;
        }
        l.Add(curr.value);
        GANPreO(curr.left, ref l);
        GANPreO(curr.right, ref l);
    }
    private void GANIO(Node curr, ref List<int> l)
    {
        if (curr == null)
        {
            return;
        }
        GANIO(curr.left, ref l);
        l.Add(curr.value);
        GANIO(curr.right, ref l);
    }
    private void GANPostO(Node curr, ref List<int> l)
    {
        if (curr == null)
        {
            return;
        }
        GANPostO(curr.left, ref l);
        GANPostO(curr.right, ref l); 
        l.Add(curr.value);
    }

    private bool F(Node curr, int target)
    {
        if (curr == null)
        {
            return false;
        }

        if (target == curr.value)
        {
            return true;
        }
        if (target < curr.value)
        {
            return F(curr.left, target);
        }
        if(target > curr.value)
        {
            return F(curr.right, target);
        }
        return false;
    }

    private int GMax(Node curr)
    {
        if (curr == null)
        {
            return -1;
        }

        if (curr.right == null)
            return curr.value;
        return GMax(curr.right);
    }
    private int GMin(Node curr)
    {
        if (curr == null)
        {
            return -1;
        }

        if (curr.left == null)
            return curr.value;
        return GMin(curr.left);
    }

    private void Path(Node curr, int target, ref bool found, ref List<int> l)
    {
        if (curr == null)
        {
            return;
        }

        if (target == curr.value)
        {
            l.Add(curr.value);
            found = true;
            return;
        }
        else if (target < curr.value)
        {
            l.Add(curr.value);
            Path(curr.left, target, ref found, ref l);
        }
        else if (target > curr.value)
        {
            l.Add(curr.value);
            Path(curr.right, target, ref found, ref l);
        }
        
    }

    private void Range(Node curr, int min, int max, ref List<int> l)
    {
        if (curr == null)
        {
            return;
        }

        
        if (min < curr.value)
        {
            Range(curr.left, min, max, ref l);
        }

     
        if (min <= curr.value && curr.value <= max)
        {
            l.Add(curr.value);
        }

        
        if (max > curr.value)
        {
            Range(curr.right, min, max, ref l);
        }
    }

    
    
    //====================================public methods below===================================
    
    /// <summary>
    /// Non-return method takes int input and inserts into the tree.
    /// </summary>
    public void AddNode(int input)
    {
        if (root == null)
        {
            root = new Node(input);
        }
        else
        {
            TravTree(root, input);
        }

        size++;

    }
    
    /// <summary>
    /// Returns the root int value of the tree.
    /// </summary>
    public int GetRoot()
    {
        return root.value;
    }

    /// <summary>
    /// Returns the int size of the tree.
    /// </summary>
    public int GetSize()
    {
        return size;
    }

    /// <summary>
    /// Returns a list of the leaves.
    /// </summary>
    public List<int> GetLeaves()
    {
        List<int> l = new List<int>();
        leaf(root, ref l);
        return l;
    }

    /// <summary>
    /// Returns int maximum height of the tree.
    /// </summary>
    public int GetMaxHeight()
    {
        return depth(root);
    }
    
    
    /// <summary>
    /// Returns a list of all the values of the tree
    /// in pre-order.
    /// </summary>
    public List<int> GetAllNodesPre()
    {
        List<int> l = new List<int>();
        GANPreO(root, ref l);
        return l;
    }
    /// <summary>
    /// Returns a list of all the values of the tree
    /// in in-order.
    /// </summary>
    public List<int> GetAllNodesIn()
    {
        List<int> l = new List<int>();
        GANIO(root, ref l);
        return l;
    }
    /// <summary>
    /// Returns a list of all the values of the tree
    /// in post-order.
    /// </summary>
    public List<int> GetAllNodesPost()
    {
        List<int> l = new List<int>();
        GANPostO(root, ref l);
        return l;
    }

    /// <summary>
    /// Non-return method that prints the tree in pre-order.
    /// </summary>
    public void PrintTree()
    {
        Console.WriteLine("Current tree:");
        print(root);
    }
    /// <summary>
    /// Non-return method that prints the tree in-order.
    /// </summary>
    public void PrintInOrderTree()
    {
        Console.WriteLine("Current tree in order:");
        PrintOrder(root);
    }
    /// <summary>
    /// Deletes specified target value from the tree
    /// </summary>
    public void DeleteNode(int target)
    {
        bool deleted = false;
        Del(root, null, target, ref deleted);

        if (deleted == true)
        {
            Console.WriteLine("\nSuccessfully deleted " + target + " from the tree!");
            size--;
        }
        else
        {
            Console.WriteLine("The value " + target + " is not in the tree!");
        }
    }
    
    /// <summary>
    /// Returns true if value is found in the tree
    /// Returns false if not found
    /// </summary>
    public bool Find(int target)
    {
        return F(root, target);
    }

    /// <summary>
    /// Returns highest value in the tree
    /// </summary>
    public int GetMax()
    {
        return GMax(root);
    }
    /// <summary>
    /// Returns lowest value in the true
    /// </summary>
    public int GetMin()
    {
        return GMin(root);
    }
    /// <summary>
    /// Non-return method that prints the path to a target value
    /// </summary>
    public void PrintPath(int target)
    {
        bool found = false;
        List<int> l = new List<int>();

        Path(root, target, ref found, ref l);
        if (found)
        {
            Console.WriteLine("Path to " + target + ": ");
            foreach (var x in l)
            {
                Console.Write(x + " ");
            }
        }
        else
        {
            Console.WriteLine("\nTarget not found");
        }
        

    }

    /// <summary>
    /// Returns list of search in range from min to max
    /// </summary>
    public List<int> RangeSearch(int min, int max)
    {
        if (max < min)
        {
            throw new ArgumentException("The max must be higher than the min");
        }

        List<int> l = new List<int>();
        Range(root, min, max, ref l);

        if (l.Count == 0)
        {
            Console.WriteLine("There are no values in the range.");
        }

        return l;
    }

    /// <summary>
    /// Returns a string of the tree
    /// </summary>
    public override string ToString()
    {
        string s = "";
        foreach (int x in GetAllNodesIn())
        {
            s = s + x.ToString() + " ";
        }

        return s;
    }

    /// <summary>
    /// Returns a tree of the set difference
    /// </summary>
    public BST Difference(BST otherTree)
    {
        BST t3 = new BST();
        
        HashSet<int> set1 = new HashSet<int>(GetAllNodesPre());
        HashSet<int> set2 = new HashSet<int>(otherTree.GetAllNodesPre());
        
        set1.ExceptWith(set2);

        foreach (var x in set1)
        {
            t3.AddNode(x);
        }


        return t3;
    }
    /// <summary>
    /// Returns a tree of the set intersection
    /// </summary>
    public BST Intersection(BST otherTree)
    {
        BST t3 = new BST();
        
        HashSet<int> set1 = new HashSet<int>(GetAllNodesPre());
        HashSet<int> set2 = new HashSet<int>(otherTree.GetAllNodesPre());
        
        set1.IntersectWith(set2);

        foreach (var x in set1)
        {
            t3.AddNode(x);
        }


        return t3;
    }
    /// <summary>
    /// Returns a tree of the set union
    /// </summary>
    public BST Union(BST otherTree)
    {
        BST t3 = new BST();
        
        HashSet<int> set1 = new HashSet<int>(GetAllNodesPre());
        HashSet<int> set2 = new HashSet<int>(otherTree.GetAllNodesPre());
        
        set1.UnionWith(set2);
        foreach (var x in set1)
        {
            t3.AddNode(x);
        }


        return t3;
    }
    /// <summary>
    /// Non-return method that fills tree with specified csv file
    /// </summary>
    public void ImportCSV(String fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                foreach (var x in line.Split(","))
                {
                    // Console.WriteLine(x.Replace(" ", ""));
                    AddNode(Int32.Parse(x));
                }
                
            }
        }
    }
    
    /// <summary>
    /// Non-return method that export tree to specified csv file
    /// </summary>
    public void ExportCsv(String fileName)
    {
        StringBuilder csvContent = new StringBuilder();
        int elementsPerLine = 5;
        for (int i = 0; i < size; i++)
        {
            csvContent.Append(GetAllNodesPre()[i]);
            
            if ((i + 1) % elementsPerLine != 0 && i != GetAllNodesPre().Count - 1)
                csvContent.Append(",");
            else
                csvContent.AppendLine();
        }

        string filePath = fileName;
        File.WriteAllText(filePath, csvContent.ToString());
    }
    
}