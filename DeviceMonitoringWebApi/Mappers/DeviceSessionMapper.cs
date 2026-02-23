using DeviceMonitoringWebApi.Dto;
using DeviceMonitoringWebApi.Entities;

namespace DeviceMonitoringWebApi.Mappers
{
    public static class DeviceSessionMapper
    {
        public static DeviceSession ToDomain(this CreateDeviceSessionRequest request)
        {
            return new DeviceSession
            {
                DeviceId = request.DeviceId,
                Name = request.Name,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Version = request.Version
            };
        }

        public static DeviceInfoResponse ToDeviceInfoResponse(this DeviceSession deviceSession)
        {
            return new DeviceInfoResponse
            {
                DeviceId = deviceSession.DeviceId,
                Name = deviceSession.Name,
                LastSession = deviceSession.EndTime
            };
        }

        public static DeviceSessionResponse ToDeviceSessionResponse(this DeviceSession deviceSession)
        {
            return new DeviceSessionResponse
            {
                Name = deviceSession.Name,
                StartTime = deviceSession.StartTime,
                EndTime = deviceSession.EndTime,
                Version = deviceSession.Version
            };
        }
    }
}
