using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusRabbitMq
{
    public interface IRabbitMqConnection : IDisposable
    {
        public bool IsConnected { get; }
        public bool TryConnect();

        IModel CreateModel();
    }
}
