# SOLID Principles for C# Developers | Interface Segregation Principle

A sample application used to demonstrate SOLID principles. This code base is cloned from main repository and
modified to show how ISP works <br/>

-> Clients should not be forced to depend on methods they do not use <br/>

What is Client? <br/>

The client is the code that is interacting with an instance of the interface. It's the calling code <br/>

Minimize interfaces as mush as you can <br/>

More Dependencies Means </br>

* More coupling
* More brittle code
* More difficult testing
* MOre difficult deployments

## Give a Star! :star:
If you like this project please give it a star. Thanks!

## Usage Instructions

This branch shows how we can implement the ISP (Interface Segregation Principle) to our code.

* Look to large interfaces
* Check for NotImplementedException

Don't forget that C# is supporting "Multiple Interface Inheritance"

## Related Concepts

Interface Segregation Principle is related with ;

* [Liskov Substitution Principle](https://github.com/omrcm/SolidPrinciples/tree/lsp)
* Cohesion and [Single Responsibility Principle](https://github.com/omrcm/SolidPrinciples/tree/srp)
* Pain Driven Development

## Key Takeaways

* Prefer small, cohesive interfaces to large, expansive ones
* Following ISP helps with SRP and LSP
* Break up large interfaces by using;
  * Interface inheritance
  * The Adapter design pattern


## Reporting Bugs and Asking Questions

Please use [Issues](https://github.com/omrcm/SolidPrinciples/issues) to report actual bugs in the code. If you have questions, please ask them on twitter (mention [@omrcm](https://twitter.com/omrcm)).

