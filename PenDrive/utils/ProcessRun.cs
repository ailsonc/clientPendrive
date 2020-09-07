using PenDrive.exception;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenDrive.utils
{
    class ProcessRun
    {
        public static void processRun(String run)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo(run);
                info.UseShellExecute = true;
                info.Verb = "runas";
                Process.Start(info);
                Process.GetCurrentProcess().Kill();
            }
            catch (ExceptionProcess ep)
            {
                throw new ExceptionProcess(ep.Message);
            }
        }
    }
}
