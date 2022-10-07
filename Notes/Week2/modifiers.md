# Modifiers

## Access modifier
- It determines the accessibility of types and type members
- Public : anyone and everyone
- Private : only members of the type
- Protected : only the type and subtypes (inherited types)
- Internal : within the same assembly (within the same project)

Default access level:
In a type (Class, Enum, Struct, etc), the default access level is internal
For a type member (constructor, methods, fields, properties, indexers, etc) the default access level is private

### What is assembly? 
.dll files -> Codes in Intermediary Language (IL)
This is the smallest unit of deployment
-> the compiled project 

# Overriding vs Overloading (Two big examples of Polymorphism)

## Overriding
- Is between two classes related by inheritance
- They have to have the same method name and parameter
- To be able to override a method, the original method MUST have "virtual" modifier
- To override a virtual method, you HAVE to use "override" modifier

## Overloading
- occurs in one class
- They have to have the same name, BUT different parameters

* Abstract modifier is virtual + no content

*Optionally, you could utilize inheritance to have User base class(super class) that Employee and Manager inherit from*
- Name
- Email
- Id
- Pw

- Process ticket method
- Change role ability

# Other modifiers
- const : if you want to prevent the value from change
    - related but not actually the same: "readonly"
- virtual
- abstract
- override
- partial : allows you to spread the type across many files
- sealed: sealed prevents you from inheriting this further