using JT_BinarySearchTree;

//         10     
//        /  \
//       7    31   
//      / \   / \
//     3   8 21  47
//    / \          \
//   2   4         77

BinarySearchTree<int> tree = new();
int[] testNum = new int[] {10, 7, 31, 3, 8, 21, 47, 2, 4, 77};

foreach (var item in testNum)
{
    tree.Insert(item);
}

Console.WriteLine("Count: " + tree.Count()); // 10

Console.WriteLine("10 exists: " + tree.Exists(10)); // true
Console.WriteLine("77 exists: " + tree.Exists(77)); // true
Console.WriteLine("-37 exists: " + tree.Exists(-37)); // false
Console.WriteLine("1337 exists: " + tree.Exists(1337)); // false

Console.Write("Tree status: ");
tree.Balance(); // Balanced tree

Console.WriteLine("Print tree:");
tree.Print();
Console.WriteLine();

//Tar bort en nod med L & R
//Console.WriteLine("Removing 3 ...");
//tree.Remove(3);
//Console.WriteLine("Done");

//Tar bort root med L & R
Console.WriteLine("Removing 10 ...");
tree.Remove(10);
Console.WriteLine("Done");

//Tar bort ett löv
//Console.WriteLine("Removing leaf 77 ...");
//tree.Remove(77);
//Console.WriteLine("Done");

//Tar bort en nod med endast R
//Console.WriteLine("Removing leaf 47 ...");
//tree.Remove(47);
//Console.WriteLine("Done");

Console.WriteLine("Print tree:");
tree.Print();

Console.WriteLine("Count: " + tree.Count()); // 9
