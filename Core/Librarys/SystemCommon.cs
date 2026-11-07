using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Core.Librarys
{
    public class SystemCommon
    {
        public static string GetWindowsVersionName()
        {
            string name = string.Empty;
            try
            {
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject obj in managementObjectSearcher.Get())
                {
                    name = obj["Name"].ToString();
                }

                if (!string.IsNullOrEmpty(name) && name.IndexOf("|") != -1)
                {
                    name = name.Split('|')[0];
                }
            }
            catch
            {
                return "[无法获取系统版本]";
            }

            return name;
        }


    }
}
