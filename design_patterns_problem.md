# Design Patterns Practice: Order Processing System

## Problem Statement
Build an **Order Processing System** that demonstrates Strategy, Observer, Factory, and Chain of Responsibility patterns.

## Requirements

### 1. Order Types (Factory Pattern)
Create different order types:
- `StandardOrder`, `ExpressOrder`, `BulkOrder`
- Use `OrderFactory` to create orders based on input parameters

### 2. Payment Processing (Strategy Pattern)
Implement payment strategies:
- `CreditCardPayment`, `PayPalPayment`, `BankTransferPayment`
- Each with different validation rules and processing fees
- Use `PaymentContext` to switch strategies at runtime

### 3. Shipping Methods (Strategy Pattern)  
Implement shipping strategies:
- `StandardShipping`, `ExpressShipping`, `OvernightShipping`
- Calculate costs and delivery times differently
- Use `ShippingContext` to manage strategies

### 4. Notifications (Observer Pattern)
Create notification system for order status changes:
- **Status Changes**: OrderPlaced → PaymentProcessing → OrderShipped → OrderDelivered
- **Observers**: `CustomerNotifier`, `VendorNotifier`, `InventoryManager`
- Automatically notify all observers when status changes

### 5. Order Validation (Chain of Responsibility)
Create validation chain:
- `InventoryValidator` → `PaymentValidator` → `AddressValidator` → `FraudValidator`
- Each validator either approves or rejects with error message
- Chain continues only if current validator approves

## Core Classes to Implement

```csharp
// Strategy Pattern
public interface IPaymentStrategy { bool ProcessPayment(decimal amount); }
public interface IShippingStrategy { decimal CalculateCost(Order order); }

// Observer Pattern  
public interface IOrderObserver { void OnOrderStatusChanged(Order order, OrderStatus status); }

// Chain of Responsibility
public abstract class OrderValidator 
{
    protected OrderValidator _nextValidator;
    public abstract ValidationResult Validate(Order order);
}

// Factory Pattern
public abstract class OrderFactory 
{
    public static Order CreateOrder(string type, OrderDetails details);
}
```

## Implementation Tasks

1. **Basic Structure** - Define interfaces and base classes
2. **Strategy Implementation** - Create payment and shipping strategies  
3. **Observer System** - Implement status notifications
4. **Factory Creation** - Build order factory
5. **Validation Chain** - Create validator chain
6. **Integration** - Combine all patterns in main application

## Test Scenario
```csharp
// Create order using Factory
var order = OrderFactory.CreateOrder("Express", orderDetails);

// Set payment strategy
order.SetPaymentStrategy(new CreditCardPayment());

// Set shipping strategy  
order.SetShippingStrategy(new ExpressShipping());

// Subscribe observers
order.Subscribe(new CustomerNotifier());
order.Subscribe(new InventoryManager());

// Process through validation chain
var isValid = validationChain.Validate(order);

// Process order (triggers notifications)
if (isValid) order.Process();
```

## Success Criteria
- ✅ Easy switching between payment/shipping methods
- ✅ Automatic notifications on status changes
- ✅ Dynamic order creation via factory
- ✅ Flexible validation pipeline
- ✅ Clean separation of concerns
- ✅ Unit tests for each pattern

**Bonus**: Add error handling, logging, and configuration management.