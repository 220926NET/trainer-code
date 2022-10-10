# SOLID

A collection of design principles that allows to create maintainable, scalable, extendable applications.

- Single Responsibility principle
    - class should only do one thing and one thing well
    - separation of concerns
    - looser coupling
    - easier testing
    - easier organization

- Open/Close principle
    - Software entity should be open for extension and closed for modification
    - You should be able to add features to it without changing everything in the process
    - Use abstraction (interfaces, abstract classes) to achieve the desired effect
    - Class Composition 

- Liskov Substitution principle
    - Subtypes should be able to replace supertypes w/o breaking
    - children should be able to do everything parent can do
    - related to inheritance

- Interface Segregation
    - A class that is implementing an interface should not have to implement any methods it doesn't need
    - Don't have the huge interfaces that not everyone needs everything
    - Smaller, modular interface rather than huge interfaces

- Dependency Inversion
    - The general idea of this principle is : High-level modules, which provide complex logic, should be easily reusable and unaffected by changes in low-level modules, which provide utility feature

    - Rules - 

    Rule 1. High-level modules should not depend on low-level modules 
        - Example high level module is if a class depends on another to run. 
        

    Rule 2. Abstractions should not depend on details. Details should depend on abstractions.

        - Example: A Data access class should not create their own data access implementation
            but rather inherit them from an abstract class/interface. This would allow 
            a data access class to be switched out without affecting high level business logic.  


    In order to achieve abstraction we need a more non concrete way then depending on each other concrete class. 
    This is done by implementing non-concrete classes / interfaces. 

    End Goal : We could switch out any class and implement a new class that inherits from an abstraction to achieve 
        modularization 

    _______________________________________________

    Business Logic -> interface <- data access

    --- rather than ------

    Business Logic -> data access 
    __________________________________________________
