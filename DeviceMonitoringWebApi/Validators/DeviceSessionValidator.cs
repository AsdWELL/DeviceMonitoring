using DeviceMonitoringWebApi.Dto;
using DeviceMonitoringWebApi.Exceptions;
using DeviceMonitoringWebApi.Exceptions.Base;

namespace DeviceMonitoringWebApi.Validators
{
    public static class DeviceSessionValidator
    {
        public static void EnsureStringNotEmpty(string? value, string fieldName)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new InvalidFieldValueException($"Поле '{fieldName}' не может быть пустым");
        }

        public static void ValidateCreateRequest(this CreateDeviceSessionRequest request)
        {
            EnsureStringNotEmpty(request.Name, "Имя пользователя");
            EnsureStringNotEmpty(request.Version, "Версия приложения");

            if (request.EndTime < request.StartTime)
                throw new SessionDateConflictException();
        }
    }
}
