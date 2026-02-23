namespace DeviceMonitoringWebApi.Dto
{
    public class DeviceSessionResponse
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Version { get; set; }
    }
}
