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
    public class SavingsBankAccount
    {

        #region Public Properties

        public string Name { get; set; } = null;

        public decimal Balance { get; private set; } = 0;

        #endregion

    }
}
