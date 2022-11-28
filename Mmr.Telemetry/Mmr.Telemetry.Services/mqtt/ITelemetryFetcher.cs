using MQTTnet.Client;

namespace Mmr.Telemetry.Services.mqtt
{
    public interface ITelemetryFetcher
    {
        public IMqttTelemetryClient Client { get; set; }
        public ITelemetryManager Manager { set; get; }
        public void SubscribeEvents();
        public void UnSubscribeEvents();
    }
}
