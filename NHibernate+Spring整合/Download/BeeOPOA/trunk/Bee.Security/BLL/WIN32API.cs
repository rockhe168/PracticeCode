using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

namespace Bee.BLL
{
    public static class WIN32API
    {
        [DllImport("Iphlpapi.dll")]
        public static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        public static extern Int32 inet_addr(string ip);
    }
}
