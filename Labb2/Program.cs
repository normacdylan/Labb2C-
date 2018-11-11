using System;
using System.Linq;
namespace Labb2
{
    public class Program
    {
        public static void RunGTests()
        {
            Console.WriteLine(new Position(2, 4) + new Position(1, 2) + "\n");
            Console.WriteLine(new Position(2, 4) - new Position(1, 2) + "\n");
            Console.WriteLine(new Position(1, 2) - new Position(3, 6) + "\n");
            Console.WriteLine(new Position(3, 5) % new Position(1, 3) + "\n");

            SortedPosList list1 = new SortedPosList();
            SortedPosList list2 = new SortedPosList();
            list1.Add(new Position(3, 7));
            list1.Add(new Position(1, 4));
            list1.Add(new Position(2, 6));
            list1.Add(new Position(2, 3));
            Console.WriteLine(list1 + "\n");
            list1.Remove(new Position(2, 6));
            Console.WriteLine(list1 + "\n");

            list2.Add(new Position(3, 7));
            list2.Add(new Position(1, 2));
            list2.Add(new Position(3, 6));
            list2.Add(new Position(2, 3));
            Console.WriteLine((list2 + list1) + "\n");

            SortedPosList circleList = new SortedPosList();
            circleList.Add(new Position(1, 1));
            circleList.Add(new Position(2, 2));
            circleList.Add(new Position(3, 3));
            Console.WriteLine(circleList.CircleContent(new Position(5, 5), 4) + "\n");
        }

        public static void RunVGTests()
        {
            // Testing the subtraction-operator of SortedPosLists

            SortedPosList listA = new SortedPosList();
            SortedPosList listB = new SortedPosList();
            listA.Add(new Position(0.5, 0.5));
            listA.Add(new Position(1, 4));
            listA.Add(new Position(4.5, 0));
            listB.Add(new Position(1, 4));
            listB.Add(new Position(12, 5.6));

            SortedPosList listC = listA * listB;
            SortedPosList listD = listB * listA;
            // listC should be: {(0.5, 0.5), (4.5, 0)}
            Console.Write("List C: " + listC + "\n");
            // listD should be: {(12, 5.6)}
            Console.Write("List D: " + listD + "\n");




            // Testing construction of SortedPosList with path-variable and Saving/Loading

            string path1 = "list.txt";
            string path2 = "list2.txt";

            SortedPosList listFromPath1 = new SortedPosList(path1);
            listFromPath1.Add(new Position(2.3, 3.3));
            listFromPath1.Add(new Position(3.5, 8));

            // The new List should load from path1 and be the same as listFromPath1:
            // {(2.3, 3.3), (3.5, 8)}
            Console.Write("New list reading from path1: " + new SortedPosList(path1) + "\n");

            SortedPosList listFromPath2 = new SortedPosList(path2);
            listFromPath2.Add(new Position(2.1, 1.2));
            listFromPath2.Add(new Position(0, 100));
            listFromPath2.Remove(new Position(2.1, 1.2));

            // The new List should load from path2 and be the same as listFromPath2:
            // {(0, 100)}
            Console.Write("New list reading from path2: " + new SortedPosList(path2) + "\n");
        }

        static void Main(string[] args)
        {
            RunGTests();
            RunVGTests();
        }
    }
}
