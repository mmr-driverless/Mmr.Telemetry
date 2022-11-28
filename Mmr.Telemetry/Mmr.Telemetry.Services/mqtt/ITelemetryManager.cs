namespace Mmr.Telemetry.Services.mqtt
{
    public interface ITelemetryManager
    {
        public List<Data.Telemetry> Telemetries { get; set; }
        public void AddTelemetry(Data.RawTelemetry newTelemetry);
    }
}
