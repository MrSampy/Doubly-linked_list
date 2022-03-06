using Xunit;

namespace ListLib.Tests;

public class DlsTests
{
    [Fact]
    public void AddElementsToDls()
    {
        var dls = new DoublyLinkedList<int>();
        
        dls.Add(1);
        dls.Add(2);
        dls.Add(3);
        
        Assert.Collection(dls,
            el => Assert.Equal(1, el),
            el => Assert.Equal(2, el),
            el => Assert.Equal(3, el));
    }

    [Fact]
    public void AddFirstElementToDls()
    {
        var dls = new DoublyLinkedList<int>()
        {
            1,
            2,
            3
        };

        dls.AddFirst(4);
        
        Assert.Collection(dls,
            el => Assert.Equal(4, el),
            el => Assert.Equal(1, el),
            el => Assert.Equal(2, el),
            el => Assert.Equal(3, el));
    }

    [Fact]
    public void AddOnlyFirstElementToDls()
    {
        var dls = new DoublyLinkedList<int>();

        dls.AddFirst(4);
        dls.AddFirst(3);
        dls.AddFirst(2);
        dls.AddFirst(1);

        Assert.Collection(dls,
            el => Assert.Equal(1, el),
            el => Assert.Equal(2, el),
            el => Assert.Equal(3, el),
            el => Assert.Equal(4, el));
    }

    [Fact]
    public void DlsContainsElement()
    {
        var dls = new DoublyLinkedList<int>()
        {
            1,
            2,
            3
        };

        Assert.True(dls.Contains(1));
        Assert.True(dls.Contains(2));
        Assert.True(dls.Contains(3));
    }

    [Fact]
    public void DlsEnumerateElements()
    {
        var dls = new DoublyLinkedList<int>()
        {
            1,
            2,
            3
        };

        var dslAsString = string.Join("", dls);
        
        Assert.Equal("123", dslAsString);
    }

    [Fact]
    public void DlsClear()
    {
        var dls = new DoublyLinkedList<int>()
        {
            1,
            2,
            3
        };

        dls.Clear();
        
        Assert.Equal(0, dls.Length);
    }
}