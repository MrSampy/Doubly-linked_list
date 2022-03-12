using System.Collections;

namespace ListLib;

public class DoublyLinkedList<T> : ICollection<T> where T: IComparable
{
    internal Node<T>? Head { get; private set; }
    internal Node<T>? Tail { get; private set; }

    public int Count { get; private set; }
    public bool IsReadOnly {get { return false; }}

    public void Add(T element)
    {
        var temp = new Node<T>(element);

        // This is a first element, so head & tail is a same element
        if (Head == null)
        {
            Head = temp;
            Tail = temp;
        }

        Tail!.Next = temp;
        temp.Prev = Tail;
        Tail = temp;

        ++Count;
    }
    
    public void AddFirst(T element)
    {
        var temp = new Node<T>(element)
        {
            Next = Head
        };

        Head = temp;

        if (Count == 0)
        {
            Tail = Head;
        }
        else
        {
            Tail!.Next = temp;
        }

        ++Count;
    }

    public bool Contains(T? element)
    {
        var temp = Head;

        if (temp is null)
        {
            return false;
        }

        if (element is null && temp.Data is null)
        {
            return true;
        }

        do
        {
            if (temp.Data?.CompareTo(element) == 0)
            {
                return true;
            }

            temp = temp.Next;
        } while (temp?.Next != null);

        return temp!.Data?.CompareTo(element) == 0;
    }

    public void CopyTo(T?[] array, int arrayIndex)
    {      
        if(arrayIndex >= array.Length)
            return;
        var temp = Head;

        do
        {
            array[arrayIndex] = temp.Data;
            ++arrayIndex;
            temp = temp.Next;
        } while (temp?.Next != null || arrayIndex >= array.Length);
        
        
    }

    public bool Remove(T? item)
    {
        if (!Contains(item))
            return false;
        var nodetoremove = GetNode(item);
        var nextnode = nodetoremove.Next;
        var prevnode = nodetoremove.Prev;
        if (nextnode != null)
        {
            nextnode.Prev = prevnode;
        }
        if (prevnode != null)
        {
            prevnode.Next = nextnode;
        }
        return true;
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }
    public Node<T>? GetNode(T? item)
    {
        if (Head == null || item ==null)
            return null;
        var temp = Head;
        do
        {
            if (temp.Data?.CompareTo(item) == 0) 
                break;
            temp = temp.Next;
        } while (temp?.Next != null);
         return temp;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new DoublyLinkedListEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private struct DoublyLinkedListEnumerator : IEnumerator<T>
    {
        public T? Current { get; set; }
        object IEnumerator.Current => Current!;

        private int _index;
        private Node<T>? _currentNode;
        private readonly DoublyLinkedList<T> _list;


        public DoublyLinkedListEnumerator(DoublyLinkedList<T> list)
        {
            _list = list;

            _index = 0;
            _currentNode = list.Head;

            Current = list.Head != null
                ? list.Head.Data
                : default;
        }

        public bool MoveNext()
        {
            if (_currentNode == null) {
                _index = _list.Count + 1;
                return false;
            }

            ++_index;
            Current = _currentNode.Data;   
            _currentNode = _currentNode.Next;  
            if (_currentNode == _list.Head) {
                _currentNode = null;
            }

            return true;
        }

        public void Reset()
        {
            _index = 0;
            _currentNode = _list.Head;
            Current = default;
        }
        
        public void Dispose()
        {
        }
    }
}

