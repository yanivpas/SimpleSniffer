namespace SimpleSniffer
{
    partial class SnifferForm
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
            this.connectionsList = new System.Windows.Forms.ListBox();
            this.resume_button = new System.Windows.Forms.Button();
            this.numberPackts_label = new System.Windows.Forms.Label();
            this.stop_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectionsList
            // 
            this.connectionsList.Dock = System.Windows.Forms.DockStyle.Left;
            this.connectionsList.FormattingEnabled = true;
            this.connectionsList.Location = new System.Drawing.Point(0, 0);
            this.connectionsList.Name = "connectionsList";
            this.connectionsList.Size = new System.Drawing.Size(341, 536);
            this.connectionsList.TabIndex = 0;
            this.connectionsList.SelectedIndexChanged += new System.EventHandler(this.connectionsList_SelectedIndexChanged);
            // 
            // resume_button
            // 
            this.resume_button.Location = new System.Drawing.Point(441, 343);
            this.resume_button.Name = "resume_button";
            this.resume_button.Size = new System.Drawing.Size(75, 23);
            this.resume_button.TabIndex = 1;
            this.resume_button.Text = "resume";
            this.resume_button.UseVisualStyleBackColor = true;
            this.resume_button.Click += new System.EventHandler(this.resume_button_Click);
            // 
            // numberPackts_label
            // 
            this.numberPackts_label.AutoSize = true;
            this.numberPackts_label.Location = new System.Drawing.Point(438, 275);
            this.numberPackts_label.Name = "numberPackts_label";
            this.numberPackts_label.Size = new System.Drawing.Size(60, 13);
            this.numberPackts_label.TabIndex = 2;
            this.numberPackts_label.Text = "no packets";
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(441, 385);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(75, 21);
            this.stop_button.TabIndex = 3;
            this.stop_button.Text = "stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // SnifferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 536);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.numberPackts_label);
            this.Controls.Add(this.resume_button);
            this.Controls.Add(this.connectionsList);
            this.Name = "SnifferForm";
            this.Text = "SnifferForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox connectionsList;
        private System.Windows.Forms.Button resume_button;
        private System.Windows.Forms.Label numberPackts_label;
        private System.Windows.Forms.Button stop_button;
    }
}