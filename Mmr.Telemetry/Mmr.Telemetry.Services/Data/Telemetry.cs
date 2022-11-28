using Mmr.Telemetry.Services.Enums;

namespace Mmr.Telemetry.Services.Data
{
    public class Telemetry
    {
        public Guid Id { get; set; }
        public CanBusEnum Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public IMessage[] Messages { get; set; }
        public Telemetry()
        {
            
        }
    }

}
