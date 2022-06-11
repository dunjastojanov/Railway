using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace Railway
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptControlHelper
    {
        Railway.MainWindow mainWindow;
        
        public JavaScriptControlHelper(Railway.MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void RunFromJavascript(string param)
        {
            mainWindow.doThings(param);
        }
    }
}
