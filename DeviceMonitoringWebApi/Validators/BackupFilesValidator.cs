using DeviceMonitoringWebApi.Exceptions;

namespace DeviceMonitoringWebApi.Validators
{
    public static class BackupFilesValidator
    {
        public static void ValidateFileName(this string fileName, string requiredExtension)
        {
            Ensure.StringNotEmpty(fileName, "Имя файла");

            var invalidChars = Path.GetInvalidFileNameChars();

            if (fileName.IndexOfAny(invalidChars) != -1 ||
                fileName.Contains("..") ||
                fileName.Contains('/') ||
                fileName.Contains('\\') ||
                !fileName.EndsWith(
                    requiredExtension.StartsWith('.')
                        ? requiredExtension
                        : $".{requiredExtension}",
                    StringComparison.OrdinalIgnoreCase))
                throw new InvalidBackupFileName(fileName);
        }
    }
}
