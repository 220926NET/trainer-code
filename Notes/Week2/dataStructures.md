# Data Structures

- Time Complexity : The number of instructions it takes to complete a certain algorithm
- Space Complexity : concerned about the memory it take up to do the operation

## Big O Notation
Worse case scenario analysis

- Looking up a value -> 1 instruction
- given an array of n items, looking at every item of that array -> n instructions
- given an array of size n, looking at them twice -> 2*n instructions
- given an array of size n, looking at the entire array for every item in array -> n^2 instructions
- given an array of size n, triple nested loops -> n^3

Examples:
- O(1)
    - Looking up a value in an array by its index
    - assigning a value to a variable
    - comparison operators

- O(log_n): 
    - Binary Search (searching binary search tree)

- O(n):
    - looking at every item of an array
        - adding up values in an array
    - iterating through a loop
    - reversing an already sorted array (in whichever order it was given, without sorting it first) by reading backwards

O(nlog_n)
    - Quick sort, Merge sort
    - Recursive searching

O(n^2)
    - Naive sorts (bubble sort)
    - Nested loops

O(n^3)
    - Triple nested loops

O(2^n)
    - Solving traveling salesman by dynamic programming

O(n!)
    - Solving traveling salesman by brute force search

## Generic Collections

## List<T>
    - Dynamic arrays (which means they auto-resize)
    - We store one type at a time ex. List<int>, List<string>, List<FlashCard>, List<List<int>>, etc.
    - We add with .Add() or .AddRange(List<T>), remove with .RemoveAt()
    - Size property which gives you the # of items you have in the collection
    - Adding to the end of the list: O(1)
    - Looking at every item of the list: O(n)
    - Removing an item from a specified index: O(1)
    - Searching for an item: O(n)

## LinkedList<T>
    - It can't access an item by index in O(1)
    - Looking up an item at a certain position: O(n) 
    - If you don't have tail reference, you can't add to the list in O(1)
    - When working with singly linked list, you can't go back
    - It's super easy to add to the front of the linkedlist O(1)
    - Removing from front of the list: O(1)
    - ex: Playlist for songs (you already have a huge list of songs, you can just point around to create a linked list)
    - Any sequential operation
    - Use foreach loop to iterate through each item

## Queue<T>, Stack<T>
    - Queue: "First Come, First Served": First In First Out (FIFO)
    - Stack: Stack of pancakes: Last In, First Out (LIFO)
    - They are not meant to be searched for
    - Adding to the Queue: "Enqueue", removing from it: "Dequeue"
    - Stack: Adding: "push", removing: "pop"
    - "Peek" to look at what's next w/o removing it

## Dictionary<Tkey, TValue>
    - Key value pairs, ex. phonebook
    - Keys are unique, values are not
    - You can also directly access the value of key. `dictionary[key_name]`
    - Lookup table
    - Given a string, give me the most frequent letters
    - User DB, where the key is username, and the value is userData

## HashSet<T>
    - This ds does not store duplicates 
    - good for getting unique values from another ds that contains duplicates
    - counting how many unique words
    - Set operation (Intersect, Union, etc.)