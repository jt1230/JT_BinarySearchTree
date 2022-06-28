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
        private Node<T>? Current = null;
        private int count = 0;

        public void Balance()
        {
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
            var node = new Node<T>(value);
            if (Root == null)
            {
                Root = node;
                count++;
                return;
            }

            Current = Root;
            while (true)
            {
                if (node.Data.CompareTo(Current.Data) < 0) // om node < current
                {
                    if (Current.LeftChild == null)
                    {
                        Current.LeftChild = node;
                        count++;
                        return;
                    }
                    Current = Current.LeftChild;
                }
                else if(node.Data.CompareTo(Current.Data) > 0) // om node > current
                {
                    if (Current.RightChild == null)
                    {
                        Current.RightChild = node;
                        count++;
                        return;
                    }
                    Current = Current.RightChild;
                }
                else // node == current
                {
                    if (Current.LeftChild == null)
                    {
                        Current.LeftChild = node;
                        count++;
                    }
                    else if (Current.RightChild == null)
                    {
                        Current.RightChild = node;
                        count++;
                    }
                    else
                    {
                        // TODO: kolla vidare nästa icke tomma nod, kolla balansen för att gå höger vänster?
                    }
                }
            }
            }

        public void Remove(T value)
        {
            throw new NotImplementedException();
        }
    }
}
