using ListLib;

Console.WriteLine("This project is a demo for 'ListLib' that contains a custom doubly linked list!");

var lst = new DoublyLinkedList<int>();

lst.Add(1);
lst.Add(2);
lst.Add(3);
lst.AddFirst(4);

foreach (var el in lst)
{
    Console.WriteLine(el);
}

Console.WriteLine("List contains 4: " + lst.Contains(4));

Console.WriteLine("Actual list size: " + lst.Count);
lst.Clear();
Console.WriteLine("List cleared!");
Console.WriteLine("Actual list size: " + lst.Count);
