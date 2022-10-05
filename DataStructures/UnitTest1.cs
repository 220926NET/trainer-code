// using Xunit;
// using System;
// using System.Linq;

// namespace DataStructures;
// public class IntQueue
// {
//     public IntQueue() {
//         _backingArr = new int[INITIAL_CAPACITY];
//     }
//     const int INITIAL_CAPACITY = 8;
//     private int[] _backingArr;

//     private int _size = 0;
//     public int Size { get {
//         return _size;
//     }}

//     public void Enqueue(int n)
//     {
//         _backingArr[_size] = n;
//         _size++;
//     }
    
//     public int Capacity { get { return _backingArr.Length; }}
// }


// public class QueueTests
// {
//     [Fact]
//     public void ShouldCreate()
//     {
//         IntQueue q = new IntQueue();

//         Assert.NotNull(q);
//         Assert.Equal(q.Capacity, 8);
//     }

//     [Theory]
//     [InlineData("1, 2, 3, 4, 5")]
//     public void Enqueue(string input)
//     {
//         int[] inputs = input.Trim().Split(',').Select(i => int.Parse(i)).ToArray<int>();
//         IntQueue q = new IntQueue();

//         foreach(int i in inputs)
//         {
//             q.Enqueue(i);    
//         }

//         Assert.Equal(q.Capacity, 8);
//         Assert.Equal(q.Size, 5);
//     }
// }