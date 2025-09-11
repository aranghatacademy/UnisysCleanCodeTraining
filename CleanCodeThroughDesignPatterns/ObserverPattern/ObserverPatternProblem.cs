using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.ObserverPattern
{
    public class TemperatureObserver
    {
        private readonly AlarmStation _alarmStation;
        private readonly SendSMSService _sendSMSService;
        private readonly BroadCaseSOSToFireStation _broadCastService;

        public TemperatureObserver()
        {
            _alarmStation = new AlarmStation();
            _sendSMSService = new SendSMSService();
            _broadCastService = new BroadCaseSOSToFireStation();
        }

        public void UpdateTemperature(int temperature)
        {
            if(temperature > 80)
            {
                _alarmStation.RaiseAlarm();
                _sendSMSService.SendSMS("Temperature has exceeded the threshold!");
                _broadCastService.BroadCast("Emergency! High Temperature Alert!");
            }
        }
    }

    public class AlarmStation
    {
        public void RaiseAlarm()
        {
            Console.WriteLine("Alarm Raised! Temperature threshold exceeded.");
        }
    }

    public class SendSMSService
    {
        public void SendSMS(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    public class BroadCaseSOSToFireStation
    {
        public void BroadCast(string message)
        {
            Console.WriteLine($"Broadcasting to Fire Station: {message}");
        }
    }
}
