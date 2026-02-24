using DeviceMonitoringWebApi.Exceptions.Base;

namespace DeviceMonitoringWebApi.Exceptions
{
    public class InvalidBackupFileName(string fileName) : BadRequestException($"Файл {fileName} содержит недопустимые символы");
}
