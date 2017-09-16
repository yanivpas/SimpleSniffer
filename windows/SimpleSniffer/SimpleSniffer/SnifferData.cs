using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SimpleSniffer
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public class SnifferData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char [] src;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char [] dst;
        public UInt16 src_port;
        public UInt16 dst_port;
        public char pad1;
        public char tcp_flags;
        public char pad2;
        public UInt32 data;
        public char pad3;
        public UInt16 len;
        public char pad4;
        public IntPtr original_data;
    }
}
