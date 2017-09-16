namespace SimpleSniffer
{
    partial class ConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connectionText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // connectionText
            // 
            this.connectionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionText.Location = new System.Drawing.Point(0, 0);
            this.connectionText.Name = "connectionText";
            this.connectionText.ReadOnly = true;
            this.connectionText.Size = new System.Drawing.Size(943, 541);
            this.connectionText.TabIndex = 0;
            this.connectionText.Text = "";
            this.connectionText.TextChanged += new System.EventHandler(this.connectionText_TextChanged);
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 541);
            this.Controls.Add(this.connectionText);
            this.Name = "ConnectionForm";
            this.Text = "ConnectionForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox connectionText;
    }
}