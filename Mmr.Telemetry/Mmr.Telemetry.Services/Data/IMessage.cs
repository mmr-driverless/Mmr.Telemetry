using Mmr.Telemetry.Services.Enums;

namespace Mmr.Telemetry.Services.Data
{
    public interface IMessage
    {
        public Guid Id { get; set; }
        public int CanId { get; set; }
        public DateTime TimeStamp { get; set; }
        public CanBusEnum MessageType { get; set; }
    }
}
