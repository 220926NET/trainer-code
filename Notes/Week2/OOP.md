# 4 Pillars of Object Oriented Programming
A(bstraction) P(olymorphism)I(nheritance)E(ncapsulation)

## Abstraction
- A process of hiding implementation details and showing only the functionalities to users
- Examples: 
    - Interface: it's a contact for public facing behaviors (methods)
        - Just the signature of public methods (No implementation)
        - these methods are implicitly abstract and public
    - Abstract Class: it's a class that has abstract non-access modifier
        - you can't instantiate it
        - you have to inherit the abstract class first and then actually provide the implementation detail
    - Interface vs Abstract Class
        - classes that either implement an interface or inherit abstract class they have to implement all methods/properties defined in those types
        - Interface is a contract used to provide certain functionalities, abstract class is more for managing internal states that all children will share
        - A class can only inherit one class but it can implement multiple interfaces
        - Abstract class can have constructors but not in interfaces.
    - Design patterns
        - Dependency Injection
        - Factory Pattern Method
        - Repository pattern
    - IRL
        - DVD player
        - Car
        - Computer
        - high level programming languages

## Encapsulation
- Data Wrapping:
    - Wrapping related things together
    - Taking (related) data and behavior and wrapping it in an object
    - Examples:
        - Classes
        - Namespace 
- Data Hiding:
    - Hiding irrelevant/sensitive data away from the users
    - Examples:
        - Access Modifier
        - Properties(getter/setter) and private backing fields

### Abstraction vs Encapsulation
- both tries to simplify what users see by taking care of the logic behind the scene
- Abstraction is not knowing what exactly what your data is going to do, but encapsulation is grouping the data together
- Encapsulation is more focused on data hiding while abstraction is more focused on the hiding the details
- abstraction is more for protecting state control and encapsulation is more for protecting data

- "Abstraction and encapsulation are complementary concepts: abstraction focuses on the observable behavior of an object...encapsulation focuses on the implementation that gives rise to this behavior“
    -` Object-Oriented Analysis and Design, Grady Booch

## Inheritance
- When subtypes take the trait and behavior of the parent type.
- You can inherit a class and modify the behavior in child class w/o affecting the parent class
    - Overriding
        - Virtual - in parent class
        - Override - child class
- IS-A relationship
    - Honda IS-A car
    - Cat IS-A(n) animal
    - An instance of child class Is-A instance of parent class

- Benefit:
    - Code reusability (single source of truth)
    - Up/Down Casting : allows the program to be more flexible

## Polymorphism
- An ability for something to have many forms

- Method Overriding
    - between parent class and child class
    - To provide an implementation that is more specific/relevant to the subtypes.
    - virtual/override modifier
    - In method signature... same name, same parameters

- Method Overloading
    - occurs inside the same class, same method name different parameters
    - This allows the method to act differently based on different inputs