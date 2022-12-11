
using Mmr.Telemetry.WebApp.Enums;

namespace Mmr.Telemetry.WebApp.Data
{
    public class SensingMessage : IMessage
    {
        private Guid _id;
        public int Id { get; set; }
        public int CanId { get; set; }

        Guid IMessage.Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime TimeStamp { get; set; }
        public CanBusEnum MessageType { get; set; }
    }
}
