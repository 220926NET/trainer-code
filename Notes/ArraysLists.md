# Arrays, Lists

## Array
- Array is a data structure that can hold same type of data together
- In order to create an array
```csharp
datatype[] varName = new dataType[lengthofarray];
```
- Access items by its index using `arrName[index]`
- Arrays are 0 indexed, which means the index starts at 0
- Be careful when you loop through an array in for loop, that you don't accidentally read `arr[arrLength]` (you'll get index out of bound exception)
- Get Length (the capacity) of array by the Length property (`arr.Length`)
- and an item at a certain index by `arr[index]`
- Arrays are immutable, which means once you create it, you can't resize it
    - If you run out of space, you create a bigger one and copy over everything, and reassign

## Lists
- Lists are part of System.Collections.Generic namespace
    - If you want to use Lists, you have to put `using System.Collections.Generic;` on top of your file
- List is an auto-resizing array
- To see the # of elements in a list, list.Count
- to see the current capacity of the backing data structure, list.Capacity
- to add a new element, list.Add()
- to access element by index, `list[index]`
- For other functionalities... https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0

