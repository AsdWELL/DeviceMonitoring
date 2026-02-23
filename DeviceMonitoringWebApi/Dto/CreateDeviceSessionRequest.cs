namespace DeviceMonitoringWebApi.Dto
{
    public class CreateDeviceSessionRequest
    {
        public string DeviceId { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Version { get; set; }
    }
}
