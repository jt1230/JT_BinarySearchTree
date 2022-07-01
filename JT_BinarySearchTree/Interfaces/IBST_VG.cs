namespace JT_BinarySearchTree.Interfaces
{
	public interface IBST_VG<T> where T : IComparable<T>
	{
		public void Remove(T value);
		public void Balance();
	}
}
