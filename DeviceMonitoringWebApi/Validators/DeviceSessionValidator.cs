using DeviceMonitoringWebApi.Dto;
using DeviceMonitoringWebApi.Exceptions;

namespace DeviceMonitoringWebApi.Validators
{
    public static class DeviceSessionValidator
    {
        public static void ValidateCreateRequest(this CreateDeviceSessionRequest request)
        {
            Ensure.StringNotEmpty(request.Name, "Имя пользователя");
            Ensure.StringNotEmpty(request.Version, "Версия приложения");

            if (request.EndTime < request.StartTime)
                throw new SessionDateConflictException();
        }
    }
}
