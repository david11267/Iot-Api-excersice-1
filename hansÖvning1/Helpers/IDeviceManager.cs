using hansÖvning1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Shared;

namespace hansÖvning1.Helpers
{
    public interface IDeviceManager
    {
        public Task<Twin> GetDeviceAsync(string deviceId);
        public Task<string> CreateDeviceAsync(IotDevice iotDevice);
        public Task<string> GetOrCreateDeviceAsync(IotDevice iotDevice);
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
            Console.WriteLine("Creating device");
            return $"HostName=Shared-IOT-Hub.azure-devices.net;DeviceId={deviceResponse.Id};SharedAccessKey={deviceResponse.Authentication.SymmetricKey.PrimaryKey};Created";
        }

        public async Task<Twin> GetDeviceAsync(string deviceId)
        {
            try
            {
                var deviceResponse = await _registryManager.GetTwinAsync(deviceId);

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

        public async  Task<string> GetOrCreateDeviceAsync(IotDevice iotDevice)
        {
           var response =  await GetDeviceAsync(iotDevice.id.ToString());

            if (response == null)
            {
                Twin createdTwin = new Twin { DeviceId = iotDevice.id.ToString() };
                var created = await CreateDeviceAsync(iotDevice);
                return "Created Device";
            }
        
            return "Device found use get API call for more detail";
        }
    }
}
