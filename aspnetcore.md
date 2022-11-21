# ASP.NET Core

#### Clarification
ASP.NET -> written for .NET Framework (the original .NET impl)
ASP.NET Core -> written for .NET Core and .NET 5+ (the new one from 2010's)

## What is it?
Is a web application framework that can create all kind of web apps- you can pair this with angular/react to have a SPA + API inside a single project, you can create api's, or you create full stack application without writing js by using Razor syntax. Razor is a html markup language and we use C# syntax to introduce programmatic functionality to html. Blazor is a full stack web application framework provided by ASP.NET where you can write everything in C#

ASP.NET MVC -> this uses Razor to render view

MVC(Model View Controller) by itself is just a way of structuring your application

## Middleware, Filters
Filters remind pipes, so if you want to capitalize any given word, you can use capitalize pipe
When dealing with web traffic, there are certain set of tasks that we perform over and over and over again
- URL parsing
- deconstructing Request header/body and making it available for the application to consume
- Parsing and decoding json
- automatic binding of data to models
- Assembling the response
- Finding which controller action to invoke
- rerouting http traffic to https

Middleware and filters allow developers to focus on application logic by abstracting away the repetitive tasks.
Middleware execute in waterfall fashion (one by one), and is configured in program.cs.
The order in which you include your middleware matters.
Middleware also execute OUTSIDE of the controller context (they execute before your controller class is initialized)
[Middleware Docs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0)

Filter is similar to middleware that they also handle crosscutting concerns
BUT they execute inside the controller context
You use filters by including them as attributes above your controller class
[Filter Tutorial](https://jakeydocs.readthedocs.io/en/latest/mvc/controllers/filters.html)

## Model Binding
- using System.ComponentModel.DataAnnotations you can have ASP.NET validate your models before it executes controller actions
- It will automatically send back 400 whenever the data fails any of the validation rule
- [doc](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0)

## (In Memory) Response Caching in Back End
- This has to do with the REST's Cacheable (guiding) principle.
- We can cache some commonly requested data in memory, so we don't have to retrieve it from the DB EVERY SINGLE TIME

- Pros:
    - Big performance boost 
    - certain queries are big, so storing this in memory can speed the response up quite a bit
    - If we get asked for that resource A LOT, then this makes sense
- Cons:
    - If the resource changes, then we need to update it
    - We are using memory to store this data, which is a scarce resource
[Caching Guideline](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-6.0#cache-guidelines)

- Cacheable means (in this context) server can _save_ certain stateless data in its memory to reuse  
- Stateless means that the server should not store _client's_ information in the server (any information that can change depending on clients)

## OpenAPI
- This is a specification/initiative to standardize API documentation
- Swagger is part of OpenAPI
- TLDR; devs hate documenting but API is all about documenting, so let's make it easy
- [OpenAPI](https://www.openapis.org/)