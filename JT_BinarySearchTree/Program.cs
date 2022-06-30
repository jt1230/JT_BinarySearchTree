using JT_BinarySearchTree;

BinarySearchTree<int> tree = new();
int[] testNum = new int[] {10, 5, 31, 3, 4, 21, 7, 42, 1, 11, 77};

foreach (var item in testNum)
{
    tree.Insert(item);
}

Console.WriteLine("Count: " + tree.Count()); // 11
Console.WriteLine("10 exists: " + tree.Exists(10)); // true
Console.WriteLine("5 exists: " + tree.Exists(5)); // true
Console.WriteLine("-37 exists: " + tree.Exists(-37)); // false
Console.WriteLine("1337 exists: " + tree.Exists(1337)); // false
Console.Write("Depth: ");
tree.Balance(); // TODO: 3-3 = 0
Console.WriteLine("Print:");
tree.Print();
Console.WriteLine();
//Tar bort en nod med L & R - L
//Console.WriteLine("Removing leaf 5 ...");
//tree.Remove(5);
//Console.WriteLine("Done");
//Tar bort en nod med L & R - R
Console.WriteLine("Removing leaf 31 ...");
tree.Remove(31);
Console.WriteLine("Done");
////Tar bort ett löv
//Console.WriteLine("Removing leaf 77 ...");
//tree.Remove(77);
//Console.WriteLine("Done");
////Tar bort en nod med endast R
//Console.WriteLine("Removing leaf 7 ...");
//tree.Remove(7);
//Console.WriteLine("Done");
Console.WriteLine("Print:");
tree.Print();
Console.WriteLine("Count: " + tree.Count()); // 10
