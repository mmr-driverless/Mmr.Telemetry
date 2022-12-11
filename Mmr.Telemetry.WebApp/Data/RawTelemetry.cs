namespace Mmr.Telemetry.WebApp.Data
{
    public class RawTelemetry
    {
        public Guid Id { get; set; }
        public DateTime? Date { get; set; }
        public IMessage[] Messages { get; set; }
    }
}
