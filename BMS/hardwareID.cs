using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading.Tasks;

namespace bms1
{
    class hardwareID
    {
        public static string Get_HardWareID => ReturnHardwareID().Result;
        private static async Task<string> ReturnHardwareID()
        {
            byte[] bytes;
            byte[] hashedBytes;
            StringBuilder sb = new StringBuilder();

            Task task = Task.Run(() =>
             {
                 ManagementObjectSearcher cpu = new ManagementObjectSearcher("Select * from Win32_Processor");
                 ManagementObjectCollection cpu_collection = cpu.Get();
                 foreach (ManagementObject obj in cpu_collection)
                 {
                     sb.Append(obj["ProcessorID"].ToString().Substring(0, 4));
                     break;
                 }

                 ManagementObjectSearcher bios = new ManagementObjectSearcher("Select * from Win32_BIOS");
                 ManagementObjectCollection bios_collection = bios.Get();
                 foreach (ManagementObject obj in bios_collection)
                 {
                     sb.Append(obj["Version"].ToString().Substring(0, 4));
                     break;
                 }

                 ManagementObjectSearcher hdd = new ManagementObjectSearcher("Select * from Win32_DiskDrive");
                 ManagementObjectCollection hdd_collection = cpu.Get();
                 foreach (ManagementObject obj in cpu_collection)
                 {
                     sb.Append(obj["Signature"].ToString().Substring(0, 4));
                     break;
                 }
             });
            Task.WaitAll(task);
            bytes = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            hashedBytes = System.Security.Cryptography.SHA256.Create().ComputeHash(bytes);
            return await Task.FromResult(Convert.ToBase64String(hashedBytes).Substring(25));
        }
    }
}
