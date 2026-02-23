namespace DeviceMonitoringWebApi.Entities
{
    public class DeviceSession
    {
        public int Id { get; set; }

        public string DeviceId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Version { get; set; }
    }
}