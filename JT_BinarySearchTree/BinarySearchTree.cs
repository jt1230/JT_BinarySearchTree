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
            // Methods that you may find useful:
            // private int GetMaxDepth()
            // private int GetMinDepth()
            Console.WriteLine(Root.GetBalance()); // TODO
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
            if (Exists(value)) return; // TODO: inga dubletter tillåts :)

            var node = new Node<T>(value);
            if (Root == null)
            {
                Root = node;
                count++;
                return;
            }

            var current = Root;
            while (true)
            {
                if (node.Data.CompareTo(current.Data) < 0)
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = node;
                        count++;
                        return;
                    }
                    current = current.LeftChild;
                }
                else
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = node;
                        count++;
                        return;
                    }
                    current = current.RightChild;
                }
            }
        }

        public void Remove(T value)
        // TODO: när nod inte är löv
        // TODO: finns det snyggare lösningsförslag för att spara parent???
        {
            if (Root == null) return;

            var current = Root;
            var parent = Root;

            while (current != null && current.Data.CompareTo(value) != 0)
            {
                parent = current;
                if (current.Data.CompareTo(value) > 0) current = current.LeftChild;
                else current = current.RightChild;
            }
            
            if (current == null) return;

            if (current.RightChild == null && current.LeftChild == null) // sökt nod hittad - löv
            {
                if (current == Root) Root = null;
                else if (current == parent.LeftChild) parent.LeftChild = null;
                else parent.RightChild = null;
                count--;
            }
            else if(current.RightChild == null) // sökt nod har en leftChild
            {
                if (current == parent.LeftChild) parent.LeftChild = current.LeftChild;
                else parent.RightChild = current.LeftChild;
                count--;
            }
            else if (current.LeftChild == null) // sökt nod har en rightChild
            {
                if (current == parent.RightChild) parent.RightChild = current.RightChild;
                else parent.LeftChild = current.RightChild;
                count--;
            }
            else // sökt nod har både right- och leftChild
            {
                if(current == parent.LeftChild) // vänstra subträdet
                {
                    if(current.LeftChild.RightChild == null) // om currents vänstra barn inte har en höger child (lättare switch)
                    {
                        current.LeftChild.RightChild = current.RightChild;
                        parent.LeftChild = current.LeftChild;
                    }
                    else // måste hitta current.LeftChilds mest högra nod
                    {
                        var rightestNode = current.LeftChild.RightChild;
                        
                        while (rightestNode.RightChild != null)
                        {
                            rightestNode = rightestNode.RightChild;
                        }
                        rightestNode.RightChild = current.RightChild;
                        rightestNode.LeftChild = current.LeftChild;
                        parent.LeftChild = rightestNode;
                        parent.LeftChild.LeftChild.RightChild = null;
                    }
                }
                else // högra subträdet
                {
                    if (current.LeftChild.RightChild == null) // om currents vänstra barn inte har en höger child (lättare switch)
                    {
                        current.LeftChild.RightChild = current.RightChild;
                        parent.LeftChild = current.LeftChild;
                    }
                    else // måste hitta current.LeftChilds mest högra nod
                    {
                        var rightestNode = current.LeftChild.RightChild;

                        while (rightestNode.RightChild != null)
                        {
                            rightestNode = rightestNode.RightChild;
                        }
                        rightestNode.RightChild = current.RightChild;
                        rightestNode.LeftChild = current.LeftChild;
                        parent.LeftChild = rightestNode;
                        parent.LeftChild.LeftChild.RightChild = null;
                    }
                }
            }
        }

        // Code from David
        public void Print()
        {
            Queue<Node<T>?> nodes = new Queue<Node<T>?>();
            Queue<Node<T>?> newNodes = new Queue<Node<T>?>();
            nodes.Enqueue(Root);
            //int maxDepth = Root.GetDepth();
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
