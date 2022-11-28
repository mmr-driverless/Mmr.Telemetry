
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Packets;

namespace Mmr.Telemetry.Services.mqtt
{
    public class MqttTelemetryClient : IMqttTelemetryClient
    {
        public MQTTnet.Client.IMqttClient Client { get; set; }
        public MqttClientOptions? Options { get; set; }
        public MqttTopicFilter Topic { get; set; }

        public MqttTelemetryClient(string topic)
        {
            var mqttFactory = new MqttFactory();
            this.Client = mqttFactory.CreateMqttClient();
            this.Options = new MqttClientOptionsBuilder()
                .WithClientId(Guid.NewGuid().ToString())
                .WithTcpServer("test.mosquitto.org", 1883)
                .WithCleanSession()
                .Build();

            this.Topic = new MqttTopicFilterBuilder()
                .WithTopic(topic) // mqtt.test
                .Build();
        }

        public async Task Connect()
        {
            try
            {
                await this.Client.ConnectAsync(this.Options);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task Disconnect()
        {
            try
            {
                await this.Client.DisconnectAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool IsConnected() { return this.Client.IsConnected; }
    }
}
