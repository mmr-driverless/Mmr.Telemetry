using Mmr.Telemetry.WebApp.Enums;

namespace Mmr.Telemetry.WebApp.Data
{
    public interface IMessage
    {
        public Guid Id { get; set; }
        public int CanId { get; set; }
        public DateTime TimeStamp { get; set; }
        public CanBusEnum MessageType { get; set; }
    }
}
