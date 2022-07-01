using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using JT_BinarySearchTree.Interfaces;

namespace JT_BinarySearchTree
{
    public class BinarySearchTree<T> : IBST_G<T>, IBST_VG<T> where T : IComparable<T>
    {
        private Node<T>? Root = null;
        private int count = 0;

        public void Balance()
        {
            if(Root.GetBalance() > 1) Console.WriteLine("Right subtree is deeper, unbalanced, need to rotate");
            else if(Root.GetBalance() < -1) Console.WriteLine("Left subtree is deeper, unbalanced, need to rotate");
            else Console.WriteLine("Tree is balanced");
        }

        public int Count()
        {
            return count;
        }

        public bool Exists(T value)
        {
            if (Root == null) return false;

            var node = Root;
            while (node != null)
            {
                if (node.Data.CompareTo(value) == 0) return true;
                else if (node.Data.CompareTo(value) > 0)
                    node = node.LeftChild;
                else node = node.RightChild;
            }
            return false;
        }

        public void Insert(T value)
        {
            if (Exists(value)) return;

            var node = new Node<T>(value);
            if (Root == null)
            {
                Root = node;
                count++;
                return;
            }

            var current = Root;
            bool isInserting = true;

            while (isInserting)
            {
                if (node.Data.CompareTo(current.Data) < 0)
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = node;
                        count++;
                        isInserting = false;
                    }
                    current = current.LeftChild;
                }
                else
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = node;
                        count++;
                        isInserting = false;
                    }
                    current = current.RightChild;
                }
            }

            //Balance() would have been called here to check the balance and another function to execute the balancing of the tree would then act accordingly after each insert
        }

        public void Remove(T value)
        {
            // empty tree
            if (Root == null) return;

            var current = Root;
            var parent = Root;
            bool isLeftChild = false;

            while (current != null && current.Data.CompareTo(value) != 0)
            {
                parent = current;
                if (current.Data.CompareTo(value) > 0)
                {
                    current = current.LeftChild;
                    isLeftChild = true;
                }
                else
                { 
                    current = current.RightChild;
                    isLeftChild = false;
                }
            }
            
            // searched node not found
            if (current == null) return;

            if (current.RightChild == null && current.LeftChild == null) // searched node is leaf node
            {
                if (current == Root) Root = null;
                else
                {
                    if (isLeftChild) parent.LeftChild = null;
                    else parent.RightChild = null;
                }
                count--;
            }
            else if(current.RightChild == null) // searched node has only a left node
            {
                if (current == Root) Root = current.LeftChild;
                else
                {
                    if (isLeftChild) parent.LeftChild = current.LeftChild;
                    else parent.RightChild = current.LeftChild;
                }
                count--;
            }
            else if (current.LeftChild == null) // searched node has only a right node
            {
                if (current == Root) Root = current.RightChild;
                else
                {
                    if (isLeftChild) parent.LeftChild = current.RightChild;
                    else parent.RightChild = current.RightChild;
                }
                count--;
            }
            else // searched node has a left node and a right node
            {
                // find the least greater node and let it take the place of searched node
                var successor = GetSuccessor(current);

                //readjust references above the removed node
                if (current == Root) Root = successor;
                else if (isLeftChild) parent.LeftChild = successor;
                else parent.RightChild = successor;
                count--;
            }
        }

        private Node<T> GetSuccessor(Node<T> node)
        {
            // right node of searched node will always be bigger than searched node, and the left node of the right node will then always be the least greater node in the right subtree of searched node
            var parentOfSuccessor = node;
            var successor = node;
            var current = node.RightChild;

            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.LeftChild;
            }

            // readjust the references accordingly 
            if(successor != node.RightChild)
            {
                parentOfSuccessor.LeftChild = successor.RightChild;
                successor.RightChild = node.RightChild;
            }
            successor.LeftChild = node.LeftChild;

            return successor;
        }

        // Code from David
        public void Print()
        {
            Queue<Node<T>?> nodes = new Queue<Node<T>?>();
            Queue<Node<T>?> newNodes = new Queue<Node<T>?>();
            nodes.Enqueue(Root);
            int depth = 0;

            bool exitCondition = false;
            while (nodes.Count > 0 && !exitCondition)
            {
                depth++;
                newNodes = new Queue<Node<T>?>();

                string xs = "[";
                foreach (var maybeNode in nodes)
                {
                    string data = maybeNode == null ? " " : "" + maybeNode.Data;
                    if (maybeNode == null)
                    {
                        xs += "_, ";
                        newNodes.Enqueue(null);
                        newNodes.Enqueue(null);
                    }
                    else
                    {
                        Node<T> node = maybeNode;
                        string s = node.Data.ToString();
                        xs += s.Substring(0, Math.Min(4, s.Length)) + ", ";
                        if (node.LeftChild != null) newNodes.Enqueue(node.LeftChild);
                        else newNodes.Enqueue(null);
                        if (node.RightChild != null) newNodes.Enqueue(node.RightChild);
                        else newNodes.Enqueue(null);
                    }
                }
                xs = xs.Substring(0, xs.Length - 2) + "]";

                Console.WriteLine(xs);

                nodes = newNodes;
                exitCondition = true;
                foreach (var m in nodes)
                {
                    if (m != null) exitCondition = false;
                }
            }
        }
    }
}
