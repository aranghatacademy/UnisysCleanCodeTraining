namespace CodeSmellType
{
    /*
     * 1-5 : Low Risk ( Simple and Easy To Maintain)
     * 6-10 : Medium Risk ( Moderate Complexity and Maintenance Effort, Refactoring)
     * >10 : High Risk ( Complex and Difficult to Maintain, Refactoring Required)
     */

    public interface IDiscountCalculator
    {
        float CalculateDiscount(float totalAmount);
    }

    public class CustomerDiscountCalculator : IDiscountCalculator
    {
        private readonly string _customerType;
        private  float _baseDiscount;
        public CustomerDiscountCalculator(string customerType)
        {
            _customerType = customerType;
            _baseDiscount = customerType == "Prime" ? 0.12f : 0.05f; 
        }
        public float CalculateDiscount(float totalAmount)
        {
           if(totalAmount > 500) //1
            {
                _baseDiscount = _customerType == "Prime" ? 0.15f : 0.07f; //2
                /*if (_customerType == "Prime") //1
                    _baseDiscount = 0.15f; 
                else if (_customerType == "Regular") //1
                    _baseDiscount = 0.07f; */
            }

            /* switch (_customerType) // 2
              {
                  case
                      "Prime":
                      if (totalAmount > 500) //1
                          baseDiscount = 0.15f; break;
                  case "Regular":
                      if (totalAmount > 500) // 1
                          return 0.07f; break;
              }*/

            return _baseDiscount;


        }
    }

    public class NonCustomerDiscountCalculator : IDiscountCalculator
    {
        public float CalculateDiscount(float totalAmount)
        {
            if (totalAmount > 1000)
                return 0.1f;
            return 0.05f;
        }
    }

    public class  Order
    {
        public float CalculateDiscount(float totalAmount,string customerType)
        {
            IDiscountCalculator discountCalculator = !string.IsNullOrEmpty(customerType)
                ? new CustomerDiscountCalculator(customerType)
                : new NonCustomerDiscountCalculator();

            return discountCalculator.CalculateDiscount(totalAmount);
        }
    }
}
