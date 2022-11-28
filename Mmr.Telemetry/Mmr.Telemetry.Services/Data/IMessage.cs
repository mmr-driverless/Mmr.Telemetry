namespace Mmr.Telemetry.Services.Data
{
    public interface IMessage
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
