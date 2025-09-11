using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.ObserverPattern
{
    public class OpenEmergencyDoors : IObserver
    {
        public void Update(int temperature)
        {
            Console.WriteLine("Emergency doors opened due to high temperature!");
        }
    }
}
