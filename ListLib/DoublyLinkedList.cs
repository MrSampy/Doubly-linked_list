namespace ListLib;

public class DoublyLinkedList<T>
{
    private Element<T> _FirstElement, _LastElement;
    private int _Length = 0;

    public int _length
    {
        get { return _Length; }
    }

    public void Add(T element)
    {
        Element<T> tempel = new Element<T>(element);
        if (_FirstElement == null)
            _FirstElement = tempel;
        else
        {
            _LastElement._NextEl = tempel;
            tempel._PrevEl = _LastElement;
        }

        _LastElement = tempel;
        ++_Length;
    }

    public void Clear()
    {
        _FirstElement = null;
        _LastElement = null;
        _Length = 0;
    }

    public void AddFirstEl(T element)
    {
        Element<T> tempel = new Element<T>(element);
        Element<T> newFirstEl = _FirstElement;
        tempel._NextEl = newFirstEl;
        _FirstElement = tempel;
        if (_Length == 0)
            _LastElement = _FirstElement;
        else
            newFirstEl._PrevEl = tempel;
        ++_Length;
    }

    public bool Contains(T element)
    {
        Element<T> tempel = _FirstElement;
        while (element != null)
        {
            if (tempel._Data == element)
                return true;
            tempel = tempel._NextEl;
        }

        return false;
    }
}