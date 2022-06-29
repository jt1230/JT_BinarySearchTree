using JT_BinarySearchTree;

BinarySearchTree<int> tree = new();
const int TREE_SIZE = 5;
var rand = new Random();

for (int i = 0; i < TREE_SIZE; i++)
{
    //tree.Insert(rand.Next(1,101));
    
}

int[] testNum = new int[] {10, 5, 31, 11, 2, 67, 42};

foreach (var item in testNum)
{
    tree.Insert(item);
}
Console.WriteLine("Count: " + tree.Count()); // 7
Console.WriteLine("10 exists: " + tree.Exists(10)); // true
Console.WriteLine("5 exists: " + tree.Exists(5)); // true
Console.WriteLine("-37 exists: " + tree.Exists(-37)); // false
Console.WriteLine("1337 exists: " + tree.Exists(1337)); // false
Console.Write("Depth: ");
tree.Balance(); // TODO: 1
Console.WriteLine("Print:");
tree.Print();
Console.WriteLine();
Console.WriteLine("Removing leaf 2 ...");
tree.Remove(2);
Console.WriteLine("Done");
Console.WriteLine("Count: " + tree.Count()); // 6
//Console.WriteLine("Removing leaf 5 ...");
//tree.Remove(5);
//Console.WriteLine("Count: " + tree.Count()); // 5
Console.WriteLine("Print:");
tree.Print();
