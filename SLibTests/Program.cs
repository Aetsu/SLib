using SLib;
using System;

namespace SLibTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Filesystem fsChecks = new Filesystem();
            Generic.SandboxRes fsRes1 = fsChecks.checkFiles();
            Console.WriteLine("[+] Filesystem detection methods");
            Console.WriteLine("   [-] Check if specific files exist");
            Console.WriteLine("     [*] Is sandbox? " + fsRes1.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in fsRes1.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }

            Generic.SandboxRes fsRes2 = fsChecks.checkDirectories();
            Console.WriteLine("   [-] Check if specific directories are present");
            Console.WriteLine("     [*] Is sandbox? " + fsRes2.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in fsRes2.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes fsRes3 = fsChecks.checkExePath();
            Console.WriteLine("   [-] Check if full path to the executable contains one of the specific strings &\n" +
                              "       Check if the executable is run from specific directory");
            Console.WriteLine("     [*] Is sandbox? " + fsRes3.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in fsRes3.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes fsRes4 = fsChecks.checkExeRoot();
            Console.WriteLine("   [-] Check if the executable files with specific names are present in physical disk drives' root");
            Console.WriteLine("     [*] Is sandbox? " + fsRes4.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in fsRes4.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Console.WriteLine();
            RegistryQuery rQuery = new RegistryQuery();
            Console.WriteLine("[+] Registry detection methods");
            Generic.SandboxRes rQueryRes1 = rQuery.checkPath();
            Console.WriteLine("   [-] Check if particular registry paths exist");
            Console.WriteLine("     [*] Is sandbox? " + rQueryRes1.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in rQueryRes1.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes rQueryRes2 = rQuery.checkKeyValue();
            Console.WriteLine("   [-] Check if particular registry keys contain specified strings");
            Console.WriteLine("     [*] Is sandbox? " + rQueryRes2.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in rQueryRes2.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }

            Console.WriteLine();
            OsChecks osCheck = new OsChecks();
            Console.WriteLine("[+] Detection via generic OS checks");
            Generic.SandboxRes osCheckRes1 = osCheck.checkUsername();
            Console.WriteLine("   [-] Check if username is specific");
            Console.WriteLine("     [*] Is sandbox? " + osCheckRes1.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in osCheckRes1.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes osCheckRes2 = osCheck.checkComputerName();
            Console.WriteLine("   [-] Check if computer name is specific");
            Console.WriteLine("     [*] Is sandbox? " + osCheckRes2.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in osCheckRes2.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes osCheckRes3 = osCheck.checkHostName();
            Console.WriteLine("   [-] Check if host name is specific");
            Console.WriteLine("     [*] Is sandbox? " + osCheckRes3.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in osCheckRes3.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes osCheckRes4 = osCheck.checkComputerRAM();
            Console.WriteLine("   [-] Check if total RAM is low");
            Console.WriteLine("     [*] Is sandbox? " + osCheckRes4.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in osCheckRes4.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes osCheckRes5 = osCheck.checkScreenRes();
            Console.WriteLine("   [-] Check if screen resolution is non-usual for host OS");
            Console.WriteLine("     [*] Is sandbox? " + osCheckRes5.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in osCheckRes5.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes osCheckRes6 = osCheck.checkNProcessors();
            Console.WriteLine("   [-] Check if number of processors is low");
            Console.WriteLine("     [*] Is sandbox? " + osCheckRes6.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in osCheckRes6.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes osCheckRes7 = osCheck.checkNScreens();
            Console.WriteLine("   [-] Check if quantity of monitors is small");
            Console.WriteLine("     [*] Is sandbox? " + osCheckRes7.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in osCheckRes7.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes osCheckRes8 = osCheck.checkHDSize();
            Console.WriteLine("   [-] Check if hard disk drive size and free space are small");
            Console.WriteLine("     [*] Is sandbox? " + osCheckRes8.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in osCheckRes8.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes osCheckRes9 = osCheck.checkSystemUptime();
            Console.WriteLine("   [-] Check if system uptime is small");
            Console.WriteLine("     [*] Is sandbox? " + osCheckRes9.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in osCheckRes9.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            //Generic.SandboxRes osCheckRes10 = osCheck.checkBootVirtual();
            //Console.WriteLine("   [-] Check if os was boot from virtual hard disk");
            //Console.WriteLine("     [*] Is sandbox? " + osCheckRes10.isSandbox.ToString());
            //foreach (Generic.SandboxTag tag in osCheckRes10.tagList)
            //{
            //    Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            //}

            Console.WriteLine();
            GlobalObjects gObjects = new GlobalObjects();
            Console.WriteLine("[+] Global objects detection methods");
            Generic.SandboxRes gObjects1 = gObjects.checkGlobalMutexes();
            Console.WriteLine("   [-] Check for specific global mutexes");
            Console.WriteLine("     [*] Is sandbox? " + gObjects1.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in gObjects1.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }

            Console.WriteLine();
            UiArtifacts uiArtifact = new UiArtifacts();
            Console.WriteLine("[+] UI artifacts detection methods");
            Generic.SandboxRes uiArtifactRes1 = uiArtifact.checkWindowTitle();
            Console.WriteLine("   [-] Check if windows with certain class names are present in the OS");
            Console.WriteLine("     [*] Is sandbox? " + uiArtifactRes1.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in uiArtifactRes1.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes uiArtifactRes2 = uiArtifact.checkNWindows();
            Console.WriteLine("   [-] Check if windows with certain class names are present in the OS");
            Console.WriteLine("     [*] Is sandbox? " + uiArtifactRes2.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in uiArtifactRes2.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }

            Console.WriteLine();
            OsFeatures osFeature = new OsFeatures();
            Console.WriteLine("[+] OS features detection methods");
            Generic.SandboxRes osFeatureRes1 = osFeature.checkDebugPrivs();
            Console.WriteLine("   [-] Checking debug privileges");
            Console.WriteLine("     [*] Is sandbox? " + osFeatureRes1.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in osFeatureRes1.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }

            Console.WriteLine();
            Processes processHelper = new Processes();
            Console.WriteLine("[+] Processes and libraries detection methods");
            Generic.SandboxRes processRes1 = processHelper.checkProcessName();
            Console.WriteLine("   [-] Check specific running processes and loaded libraries");
            Console.WriteLine("     [*] Is sandbox? " + processRes1.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in processRes1.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes processRes2 = processHelper.checkProcessDll();
            Console.WriteLine("   [-] Check if specific libraries are loaded in the process address space");
            Console.WriteLine("     [*] Is sandbox? " + processRes2.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in processRes2.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes processRes3 = processHelper.checkNProcess();
            Console.WriteLine("   [-] Check number of processes");
            Console.WriteLine("     [*] Is sandbox? " + processRes3.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in processRes3.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }

            Console.WriteLine();
            NetworkHelpers networkHelper = new NetworkHelpers();
            Console.WriteLine("[+] Network detection methods");
            Generic.SandboxRes networkRes1 = networkHelper.checkMac();
            Console.WriteLine("   [-] Check if MAC address is specific");
            Console.WriteLine("     [*] Is sandbox? " + networkRes1.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in networkRes1.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes networkRes2 = networkHelper.checkAdapterName();
            Console.WriteLine("   [-] Check if adapter name is specific");
            Console.WriteLine("     [*] Is sandbox? " + networkRes2.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in networkRes2.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes networkRes3 = networkHelper.checkIP();
            Console.WriteLine("   [-] Check if network belongs to security perimeter");
            Console.WriteLine("     [*] Is sandbox? " + networkRes3.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in networkRes3.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes networkRes4 = networkHelper.checkCuckoo();
            Console.WriteLine("   [-] Cuckoo ResultServer connection based anti-emulation technique");
            Console.WriteLine("     [*] Is sandbox? " + networkRes4.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in networkRes4.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }

            Console.WriteLine();
            Hardware hwHelper = new Hardware();
            Console.WriteLine("[+] Hardware info detection methods");
            Generic.SandboxRes hwRes1 = hwHelper.checkHdName();
            Console.WriteLine("   [-] Check if HDD has specific name");
            Console.WriteLine("     [*] Is sandbox? " + hwRes1.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in hwRes1.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes hwRes2 = hwHelper.checkHdVendor();
            Console.WriteLine("   [-] Check if HDD Vendor ID has specific value");
            Console.WriteLine("     [*] Is sandbox? " + hwRes2.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in hwRes2.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }
            Generic.SandboxRes hwRes3 = hwHelper.checkAudio();
            Console.WriteLine("   [-] Check if CPU temperature information is available");
            Console.WriteLine("     [*] Is sandbox? " + hwRes3.isSandbox.ToString());
            foreach (Generic.SandboxTag tag in hwRes3.tagList)
            {
                Console.WriteLine("       Tag: {0} -> {1}", tag.tag, tag.query);
            }

            Console.ReadLine();
        }
    }
}
