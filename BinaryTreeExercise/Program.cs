using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeExercise
{/// <summary>
/// 
/// </summary>
    class Program
    {
       
            class Node
            {
                public int value;
                public Node left;
                public Node right;
                //public char key;
            }
            class Tree
            {
                //EXERCISE 1 
                //recursive 
                public Node Insert(Node root, int v)
                {
                    if (root == null)
                    {
                        root = new Node();
                        root.value = v;
                    }
                    else if (v == root.value)
                    {
                        //RemoveNode(ref root, v);

                    }
                    else if (v < root.value)
                    {
                        root.left = Insert(root.left, v);
                    }
                    else
                    {
                        root.right = Insert(root.right, v);
                    }

                    return root;
                }
                //нерекурсивна реализация на добавяне на елемент        
                public void AddNR(ref Node root, int v)
                {
                    if (root == null)
                    {
                        root = new Node();
                        root.value = v;
                    }

                    else
                    {

                        Node newNode = new Node();
                        newNode.value = v;
                        Node prior = root;
                        Node next;
                        if (v < root.value)
                            next = root.left;

                        else
                            next = root.right;
                        while (next != null)
                        {
                            prior = next;
                            if (v < prior.value)
                                next = prior.left;
                            else if (v == prior.value)
                            {
                                RemoveNode(ref prior, v);
                                return;
                            }
                            else
                                next = prior.right;
                        }
                        if (v < prior.value)
                            prior.left = newNode;
                        else
                            prior.right = newNode;
                    }
                }
                //EXERCISE 2
                //рекурсивна реализация на търсене на елемент
                public static bool Search(Node root, int key)
                {
                    if (root == null)
                        return false;
                    if (root.value == key)
                        return true;
                    if (root.value > key)
                        return Search(root.left, key);
                    else
                        return Search(root.right, key);
                }
                // An iterative process to search 
                // an element x in a given binary tree  
                public static Boolean IterativeSearch(Node root,
                                               int v)
                {
                    // Base Case  
                    if (root == null)
                        return false;

                    // Create an empty queue for  
                    // level order traversal  
                    Queue<Node> q = new Queue<Node>();

                    // Enqueue Root and initialize height  
                    q.Enqueue(root);

                    // Queue based level order traversal  
                    while (q.Count > 0)
                    {
                        // See if current node is same as x  
                        Node node = q.Peek();
                        if (node.value == v)
                            return true;

                        // Remove current node and  
                        // enqueue its children  
                        q.Dequeue();
                        if (node.left != null)
                            q.Enqueue(node.left);
                        if (node.right != null)
                            q.Enqueue(node.right);
                    }
                    return false;
                }

                //намиране на минимален елемент в дясно поддърво
                static Node FindMinRight(Node root)
                {
                    Node p = root.right;
                    while (p.left != null)
                    {
                        p = p.left;
                    }
                    return p;
                }
                /// <summary>
                /// EXERCISE 3
                /// </summary>
                /// <param name="root"></param>
                /// <param name="key"></param>
                //рекурсивна реализация на изтриване на елемент
                public static void RemoveNode(ref Node root, int key)
                {
                    if (root == null)
                    {
                        Console.WriteLine("Node with this key does not exists in the tree");
                    }
                    else
                        if (key < root.value)
                        RemoveNode(ref root.left, key);
                    else
                    {
                        if (key > root.value)
                            RemoveNode(ref root.right, key);
                        else
                        {
                            if (root.left != null && root.right != null)
                            {
                                Node replace = FindMinRight(root);
                                root.value = replace.value;
                                RemoveNode(ref root.right, root.value);
                            }
                            else
                            {
                                Node temp = root;
                                if (root.left != null) root = root.left;
                                else root = root.right;
                                temp = null;
                            }
                        }
                    }

                }
                public static Node RemoveNodeIteratively(Node root, int v)
                {
                    Node parent = null, current = root;
                    bool hasLeft = false;

                    if (root == null)
                        return root;

                    while (current != null)
                    {
                        if (current.value == v)
                        {
                            break;
                        }

                        parent = current;
                        if (v < current.value)
                        {
                            hasLeft = true;
                            current = current.left;
                        }
                        else
                        {
                            hasLeft = false;
                            current = current.right;
                        }
                    }

                    if (parent == null)
                    {
                        return DeleteIteratively(current);
                    }
                    if (hasLeft)
                    {
                        parent.left = DeleteIteratively(current);
                    }
                    else
                    {
                        parent.right = DeleteIteratively(current);
                    }
                    return root;
                }

                private static Node DeleteIteratively(Node node)
                {
                    if (node != null)
                    {
                        if (node.left == null && node.right == null)
                        {
                            return null;
                        }
                        if (node.left != null && node.right != null)
                        {
                            Node inOrderSuccessor = DeleteInOrderSuccessorDuplicate(node);
                            node.value = inOrderSuccessor.value;
                        }
                        else if (node.left != null)
                        {
                            node = node.left;
                        }
                        else
                        {
                            node = node.right;
                        }
                    }
                    return node;
                }
                private static Node DeleteInOrderSuccessorDuplicate(Node node)
                {
                    Node parent = node;
                    node = node.right;
                    Boolean rightChild = node.left == null;

                    while (node.left != null)
                    {
                        parent = node;
                        node = node.left;
                    }

                    if (rightChild)
                        parent.right = node.right;
                    else
                    {
                        parent.left = node.right;
                    }

                    node.right = null;
                    return node;
                }
                //EXERCISE 4
                // КЛД обхождане на дървото
                public static void TraverseKLD(Node root)
                {
                    if (root == null)
                    {
                        return;
                    }
                    Console.Write(root.value + " ");
                    if (root.left != null)
                        TraverseKLD(root.left);
                    if (root.right != null)
                        TraverseKLD(root.right);
                }
                // ЛКД обхождане на дървото
                public static void TraverseLKD(Node root)
                {
                    if (root == null)
                    {
                        return;
                    }
                    if (root.left != null)
                        TraverseLKD(root.left);
                    Console.Write(root.value + " ");
                    if (root.right != null)
                        TraverseLKD(root.right);
                }
                // ЛДК обхождане на дървото
                public static void TraverseLDK(Node root)
                {
                    if (root == null)
                    {
                        return;
                    }
                    if (root.left != null)
                        TraverseLDK(root.left);
                    if (root.right != null)
                        TraverseLDK(root.right);

                    Console.Write(root.value + " ");
                }


                class BinaryTree
                {
                    static void Main(string[] args)
                    {
                        Node root = null;
                        Tree bst = new Tree();
                        int key = 5;
                        int size = 10;
                        int[] a = new int[size];
                        Console.WriteLine("Generating random array with {0} values...", size);
                        Random random = new Random();

                        for (int i = 0; i < size; i++)
                        {
                            a[i] = random.Next(40);

                        }
                        Console.WriteLine();

                        for (int i = 0; i < size; i++)
                        {
                            root = bst.Insert(root, a[i]);
                        }
                        Tree.TraverseLDK(root);

                        //adding note with key = 5
                        bst.AddNR(ref root, 5);
                        Console.WriteLine("Adding note with key = {0}.", key);
                        Console.WriteLine();

                        Tree.TraverseLDK(root);
                        Console.WriteLine();

                        Console.WriteLine("Walking the tree in direction root-left-rigth");
                        Tree.TraverseKLD(root);
                        Console.WriteLine();

                        Console.WriteLine("Walking the tree in direction left-right-root");
                        Tree.TraverseLDK(root);
                        Console.WriteLine();

                        Console.WriteLine("Walking the tree in direction left-root-rigth");
                        Tree.TraverseLKD(root);
                        Console.WriteLine();
                        key = 6;
                        Tree.Search(root, key);
                        Console.WriteLine((Tree.IterativeSearch(root, key) ?
                                                          " Key Found\n" :
                                                      "Key Not Found\n"));

                        Console.WriteLine("Deleting node with value {0} from binary tree", key);
                        Tree.RemoveNode(ref root, key);
                        Console.WriteLine();
                        Tree.TraverseLKD(root);

                        Console.ReadKey();
                    }
                }
            }
        }
    }

