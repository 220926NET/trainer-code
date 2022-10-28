# TypeScript

## Node.js
standalone js engine that allows us to run js files as is.

## Node Package Manager
Akin to Nuget + MSBUILD

## Typescript
Is language that is a superset of javascript - any valid js is valid ts
with few more features, mainly static typing
- Static type checking
- access modifiers
- interfaces
- define your custom types

- Typescript isn't natively supported by browser engines we need a way to "translate" it back to js
- We call this process transpiling

### Structural Typing / "Duck Typing"
Typescript figures out what a type of an object is by looking at its properties and making sure that it has all the required ones

### Commands
- tsc path-to-file
    - to transpile this to js
- tsc -- init
    - to get yourself the config file

### Resources
- [TS CheatSheet](https://www.typescriptlang.org/cheatsheets)
- [TS For Java/C# Programmers](https://www.typescriptlang.org/docs/handbook/typescript-in-5-minutes-oop.html)
- [TS For Javascript Programmers](https://www.typescriptlang.org/docs/handbook/typescript-in-5-minutes.html)

## NPM
Node Package Manager. We use NPM to manage our dependencies for js projects, as well as write scripts that we can run by doing `npm <name>`
In order to install packages from NPM, we use `npm install` or `npm i` command followed by the package name. For example `npm install typescript`.
When we install packages, they go in the special folder named node_modules.
You can use --global to install the package accessible everywhere in your machine, or you can use --save to save the package as your project dependency. --save-dev saves the package information as your dev dependency. 

## NPX
node package runner. We use this to run the typescript compiler ('tsc') to 'transpile' the typescript file to a js file.

## TypeScript
In order to run locally installed typescript, first install the package and then run `npx tsc` ("typescript compiler")

Typescript is a superset of javascript, or as people like to say, if you make OOP developers code in javascript, they'll come up with typescript.

Typescript is a static typed language, which means that it will enforce you to define types as you define variables. Instead of doing `let foo = 'bar'`, we have to define the type, by doing `let foo:string = 'bar'`

Typescript is not natively understood by browsers, so we have to transpile it down to javascript. Do it by `npx tsc <file-path>`. If you don't want to run this everytime you change, you can use `npx tsc --watch <file-path>`

Typescript enforces type safety by having you declare types for your variables. But it is still javascript under the hood.

## Additional Typescript Features
### Additional Types
TS introduces types that doesn't exist in javascript, such as any, void, never, and more!
- Any type is when you want to use ts like js, really any data type can be assigned to the variable.
- void is exclusively used for fn's. Just means function does not return anything.
- never is for something that will never be anything- usually used for functions that will always throw an error
- Union types

### Access modifiers for class
Typescript introduces access modifiers for classes that doesn't exist in js

### Interfaces
Typescript interface is a way to define a shape of an object
Typescript will then enforce that the properties of interface exists in an object when we claim that an object is of a certain type.
Interface is useful when we are only interested in enforcing certain shape in an object but not interested in defining behaviors.
Typescript uses duck typing, or structural typing, which checks for the existence of properties.