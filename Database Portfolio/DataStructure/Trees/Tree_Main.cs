using System;
using System.Collections.Generic;
namespace Trees
{
    public class Tree_Main
    {
        public static void RunTree()
        {
            //Binary Tree Traversal  Variables
            BinaryTree_Traversal<int> treeTrav = new BinaryTree_Traversal<int>();
            
            //Binary Search Variables
            BinarySearchTree<int> treeSearch = new BinarySearchTree<int>();

            //---Binary Tree Traversal---//
            treeTrav.CreateTree(0,1,2,3,4,5,6);
            treeTrav.InOrderT(treeTrav.root);
            Console.WriteLine("\n");
            treeTrav.PostOrderT(treeTrav.root);
            Console.WriteLine("\n");
            treeTrav.PreOrderT(treeTrav.root);

            //---Binary Search Tree---//
            treeSearch.Insert(new Node_Tree<int>(5));
            treeSearch.Insert(new Node_Tree<int>(1));
            treeSearch.Insert(new Node_Tree<int>(9));
            treeSearch.Insert(new Node_Tree<int>(2));
            treeSearch.Insert(new Node_Tree<int>(7));
            treeSearch.Insert(new Node_Tree<int>(3));
            treeSearch.Insert(new Node_Tree<int>(6));
            treeSearch.Insert(new Node_Tree<int>(4));
            treeSearch.Insert(new Node_Tree<int>(8));

            Console.WriteLine($"\n\n");
            treeSearch.Display();
            Console.WriteLine($"\n\n");
            treeSearch.Remove(1);
            treeSearch.Display();
            Console.WriteLine($"\n\n{treeSearch.Search(5)}");
        }
    }
}
