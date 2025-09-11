using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.ObserverPattern
{
    public interface IObserver
    {
        void Update(int temperature);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(int temp);
    }

    public class TemperatureObserverService : ISubject
    {
        private readonly List<IObserver> _observers;

        public TemperatureObserverService()
        {
            _observers = new List<IObserver>();
        }

        public void UpdateTemperature(int temperature)
        {
            if (temperature > 80)
            {
                NotifyObservers(temperature);
            }
        }

        public void NotifyObservers(int temp)
        {
            foreach (var observer in _observers)
            {
                observer.Update(temperature: temp); 
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }


    public class AlarmObserver : IObserver
    {
        public void Update(int temperature)
        {
            Console.WriteLine("Alarm Raised! Temperature threshold exceeded.");
        }
    }

    public class SMSObserver : IObserver
    {
        public void Update(int temperature)
        {
            Console.WriteLine($"SMS sent: Temperature has exceeded the threshold!");
        }
    }

    public class FireStationObserver : IObserver
    {
        public void Update(int temperature)
        {
            Console.WriteLine($"Broadcasting to Fire Station: Emergency! High Temperature Alert!");
        }
    }
}
