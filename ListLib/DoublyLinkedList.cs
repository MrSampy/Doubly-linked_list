﻿using System.Collections;

namespace ListLib;

public class DoublyLinkedList<T> : IEnumerable<T> where T: IComparable
{
    internal Node<T>? Head { get; private set; }
    internal Node<T>? Tail { get; private set; }

    public int Length { get; private set; }

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

        ++Length;
    }
    
    public void AddFirst(T element)
    {
        var temp = new Node<T>(element)
        {
            Next = Head
        };

        Head = temp;

        if (Length == 0)
        {
            Tail = Head;
        }
        else
        {
            Tail!.Next = temp;
        }

        ++Length;
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

        while (temp?.Next != null)
        {
            if (temp.Data?.CompareTo(element) == 0)
            {
                return true;
            }

            temp = temp.Next;
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

