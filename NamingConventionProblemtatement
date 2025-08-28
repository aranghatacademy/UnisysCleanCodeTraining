# Practice Problem: Naming Conventions in C# (DDD, Semantic, Value Objects)

## Context  
You are designing part of an **Online Bookstore’s Checkout Domain** in C#. The primary goal is to practice **naming conventions** with a focus on:  

1. **Domain-Driven Naming** – Names should reflect the ubiquitous language of the business, not technical jargon.  
2. **Semantic Naming** – Class and property names should clearly reveal intent without extra comments.  
3. **Value Object Modeling** – Objects like `Money`, `ISBN`, and `Address` should be modeled as **immutable Value Objects**, avoiding primitive obsession.  

---

## Requirements  

### Entities and Aggregates  
- A **Customer** can have multiple **Orders**.  
- Each **Order** contains a list of **OrderItems**.  
- An **OrderItem** references a **Book** and has a **Quantity**.  

### Value Objects  
- **ISBN** → must be validated when created.  
- **Money** → represents price and currency (should avoid using `decimal` or `double` directly).  
- **Address** → represents a customer’s shipping address (Street, City, State, Zip).  

### Naming Challenges  
- Use **domain terms** (`Order`, `Customer`, `Book`) instead of technical/database terms (`DbCustomerEntity`, `TblOrders`).  
- Use **semantic clarity** in names (`TotalPrice`, `ShippingAddress`) instead of vague names (`data`, `info`, `value`).  
- Avoid leaking primitives – model **Value Objects** instead of passing raw types like `string isbn` or `decimal price`.  

---

## Example Use Cases to Model  
- A customer places an order containing multiple books.  
- The system represents the total cost using the `Money` value object.  
- The system ensures that only valid ISBNs are accepted when creating books.  
- Customer shipping information is always captured as an `Address` value object.  

---

## Task  
- Define **Entities, Value Objects, and Aggregates** using **correct domain-driven and semantic naming conventions**.  
- Refactor any potential “bad names” into **meaningful domain names**.  
- Ensure **Value Objects** are **immutable** and enforce validation at creation.  

---

## Areas for Exploration  
- Enforcing naming rules with **Roslyn Analyzers** or **.editorconfig**.  
- Comparing **technical vs. domain-driven naming**.  
- Identifying when to use **nouns** (entities, value objects) vs. **verbs** (behaviors, operations).  
- Refactoring existing code with poor names into proper **DDD-aligned names**.  
