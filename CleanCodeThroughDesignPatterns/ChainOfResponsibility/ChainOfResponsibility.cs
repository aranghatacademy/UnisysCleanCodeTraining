using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.ChainOfResponsibility
{
    public class PurchaseRequest
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }

    public abstract class Approver
    {
        protected Approver _next;

        public Approver SetNext(Approver next)
        {
            _next = next;
            return next;
        }

        abstract public void ProcessRequest(PurchaseRequest request);
    }

    public class TeamLeader : Approver
    {
        public override void ProcessRequest(PurchaseRequest request)
        {
            if(request.Amount <= 1000)
            {
                Console.WriteLine($"Team Leader approved request: {request.Description} for amount {request.Amount}");
            }
            else if (_next != null)
            {
                _next.ProcessRequest(request);
            }
        }
    }

    public class Manager : Approver
    {
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount > 1000 && request.Amount <= 10000)
            {
                Console.WriteLine($"Manager approved request: {request.Description} for amount {request.Amount}");
            }
            else if (_next != null)
            {
                _next.ProcessRequest(request);
            }
        }
    }

    public class Director : Approver
    {
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount > 10000 && request.Amount <= 50000)
            {
                if (string.IsNullOrWhiteSpace(request.Description))
                {
                    Console.WriteLine("Director rejected the request due to missing description.");
                }
                else
                {
                    Console.WriteLine($"Director approved request: {request.Description} for amount {request.Amount}");
                }
            }
            else if (_next != null)
            {
                _next.ProcessRequest(request);
            }
        }
    }
}
