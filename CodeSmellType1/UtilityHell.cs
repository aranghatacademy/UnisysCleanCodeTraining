using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellType1
{
    public static class DateUtil
    {
        public static string ConvertToHumanReadable(DateTime date)
        {
            return date.ToString("dd-MMM-yyyy");
        }

        public static bool IsHoliday(DateTime date)
        {
            // Simplified holiday check
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }

    public static class EmailUtil
    {
        public static void SendEmail(string to, string subject, string body)
        {
            // Simplified email sending logic
            Console.WriteLine($"Sending Email to: {to}\nSubject: {subject}\nBody: {body}");
        }
    }

    public static class LogUtil
    {
        public static void Log(string message)
        {
            // Simplified logging logic
            Console.WriteLine($"Log: {message}");
        }
    }
    

    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }

    public interface ILogService
    {
        void Log(string message);
    }

    public class RegistrationService(IEmailService emailService, ILogService logService) // DI 
    {

        /* public void RegisterUser(string username, string email)
         {
             LogUtil.Log($"Registering user: {username}"); // Hard Dependency
             // Registration logic
             Console.WriteLine($"User {username} registered with email {email} on {DateUtil.ConvertToHumanReadable(DateTime.Now)}");
             // Send welcome email
             EmailUtil.SendEmail(email, "Welcome!", $"Hello {username}, welcome to our platform!"); // Hard Dependency
         }*/

        public void RegisterUser(string username, string email)
        {
            logService.Log($"Registering user: {username}"); // Hard Dependency
            // Registration logic
            Console.WriteLine($"User {username} registered with email {email} on {DateUtil.ConvertToHumanReadable(DateTime.Now)}");
            // Send welcome email
            emailService.SendEmail(email, "Welcome!", $"Hello {username}, welcome to our platform!"); // Hard Dependency
        }
    }
}
