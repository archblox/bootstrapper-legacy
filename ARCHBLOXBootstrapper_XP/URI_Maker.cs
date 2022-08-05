using System;
using System.Windows.Forms;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Text;
using System.Net;
using System.IO;

namespace ARCHBLOXProtocol
{
    class SharedVariables
    {
        public static string Arguments = "";
    };
    internal static class ARCHBLOXURIProtocol
    {
        private static RegistryKey softwareClasses = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Classes", true);

        internal static void Register()
        {
            // credit to p0s0 for helping me with this
            if (softwareClasses.OpenSubKey("archbloxstudio") == null) {} else { softwareClasses.DeleteSubKeyTree("archbloxstudio"); }
            RegistryKey key = softwareClasses.CreateSubKey("archbloxstudio");
            key.SetValue("", "URL: archbloxstudio Protocol");
            key.SetValue("URL Protocol", "");

            RegistryKey key1 = key.CreateSubKey("DefaultIcon");
            key1.SetValue("", ARCHBLOXBootstrapper_XP.Extensions.GetExecutablePath());

            RegistryKey key2 = key.CreateSubKey("shell");
            RegistryKey key3 = key2.CreateSubKey("open");

            RegistryKey key4 = key3.CreateSubKey("command");
            key4.SetValue("", "\"" + ARCHBLOXBootstrapper_XP.Extensions.GetExecutablePath() + "\" %1");

            key.Close();
            key1.Close();
            key2.Close();
            key3.Close();
            key4.Close();
        }
    }
}
