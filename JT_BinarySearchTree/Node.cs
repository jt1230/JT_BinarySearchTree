using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT_BinarySearchTree
{
	// Code from David
	public class Node<T>
    {
		public T Data { get; set; }
		public Node<T>? LeftChild { get; set; }
		public Node<T>? RightChild { get; set; }

		public Node(T value)
		{
			LeftChild = null;
			RightChild = null;
			Data = value;
		}

		public int GetBalance()
		{
			int left = (LeftChild == null) ? 0 : LeftChild.GetBalanceHelper(1);
			int right = (RightChild == null) ? 0 : RightChild.GetBalanceHelper(1);
			return right - left;
		}

		// Help from Thomas to fix GetBalance()
		private int GetBalanceHelper(int level)
        {
			int left = (LeftChild == null) ? level : LeftChild.GetBalanceHelper(level + 1);
			int right = (RightChild == null) ? level : RightChild.GetBalanceHelper(level + 1);
			return left > right ? left : right;
		}
	}
}
