using System.Collections.Generic;
using System.Diagnostics;

namespace SLib
{
    public class Processes
    {
        //Check if specific files exist
        public Generic.SandboxRes checkProcessName()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            //VirtualBox
            string[] list1 = { "vboxservice", "vboxtray" };
            foreach (string p in list1)
            {
                Process[] pByName = Process.GetProcessesByName(p);
                if (pByName.Length > 0)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", p);
                    returnData.tagList.Add(aux);
                }
            }
            //JoeBox
            string[] list2 = { "joeboxserver", "joeboxcontrol" };
            foreach (string p in list2)
            {
                Process[] pByName = Process.GetProcessesByName(p);
                if (pByName.Length > 0)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("JoeBox", p);
                    returnData.tagList.Add(aux);
                }
            }
            //Parallels
            string[] list3 = { "prl_cc", "prl_tools" };
            foreach (string p in list3)
            {
                Process[] pByName = Process.GetProcessesByName(p);
                if (pByName.Length > 0)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("Parallels", p);
                    returnData.tagList.Add(aux);
                }
            }
            //VirtualPC
            string[] list4 = { "vmsrvc", "vmusrvc" };
            foreach (string p in list4)
            {
                Process[] pByName = Process.GetProcessesByName(p);
                if (pByName.Length > 0)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("VirtualPC", p);
                    returnData.tagList.Add(aux);
                }
            }
            //VMWare
            string[] list5 = { "vmtoolsd", "vmacthlp", "vmwaretray", "vmwareuser", "vmware", "vmount2" };
            foreach (string p in list5)
            {
                Process[] pByName = Process.GetProcessesByName(p);
                if (pByName.Length > 0)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("VMWare", p);
                    returnData.tagList.Add(aux);
                }
            }
            //Xen
            string[] list6 = { "xenservice", "xsvc_depriv" };
            foreach (string p in list6)
            {
                Process[] pByName = Process.GetProcessesByName(p);
                if (pByName.Length > 0)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("Xen", p);
                    returnData.tagList.Add(aux);
                }
            }
            //WPE Pro
            string[] list7 = { "WPE Pro" };
            foreach (string p in list7)
            {
                Process[] pByName = Process.GetProcessesByName(p);
                if (pByName.Length > 0)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("WPE Pro", p);
                    returnData.tagList.Add(aux);
                }
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }


        //Check if specific libraries are loaded in the process address space
        public Generic.SandboxRes checkProcessDll()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            Process currentProcess = Process.GetCurrentProcess();
            ProcessModuleCollection myProcessModuleCollection = currentProcess.Modules;
            List<string> list1 = new List<string> { "api_log.dll", "dir_watch.dll", "pstorec.dll" };
            foreach (ProcessModule m in myProcessModuleCollection)
            {
                //CWSandbox
                if (list1.Contains(m.ModuleName.ToLower()))
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("CWSandbox", m.ModuleName);
                    returnData.tagList.Add(aux);
                }
                //Sandboxie
                if ("sbiedll.dll" == m.ModuleName.ToLower())
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("Sandboxie", m.ModuleName);
                    returnData.tagList.Add(aux);
                }
                //ThreatExpert
                if ("dbghelp.dll" == m.ModuleName.ToLower())
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("ThreatExpert", m.ModuleName);
                    returnData.tagList.Add(aux);
                }
                //VirtualPC
                if ("vmcheck.dll" == m.ModuleName.ToLower())
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("VirtualPC", m.ModuleName);
                    returnData.tagList.Add(aux);
                }
                //WPE Pro
                if ("wpespy.dll" == m.ModuleName.ToLower())
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("WPE Pro", m.ModuleName);
                    returnData.tagList.Add(aux);
                }
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check number of processes
        public Generic.SandboxRes checkNProcess()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            Process[] processL = Process.GetProcesses();
            if (processL.Length < 85)
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("Number of processes", processL.Length.ToString());
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
