using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.StratagyPAttern
{
    public  interface IStrategy<T,TResult>
    {
        TResult Execute(T input);
    }

    public class StrategyContext<T, TResult>
    {
        private readonly IStrategy<T, TResult> _strategy;
        public StrategyContext(IStrategy<T, TResult> strategy)
        {
            _strategy = strategy;
        }
        public TResult ExecuteStrategy(T input)
        {
            return _strategy.Execute(input);
        }
    }

    // Strategy Used for Payment
    public class  PaymentRequest
    {
        public decimal Amount { get; set; }
    }

    public class PaymentResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class CreditCardPaymentStrategy : IStrategy<PaymentRequest, PaymentResponse>
    {
        public PaymentResponse Execute(PaymentRequest input)
        {
            // Process Credit Card Payment
            return new PaymentResponse { IsSuccess = true, Message = $"Processed credit card payment of {input.Amount}" };
        }
    }

    public class PayPalPaymentStrategy : IStrategy<PaymentRequest, PaymentResponse>
    {
        public PaymentResponse Execute(PaymentRequest input)
        {
            // Process PayPal Payment
            return new PaymentResponse { IsSuccess = true, Message = $"Processed PayPal payment of {input.Amount}" };
        }
    }


   //Strategy To Sent a Message
   public class Message
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }

    public class MessageResponse
    {
        public bool IsSent { get; set; }
        public string StatusMessage { get; set; }
    }

    public class SMSMEssageSender : IStrategy<Message, MessageResponse>
    {
        public MessageResponse Execute(Message input)
        {
            // Send SMS
            return new MessageResponse { IsSent = true, StatusMessage = $"SMS sent to {input.PhoneNumber}" };
        }
    }

    public class EmailMessageSender : IStrategy<Message, MessageResponse>
    {
        public MessageResponse Execute(Message input)
        {
            // Send Email
            return new MessageResponse { IsSent = true, StatusMessage = $"Email sent to {input.Email}" };
        }
    }


    public class Order
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
    }

    public class PrimeMemberDiscountStrategy  : IStrategy<Order, decimal>
    {
        public decimal Execute(Order input)
        {
            // 20% discount for prime members
            return input.Amount * 0.8m;
        }
    }

    public class RegularMemberDiscountStrategy : IStrategy<Order, decimal>
    {
        public decimal Execute(Order input)
        {
            // 10% discount for regular members
            return input.Amount * 0.9m;
        }
    }

}
