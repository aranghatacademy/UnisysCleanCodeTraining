using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.ChainOfResponsibility
{
    public class ApprovePurchaseOrder
    {
        public bool ApproveOrder(decimal purChangeOrder, string currentUserType)
        {
            bool isApproved = false;

            if(purChangeOrder < 10000 && currentUserType == "Manager")
            {
                isApproved = true;
            }
            else if(purChangeOrder >= 10000 && purChangeOrder < 50000 && currentUserType == "Director")
            {
                if(isApproved == true)
                {
                    //IF there is no description reject
                    isApproved = false;
                    return isApproved;
                }
                isApproved = true;
            }


           return isApproved;

        }
    }
}
