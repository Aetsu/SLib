using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SLib
{
    public class OsFeatures
    {
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            QueryLimitedInformation = 0x1000
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess,
                                         bool bInheritHandle, int dwProcessId);


        //Checking debug privileges
        public Generic.SandboxRes checkDebugPrivs()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            try
            {
                Process[] target = Process.GetProcessesByName("csrss");
                if (target.Length > 0)
                {
                    IntPtr hprocess = OpenProcess(ProcessAccessFlags.QueryLimitedInformation, false, target[0].Id);
                    if (hprocess != IntPtr.Zero)
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("Debug privileges", "Enabled");
                        returnData.tagList.Add(aux);
                    }

                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("[/] Error:" + e);
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }
    }
}
