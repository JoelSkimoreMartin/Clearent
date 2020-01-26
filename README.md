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

1. 
    * []()
1. 
    * []()
1. 
    * []()
1. 
    * []()
1. 
    * []()
1. 
    * []()
1. 
    * []()
1. 
    * []()


### Open–closed principle


1. 
    * []()
1. 
    * []()
1. 
    * []()
1. 
    * []()
1. 
    * []()
1. 
    * []()
1. 
    * []()
1. 
    * []()


### Liskov substitution principle


1. Reporter classes
    * [Clearent.WebApi/Controllers/TestController.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.WebApi/Controllers/TestController.cs)
        * Commented code shows how reporters can be swappped, interchangeably
    * [Clearent/Reporters](https://github.com/JoelSkimoreMartin/Clearent/tree/master/Clearent/Reporters)
        * Implementation of clases that can be interchangeably used
1. ICardResolver interface being supported on POCO objects to retrieve credit cards
    * [Clearent.Models/Interfaces/ICardResolver.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Models/Interfaces/ICardResolver.cs)
        * Defines resolver interface
    * [Clearent.Models/Person.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Models/Person.cs)
        * Resolves to all credit cards for a person
    * [Clearent.Models/Wallet.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Models/Wallet.cs)
        * Resolves to all credit cards in a wallet
    * [Clearent.Models/CreditCard.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Models/CreditCard.cs)
        * Resolves to the current credit card
    * [Clearent/SimpleInterestCalculator.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent/SimpleInterestCalculator.cs)
        * Use of ICardResolver shows how the different POCO classes can be evaluated interchangeably in order to calculate the simple interest rate, depending on the scope supplied


### Interface segregation principle


1. 
    * []()
        *
    * []()
        *
1. 
    * []()
        *
1. 
    * []()
        *
1. 
    * []()
        *
1. 
    * []()
        *
1. 
    * []()
        *
1. 
    * []()
        *


### Dependency inversion principle


1. Initialze dependency injection
    *  [Clearent.WebApi/Startup.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.WebApi/Startup.cs)
    *  [Clearent/Extensions/DependencyInjectionExtensions.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent/Extensions/DependencyInjectionExtensions.cs)
    *  [Clearent.Repo/Extensions/DependencyInjectionExtensions.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Repo/Extensions/DependencyInjectionExtensions.cs)
1. Constructor dependency injection in practice
    * [Clearent.WebApi/Controllers/TestController.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.WebApi/Controllers/TestController.cs)
    *  [Clearent/SimpleInterestCalculator.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent/SimpleInterestCalculator.cs)
    *  [Clearent/Reporters/JsonReporter.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent/Reporters/JsonReporter.cs)
    *  [Clearent/Reporters/StringReporter.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent/Reporters/StringReporter.cs)
    *  [Clearent/Reporters/XmlReporter.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent/Reporters/XmlReporter.cs)
    *  [Clearent.Repo/CardRepo.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Repo/CardRepo.cs)
    *  [Clearent.Repo/JsonRepo.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Repo/JsonRepo.cs)
