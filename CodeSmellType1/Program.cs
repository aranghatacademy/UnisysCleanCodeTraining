using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellType1
{
    public class Program
    {
        public static void Main()
        {
            /*var options =  new ReportOptions("Sales Report", DateTime.Now.AddMonths(-1), DateTime.Now, ExportFormat.PDF, Orientation.Portrait);
            var reportGenerator = new ReportGenerator();
            var report = reportGenerator.GenerateReport(options);*/


            /*try
            {
                var registerService = new OpaqueReturnTypes();
                // We dont know if the fails to register the user or it fails to throw a exception
                registerService.Register("anced", "ancd@test.com");
                Console.WriteLine("User registered successfully");
            }
            catch(Exception excp)
            {
                Console.WriteLine("Error while registering user");
                Console.WriteLine(excp.Message);
            }*/

            var registrationService = new RegistrationServiceWithResult();
            var result = registrationService.RegisterUser("Test", "test@1323.com");

            if(result.IsSuccess)
            {

            }
            else
            {
                Console.WriteLine("Registration FAiled with error {error}", result.ErrorMessage);
            }

        }
    }
}
