# Clearent SOLID Examples

Visual Studio 2019 .NET Core 3.1 Solution

## Solution projects

1. [Clearent](https://github.com/JoelSkimoreMartin/Clearent/tree/master/Clearent)
    * Library containing the main business logic
1. [Clearent.Models](https://github.com/JoelSkimoreMartin/Clearent/tree/master/Clearent.Models)
    * Library of POCO classes
1. [Clearent.Repo](https://github.com/JoelSkimoreMartin/Clearent/tree/master/Clearent.Repo)
    * Library of data repository
1. [Clearent.Test](https://github.com/JoelSkimoreMartin/Clearent/tree/master/Clearent.Test)
    * Nunit test cases
1. [Clearent.WebApi](https://github.com/JoelSkimoreMartin/Clearent/tree/master/Clearent.WebApi)
   * Web api

## SOLID principles in code

### Single responsibility principle

1. []()
    * 
1. []()
    * 
1. []()
    * 
1. []()
    * 
1. []()
    * 

### Open–closed principle

1. []()
    * 
1. []()
    * 
1. []()
    * 
1. []()
    * 
1. []()
    * 

### Liskov substitution principle

1. [Clearent.WebApi/Controllers/TestController.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.WebApi/Controllers/TestController.cs)
    * Can swap the reporters and they will work interchangeably
1. []()
    * 
1. []()
    * 
1. []()
    * 
1. []()
    * 

### Interface segregation principle

1. []()
    * 
1. []()
    * 
1. []()
    * 
1. []()
    * 
1. []()
    * 

### Dependency inversion principle

1. Initialze dependency injection
    *  [Clearent.WebApi/Startup.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.WebApi/Startup.cs)
    *  [Clearent/Extensions/DependencyInjectionExtensions.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent/Extensions/DependencyInjectionExtensions.cs)
    *  [Clearent.Repo/Extensions/DependencyInjectionExtensions.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Repo/Extensions/DependencyInjectionExtensions.cs)
1. Dependency injection in practice
    * [Clearent.WebApi/Controllers/TestController.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.WebApi/Controllers/TestController.cs)
    *  []()
    *  []()
    *  []()
    *  []()
    *  []()
