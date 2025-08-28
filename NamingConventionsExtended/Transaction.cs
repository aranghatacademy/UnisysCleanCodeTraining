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
    public class PaymentTransaction
    {
        #region Private Members

        private readonly int id;

        #endregion

        #region Public Properties

        public string Name { get; set; }

        #endregion

        #region Private Methods
        private void PrivateMethod()
        {
            // Implementation of a private method
        }

        #endregion

        #region Public Methods
        public void PublicMethod()
        {
            // Implementation of a public method
        }

        #endregion

        #region Constructors
        public Transaction(int id, string name)
        {
            this.id = id;
            Name = name;
        }

        #endregion
    }

    public class RefundTransaction 
    {
       
    }
}
