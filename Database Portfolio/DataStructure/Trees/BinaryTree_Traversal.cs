/*
 * Author: Yan Lun Chan
 * Date: March 2023
 */
using System;

namespace Trees
{
    public class BinaryTree_Traversal<T>
    {
        public Node_Tree<T> root;

        //create example tree to showcase traveral
        public void CreateTree(T root, T left, T right, T lleft, T rleft) 
        {
            this.root = new Node_Tree<T>(root);
            this.root.left = new Node_Tree<T>(left);
            this.root.right = new Node_Tree<T>(right);
            this.root.left.left = new Node_Tree<T>(lleft);
            this.root.right.left = new Node_Tree<T>(rleft);
        }
        public void CreateTree(T root, T left, T Lleft, T Lright, T right, T Rleft, T Rright) 
        {
            this.root = new Node_Tree<T>(root);
            this.root.left = new Node_Tree<T>(left);
            this.root.left.left = new Node_Tree<T>(Lleft);
            this.root.left.right = new Node_Tree<T>(Lright);
            this.root.right = new Node_Tree<T>(right);
            this.root.right.left = new Node_Tree<T>(Rleft);
            this.root.right.right = new Node_Tree<T>(Rright);
        }

        /// <summary>
        /// In-order traversal Explanation:
        ///  Prints left most first, then root, then right.
        ///  
        /// </summary>
        public void InOrderT(Node_Tree<T> root)
        {
            if (root == null)
                return;
            InOrderT(root.left);
            Console.WriteLine(root.value);
            InOrderT(root.right);
        }

        /// <summary>
        /// Post-order traversal Explanation:
        /// Prints left most , then right, then root
        /// </summary>
        public void PostOrderT(Node_Tree<T> root) 
        {
            if (root == null)
                return;
            PostOrderT(root.left);
            PostOrderT(root.right);
            Console.WriteLine(root.value);
        }

        /// <summary>
        /// Pre-order traversal Explanation:
        /// prints root, then left then right
        /// 
        /// </summary>
        public void PreOrderT(Node_Tree<T> root) 
        {
            if (root == null)
                return;
            Console.WriteLine(root.value);
            PreOrderT(root.left);
            PreOrderT(root.right);
        }
    }
}
