# Reflection

Reflection is a collection of features available in programming languages that allows the program to "reflect" upon itself during the runtime. It allows the program to get the types of objects during runtime - which maybe different from the type during compilation

```csharp
IEnumerable<int> enumerate = new List<int>();
```

## GetType, typeof methods
- GetType() method gets us the runtime type of the object (you use this with instances)
- typeof methods gets us the official type name (.NET CTS name) of our types (you use this with types)

```csharp
IEnumerable<string> strCollection = new Queue<string>();
strCollection.GetType() == typeof(Queue<string>) //true
```

## But.. there's more
- You can also use reflection to find out about properties, methods, annotations, attributes, etc.

## Pros
- It's very flexible
- It allows the program to change the behavior during runtime, based on user input/etc.

## Cons
- It's very difficult to read, it's hard to figure out what's going on 
- It's not very performant
