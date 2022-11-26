namespace Mmr.Telemetry.Services.Enums
{
    public class CanBusEnums
    {

        public static IDictionary<CanBusEnum, string> CanBusDictionary = new Dictionary<CanBusEnum, string>()
        {
            { CanBusEnum.Res, "RES" },
            { CanBusEnum.Sensing, "S" },
            { CanBusEnum.AutonomousState, "AS" },
            { CanBusEnum.Mission, "M" },
            { CanBusEnum.Drive, "D" },
            { CanBusEnum.EcuBosch, "ECU" },
            { CanBusEnum.ControlSignal, "CS" },
            { CanBusEnum.Steering, "ST" },
            { CanBusEnum.Brake, "BRK" },
            { CanBusEnum.Logging, "L" },
        };
    }
    public enum CanBusEnum
    {
        Res,
        Sensing,
        AutonomousState,
        Mission,
        Drive,
        EcuBosch,
        ControlSignal,
        Steering,
        Brake,
        Logging
    }
}
