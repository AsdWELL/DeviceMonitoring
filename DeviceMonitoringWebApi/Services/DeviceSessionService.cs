using DeviceMonitoringWebApi.Dto;
using DeviceMonitoringWebApi.Exceptions;
using DeviceMonitoringWebApi.Mappers;
using DeviceMonitoringWebApi.Repositories.Interfaces;
using DeviceMonitoringWebApi.Services.Interfaces;
using DeviceMonitoringWebApi.Validators;

namespace DeviceMonitoringWebApi.Services
{
    public class DeviceSessionService(
        IDeviceSessionRepository deviceSessionRepository,
        ILogger<DeviceSessionService> logger) : IDeviceSessionService
    {
        private async Task ThrowIfDeviceNotExists(string deviceId)
        {
            if (!await deviceSessionRepository.IsDeviceExists(deviceId))
                throw new DeviceNotFoundException(deviceId);
        }
        
        public async Task<int> AddDeviceSession(CreateDeviceSessionRequest request)
        {
            request.ValidateCreateRequest();

            var sessionId = await deviceSessionRepository.AddDeviceSession(request.ToDomain());

            logger.LogInformation($"Добавлена сессия {sessionId} об устройстве {request.DeviceId}");

            return sessionId;
        }

        public async Task<List<DeviceInfoResponse>> GetAllDevices()
        {
            var devices = await deviceSessionRepository.GetAllDevices();

            logger.LogInformation($"Получен список устройств. Всего найдено ${devices.Count} устройств");

            return [.. devices.Select(device => device.ToDeviceInfoResponse())];
        }

        public async Task<List<DeviceSessionResponse>> GetDeviceSessionsByDeviceId(string deviceId)
        {
            await ThrowIfDeviceNotExists(deviceId);

            var sessionHistory = await deviceSessionRepository.GetDeviceSessionsByDeviceId(deviceId);

            logger.LogInformation($"Получена история сессия для устройства {deviceId}." +
                $" Найдено ${sessionHistory.Count} записей");

            return [.. sessionHistory.Select(session => session.ToDeviceSessionResponse())];
        }
    }
}
