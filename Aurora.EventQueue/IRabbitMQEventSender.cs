using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.EventQueue
{
    public interface IRabbitMQEventSender
    {
        void SendMessage(Object message, string queueName);
    }
}
