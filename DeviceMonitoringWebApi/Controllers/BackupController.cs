using DeviceMonitoringWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace DeviceMonitoringWebApi.Controllers
{
    [Route("api/[controller]")]
    public class BackupController(IBackupService backupService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateBackup()
        {
            return Ok(await backupService.CreateBackup());
        }

        [HttpGet]
        public async Task<IActionResult> GetBackups()
        {
            return Ok(await backupService.GetBackups());
        }

        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> DownloadBackup(string fileName)
        {
            return File(await backupService.DownloadBackup(fileName), MediaTypeNames.Application.Json, fileName);
        }
    }
}
