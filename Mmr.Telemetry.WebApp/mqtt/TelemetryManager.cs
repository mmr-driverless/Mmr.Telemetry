using System.Globalization;
using System.Text.Unicode;
using AutoMapper;
using Mmr.Telemetry.WebApp.Data;
using Mmr.Telemetry.WebApp.Enums;

namespace Mmr.Telemetry.WebApp.mqtt
{
    public class TelemetryManager : ITelemetryManager
    {
        private readonly IMapper mapper;

        public List<Data.Telemetry> Telemetries { get; set; } = new List<Data.Telemetry>()
        {
            new Data.Telemetry()
            {
                Name = "test-telemetry",
                Date = DateTime.Now,
                Description = "description",
                Id = Guid.NewGuid(),
                MessageType = CanBusEnum.Brake,
                Messages = new IMessage[]
                {
                    new ResMessage()
                    {
                        CanId = 10,
                        Id = 1,
                        MessageType = CanBusEnum.Brake,
                        TimeStamp = DateTime.Now
                    },
                    new ResMessage()
                    {
                        CanId = 20,
                        Id = 2,
                        MessageType = CanBusEnum.Brake,
                        TimeStamp = DateTime.Now
                    },
                    new ResMessage()
                    {
                        CanId = 30,
                        Id = 3,
                        MessageType = CanBusEnum.Brake,
                        TimeStamp = DateTime.Now
                    }
                }
            }
        };

        public TelemetryManager(IMapper mapper)
        {
            
        }

        public void AddTelemetry(Data.RawTelemetry newTelemetry)
        {
            var telemetry = new Data.Telemetry()
            {
                Id = newTelemetry.Id,
                Date = newTelemetry.Date,
                Messages = newTelemetry.Messages,
            };
            this.Telemetries.Add(telemetry);
        }
    }
}
