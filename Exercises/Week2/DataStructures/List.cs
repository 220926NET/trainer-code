using Xunit;
using System;

namespace DataStructures;

public class IntList
{
    public IntList()
    {
        _backingArray = new int[INITIAL_CAP];
    }

    private const int INITIAL_CAP = 8;
    private int[] _backingArray;
    public void Add(int n) 
    {
        EnsureCapacity();
        _backingArray[_size] = n;
        _size++;
    }

    private void EnsureCapacity()
    {
        if(Size >= Capacity)
        {
            //we need to resize, we are about to run out of space
            //we create a new array with more space
            //and then we copy over everything from an old array to new array
            //and move the _backingArr to point at the new arr
            int[] newArr = new int[_backingArray.Length * 2];
            for(int i = 0; i < _backingArray.Length; i++)
            {
                newArr[i] = _backingArray[i];
            }
            _backingArray = newArr;
        }
    }

    public int Remove()
    {
        if(Size == 0) throw new Exception("List is empty");
        _size--;
        return _backingArray[_size];
    }

    private int _size = 0;

    //not settable, by other users
    public int Size { get { return _size; } }

    public int Capacity { get {return _backingArray.Length; }}
}

public class ListTests
{
    [Fact]
    public void ListShouldCreate()
    {
        //AAA
        IntList list = new();
        Assert.NotNull(list);
        Assert.Equal(list.Capacity, 8);
    }

    [Fact]
    public void AddTests()
    {
        //AAA

        IntList list = new();

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        Assert.Equal(list.Size, 4);
        Assert.Equal(list.Capacity, 8);
    }

    [Fact]
    public void RemoveTests()
    {
        IntList list = new();

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        list.Remove();
        int removedItem = list.Remove();


        Assert.Equal(removedItem, 3);
    }

    [Fact]
    public void AddBeyondInitialCap()
    {
        //AAA

        IntList list = new();

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(1);


        Assert.Equal(list.Size, 9);
        Assert.Equal(list.Capacity, 16);
    }

    [Fact]
    public void RemovingFromEmptyList()
    {
        IntList list = new();

        Assert.Throws<Exception>(() => list.Remove());
    }
}