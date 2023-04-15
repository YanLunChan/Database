/*
 * Author: Yan Lun Chan
 * Date: March 2023
 */
namespace Trees
{
    public class Node_Tree<T>
    {
        public T value;
        public Node_Tree<T> left, right;

        public Node_Tree(T value)
        {
            this.value = value;
        }
    }
}
