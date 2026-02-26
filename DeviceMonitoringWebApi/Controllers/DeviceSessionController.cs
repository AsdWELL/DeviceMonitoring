using DeviceMonitoringWebApi.Dto;
using DeviceMonitoringWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeviceMonitoringWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceSessionController(IDeviceSessionService deviceSessionService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddDeviceSession(CreateDeviceSessionRequest request)
        {
            return Ok(new { Id = await deviceSessionService.AddDeviceSession(request) });
        }

        [HttpGet("devices")]
        public async Task<IActionResult> GetAllDevices()
        {
            return Ok(await deviceSessionService.GetAllDevices());
        }

        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetDeviceSessionsByDeviceId([FromRoute] string deviceId)
        {
            return Ok(await deviceSessionService.GetDeviceSessionsByDeviceId(deviceId));
        }
    }
}
