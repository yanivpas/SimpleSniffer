using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSniffer
{
    public partial class InterfacesForm : Form
    {
        private ListBox interfaceList;
        private List<string> interfaces;
        public InterfacesForm()
        {
            InitializeComponent();
            interfaces = Sniffer.get_interfaces();
            foreach (string if_name in interfaces)
            {
                interfaceList.Items.Add(if_name);
                Sniffer.sniffer_set_inteface(if_name);
            }
        }
        private void interfaceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (interfaceList.SelectedItem != null)
            {

                
                SnifferForm m = new SnifferForm(interfaceList.SelectedItem);
                m.Show();
            }

        }

        private void InitializeComponent()
        {
            this.interfaceList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // interfaceList
            // 
            this.interfaceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interfaceList.FormattingEnabled = true;
            this.interfaceList.Location = new System.Drawing.Point(0, 0);
            this.interfaceList.Name = "interfaceList";
            this.interfaceList.Size = new System.Drawing.Size(652, 366);
            this.interfaceList.TabIndex = 0;
            this.interfaceList.SelectedIndexChanged += new System.EventHandler(this.interfaceList_SelectedIndexChanged);
            // 
            // InterfacesForm
            // 
            this.ClientSize = new System.Drawing.Size(652, 366);
            this.Controls.Add(this.interfaceList);
            this.Name = "InterfacesForm";
            this.ResumeLayout(false);

        }

    }
}
