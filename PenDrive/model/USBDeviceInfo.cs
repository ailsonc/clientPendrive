using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace PenDrive.model
{
    class USBDeviceInfo
    {
        public static List<USB> getDiskNames()
        {
            List<USB> usbs = new List<USB>();
        
            foreach (ManagementObject drive in new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive where InterfaceType='USB'").Get())
            {
                foreach (ManagementObject partition in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + drive["DeviceID"] + "'} WHERE AssocClass=Win32_DiskDriveToDiskPartition").Get())
                {
                    // associate partitions with logical disks (drive letter volumes)
                    foreach (ManagementObject disk in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass=Win32_LogicalDiskToPartition").Get())
                    {
                        USB usb = new USB(disk["DeviceID"].ToString(), drive["Caption"].ToString());
                        usbs.Add(usb);
                    }
                }
            }
            return usbs;
        }
    }
}
