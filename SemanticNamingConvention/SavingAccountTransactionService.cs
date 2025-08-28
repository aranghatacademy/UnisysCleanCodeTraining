/*
 * Product : Aranghat Class Library
 * Company : Aranghat Technologies Private Limited
 * Copyright : All rights reserved
 * Author : Sreehari Aranghat
 * 
 * Change History :
 * 
 * [Date]        [Author]        [Description]
 * 
 * */

namespace Aranghat.Product.Feature
{
    /// <summary>
    /// Provides a sample class with organized regions.
    /// </summary>
    // Semantic Distance of a Class Name from its Responsibilities
    public class SavingAccountTransactionService // Represent a Business Concept
    {
       

        #region Public Methods

        public void DepositToAccount(SavingsBankAccount customerAccount //The account to which its money is deposited
            , decimal depositAmount // The amount to be deposited
            ) // Represent a Business Action
        {
            // Implementation of a public method
        }

        public void WithdrawFromAccount(SavingsBankAccount account, decimal amount)
        {
            // Implementation of a public method
        }

        #endregion


    }

    public class ProcessTransaction
    {

        public void Process()
        {
           Console.WriteLine("Processing Transaction");
        }

    }
}
