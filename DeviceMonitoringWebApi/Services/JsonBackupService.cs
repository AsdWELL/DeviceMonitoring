using DeviceMonitoringWebApi.Exceptions;
using DeviceMonitoringWebApi.Repositories.Interfaces;
using DeviceMonitoringWebApi.Services.Interfaces;
using DeviceMonitoringWebApi.Validators;
using System.Text.Json;

namespace DeviceMonitoringWebApi.Services
{
    public class JsonBackupService(
        IDeviceSessionRepository deviceSessionRepository,
        ILogger<JsonBackupService> logger) : IBackupService
    {
        private readonly string _backupPath = Path.Combine(Directory.GetCurrentDirectory(), "Backups");

        private void CreateBackupDirectoryIfNotExists()
        {
            if (!Directory.Exists(_backupPath))
                Directory.CreateDirectory(_backupPath);
        }

        private void ThrowIfBackupFileNotExists(string fileName)
        {
            var filePath = Path.Combine(_backupPath, fileName);

            if (!File.Exists(filePath))
                throw new BackupNotFoundException(fileName);
        }

        public async Task<string> CreateBackup()
        {
            CreateBackupDirectoryIfNotExists();

            var fileName = $"backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.json";
            var filePath = Path.Combine(_backupPath, fileName);

            var sessions = await deviceSessionRepository.GetAllSessions();
            
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(sessions, jsonOptions);

            await File.WriteAllTextAsync(filePath, json);

            logger.LogInformation($"Создан бекап БД {fileName}");

            return fileName;
        }

        public Task<Stream> DownloadBackup(string fileName)
        {
            fileName.ValidateFileName("json");

            ThrowIfBackupFileNotExists(fileName);

            var filePath = Path.Combine(_backupPath, fileName);

            var fstream = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                4096,
                true);

            logger.LogInformation($"Бекап {fileName} доступен для скачивания");

            return Task.FromResult<Stream>(fstream);
        }

        public Task<List<string>> GetBackups()
        {
            CreateBackupDirectoryIfNotExists();

            var files = Directory.GetFiles(_backupPath, "*.json")
                .Select(Path.GetFileName)
                .OrderByDescending(f => f)
                .ToList();

            logger.LogInformation($"Найдено бекапов: {files.Count}");

            return Task.FromResult(files);
        }
    }
}
