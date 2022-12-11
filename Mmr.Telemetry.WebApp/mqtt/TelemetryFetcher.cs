using System.Text;
using Mmr.Telemetry.WebApp.Data;
using MQTTnet.Client;
using Newtonsoft.Json;

namespace Mmr.Telemetry.WebApp.mqtt
{
    public class TelemetryFetcher : ITelemetryFetcher, IDisposable
    {
        public IMqttTelemetryClient Client { get; set; }
        public ITelemetryManager Manager { set; get; }
        public ILiveTelemetryManager LiveManager { get; set; }

        public TelemetryFetcher(IMqttTelemetryClient client, ITelemetryManager manager, ILiveTelemetryManager liveManager)
        {
            this.Client = client;
            this.Manager = manager;
            LiveManager = liveManager;

            client.Connect();

            while (!client.IsConnected())
            {
                Console.WriteLine("Connecting to MQTT Broker Service...");
            }
        }

        public void SubscribeEvents()
        {
            Client.Client.DisconnectedAsync += OnDisconnectedAsync;
            Client.Client.ConnectedAsync += OnConnectedAsync;
            Client.Client.ConnectingAsync += OnConnectingAsync;
            Client.Client.ApplicationMessageReceivedAsync += OnTelemetryReceivedAsync;
        }

        public void UnSubscribeEvents()
        {
            Client.Client.DisconnectedAsync -= OnDisconnectedAsync;
            Client.Client.ConnectedAsync -= OnConnectedAsync;
            Client.Client.ConnectingAsync -= OnConnectingAsync;
            Client.Client.ApplicationMessageReceivedAsync -= OnTelemetryReceivedAsync;
        }

        private async Task OnTelemetryReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            if(arg.ApplicationMessage.Topic!=Client.Topic.Topic)
                return;
            else
            {
                var jsonMessage = Encoding.UTF8.GetString(arg.ApplicationMessage.Payload);
                try
                {
                    var telemetry = JsonConvert.DeserializeObject<RawTelemetry>(jsonMessage);
                    Manager.AddTelemetry(telemetry);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        private Task OnConnectingAsync(MqttClientConnectingEventArgs arg)
        {
            Console.WriteLine("Connection attempt...");
            return Task.CompletedTask;
        }

        private Task OnConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            if (arg.ConnectResult.ResultCode != MqttClientConnectResultCode.Success)
                Console.WriteLine($"Connection failed with result {arg.ConnectResult.ResultCode}");
            else
            {
                Console.WriteLine($"Connection established. Assigned client ID = {arg.ConnectResult.AssignedClientIdentifier}");
                SubscribeEvents();
            }
                
            return Task.CompletedTask;
        }

        private async Task OnDisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            Console.WriteLine("Warning: connection lost");
            if(!Client.IsConnected())
                await Client.Connect();
        }

        public void Dispose()
        {
            Console.WriteLine("Disconnecting on close...");
            UnSubscribeEvents();
            this.Client.Disconnect();
        }
    }
}
