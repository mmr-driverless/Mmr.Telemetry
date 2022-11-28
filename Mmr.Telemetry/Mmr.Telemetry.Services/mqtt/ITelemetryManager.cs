namespace Mmr.Telemetry.Services.mqtt
{
    public interface ITelemetryManager
    {
        public List<Data.Telemetry> Telemetries { get; set; }
        public ITelemetryFetcher TelemetryFetcher { get; set; }
    }
}
