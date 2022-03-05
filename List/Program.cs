namespace List
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
        public class Element<T>
        {   public Element(T data) => _Data = data; 
            public T _Data { set; get; }
            public Element<T> _PrevEl { get; set; }
            public Element<T> _NextEl { get; set; }
        }

        public class DoublyLinkedList<T>
        {
            private Element<T> _FirstElement, _LastElement;
            private int _Length = 0;
            public int _length{get{return _Length;}}
            public void Add(T element)
            {
                Element<T> tempel = new Element<T>(element);
                if (_FirstElement == null)
                    _FirstElement=tempel;
                else{
                    _LastElement._NextEl=tempel;
                    tempel._PrevEl=_LastElement;
                }
                _LastElement=tempel;
                ++_Length;
            }
            public void Clear()
            {
                _FirstElement=null;
                _LastElement=null;
                _Length=0;
            }
            
            
        }
        
        
    }
}   