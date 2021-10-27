using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusRabbitMQ
{
    public interface IRabbitMQConnection:IDisposable
    {
        public bool IsConnected { get; }
        public bool TryConnect();
        IModel CreateModel();
    }
}
