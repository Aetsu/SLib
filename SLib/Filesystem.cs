using System;
using System.Collections.Generic;
using System.IO;

namespace SLib
{
    public class Filesystem
    {
        //Check if specific files exist
        public Generic.SandboxRes checkFiles()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());

            string[] list1 = { @"c:\take_screenshot.ps1", @"c:\loaddll.exe", @"c:\email.doc", @"c:\email.htm", @"c:\123\email.doc", @"c:\123\email.docx", @"c:\a\foobar.bmp", @"c:\a\foobar.doc", @"c:\a\foobar.gif", @"c:\symbols\aagmmc.pdb" };
            foreach (string f in list1)
            {
                try
                {
                    if (File.Exists(f))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("General", f);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }

            }
            string[] list2 = { @"c:\windows\system32\drivers\prleth.sys", @"c:\windows\system32\drivers\prlfs.sys", @"c:\windows\system32\drivers\prlmouse.sys", @"c:\windows\system32\drivers\prlvideo.sys", @"c:\windows\system32\drivers\prltime.sys", @"c:\windows\system32\drivers\prl_pv32.sys", @"c:\windows\system32\drivers\prl_paravirt_32.sys" };
            foreach (string f in list2)
            {
                try
                {
                    if (File.Exists(f))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("Parallels", f);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }
            string[] list3 = { @"c:\windows\system32\drivers\VBoxMouse.sys", @"c:\windows\system32\drivers\VBoxGuest.sys", @"c:\windows\system32\drivers\VBoxSF.sys", @"c:\windows\system32\drivers\VBoxVideo.sys", @"c:\windows\system32\vboxdisp.dll", @"c:\windows\system32\vboxhook.dll", @"c:\windows\system32\vboxmrxnp.dll", @"c:\windows\system32\vboxogl.dll", @"c:\windows\system32\vboxoglarrayspu.dll", @"c:\windows\system32\vboxoglcrutil.dll", @"c:\windows\system32\vboxoglerrorspu.dll", @"c:\windows\system32\vboxoglfeedbackspu.dll", @"c:\windows\system32\vboxoglpackspu.dll", @"c:\windows\system32\vboxoglpassthroughspu.dll", @"c:\windows\system32\vboxservice.exe", @"c:\windows\system32\vboxtray.exe", @"c:\windows\system32\VBoxControl.exe" };
            foreach (string f in list3)
            {
                try
                {
                    if (File.Exists(f))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", f);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }
            string[] list4 = { @"c:\windows\system32\drivers\vmsrvc.sys", @"c:\windows\system32\drivers\vpc-s3.sys" };
            foreach (string f in list4)
            {
                try
                {
                    if (File.Exists(f))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VirtualPC", f);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }
            string[] list5 = { @"c:\windows\system32\drivers\vmmouse.sys", @"c:\windows\system32\drivers\vmnet.sys", @"c:\windows\system32\drivers\vmxnet.sys", @"c:\windows\system32\drivers\vmhgfs.sys", @"c:\windows\system32\drivers\vmx86.sys", @"c:\windows\system32\drivers\hgfs.sys" };
            foreach (string f in list5)
            {
                try
                {
                    if (File.Exists(f))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VMWare", f);
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

        //Check if specific directories are present
        public Generic.SandboxRes checkDirectories()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            try
            {
                if (Directory.Exists(@"c:\analysis"))
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("CWSandbox", @"c:\analysis");
                    returnData.tagList.Add(aux);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("[/] Error:" + e);
            }
            try
            {
                if (Directory.Exists(Environment.GetEnvironmentVariable("ProgramFiles") + @"\oracle\virtualbox guest additions"))
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", Environment.GetEnvironmentVariable("ProgramFiles") + @"\oracle\virtualbox guest additions");
                    returnData.tagList.Add(aux);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("[/] Error:" + e);
            }
            try
            {
                if (Directory.Exists(Environment.GetEnvironmentVariable("ProgramFiles") + @"\VMWare"))
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("VMWare", Environment.GetEnvironmentVariable("ProgramFiles") + @"\VMWare");
                    returnData.tagList.Add(aux);
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

        //Check if full path to the executable contains one of the specific strings
        //Check if the executable is run from specific directory
        public Generic.SandboxRes checkExePath()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            string[] list1 = { "sample", "virus", "sandbox" };
            foreach (string f in list1)
            {
                try
                {
                    if (Directory.GetCurrentDirectory().ToLower().Contains(f.ToLower()))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("General", f);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }
            string[] list2 = { @"c:\insidetm" };
            foreach (string f in list2)
            {
                try
                {
                    if (Directory.GetCurrentDirectory().ToLower().Contains(f.ToLower()))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("Anubis", f);
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

        //Check if the executable files with specific names are present in physical disk drives' root
        public Generic.SandboxRes checkExeRoot()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            string[] list1 = { "malware.exe", "sample.exe" };
            foreach (string f in list1)
            {
                try
                {
                    if (File.Exists(Path.GetPathRoot(Environment.SystemDirectory) + "\\" + f))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("General", f);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }
            string[] list2 = { @"c:\insidetm" };
            foreach (string f in list2)
            {
                try
                {
                    if (Directory.GetCurrentDirectory().ToLower().Contains(f.ToLower()))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("Anubis", f);
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
    }
}
