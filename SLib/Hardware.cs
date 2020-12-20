using System;
using System.Collections.Generic;
using System.Management;


namespace SLib
{
    public class Hardware
    {
        //Check if HDD has specific name
        public Generic.SandboxRes checkHdName()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());

            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in moSearcher.Get())
            {
                try
                {
                    //VMWare
                    if (wmi_HD["Model"].ToString().ToLower().Contains("VMWare".ToLower()))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VMWare", wmi_HD["Model"].ToString());
                        returnData.tagList.Add(aux);
                    }
                    //QEMU
                    if (wmi_HD["Model"].ToString().ToLower().Contains("QEMU".ToLower()))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("QEMU", wmi_HD["Model"].ToString());
                        returnData.tagList.Add(aux);
                    }
                    //VirtualBox
                    if (wmi_HD["Model"].ToString().ToLower().Contains("VBOX".ToLower()))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", wmi_HD["Model"].ToString());
                        returnData.tagList.Add(aux);
                    }
                    //VirtualPC
                    if (wmi_HD["Model"].ToString().ToLower().Contains("VIRTUAL HD".ToLower()))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VirtualPC", wmi_HD["Model"].ToString());
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if HDD Vendor ID has specific value
        public Generic.SandboxRes checkHdVendor()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());

            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in moSearcher.Get())
            {
                try
                {
                    //VMWare
                    if (wmi_HD["PNPDeviceID"].ToString().ToLower().Contains("vmware".ToLower()))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VMWare", wmi_HD["PNPDeviceID"].ToString());
                        returnData.tagList.Add(aux);
                    }
                    //VirtualBox
                    if (wmi_HD["PNPDeviceID"].ToString().ToLower().Contains("VBOX".ToLower()))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", wmi_HD["PNPDeviceID"].ToString());
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if CPU temperature information is available
        public Generic.SandboxRes checkAudio()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
            try
            {
                searcher.Get();
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    double temp = Convert.ToDouble(queryObj["CurrentTemperature"].ToString());
                    double temp_cel = (temp / 10 - 273.15);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("[/] Error:" + e);
                Generic.SandboxTag aux = new Generic.SandboxTag("CPU Temperature available", "False");
                returnData.tagList.Add(aux);
            }


            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }
    }
}
