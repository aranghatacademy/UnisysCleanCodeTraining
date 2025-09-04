##Code Smells
1. Use Cyclomatic Complexity to identify complex methods and refactor them.
2. Avoid long method parameters by avoiding primitive obsession.
3. Feature Envy: Move methods to the class they are most related to.
4. Utility Hell: Avoid overusing utility classes; Consider using services and DI
5. Opaque Return Types: Use boundry exception or better use Result<T> pattern.


##Solid Principles in clean code

1. Single Responsibility Principle - A Class or a method only reason for its existance. In another words there 
									 must only one reason to change a class or a method
2. Open Close Principle			   - Class or a Method must be open for extention but closed for modification

3. Liskov Substitution Principle   - Derived classes must be substitutable for their base classes

4. Interface Seggregation Principle - Insted of creating a mother of all interfaces. Create smaller focused interfaces 
		so that the client can pick and choose the services.

5. Dependency Inversion Principle - Highlevel modules must not depend on low level modules. Both must depend on abstractions.
		Abstractions must not depend on details. Details must depend on abstractions.