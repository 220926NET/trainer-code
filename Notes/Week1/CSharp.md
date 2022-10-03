# C#

## What is C#?
C# (pronounced see-sharp) is a compiled, type-safe, object oriented programming language

## What is compiling?
Compiling is a process of translating a program code to something machines can understand (aka machine code, aka 0's and 1's)

## What is Type Safety?
Type safety means that whenever you create a variable, you have to let the compiler know which data type you plan on assigning to that variable.

## What is Object Oriented?
Object oriented programming is one of paradigms of computer programming where the data and the behavior is bundled together as an object and the program is defined by the relationship between those objects (way more on this later)

## What is .NET Platform?
C# is one of .NET compliant languages (VB.NET, F#, C#)
.NET Platform is a development platform where developers can create variety of applications under same standard. (.NET standard)
It's comprised of the following
- .NET compliant languages (C#)
- Frameworks (Mono, Xamarin, .NET (core), ASP.NET core, UWP, etc)
- Development tools such as visual studio and vscode

- .NET 6 is the most current .NET implementation (this is what we'll be using)
    - Open source, cross platform (doesn't discriminate against OS's, can run on Windows, Mac, Linux)
- .NET Framework is the first .NET implementation (this is NOT what we're using)
    - This is platform specific (windows) and proprietary framework
- .NET Standard is a set of standard that all .NET platform tools comply to

- Difference between SDK and runtime
    - SDK stands for: software development kit
        - it has tools and libraries developers need to build applications
        - ex. compiler
    - runtime: it contains tool necessary to run the program (for .NET platform, we call this CLR, common language runtime)
        - functionalities such as automatic memory management ("Garbage collection")
        - Exception handling

## .NET Commands
- dotnet new console -n "app-name"
    - To create new console application
- dotnet run (inside the project you plan on running)
    - to build and run your application
    - implicitly builds before it runs
- dotnet new gitignore 
    - to generate .NET sdk's gitignore file
- dotnet new classlib -n "project-name"
    - to generate a class library project
- dotnet add reference path-to-the-folder-containing-csproj-file
    - to add project dependency to another project
- dotnet build
    - just compiles the project