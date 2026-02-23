using DeviceMonitoringWebApi.Exceptions.Base;

namespace DeviceMonitoringWebApi.Exceptions
{
    public class SessionDateConflictException() : ConflictException("Устройство не может быть выключено раньше, чем включено");
}
