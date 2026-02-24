using DeviceMonitoringWebApi.Exceptions.Base;

namespace DeviceMonitoringWebApi.Validators
{
    public static class Ensure
    {
        public static void StringNotEmpty(string? value, string fieldName)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new InvalidFieldValueException($"Поле '{fieldName}' не может быть пустым");
        }
    }
}
