using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SLib
{
    public class UiArtifacts
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //Check if windows with certain class names are present in the OS
        public Generic.SandboxRes checkWindowTitle()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());

            IntPtr hWnd = FindWindow("VBoxTrayToolWndClass", null);
            if (hWnd.ToInt32() != 0)
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", "VBoxTrayToolWndClass");
                returnData.tagList.Add(aux);
            }
            IntPtr hWnd2 = FindWindow(null, "VBoxTrayToolWnd");
            if (hWnd2.ToInt32() != 0)
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", "VBoxTrayToolWnd");
                returnData.tagList.Add(aux);
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if top level windows' number is too small
        public Generic.SandboxRes checkNWindows()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());

            Process[] processlist = Process.GetProcesses();
            int count = 0;
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    count++;
                }
            }
            if (count < 10)
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("Number of top level windows", count.ToString());
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
