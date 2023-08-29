using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;

namespace SLib
{
    public class NetworkHelpers
    {
        //Check if MAC address is specific
        public Generic.SandboxRes checkMac()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            string[] list1 = { "000569", "000C29", "001C14", "005056" };
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    //VirtualBox
                    if (nic.GetPhysicalAddress().ToString().StartsWith("080027"))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VirtualBox", nic.GetPhysicalAddress().ToString());
                        returnData.tagList.Add(aux);
                    }
                    //Parallels
                    if (nic.GetPhysicalAddress().ToString().StartsWith("001C42"))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("Parallels", nic.GetPhysicalAddress().ToString());
                        returnData.tagList.Add(aux);
                    }
                    //Xen
                    if (nic.GetPhysicalAddress().ToString().StartsWith("0016E3"))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("Xen", nic.GetPhysicalAddress().ToString());
                        returnData.tagList.Add(aux);
                    }
                    //VMWare
                    foreach (string m in list1)
                    {
                        if (nic.GetPhysicalAddress().ToString().StartsWith(m))
                        {
                            Generic.SandboxTag aux = new Generic.SandboxTag("VMWare", nic.GetPhysicalAddress().ToString());
                            returnData.tagList.Add(aux);
                        }
                    }

                }
            }


            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if adapter name is specific
        public Generic.SandboxRes checkAdapterName()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    //VMWare
                    if (nic.Name.ToLower() == "vmware")
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("VMWare", nic.Name);
                        returnData.tagList.Add(aux);
                    }
                }
            }

            if (returnData.tagList.Count > 0)
            {
                returnData.isSandbox = true;
            }
            return returnData;
        }

        //Check if network belongs to security perimeter
        public Generic.SandboxRes checkIP()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            string[] list1 = { "Amazon", "anonymous", "BitDefender", "BlackOakComputers", "Blue Coat", "BlueCoat", "Cisco", "cloud", "Data Center", "DataCenter", "DataCentre", "dedicated", "ESET, Spol", "FireEye", "ForcePoint", "Fortinet", "Hetzner", "hispeed.ch", "hosted", "Hosting", "Iron Port", "IronPort", "LeaseWeb", "MessageLabs", "Microsoft", "MimeCast", "NForce", "Ovh Sas", "Palo Alto", "ProofPoint", "Rackspace", "security", "Server", "Strong Technologies", "Trend Micro", "TrendMicro", "TrustWave", "VMVault", "Zscaler" };
            string html = string.Empty;
            try
            {
                ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://geoip.maxmind.com/geoip/v2.1/city/me?");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.1; rv:11.3) like Gecko";
                request.Referer = "https://www.maxmind.com/en/locate-my-ip-address";

                if (request.Proxy != null)
                {
                    request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
                foreach (string tag in list1)
                {
                    if (html.ToLower().Contains(tag.ToLower()))
                    {
                        Generic.SandboxTag aux = new Generic.SandboxTag("Network tag", tag);
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

        //Cuckoo ResultServer connection based anti-emulation technique
        public Generic.SandboxRes checkCuckoo()
        {
            Generic.SandboxRes returnData = new Generic.SandboxRes(false, new List<Generic.SandboxTag>());
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation c in connections)
            {
                if (c.RemoteEndPoint.ToString().EndsWith(":2042"))
                {
                    Generic.SandboxTag aux = new Generic.SandboxTag("Cuckoo", c.RemoteEndPoint.ToString());
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
