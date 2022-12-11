using Mmr.Telemetry.WebApp.Data;

namespace Mmr.Telemetry.WebApp.mqtt
{
    public interface ILiveTelemetryManager
    {
        public List<IMessage> LiveMessages { get; set; }
        public void AddTelemetry(Data.RawTelemetry newTelemetry);
    }
}
