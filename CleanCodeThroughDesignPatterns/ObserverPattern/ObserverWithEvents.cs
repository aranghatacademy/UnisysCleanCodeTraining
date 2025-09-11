using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.ObserverPattern
{
   public interface IPublisher
   {
        event EventHandler<HighTempEventArgs> UpdateEventHandler;
   }

    public class HighTempEventArgs : EventArgs
    {
        public int Temperature { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }

    public class TemperatureSensor : IPublisher
    {
        public event EventHandler<HighTempEventArgs> UpdateEventHandler;

        public void SetTemperature(int temperature)
        {
            if (temperature > 80)
            {
                OnTemperatureChanged(new HighTempEventArgs { Temperature = temperature
                    , TimeStamp = DateTimeOffset.Now });
            }
        }

        protected virtual void OnTemperatureChanged(HighTempEventArgs e)
        {
            UpdateEventHandler?.Invoke(this, e);
        }
    }
}
