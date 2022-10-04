# Testing

## Unit Testing
Unit testing is all about testing a small isolated piece of code.
What we don't test in unit testing:
- Testings things that the result depend on other things/aspects
- ex: Other people's code (libraries), any thing that interacts with external resources (db access codes, user interfaces)

What we do test:
- Methods that will always act the same way given a same input (pure functions in js terms)
- Input validation 
- getting/setting properties

## Integration Testing
All about testing how different modules/pieces of code work together
- simulated UI
- DB connection (with test db)
- whole app workflow

## Unit testing in C#
- XUnit is the unit testing framework in C#.
- In order to create a suite of unit tests, we are going to create a test project.
- To create the test project, `dotnet new xunit -n TestProjectName`
- To run the test project, `dotnet test` inside the test project directory.
- Fact
- Theory
- Arrange/Act/Assert

## Code Coverage
This is a metric that tells us how much lines/conditions of our app the unit test is covering
- Line Coverage
- Branch Coverage
- `dotnet test --collect:"XPlat Code Coverage"` : to run tests and collect code coverage metric
- `dotnet tool install -g dotnet-reportgenerator-globaltool`: this is for generating readable code coverage report
- [Microsoft Learn Tutorial](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage?tabs=windows)