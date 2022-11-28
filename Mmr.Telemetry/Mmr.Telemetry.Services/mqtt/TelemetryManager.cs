using System.Globalization;
using System.Text.Unicode;
using AutoMapper;
using Mmr.Telemetry.Services.Enums;

namespace Mmr.Telemetry.Services.mqtt
{
    public class TelemetryManager : ITelemetryManager
    {
        private readonly IMapper mapper;
        public List<Data.Telemetry> Telemetries { get; set; }
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
