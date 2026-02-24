using DeviceMonitoringWebApi.Exceptions.Base;

namespace DeviceMonitoringWebApi.Exceptions
{
    public class BackupNotFoundException(string fileName) : NotFoundException($"Бекап {fileName} не найден");
}
