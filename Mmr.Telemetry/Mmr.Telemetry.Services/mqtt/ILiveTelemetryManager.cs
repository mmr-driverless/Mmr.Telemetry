using Mmr.Telemetry.Services.Data;

namespace Mmr.Telemetry.Services.mqtt
{
    public interface ILiveTelemetryManager
    {
        public List<IMessage> LiveMessages { get; set; }
        public void AddTelemetry(Data.RawTelemetry newTelemetry);
    }
}
