using hansÖvning1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Shared;

namespace hansÖvning1.Helpers
{
    public interface IDeviceManager
    {
        public Task<Twin> GetDeviceAsync(IotDevice iotDevice);
        public Task<string> CreateDeviceAsync(IotDevice iotDevice);
    }


    public class DeviceManager : IDeviceManager
    {
        private readonly IConfiguration _config;
        private readonly RegistryManager _registryManager;

        public DeviceManager(IConfiguration config)
        {
            _config = config;
            _registryManager = RegistryManager.CreateFromConnectionString(_config.GetConnectionString("IotHub"));

        }

        public async Task<string> CreateDeviceAsync(IotDevice iotDevice)
        {
           
            var deviceResponse = await _registryManager.AddDeviceAsync(new Device(iotDevice.id.ToString()));
            return $"HostName=Shared-IOT-Hub.azure-devices.net;DeviceId={deviceResponse.Id};SharedAccessKey={deviceResponse.Authentication.SymmetricKey.PrimaryKey}";
        }

        public async Task<Twin> GetDeviceAsync(IotDevice iotDevice)
        {
            try
            {
                var deviceResponse = await _registryManager.GetTwinAsync(iotDevice.id.ToString());

                if (deviceResponse != null)
                {
                    return deviceResponse;
                }
            }
            
            catch { }
            {
                return null!;

            }

        }
    }
}
