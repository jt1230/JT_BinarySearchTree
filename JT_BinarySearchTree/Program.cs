using JT_BinarySearchTree;

BinarySearchTree<int> tree = new();
const int TREE_SIZE = 20;

var rand = new Random();
for (int i = 0; i < TREE_SIZE; i++)
{
    //tree.Insert(rand.Next(1,101));
    tree.Insert(i);
}
Console.WriteLine("Count: " + tree.Count()); // 20
Console.WriteLine("13 exist: " + tree.Exists(13)); // true
Console.WriteLine("5 exist: " + tree.Exists(5)); // true
Console.WriteLine("-37 exist: " + tree.Exists(-37)); // false
Console.WriteLine("1337 exist: " + tree.Exists(1337)); // false
tree.Balance(); // 19
