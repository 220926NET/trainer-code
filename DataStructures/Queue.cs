using System;
using Xunit;
using System.Linq;

namespace DataStructures;

public class IntQueue
{
    public IntQueue()
    {
        //initialize backing arr here
    }

    private int[] _backingArr;
    private int INITIAL_CAP = 8;
    public int Capacity { get {return _backingArr.Length;} }
    
    private int _size = 0;
    public int Size { get {return _size;} }

    public void Enqueue(int n)
    {
        //should do something here
        throw new NotImplementedException();

    }

    public int Dequeue()
    {
        //should return the front of the backing ds here
        throw new NotImplementedException();
    }
}

//Optional Generic Queue
// public class Queue<T>
// {
// }



public class QueueTests
{
    [Fact]
    public void ShouldCreate()
    {
        IntQueue q = new IntQueue();

        Assert.NotNull(q);
        Assert.Equal(q.Capacity, 8);
    }

    [Theory]
    [InlineData("1, 2, 3, 4, 5")]
    public void Enqueue(string input)
    {
        int[] inputs = input.Trim().Split(',').Select(i => int.Parse(i)).ToArray<int>();
        IntQueue q = new IntQueue();

        foreach(int i in inputs)
        {
            q.Enqueue(i);    
        }

        Assert.Equal(q.Capacity, 8);
        Assert.Equal(q.Size, 5);
    }

    [Theory]
    [InlineData("1, 2, 3, 4, 5")]
    public void Dequeue(string input)
    {
        int[] inputs = input.Trim().Split(',').Select(i => int.Parse(i)).ToArray<int>();
        IntQueue q = new IntQueue();

        foreach(int i in inputs)
        {
            q.Enqueue(i);    
        }

        int n = q.Dequeue();

        Assert.Equal(q.Capacity, 8);
        Assert.Equal(q.Size, 4);
        Assert.Equal(n, 1);
    }

    [Theory]
    [InlineData("1, 2, 3, 4, 5, 6, 7, 8, 9")]
    public void EnqueueBeyondInitialCap(string input)
    {
        int[] inputs = input.Trim().Split(',').Select(i => int.Parse(i)).ToArray<int>();
        IntQueue q = new IntQueue();

        foreach(int i in inputs)
        {
            q.Enqueue(i);    
        }

        Assert.Equal(q.Capacity, 16);
        Assert.Equal(q.Size, 9);
    }
}