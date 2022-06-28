namespace JT_BinarySearchTree.Interfaces
{
	public interface IBST_G<T> where T : IComparable<T>
	{
		public void Insert(T value);
		public bool Exists(T value);
		public int Count();
	}
}
