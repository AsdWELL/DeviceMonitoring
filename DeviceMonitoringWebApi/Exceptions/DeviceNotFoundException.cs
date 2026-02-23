using DeviceMonitoringWebApi.Exceptions.Base;

namespace DeviceMonitoringWebApi.Exceptions
{
    public class DeviceNotFoundException(string deviceId) : NotFoundException($"Устройство с id {deviceId} не найдено");
}
