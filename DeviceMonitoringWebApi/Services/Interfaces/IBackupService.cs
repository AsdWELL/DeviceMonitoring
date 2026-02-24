namespace DeviceMonitoringWebApi.Services.Interfaces
{
    public interface IBackupService
    {
        Task<string> CreateBackup();

        Task<List<string>> GetBackups();

        Task<Stream> DownloadBackup(string fileName);
    }
}
