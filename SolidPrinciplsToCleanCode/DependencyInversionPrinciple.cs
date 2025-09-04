using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplsToCleanCode
{
    //Low Level Module
    public interface ISMSService
    {
        public void SentSMS(string number, string message);
    }

    public class AirtelSMSService : ISMSService // Implementation
    {
        public void SentSMS(string number, string message)
        {
            Console.WriteLine("Sent sms though Airtel");
        }

    }


    //High Level Module
    public class UserService
    {
        private readonly ISMSService service; // Abstraction

        public UserService(ISMSService airtelSMS)
        {
            this.service = airtelSMS;
        }

        public void RegisterUser(string userName, string phoneNumber)
        {
            //Register user logic
            //Send SMS
            service.SentSMS(phoneNumber, "Welcome to our service " + userName);
        }


        public void ResetPassword(string password, string userName)
        {
            //Reset password logic
            //Send SMS
            service.SentSMS(password, "Your password has been reset " + userName);
        }
    }
}
