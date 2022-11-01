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
- These contain different angular resources, such as components and services

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

## Directive
We use directives to bring programmatic functionality to html. *ngIf/else, *ngSwitch, *ngFor, *ngClass are all examples of directives.
Two different categories of directive
- Structural Directive : changes the structure of your html page
    - ex. *ngIf, *ngFor, *ngSwitch

- Attribute Directive : changes attributes of your html tags
    - ex. *ngClass, *ngStyle, *ngModel

    
## Model Binding
- One Way Binding
    - Event Binding
        - goes from HTML to TS
        - syntax: `(<event-name>)`
        - `(click)="clickEventHandler()"`
        - `(dblclick)`
    - Attribute Binding
        - TS to HTML
        - syntax: `[attr-name]`
        - ex. `[class]=variableNameInComponentTS`
    - String Interpolation
        - TS to HTML
        - syntax: `{{varName}}`

- Two Way Binding
    - both the view (html file) and the logic (the ts file) are dynamically updating each other
    - Syntax: `[(modelName)]` 'banana box'
    - very commonly used in template-based forms `[(ngModel)]`


## Lifecycle hooks
In each angular component's life time (from initial render to destruction), there are many different events or stages it goes through. As developers, we can subscribe to those events using lifecycle hooks to do something whenever those events are triggered. For example, if you want to do some DOM manipulation once the component renders, you can put that logic in ngOnInit function, or if you want to clean up some resources when angular destroys the component, do so on ngOnDestroy. ngDoCheck is particularly useful if you're relying heavily on an external library that angular is not aware of. 

## Pipes
https://angular.io/guide/pipes
- json
- async
- date
- upper/lower, etc.