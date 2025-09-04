using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplsToCleanCode
{
    /*public class Customer
    {
        public string Name { get; set; }
        public float CreditScore { get; set; }

        public bool IsSalaried { get; set; } // Is the customer employed?
    }

    public class LoanCalculator
    {
        public decimal CalculateIntrestRate(Customer customer)
        {
            decimal result = 0;
            if (customer.CreditScore > 750 && customer.IsSalaried)
            {
                result = 0.09M;
            }
            else
                result = 0.12M;

            return result;

        }
    }*/

    public abstract class Customer
    {
        public string Name { get; set; }
        public float CreditScore { get; set; }
    }

    public class RegularCustomer : Customer 
    {
        
    }

    public class SalariedCustomer : RegularCustomer
    {
        public float AnnualCTC {  get; set; }
    }

    public abstract class LoanCalculator<T> where T : Customer
    {
        public virtual decimal CalculateIntrestRate(T customer) { 
            if(customer.CreditScore > 750)
                return 0.12M;
            else
                return 0.15M;
        }
    }

    public class DefaultLoanCalculator<T> : LoanCalculator<T> where T : Customer
    {

    }

    public class SalariedLoanCalculator : DefaultLoanCalculator<SalariedCustomer>
    {
        public override decimal CalculateIntrestRate(SalariedCustomer customer)
        {
            var baseIntrest = base.CalculateIntrestRate(customer);
            if (customer.AnnualCTC > 500000)
                return baseIntrest - 0.03M;
            
            return baseIntrest;
        }
    }
}
