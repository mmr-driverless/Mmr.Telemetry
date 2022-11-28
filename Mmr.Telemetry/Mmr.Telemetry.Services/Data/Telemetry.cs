using Mmr.Telemetry.Services.Enums;

namespace Mmr.Telemetry.Services.Data
{
    public class Telemetry
    { 
        public Guid Id { get; set; }
        public CanBusEnum MessageType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public IMessage[]? Messages { get; set; }
        public Telemetry()
        {
            if (this.Messages == null)
            {
                this.MessageType = CanBusEnum.Unknown;
                this.Name = "Unknown Data Telemetry";
                this.Description = $"Telemetry received on {this.Date} of unknown data";
            }
            else
            {
                this.MessageType = this.Messages[0].MessageType;
                this.Name = $"{this.MessageType} Data Telemetry";
                var duration = this.Messages[this.Messages.Count() - 1].TimeStamp - this.Messages[0].TimeStamp;
                this.Description = $"Telemetry received on {this.Date} of {this.MessageType} data, of duration {duration}";
            }
        }
    }
}
