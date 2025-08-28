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
    /// Provide Comment for documentation
    /// </summary>
    public interface IOrderPaymentService
    {
        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// Initiates payment for a given order and returns a payment reference.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        string InitiateOrderPayment(OrderPaymentRequest orderPaymentRequest);

        /// <summary>
        /// Checks if the payment for a given order is completed.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        bool IsOrderPaymentCompleted(int orderId);

        #endregion

        #region Events
        #endregion
    }
}
