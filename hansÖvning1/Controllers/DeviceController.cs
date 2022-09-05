using hansÖvning1.Helpers;
using hansÖvning1.Models;
using Microsoft.AspNetCore.Mvc;

namespace hansÖvning1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceManager _deviceManager;

        public DeviceController(IDeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
        }

        [HttpPost]
        public async Task <IActionResult> CreateIotDeviceAsync(IotDevice device)
        {
            return new OkObjectResult(await _deviceManager.CreateDeviceAsync(device));
        }

        [HttpGet]
        public async Task<IActionResult> GetIotDeviceAsync(string deviceId)
        {
            return new OkObjectResult(await _deviceManager.GetDeviceAsync(deviceId));
        }
    }
}
