using DeviceMonitoringWebApi.Entities;

namespace DeviceMonitoringWebApi.Repositories.Interfaces
{
    public interface IDeviceSessionRepository
    {
        Task<int> AddDeviceSession(DeviceSession deviceSession);

        Task<List<DeviceSession>> GetAllDevices();

        Task<List<DeviceSession>> GetDeviceSessionsByDeviceId(int deviceId);
    }
}
