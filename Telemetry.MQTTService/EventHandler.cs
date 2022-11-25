using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet.Client;
using MQTTnet.Server;

namespace Telemetry.MQTTService
{
    public class EventHandlerManager
    {
        public EventHandlerManager() { }

        public Task OnConnectionCompleted(MqttClientConnectedEventArgs arg)
        {
            Console.WriteLine("Client connected!");
            return Task.CompletedTask;
        }

        public void OnConnectionFailed()
        {
            Console.WriteLine("Client connection failed!");
        }

        public Task OnDisconnectedSuccessful(MqttClientDisconnectedEventArgs arg)
        {
            Console.WriteLine("Client disconnected!");
            return Task.CompletedTask;
        }

        public Task OnMessageReceived(MqttApplicationMessageReceivedEventArgs arg)
        {
            Console.WriteLine("One message received!\n");
            var text = Encoding.UTF8.GetString(arg.ApplicationMessage.Payload);
            Console.WriteLine("TEXT OF THE MESSAGE:");
            Console.WriteLine($"{text}\n");
            return Task.CompletedTask;
        }
    }
}
