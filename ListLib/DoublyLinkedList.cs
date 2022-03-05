using System.Collections;

namespace ListLib;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    internal Node<T>? Head { get; private set; }
    internal Node<T>? Tail { get; private set; }

    public int Length { get; private set; }

    public void Add(T element)
    {
        Node<T> tempel = new Node<T>(element);
        if (Head == null)
        {
            Head = tempel;
        }
        else
        {
            Tail.Next = tempel;
            tempel.Prev = Tail;
        }

        Tail = tempel;
        ++Length;
    }
    
    public void AddFirstEl(T element)
    {
        Node<T> tempel = new Node<T>(element);
        Node<T> newFirstEl = Head;
        tempel.Next = newFirstEl;
        Head = tempel;
        if (Length == 0)
            Tail = Head;
        else
            newFirstEl.Prev = tempel;
        ++Length;
    }

    public bool Contains(T element)
    {
        Node<T> tempel = Head;
        while (element != null)
        {
            if (tempel.Data == element)
                return true;
            tempel = tempel.Next;
        }

        return false;
    }
    
    public void Clear()
    {
        Head = null;
        Tail = null;
        Length = 0;
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
                _index = _list.Length + 1;
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

