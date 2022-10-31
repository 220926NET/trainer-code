# Angular
Angular a frontend framework that allows us to create single page applications

## Framework vs Library
- Angular is a framework, react is a library
- ASP.NET is a framework, ADO.NET is a library

- Framework is something you build upon, library is something you add to something you are already building
- Library is a precompiled classes/functions that you can call/use to do a certain task, Framework is a scaffold

## SPA (Single Page Application)
- Traditionally, all websites were a directory that contained html, css, js files that were hosted on the web
- So even in more dynamic websites, server was rendering these html pages for us and serving them.
    - "Server side rendering"
    - The client sends http request (aka your web browser) to the server and then the server responds with html/css/js resources
- Couple drawbacks:
    - These(html/css/js files) are kinda big
    - There are things that are repeated across many pages that needs to be constantly re-rendered (it's wasteful)
- So what if, we get all our html/css/js files in the initial request, and assemble these webpages dynamically on the go, while just receiving the data we need?
    - any subsequent http request beyond the initial one is much smaller (because json < html/css/js)
    - Allows us to stop rendering the same stuff over and over again (Faster performance)
- Drawbacks to SPA:
    - The initial request is big

## Commands
- To install angular:
    - `npm install -g @angular/cli`
- all angular commands start with `ng`
- To create a new angular app:
    - `ng new your-app-name`
- To serve (aka dotnet run)
    - `ng serve` (and this will run the dev version)
- To get deployable artifacts
    - `ng build`
- To generate a component
    - `ng generate component comp-name`
    - `ng g c name`
- To generate a service
    - `ng g s name`
- to create a module
    - `ng g m module-name`

## Angular Build process
- Webpack Bundling
- Minification

## Module
- Angular module is like a namespace in C#
- These contain different angular resources/segments, such as components and services

## Component
- They are smallest unit of reusable views with its own style, logic, and testing files
- They must belong in an angular module
- Register them by including it in Declarations array in module decorator

## Services
- Services are reusable pieces of logic

## Decorator
This is a special angular syntax that lets the framework know that the following class is angular's resource
They all start with @ symbol
- @NgModule (to let angular know that this is angular's module)
- @Component (this is angular's component)
- These decorators, contain angular specific configuration