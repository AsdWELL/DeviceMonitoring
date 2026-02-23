using DeviceMonitoringWebApi.Dto;

namespace DeviceMonitoringWebApi.Services.Interfaces
{
    public interface IDeviceSessionService
    {
        Task<int> AddDeviceSession(CreateDeviceSessionRequest request);

        Task<List<DeviceInfoResponse>> GetAllDevices();

        Task<List<DeviceSessionResponse>> GetDeviceSessionsByDeviceId(string deviceId);
    }
}
