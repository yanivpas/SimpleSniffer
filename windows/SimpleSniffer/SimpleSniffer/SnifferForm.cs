using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace SimpleSniffer
{
    public partial class SnifferForm : Form
    {
        private Task sniffer;
        private string if_name;
        private volatile bool sniffer_running;
        List<Connection> connections;

        public SnifferForm(object sniffer_interface)
        {
            if_name = sniffer_interface.ToString();
            sniffer = new Task(sniffer_loop);
            connections = new List<Connection>();
            sniffer_running = true;
            sniffer.Start();
            var ret_value = Sniffer.sniffer_set_inteface(sniffer_interface.ToString());
            InitializeComponent();
        }

        delegate void UpdatePacketNumberCallback(int num);
        private void AddUpdatePacketNumber(int num)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.numberPackts_label.InvokeRequired)
            {
                UpdatePacketNumberCallback d = new UpdatePacketNumberCallback(AddUpdatePacketNumber);
                this.Invoke(d, new object[] { num });
            }
            else
            {
                this.numberPackts_label.Text = "Packet:" + num.ToString();
            }
        }

        private void resume_button_Click(object sender, EventArgs e)
        {
            sniffer_running = true;

        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            sniffer_running = false;
            foreach (var conn in connections)
            {
                var bla = conn.ToString();
                connectionsList.Items.Add(conn);
            }
        }
        private void add_connection(SnifferData data)
        {
            foreach (var conn in connections)
            {
                if(conn.is_connection(data))
                {
                    conn.add_data(data);
                    return;
                }
            }
            connections.Add(new Connection(data));
        }
        private void sniffer_loop()
        {
            Sniffer.sniffer_set_inteface(if_name);
            var data = new SnifferData();
            var result = 5;
            int packet = 0;
            while (true)
            {
                if (sniffer_running)
                {
                    result = Sniffer.sniffer_get(data);
                    if (result != 5)
                    {
                        packet++;
                        AddUpdatePacketNumber(packet);
                    }
                    if (result == 0)
                    {
                        add_connection(data);
                        //AddText("\n" + blabla + "\n");
                    }
                }
                else
                {
                    Thread.Sleep(10);
                }
            }

        }

        private void connectionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (connectionsList.SelectedItem != null)
            { 
                ConnectionForm m = new ConnectionForm((Connection)connectionsList.SelectedItem);
                m.Show();
            }
        }
    }
}
