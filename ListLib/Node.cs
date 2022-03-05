namespace ListLib;

public sealed class Node<T>
{
    public Node<T>? Prev { get; set; }
    public Node<T>? Next { get; set; }
    public T? Data { set; get; }

    public Node(T data)
    {
        Data = data;
        Prev = Next = null;
    }

    internal void ResetElement()
    {
        Data = default;
        Prev = Next = null;
    }
}