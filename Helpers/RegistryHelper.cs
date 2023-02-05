using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFNavigation.Helpers
{
    public class RegistryHelper
    {

        private string _registryPath;

        public RegistryHelper(String path)
        {
            _registryPath = path;
        }
        
        public void WriteToCurrentUserInRegistry(String key, String value)
        {
            Microsoft.Win32.RegistryKey registryKey;
            registryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(_registryPath);
            registryKey.SetValue(key, value);
            registryKey.Close();
        }

        public String ReadFromCurrentUserInRegistry(String key)
        {
            Microsoft.Win32.RegistryKey registryKey;
            registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(_registryPath);
            return registryKey?.GetValue(key).ToString();
        }

    }
}
