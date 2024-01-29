namespace BinarySearchTree;

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
                        parent.left = curr.right;
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

    private void GAN(Node curr, ref List<int> l)
    {
        if (curr == null)
        {
            return;
        }
        
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
        return depth(root)-1;
    }
    
    
    /// <summary>
    /// Returns a list of all the values of the tree.
    /// </summary>
    public List<int> GetAllNodes()
    {
        List<int> l = new List<int>();
        GAN(root, ref l);
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
    /// 
    /// </summary>
    public void DeleteNode(int target)
    {
        bool deleted = false;
        Del(root, null, target, ref deleted);

        if (deleted == true)
        {
            Console.WriteLine("Successfully deleted " + target + " from the tree!");
            size--;
        }
        else
        {
            Console.WriteLine("The value " + target + " is not in the tree!");
        }
    }
    
    public bool Find(int target)
    {
        return F(root, target);
    }

    public int GetMax()
    {
        return GMax(root);
    }

    public int GetMin()
    {
        return GMin(root);
    }
    



}