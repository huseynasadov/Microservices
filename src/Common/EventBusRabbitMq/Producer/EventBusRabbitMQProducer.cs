using EventBusRabbitMq.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusRabbitMq.Producer
{
    public class EventBusRabbitMQProducer
    {
        private readonly IRabbitMqConnection _connection;

        public EventBusRabbitMQProducer(IRabbitMqConnection connection)
        {
            _connection = connection;
        }

        public void PublishBasketCheckout(string queueName, BasketCheckoutEvent basketModel) 
        {
            using (var channel = _connection.CreateModel()) 
            {
                channel.QueueDeclare(queueName,false,false,false,null);
                var message = JsonConvert.SerializeObject(basketModel);
                var body = Encoding.UTF8.GetBytes(message);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.DeliveryMode = 2;

                channel.ConfirmSelect();
                channel.BasicPublish("", queueName, properties, body);
                channel.WaitForConfirmsOrDie();

                channel.BasicAcks += (sender, eventArg) =>
                {
                    Console.WriteLine("send RabbitMq");
                };
                channel.ConfirmSelect();
            }
        }
        public void PublishOrderCheckout(string queueName, OrderCheckoutEvent orderModel)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queueName, false, false, false, null);
                var message = JsonConvert.SerializeObject(orderModel);
                var body = Encoding.UTF8.GetBytes(message);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.DeliveryMode = 2;

                channel.ConfirmSelect();
                channel.BasicPublish("", queueName, properties, body);
                channel.WaitForConfirmsOrDie();

                channel.BasicAcks += (sender, eventArg) =>
                {
                    Console.WriteLine("send RabbitMq");
                };
                channel.ConfirmSelect();
            }
        }
    }

}
