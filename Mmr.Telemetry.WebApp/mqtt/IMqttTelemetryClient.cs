using MQTTnet.Client;
using MQTTnet.Packets;

namespace Mmr.Telemetry.WebApp.mqtt
{
    public interface IMqttTelemetryClient
    {
        public MQTTnet.Client.IMqttClient Client { get; set; }
        public MqttClientOptions? Options { get; set; }
        public MqttTopicFilter Topic { get; set; }
        public Task Connect();
        public Task Disconnect();
        bool IsConnected();
    }
}
