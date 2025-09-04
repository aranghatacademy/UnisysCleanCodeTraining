# Messed Up Car Rental Code

The following C# code represents a **medium complex but messy** implementation of a Car Rental system.  
It is intentionally filled with **bad practices, code smells, and violations of SOLID principles**.  

Candidates are expected to:  
1. Identify code smells.  
2. Apply **refactoring** and **SOLID principles**.  
3. Suggest better design patterns.  

---

```csharp
using System;
using System.Collections.Generic;

namespace CarRentalMessy
{
    // Poor naming, God class, doing everything
    public class CarRentalSystem
    {
        public List<string> rentedCars = new List<string>();
        public Dictionary<string, double> carPrices = new Dictionary<string, double>();
        public List<string> availableCars = new List<string>();
        private List<string> customers = new List<string>();

        public CarRentalSystem()
        {
            availableCars.Add("BMW");
            availableCars.Add("Audi");
            availableCars.Add("Maruti");
            availableCars.Add("Tesla");
            carPrices.Add("BMW", 100.0);
            carPrices.Add("Audi", 90.0);
            carPrices.Add("Maruti", 30.0);
            carPrices.Add("Tesla", 150.0);
        }

        // Does too many things at once
        public void RentCar(string customer, string car, int days, bool applyDiscount)
        {
            if (!availableCars.Contains(car))
            {
                Console.WriteLine("Car not available!");
                return;
            }
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days");
                return;
            }

            double price = carPrices[car] * days;
            if (applyDiscount)
            {
                price = price - 20; // Hardcoded discount
            }

            rentedCars.Add(car);
            availableCars.Remove(car);
            customers.Add(customer);
            Console.WriteLine(customer + " rented " + car + " for " + days + " days. Price: " + price);
        }

        // Mixed responsibilities: return, calculate fine, update data
        public void ReturnCar(string customer, string car, int delayDays)
        {
            if (!rentedCars.Contains(car))
            {
                Console.WriteLine("Car was not rented!");
                return;
            }

            rentedCars.Remove(car);
            availableCars.Add(car);
            customers.Remove(customer);

            double fine = 0;
            if (delayDays > 0)
            {
                fine = delayDays * 10; // Hardcoded fine
            }

            Console.WriteLine(customer + " returned " + car + ". Fine: " + fine);
        }

        // Violates SRP, deals with both report and business logic
        public void PrintReport()
        {
            Console.WriteLine("===== Car Rental Report =====");
            Console.WriteLine("Available cars: ");
            foreach (var c in availableCars)
                Console.WriteLine(c);
            Console.WriteLine("Rented cars: ");
            foreach (var r in rentedCars)
                Console.WriteLine(r);
            Console.WriteLine("Customers: ");
            foreach (var cust in customers)
                Console.WriteLine(cust);
        }

        // Violates OCP, adding new car requires code change
        public void AddCar(string car, double price)
        {
            availableCars.Add(car);
            carPrices.Add(car, price);
        }
    }

    public class Program
    {
        public static void Main()
        {
            CarRentalSystem system = new CarRentalSystem();
            system.RentCar("Alice", "BMW", 5, true);
            system.RentCar("Bob", "Maruti", 3, false);
            system.ReturnCar("Alice", "BMW", 2);
            system.PrintReport();
        }
    }
}
```

---

## Issues in the Code

- **God Class**: `CarRentalSystem` handles multiple responsibilities (rental, pricing, reporting, customer management).  
- **Hardcoded Values**: Discounts, fines are fixed inside methods.  
- **Violation of SOLID**:  
  - **SRP**: No separation of concerns.  
  - **OCP**: Adding new pricing rules requires modification.  
  - **LSP**: No inheritance but potential issue if extended.  
  - **ISP**: Not relevant here, but all clients forced to depend on everything.  
  - **DIP**: Depends on concrete implementations instead of abstractions.  
- **Tight Coupling**: Data storage is in lists/dictionaries directly inside system.  
- **Poor Naming**: Methods like `PrintReport` mix console output with logic.  

---

## Candidate Task

- Refactor into smaller classes (e.g., `Car`, `Customer`, `Rental`, `ReportService`).  
- Apply **SOLID principles**.  
- Use **interfaces** for pricing, discount, and fine calculation.  
- Replace hardcoded values with strategies/configurations.  
- Separate business logic from UI (console).  

---

