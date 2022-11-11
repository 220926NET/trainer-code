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

## Caching

## OpenAPI

## Model Binding