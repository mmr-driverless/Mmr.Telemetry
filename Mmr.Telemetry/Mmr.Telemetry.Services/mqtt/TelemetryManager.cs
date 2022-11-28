namespace Mmr.Telemetry.Services.mqtt
{
    public class TelemetryManager : ITelemetryManager
    {
        public List<Data.Telemetry> Telemetries { get; set; }
        public ITelemetryFetcher TelemetryFetcher { get; set; }

        public TelemetryManager()
        {
            
        }
    }
}
