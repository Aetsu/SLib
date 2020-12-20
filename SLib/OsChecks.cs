using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Net;
using System.Windows.Forms;

namespace SLib
{
    public class OsChecks
    {
        //Check if username is specific
        public Generic.SandboxRes checkUsername()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            //General
            string[] list1 = { "admin", "andy", "honey", "john", "john doe", "malnetvm", "maltest", "malware", "roo", "sandbox", "snort", "tequilaboomboom", "test", "virus", "virusclone", "wilbert" };
            foreach (string name in list1)
            {
                try
                {
                    if (name.ToLower() == Environment.UserName.ToLower())
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("General", name);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[/] Error:" + e);
                }

            }
            //Nepenthes
            try
            {
                if ("nepenthes".ToLower() == Environment.UserName.ToLower())
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("Nepenthes", "nepenthes");
                    returnData.tagList.Add(aux);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[/] Error:" + e);
            }
            //Norman
            try
            {
                if ("currentuser".ToLower() == Environment.UserName.ToLower())
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("Norman", "currentuser");
                    returnData.tagList.Add(aux);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[/] Error:" + e);
            }
            //ThreatExpert
            try
            {
                if ("username".ToLower() == Environment.UserName.ToLower())
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("ThreatExpert", "username");
                    returnData.tagList.Add(aux);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[/] Error:" + e);
            }
            //Sandboxie
            try
            {
                if ("user".ToLower() == Environment.UserName.ToLower())
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("Sandboxie", "user");
                    returnData.tagList.Add(aux);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[/] Error:" + e);
            }
            //VMware
            try
            {
                if ("vmware".ToLower() == Environment.UserName.ToLower())
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("VMware", "vmware");
                    returnData.tagList.Add(aux);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[/] Error:" + e);
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if computer name is specific
        public Generic.SandboxRes checkComputerName()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            //Generic
            string[] list1 = { "klone_x64-pc", "tequilaboomboom" };
            foreach (string name in list1)
            {
                try
                {
                    if (name.ToLower() == Environment.MachineName.ToLower())
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("Generic", name);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[/] Error:" + e);
                }
            }
            //Anubis
            string[] list2 = { "TU-4NH09SMCG1HC", "InsideTm" };
            foreach (string name in list2)
            {
                try
                {
                    if (name.ToLower() == Environment.MachineName.ToLower())
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("Anubis", name);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[/] Error:" + e);
                }
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if host name is specific
        public Generic.SandboxRes checkHostName()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            //General
            try
            {
                if ("SystemIT".ToLower() == Dns.GetHostName().ToLower())
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("Generic", "SystemIT");
                    returnData.tagList.Add(aux);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[/] Error:" + e);
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if total RAM is low
        public Generic.SandboxRes checkComputerRAM()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            try
            {
                double minium = 1; //1GB
                ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
                ManagementObjectCollection results = searcher.Get();

                double res;
                double fres = 0;
                foreach (ManagementObject result in results)
                {
                    res = Convert.ToDouble(result["TotalVisibleMemorySize"]);
                    fres += Math.Round((res / (1024 * 1024)), 2);
                }
                if (fres <= minium)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("RAM", fres.ToString());
                    returnData.tagList.Add(aux);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[/] Error:" + e);
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if screen resolution is non-usual for host OS
        public Generic.SandboxRes checkScreenRes()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            //https://www.hobo-web.co.uk/best-screen-size/
            List<string> list1 = new List<string> { "1920x1080", "1366x768", "1440x900", "1536x864", "2560x1440", "1680x1050", "1280x720", "1280x800", "360x640", "1600x900" };
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            if (!list1.Contains(screenWidth + "x" + screenHeight))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("Screen resolution", screenWidth + "x" + screenHeight);
                returnData.tagList.Add(aux);
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if number of processors is low
        public Generic.SandboxRes checkNProcessors()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());

            if (Environment.ProcessorCount < 2)
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("Number of processors", Environment.ProcessorCount.ToString());
                returnData.tagList.Add(aux);
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if quantity of monitors is small
        public Generic.SandboxRes checkNScreens()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            int currentMonitorCount = Screen.AllScreens.Length;
            if (currentMonitorCount < 1)
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("Quantity of monitors", currentMonitorCount.ToString());
                returnData.tagList.Add(aux);
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if hard disk drive size and free space are small
        public Generic.SandboxRes checkHDSize()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            string mainDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                try
                {
                    if (mainDrive == d.Name)
                    {
                        if (Math.Round(((double)d.TotalSize / (1024 * 1024 * 1024)), 2) <= 60) //60GB
                        {
                            Generic.SandboxTag aux = new Generic.SandboxTag("Hard disk drive size", Math.Round(((double)d.TotalSize / (1024 * 1024 * 1024)), 2).ToString() + " GB");
                            returnData.tagList.Add(aux);
                        }
                        //if (Math.Round(((double)d.AvailableFreeSpace / (1024 * 1024 * 1024)), 2) <= 60) //60GB
                        //{
                        //    Generic.SandboxTag aux = new Generic.SandboxTag("Hard disk free space", Math.Round(((double)d.AvailableFreeSpace / (1024 * 1024 * 1024)), 2).ToString() + " GB");
                        //    returnData.tagList.Add(aux);
                        //}
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[/] Error:" + e);
                }

            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if system uptime is small
        public Generic.SandboxRes checkSystemUptime()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            int result = Environment.TickCount & Int32.MaxValue;
            int uptimeMax = 1000 * 60 * 12; // 12 minutes
            if (result < uptimeMax)
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("System uptime", result.ToString() + " milliseconds");
                returnData.tagList.Add(aux);
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }


        //[DllImport("kernel32.dll", SetLastError = true)]
        //static extern bool IsNativeVhdBoot(ref bool NativeVhdBoot);


        //Check if os was boot from virtual hard disk
        //public Generic.SandboxRes checkBootVirtual()
        //{
        //    Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
        //    bool isNative = false;
        //    bool auxB = false;
        //    isNative = IsNativeVhdBoot(ref auxB);
        //    if (isNative)
        //    {
        //        Generic.SandboxTag aux = new Generic.SandboxTag("Boot from virtual hard disk", isNative.ToString());
        //        returnData.tagList.Add(aux);
        //    }
        //    if (returnData.tagList.Count > 0)
        //    {
        //        returnData.isSandbox = true;
        //    }
        //    return returnData;
        //}
    }
}
