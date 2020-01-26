# Clearent SOLID Examples

Visual Studio 2019 .NET Core 3.1 Solution

Requirements:
> Now write a program program that calculates Credit Card interest for a Person.  
>  
> Visa gets 10%
> MC gets 5% interest
> Discover gets 1% interest
>  
> Each Card Type can have multiple cards and there can be multiple Wallets for a Person. 
>  
> NOTE:  SIMPLE INTEREST for this test case (means 1 month of interest, if the interest rate is 10% and the amount is 100.00 – interest in this case would be 10.00) 
> 
> Here are the test Cases - 
>  
> ●	1 person has 1 wallet and 3 cards (1 Visa, 1 MC 1 Discover) – Each Card has a balance of $100 – calculate the total interest (simple interest) for this person and per card. 
> ●	1 person has 2 wallets  Wallet 1 has a Visa and Discover , wallet 2 a MC -  each card has $100 balance - calculate the total interest(simple interest) for this person and interest per wallet
> ●	2 people have 1 wallet each,  person 1 has 1 wallet , with 2 cards MC and visa person 2 has 1 wallet – 1 visa and 1 MC -  each card has $100 balance - calculate the total interest(simple interest) for each person and interest per wallet
> 
> Please be prepared to discuss your solution on the basis of SOLID programming principles-
> 
> http://www.objectmentor.com/resources/articles/Principles_and_Patterns.pdf 
> 
> http://www.blackwasp.co.uk/SOLIDPrinciples.aspx 
> 
> http://en.wikipedia.org/wiki/SOLID_(object-oriented_design) 
> 
> You must post your example on https://github.com/<Your name here>


Completed:

- [x] Met requirements
- [ ] Prove functionality validity through unit tests
- [ ] Illustrated SOLID principles

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

1. POCO classes
    * Only responsible for storing data in the shape of Person -> Wallet -> CreditCard
        * [Clearent.Models/CreditCard.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Models/CreditCard.cs)
        * [Clearent.Models/Person.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Models/Person.cs)
        * [Clearent.Models/Wallet.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Models/Wallet.cs)
1. [TestDataFactory class](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Models/Tools/TestDataFactory.cs)
    * Only responsible for building test data that can be used in both the test cases and web api
1. Group classes / enum
    * Only responsible for grouping results from ICardResolver for use by the reporter
        * [Clearent.Models/Tools/Group.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Models/Tools/Group.cs)
        * [Clearent.Models/Tools/Grouper.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Models/Tools/Grouper.cs)
        * [Clearent.Models/Tools/Grouping.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Models/Tools/Grouping.cs)
1. [JsonRepo class](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Repo/JsonRepo.cs)
    * Only responsible for retrieving data from a json data source
1. [CardRepo class](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Repo/CardRepo.cs)
    * Only responsible for retrieving credit card info from the datasource
1. DependencyInjectionExtensions classes
    * Only responsible for registering dependency injected classes for a library
        * [Clearent/Extensions/DependencyInjectionExtensions.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent/Extensions/DependencyInjectionExtensions.cs)
        * [Clearent.Repo/Extensions/DependencyInjectionExtensions.cs](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent.Repo/Extensions/DependencyInjectionExtensions.cs)
1. [SimpleInterestCalculator class](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent/SimpleInterestCalculator.cs)
    * Only responsible for calculating simple interest for credit cards
1. [JsonReporter class](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent/Reporters/JsonReporter.cs)
    * Only responsible for reporting calculated results in a json format
1. [StringReporter class](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent/Reporters/StringReporter.cs)
    * Only responsible for reporting calculated results in a sentance-based string format
1. [XmlReporter class](https://github.com/JoelSkimoreMartin/Clearent/blob/master/Clearent/Reporters/XmlReporter.cs)
    * Only responsible for reporting calculated results in an xml format


### Open–closed principle


1. 
    * []()
        *
    * []()
        *
1. 
    * []()
        *
    * []()
        *
1. 
    * []()
        *
    * []()
        *
1. 
    * []()
        *
    * []()
        *
1. 
    * []()
        *
    * []()
        *
1. 
    * []()
        *
    * []()
        *


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
    * []()
        *
1. 
    * []()
        *
    * []()
        *
1. 
    * []()
        *
    * []()
        *
1. 
    * []()
        *
    * []()
        *
1. 
    * []()
        *
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
