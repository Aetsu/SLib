using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace SLib
{
    public class RegistryQuery
    {
        //Check if particular registry paths exist
        public Generic.SandboxRes checkPath()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            //VMware
            try
            {
                RegistryKey regUser = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\VMware, Inc.\VMware Tools", false);
                if (regUser != null)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKCU\SOFTWARE\VMware, Inc.\VMware Tools");
                    returnData.tagList.Add(aux);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("[/] Error:" + e);
            }
            string[] list1 = { @"SOFTWARE\VMware, Inc.\VMware Tools", @"SYSTEM\ControlSet001\Services\vmdebug", @"SYSTEM\ControlSet001\Services\vmmouse", @"SYSTEM\ControlSet001\Services\VMTools", @"SYSTEM\ControlSet001\Services\VMMEMCTL", @"SYSTEM\ControlSet001\Services\vmware", @"SYSTEM\ControlSet001\Services\vmci", @"SYSTEM\ControlSet001\Services\vmx86" };
            foreach (string s in list1)
            {
                try
                {
                    RegistryKey regMachine = Registry.LocalMachine.OpenSubKey(s, false);
                    if (regMachine != null)
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VMware", "HKLM\\" + s);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }
            //General
            try
            {
                RegistryKey regMachine = Registry.LocalMachine.OpenSubKey(@"Software\Classes\Folder\shell\sandbox", false);
                if (regMachine != null)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("General", @"HKLM\Software\Classes\Folder\shell\sandbox");
                    returnData.tagList.Add(aux);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("[/] Error:" + e);
            }
            //Hyper-V
            string[] list2 = { @"SOFTWARE\Microsoft\Hyper-V", @"SOFTWARE\Microsoft\VirtualMachine", @"SOFTWARE\Microsoft\Virtual Machine\Guest\Parameters", @"SYSTEM\ControlSet001\Services\vmicheartbeat", @"SYSTEM\ControlSet001\Services\vmicvss", @"SYSTEM\ControlSet001\Services\vmicshutdown", @"SYSTEM\ControlSet001\Services\vmicexchange" };
            foreach (string s in list2)
            {
                try
                {
                    RegistryKey regMachine = Registry.LocalMachine.OpenSubKey(s, false);
                    if (regMachine != null)
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("Hyper-V", "HKLM\\" + s);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }
            //Sandboxie
            string[] list3 = { @"SYSTEM\CurrentControlSet\Services\SbieDrv", @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Sandboxie" };
            foreach (string s in list3)
            {
                try
                {
                    RegistryKey regMachine = Registry.LocalMachine.OpenSubKey(s, false);
                    if (regMachine != null)
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("Sandboxie", "HKLM\\" + s);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }
            //VirtualBox
            string[] list4 = { @"HARDWARE\ACPI\DSDT\VBOX__", @"HARDWARE\ACPI\FADT\VBOX__", @"HARDWARE\ACPI\RSDT\VBOX__", @"SOFTWARE\Oracle\VirtualBox Guest Additions", @"SYSTEM\ControlSet001\Services\VBoxGuest", @"SYSTEM\ControlSet001\Services\VBoxMouse", @"SYSTEM\ControlSet001\Services\VBoxService", @"SYSTEM\ControlSet001\Services\VBoxSF", @"SYSTEM\ControlSet001\Services\VBoxVideo" };
            foreach (string s in list4)
            {
                try
                {
                    RegistryKey regMachine = Registry.LocalMachine.OpenSubKey(s, false);
                    if (regMachine != null)
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", "HKLM\\" + s);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }
            //VirtualPC
            string[] list5 = { @"SYSTEM\ControlSet001\Services\vpcbus", @"SYSTEM\ControlSet001\Services\vpc-s3", @"SYSTEM\ControlSet001\Services\vpcuhub", @"SYSTEM\ControlSet001\Services\msvmmouf" };
            foreach (string s in list5)
            {
                try
                {
                    RegistryKey regMachine = Registry.LocalMachine.OpenSubKey(s, false);
                    if (regMachine != null)
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VirtualPC", "HKLM\\" + s);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }
            //Xen
            string[] list6 = { @"HARDWARE\ACPI\DSDT\xen", @"HARDWARE\ACPI\FADT\xen", @"HARDWARE\ACPI\RSDT\xen", @"SYSTEM\ControlSet001\Services\xenevtchn", @"SYSTEM\ControlSet001\Services\xennet", @"SYSTEM\ControlSet001\Services\xennet6", @"SYSTEM\ControlSet001\Services\xensvc", @"SYSTEM\ControlSet001\Services\xenvdb" };
            foreach (string s in list6)
            {
                try
                {
                    RegistryKey regMachine = Registry.LocalMachine.OpenSubKey(s, false);
                    if (regMachine != null)
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("Xen", "HKLM\\" + s);
                        returnData.tagList.Add(aux);
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("[/] Error:" + e);
                }
            }
            //Wine
            try
            {
                RegistryKey regUser = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Wine", false);
                if (regUser != null)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("Wine", @"SOFTWARE\Wine");
                    returnData.tagList.Add(aux);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("[/] Error:" + e);
            }
            try
            {
                RegistryKey regMachine = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wine", false);
                if (regMachine != null)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("Wine", @"SOFTWARE\Wine");
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

        //Check if particular registry keys contain specified strings
        public Generic.SandboxRes checkKeyValue()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            //VMWare
            if (checkKey("HKLM", @"HARDWARE\DEVICEMAP\Scsi\Scsi Port 0\Scsi Bus 0\Target Id 0\Logical Unit Id 0", "Identifier", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\HARDWARE\DEVICEMAP\Scsi\Scsi Port 0\Scsi Bus 0\Target Id 0\Logical Unit Id 0 : Identifier - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\DEVICEMAP\Scsi\Scsi Port 1\Scsi Bus 0\Target Id 0\Logical Unit Id 0", "Identifier", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\HARDWARE\DEVICEMAP\Scsi\Scsi Port 1\Scsi Bus 0\Target Id 0\Logical Unit Id 0 : Identifier - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\DEVICEMAP\Scsi\Scsi Port 2\Scsi Bus 0\Target Id 0\Logical Unit Id 0", "Identifier", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\HARDWARE\DEVICEMAP\Scsi\Scsi Port 2\Scsi Bus 0\Target Id 0\Logical Unit Id 0 : Identifier - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System", "SystemBiosVersion", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\HARDWARE\Description\System : SystemBiosVersion - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System", "SystemBiosVersion", "INTEL  - 6040000"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\HARDWARE\Description\System : SystemBiosVersion - INTEL - 6040000");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System", "VideoBiosVersion", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\HARDWARE\Description\System : VideoBiosVersion - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System\BIOS", "SystemProductName", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\HARDWARE\Description\System\BIOS : SystemProductName - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet001\Services\Disk\Enum", "0", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet001\Services\Disk\Enum : 0 - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet001\Services\Disk\Enum", "1", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet001\Services\Disk\Enum : 1 - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet001\Services\Disk\Enum", "DeviceDesc", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet001\Services\Disk\Enum : DeviceDesc - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet001\Services\Disk\Enum", "FriendlyName", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet001\Services\Disk\Enum : FriendlyName - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet001\Services\Disk\Enum", "DeviceDesc", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet001\Services\Disk\Enum : DeviceDesc - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet002\Services\Disk\Enum", "FriendlyName", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet002\Services\Disk\Enum : FriendlyName - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet002\Services\Disk\Enum", "DeviceDesc", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet002\Services\Disk\Enum : DeviceDesc - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet003\Services\Disk\Enum", "FriendlyName", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet003\Services\Disk\Enum : FriendlyName - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet003\Services\Disk\Enum", "DeviceDesc", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet003\Services\Disk\Enum : DeviceDesc - VMWARE");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKCR", @"Installer\Products", "ProductName", "vmware tools"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKCR\Installer\Products : ProductName - vmware tools");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKCU", @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", "DisplayName", "vmware tools"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall : DisplayName - vmware tools");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", "DisplayName", "vmware tools"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall : DisplayName - vmware tools");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000", "CoInstallers32", "vmx"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000 : CoInstallers32 - vmx");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000", "DriverDesc", "VMware"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000 : DriverDesc - VMware");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000", "InfSection", "vmx"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000 : InfSection - vmx");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000", "ProviderName", "VMware"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000 : ProviderName - VMware");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000", "Device Description", "VMware"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\ControlSet001\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}\0000 : Device Description - VMware");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\CurrentControlSet\Control\SystemInformation", "SystemProductName", "VMWARE"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\CurrentControlSet\Control\SystemInformation : SystemProductName - VMWARE");
                returnData.tagList.Add(aux);
            }
            RegistryKey regMachine = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Video", false);
            string[] valueNames = regMachine.GetSubKeyNames();
            foreach (string entry in valueNames)
            {
                if (checkKey("HKLM", @"SYSTEM\CurrentControlSet\Control\Video\" + entry + @"\Video", "Service", "vm3dmp"))
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\CurrentControlSet\Control\Video\" + entry + @"\Video : Service - vm3dmp");
                    returnData.tagList.Add(aux);
                }
                if (checkKey("HKLM", @"SYSTEM\CurrentControlSet\Control\Video\" + entry + @"\Video", "Service", "vmx_svga"))
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\CurrentControlSet\Control\Video\" + entry + @"\Video : Service - vmx_svga");
                    returnData.tagList.Add(aux);
                }
                if (checkKey("HKLM", @"SYSTEM\CurrentControlSet\Control\Video\" + entry + @"\0000", "Device Description", "VMware SVGA"))
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("VMware", @"HKLM\SYSTEM\CurrentControlSet\Control\Video\" + entry + @"\0000 : Device Description - VMware SVGA");
                    returnData.tagList.Add(aux);
                }
            }
            //Xen
            if (checkKey("HKLM", @"HARDWARE\Description\System\BIOS", "SystemProductName", "Xen"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("Xen", @"HKLM\HARDWARE\Description\System\BIOS : SystemProductName - Xen");
                returnData.tagList.Add(aux);
            }
            //General
            if (checkKey("HKLM", @"HARDWARE\Description\System\BIOS", "SystemProductName", "A M I"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("General", @"HKLM\HARDWARE\Description\System\BIOS : SystemProductName - A M I");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System", "SystemBiosDate", "06/23/99"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("General", @"HKLM\HARDWARE\Description\System : SystemBiosDate - 06/23/99");
                returnData.tagList.Add(aux);
            }
            //BOCHS
            if (checkKey("HKLM", @"HARDWARE\Description\System", "SystemBiosVersion", "BOCHS"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("BOCHS", @"HKLM\HARDWARE\Description\System : SystemBiosVersion - BOCHS");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System", "VideoBiosVersion", "BOCHS"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("BOCHS", @"HKLM\HARDWARE\Description\System : VideoBiosVersion - BOCHS");
                returnData.tagList.Add(aux);
            }
            //Anubis
            if (checkKey("HKLM", @"SOFTWARE\Microsoft\Windows\CurrentVersion", "ProductID", "76487-337-8429955-22614"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("Anubis", @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion : ProductID - 76487-337-8429955-22614");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductID", "76487-337-8429955-22614"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("Anubis", @"HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion : ProductID - 76487-337-8429955-22614");
                returnData.tagList.Add(aux);
            }
            //CwSandbox
            if (checkKey("HKLM", @"SOFTWARE\Microsoft\Windows\CurrentVersion", "ProductID", "76487-644-3177037-23510"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("CwSandbox", @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion : ProductID - 76487-644-3177037-23510");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductID", "76487-644-3177037-23510"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("CwSandbox", @"HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion : ProductID - 76487-644-3177037-23510");
                returnData.tagList.Add(aux);
            }
            //JoeBox
            if (checkKey("HKLM", @"SOFTWARE\Microsoft\Windows\CurrentVersion", "ProductID", "55274-640-2673064-23950"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("CwSandbox", @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion : ProductID - 55274-640-2673064-23950");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductID", "55274-640-2673064-23950"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("CwSandbox", @"HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion : ProductID - 55274-640-2673064-23950");
                returnData.tagList.Add(aux);
            }
            //Parallels
            if (checkKey("HKLM", @"HARDWARE\Description\System", "SystemBiosVersion", "PARALLELS"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("Parallels", @"HKLM\HARDWARE\Description\System : SystemBiosVersion - PARALLELS");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System", "VideoBiosVersion", "PARALLELS"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("Parallels", @"HKLM\HARDWARE\Description\System : VideoBiosVersion - PARALLELS");
                returnData.tagList.Add(aux);
            }
            //QEMU
            if (checkKey("HKLM", @"HARDWARE\DEVICEMAP\Scsi\Scsi Port 0\Scsi Bus 0\Target Id 0\Logical Unit Id 0", "Identifier", "QEMU"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("QEMU", @"HKLM\HARDWARE\DEVICEMAP\Scsi\Scsi Port 0\Scsi Bus 0\Target Id 0\Logical Unit Id 0 : Identifier - QEMU");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System", "SystemBiosVersion", "QEMU"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("QEMU", @"HKLM\HKLM\HARDWARE\Description\System : SystemBiosVersion - QEMU");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System", "VideoBiosVersion", "QEMU"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("QEMU", @"HKLM\HARDWARE\Description\System : VideoBiosVersion - QEMU");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System\BIOS	", "SystemManufacturer", "QEMU"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("QEMU", @"HKLM\HARDWARE\Description\System\BIOS : VideoBiosVersion - QEMU");
                returnData.tagList.Add(aux);
            }
            //VirtualBox
            if (checkKey("HKLM", @"HARDWARE\DEVICEMAP\Scsi\Scsi Port 0\Scsi Bus 0\Target Id 0\Logical Unit Id 0", "Identifier", "VBOX"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\HARDWARE\DEVICEMAP\Scsi\Scsi Port 0\Scsi Bus 0\Target Id 0\Logical Unit Id 0: Identifier - VBOX");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\DEVICEMAP\Scsi\Scsi Port 1\Scsi Bus 0\Target Id 0\Logical Unit Id 0", "Identifier", "VBOX"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\HARDWARE\DEVICEMAP\Scsi\Scsi Port 1\Scsi Bus 0\Target Id 0\Logical Unit Id 0: Identifier - VBOX");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\DEVICEMAP\Scsi\Scsi Port 2\Scsi Bus 0\Target Id 0\Logical Unit Id 0", "Identifier", "VBOX"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\HARDWARE\DEVICEMAP\Scsi\Scsi Port 2\Scsi Bus 0\Target Id 0\Logical Unit Id 0: Identifier - VBOX");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System", "SystemBiosVersion", "VBOX"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\HARDWARE\Description\System: SystemBiosVersion - VBOX");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System", "VideoBiosVersion", "VIRTUALBOX"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\HARDWARE\Description\System: VideoBiosVersion - VIRTUALBOX");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"HARDWARE\Description\System\BIOS", "SystemProductName", "VIRTUAL"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\HARDWARE\Description\System\BIOS: SystemProductName - VIRTUAL");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet001\Services\Disk\Enum", "DeviceDesc", "VBOX"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\SYSTEM\ControlSet001\Services\Disk\Enum: DeviceDesc - VBOX");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet001\Services\Disk\Enum", "FriendlyName", "VBOX"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\SYSTEM\ControlSet001\Services\Disk\Enum: FriendlyName - VBOX");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet002\Services\Disk\Enum", "DeviceDesc", "VBOX"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\SYSTEM\ControlSet002\Services\Disk\Enum: DeviceDesc - VBOX");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet002\Services\Disk\Enum", "FriendlyName", "VBOX"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\SYSTEM\ControlSet002\Services\Disk\Enum: FriendlyName - VBOX");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet003\Services\Disk\Enum", "DeviceDesc", "VBOX"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\SYSTEM\ControlSet003\Services\Disk\Enum: DeviceDesc - VBOX");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\ControlSet003\Services\Disk\Enum", "FriendlyName", "VBOX"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\SYSTEM\ControlSet003\Services\Disk\Enum: FriendlyName - VBOX");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\CurrentControlSet\Control\SystemInformation", "SystemProductName", "VIRTUAL"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\SYSTEM\CurrentControlSet\Control\SystemInformation: SystemProductName - VIRTUAL");
                returnData.tagList.Add(aux);
            }
            if (checkKey("HKLM", @"SYSTEM\CurrentControlSet\Control\SystemInformation", "SystemProductName", "VIRTUALBOX"))
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", @"HKLM\SYSTEM\CurrentControlSet\Control\SystemInformation: SystemProductName - VIRTUALBOX");
                returnData.tagList.Add(aux);
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        
        private bool checkKey(string root, string registryPath, string key, string value)
        {
            bool output = false;
            try
            {
                RegistryKey auxKey = null;
                if (root == "HKLM")
                {
                    auxKey = Registry.LocalMachine.OpenSubKey(registryPath, false);
                }
                else if (root == "HKCU")
                {
                    auxKey = Registry.CurrentUser.OpenSubKey(registryPath, false);
                }
                else if (root == "HKCR")
                {
                    auxKey = Registry.ClassesRoot.OpenSubKey(registryPath, false);
                }
                if (auxKey != null)
                {
                    object auxValue = auxKey.GetValue(key);
                    if (auxValue is string)
                    {
                        string v = (string)auxValue;
                        if (v.ToLower().Contains(value.ToLower()))
                        {
                            output = true;
                        }
                    }
                    else if (auxValue is string[])
                    {
                        string[] v = (string[])auxValue;
                        foreach (string element in v)
                        {
                            if (element.ToLower().Contains(value.ToLower()))
                            {
                                output = true;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                output = false;
            }
            return output;
        }
    }
}
