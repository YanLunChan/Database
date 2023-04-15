/*
 * Author: Yan Lun Chan
 * Date: March 2023
 */
using System;
using System.Collections.Generic;
namespace Trees
{
    /// <summary>
    /// Binary Search Tree:
    /// Node based binary tree data structure that follow certain sets of rule:
    /// -left subtree are smaller than the parent
    /// -right subtree are greater than parent
    /// -left and right subtree must be a binary search tree.
    /// </summary>
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        Node_Tree<T> root;

        /// Insert:
        /// when inserting the insert function will call the insert recursion class. The insert recursion will go down the binary tree (left if smaller and right if bigger) 
        /// until function reaches null then function will overwrite null and set the node to the parameter. <summary>
        /// Insert:

        public void Insert(Node_Tree<T> node) => root = Insert_Recursion(root, node);
        private Node_Tree<T> Insert_Recursion(Node_Tree<T> root, Node_Tree<T> node) 
        {
            //base case
            if(root == null) 
            {
                root = node;
                return root;
            }
            else if(node.value.CompareTo(root.value) < 0) 
                root.left = Insert_Recursion(root.left, node);
            else 
                root.right = Insert_Recursion(root.right, node);
            return root;
        }
        public void Display() => Display_Recusion(root);
        private void Display_Recusion(Node_Tree<T> root) 
        {
            //use In Order Traversal, since lowest value will be in the left most, then root, then right.
            if(root != null) 
            {
                Display_Recusion(root.left);
                Console.WriteLine(root.value);
                Display_Recusion(root.right);

            }
        }
        public bool Search(T value) => Search_Recusion(root, value);
        private bool Search_Recusion(Node_Tree<T> root, T value) 
        {
            if (root == null)
                return false;
            else if (root.value.Equals(value))
                return true;
            else if (root.value.CompareTo(value) > 0)
                return Search_Recusion(root.left, value);
            else
                return Search_Recusion(root.right, value);
        }
        public void Remove(T value) 
        {
            if (Search(value))
                Remove_Recusion(root, value);
            else
                Console.WriteLine("error");
        }
        private Node_Tree<T> Remove_Recusion(Node_Tree<T> root, T value) 
        {
            if(root == null) 
            {
                return root;
            }
            else if (value.CompareTo(root.value) < 0) 
            {
                root.left = Remove_Recusion(root.left, value);
            }
            else if(value.CompareTo(root.value) > 0) 
            {
                root.right = Remove_Recusion(root.right, value);
            }
            else 
            {
                //if node is found
                if(root.left == null && root.right == null) 
                {
                    root = null;
                }
                else if(root.right != null) 
                {
                    root.value = Successor(root);
                    root.right = Remove_Recusion(root.right, root.value);
                }
                else 
                {
                    root.value = Predecessor(root);
                    root.left = Remove_Recusion(root.left, root.value);
                }
            }
            return root;
        }
        
        private T Successor(Node_Tree<T> root) 
        { 
            root = root.right;
            if(root.left != null) 
            {
                root = root.left;
            }
            return root.value;
        }
        private T Predecessor(Node_Tree<T> node) 
        {
            root = root.left;
            if (root.right != null)
            {
                root = root.right;
            }
            return root.value;
        }
    }
}
