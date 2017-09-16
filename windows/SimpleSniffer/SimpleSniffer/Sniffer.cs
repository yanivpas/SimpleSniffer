using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SimpleSniffer
{
    class Sniffer
    {
        [DllImport("SnifferLib.dll", CallingConvention=CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern int sniffer_get(
            [In, Out, MarshalAs(UnmanagedType.LPStruct)] SnifferData data);

        [DllImport("SnifferLib.dll", EntryPoint="sniffer_init", CallingConvention=CallingConvention.Cdecl)]
        public static extern void sniffer_init();

        [DllImport("SnifferLib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int sniffer_get_inteface([In, Out, MarshalAs(UnmanagedType.SysInt)]  ref IntPtr bla);

        [DllImport("SnifferLib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int sniffer_set_inteface([In, MarshalAs(UnmanagedType.LPStr)]  string bla);

        public static List<string> get_interfaces()
        {
            var intefaces = new List<string>();
            var p_if_name = new IntPtr();

            Sniffer.sniffer_get_inteface(ref p_if_name);
            while (p_if_name != IntPtr.Zero)
            {
                intefaces.Add(Marshal.PtrToStringAnsi(p_if_name));
                Sniffer.sniffer_get_inteface(ref p_if_name);
            }
            return intefaces;
        }
        public static byte[] get_data_from_snifferdata(SnifferData snifferData)
        {
            byte[] data = new byte[snifferData.len];
            if (snifferData.len != 0 && snifferData.data != 0)
            {
                Marshal.Copy((IntPtr)snifferData.data, data, 0, snifferData.len);
            }
            return data;
        }
    }
}
