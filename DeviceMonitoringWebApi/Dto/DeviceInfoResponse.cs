namespace DeviceMonitoringWebApi.Dto
{
    public class DeviceInfoResponse
    {
        public string DeviceId { get; set; }

        public string Name { get; set; }

        public DateTime LastSession { get; set; }
    }
}