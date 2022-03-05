namespace ListLib;

public class DoublyLinkedList<T>
{
    private Node<T> _firstNode, _lastNode;
    private int _Length = 0;

    public int _length
    {
        get { return _Length; }
    }

    public void Add(T element)
    {
        Node<T> tempel = new Node<T>(element);
        if (_firstNode == null)
            _firstNode = tempel;
        else
        {
            _lastNode.Next = tempel;
            tempel.Prev = _lastNode;
        }

        _lastNode = tempel;
        ++_Length;
    }

    public void Clear()
    {
        _firstNode = null;
        _lastNode = null;
        _Length = 0;
    }

    public void AddFirstEl(T element)
    {
        Node<T> tempel = new Node<T>(element);
        Node<T> newFirstEl = _firstNode;
        tempel.Next = newFirstEl;
        _firstNode = tempel;
        if (_Length == 0)
            _lastNode = _firstNode;
        else
            newFirstEl.Prev = tempel;
        ++_Length;
    }

    public bool Contains(T element)
    {
        Node<T> tempel = _firstNode;
        while (element != null)
        {
            if (tempel.Data == element)
                return true;
            tempel = tempel.Next;
        }

        return false;
    }
}