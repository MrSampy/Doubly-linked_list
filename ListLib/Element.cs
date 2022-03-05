namespace ListLib;

public class Element<T>
{
    public Element(T data) => _Data = data;
    public T _Data { set; get; }
    public Element<T> _PrevEl { get; set; }
    public Element<T> _NextEl { get; set; }
}