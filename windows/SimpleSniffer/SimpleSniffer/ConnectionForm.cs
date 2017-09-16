using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace SimpleSniffer
{
    public partial class ConnectionForm : Form
    {
        Connection conn;
    
        public ConnectionForm(Connection connection)
        {
            conn = connection;
            InitializeComponent();
            foreach (var side in connection.get_conversation())
            {
                connectionText.SelectionStart = connectionText.TextLength;
                connectionText.SelectionLength = 0;
                var color = Color.Blue;
                if (side.Item2)
                {
                    color = Color.Red;
                }
                connectionText.SelectionColor = color;
                connectionText.AppendText(side.Item1);
                connectionText.SelectionColor = connectionText.ForeColor;
            }

        }
       

        delegate void SetTextCallback(string text);

        private void AddText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.connectionText.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AddText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.connectionText.Text += text;
            }
        }

        private void connectionText_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
