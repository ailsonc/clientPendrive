using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenDrive.model
{
    class USB
    {
        public USB(string deviceID, string caption)
        {
            this.deviceID = deviceID;
            this.caption = caption;
        }

        public string deviceID { get; private set; }
        public string caption { get; private set; }
    }
}
