using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimpleSniffer
{
    public class Connection
    {
        char[] src;
        char[] dst;
        ushort src_port;
        ushort dst_port;
        List<Tuple<string, bool>> conversation;


        public Connection(SnifferData snifferData)
        {
            conversation = new List<Tuple<string, bool>>();
            src = snifferData.src;
            dst = snifferData.dst;
            src_port = snifferData.src_port;
            dst_port = snifferData.dst_port;
            add_data(snifferData);
        }

        public bool is_connection(SnifferData snifferData)
        {
            return ((src.SequenceEqual(snifferData.src) &&
                     dst.SequenceEqual(snifferData.dst) &&
                     src_port == snifferData.src_port &&
                     dst_port == snifferData.dst_port) ||
                     (src.SequenceEqual(snifferData.dst) &&
                     dst.SequenceEqual(snifferData.src) &&
                     src_port == snifferData.dst_port &&
                     dst_port == snifferData.src_port));
        }
        private bool direction(SnifferData snifferData)
        {
            return (src.SequenceEqual(snifferData.src) && src_port == snifferData.src_port);
        }
        public void add_data(SnifferData snifferData)
        {
            byte[] payload = Sniffer.get_data_from_snifferdata(snifferData);
            //string blabla = Encoding.ASCII.GetString(payload);
            string blabla = Encoding.UTF8.GetString(payload);
            blabla = Regex.Replace(blabla, @"[^\u0000-\u007F]+", ".");
            conversation.Add(new Tuple<string, bool>(blabla, direction(snifferData)));
        }
        public override string ToString()
        {
            return String.Format("{0:d}.{1:d}.{2:d}.{3:d}:{4} - {5:d}.{6:d}.{7:d}.{8:d}:{9}", 
                                (int)src[0], (int)src[1], (int)src[2], (int)src[3], (int)src_port,
                                (int)dst[0], (int)dst[1], (int)dst[2], (int)dst[3], (int)dst_port);
        }
        public List<Tuple<string, bool>> get_conversation()
        {
            return conversation;
        }
    }
}
