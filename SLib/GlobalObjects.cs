using System;
using System.Collections.Generic;
using System.Threading;

namespace SLib
{
    public class GlobalObjects
    {
        //Check for specific global mutexes
        public Generic.SandboxRes checkGlobalMutexes()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            //DeepFreeze
            Mutex m = null;
            bool doesNotExist = false;
            try
            {
                m = Mutex.OpenExisting("Frz_State");
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                doesNotExist = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("[/] Error:" + e);
            }
            if (doesNotExist == false)
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("DeepFreeze", "Frz_State");
                returnData.tagList.Add(aux);
            }
            //VirtualPC
            doesNotExist = false;
            try
            {
                m = Mutex.OpenExisting("MicrosoftVirtualPC7UserServiceMakeSureWe'reTheOnlyOneMutex");
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                doesNotExist = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("[/] Error:" + e);
            }
            if (doesNotExist == false)
            {
                Generic.SandboxTag aux = new Generic.SandboxTag("VirtualPC", "MicrosoftVirtualPC7UserServiceMakeSureWe'reTheOnlyOneMutex");
                returnData.tagList.Add(aux);
            }
            //Sandboxie
            string[] list1 = { @"Sandboxie_SingleInstanceMutex_Control", "SBIE_BOXED_ServiceInitComplete_Mutex1" };
            foreach (string mutexName in list1)
            {
                doesNotExist = false;
                try
                {
                    m = Mutex.OpenExisting(mutexName);
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    doesNotExist = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("[/] Error:" + e);
                }
                if (doesNotExist == false)
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("Sandboxie", mutexName);
                    returnData.tagList.Add(aux);
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
