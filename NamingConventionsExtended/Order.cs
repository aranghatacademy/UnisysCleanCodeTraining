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

namespace Arangahat.Product.Feature
{
    /// <summary>
    /// Provides a sample class with organized regions.
    /// </summary>
    public class CustomerOrder
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
        public float CalcualteTotalPriceWithTaxes()
        {
            // Implementation of a public method
            return 0.0F;
        }

        public float CalculateTotalPriceWithoutTaxes()
        {
            // Implementation of a public method
            return 0.0F;
        }

        #endregion

        #region Constructors


        #endregion
    }
}
