namespace FormExample
{
    partial class Form1
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
            this.toggleMonitor = new System.Windows.Forms.CheckBox();
            this.monitors = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeout = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.timeout)).BeginInit();
            this.SuspendLayout();
            // 
            // toggleMonitor
            // 
            this.toggleMonitor.AutoSize = true;
            this.toggleMonitor.Location = new System.Drawing.Point(310, 37);
            this.toggleMonitor.Name = "toggleMonitor";
            this.toggleMonitor.Size = new System.Drawing.Size(65, 17);
            this.toggleMonitor.TabIndex = 0;
            this.toggleMonitor.Text = "Turn On";
            this.toggleMonitor.UseVisualStyleBackColor = true;
            this.toggleMonitor.CheckedChanged += new System.EventHandler(this.toggleIdleMonitor_CheckedChanged);
            // 
            // monitors
            // 
            this.monitors.FormattingEnabled = true;
            this.monitors.Location = new System.Drawing.Point(15, 32);
            this.monitors.Name = "monitors";
            this.monitors.Size = new System.Drawing.Size(177, 21);
            this.monitors.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "secs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Idle Monitor type:";
            // 
            // timeout
            // 
            this.timeout.Location = new System.Drawing.Point(210, 35);
            this.timeout.Name = "timeout";
            this.timeout.Size = new System.Drawing.Size(59, 20);
            this.timeout.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 67);
            this.Controls.Add(this.timeout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monitors);
            this.Controls.Add(this.toggleMonitor);
            this.Name = "Form1";
            this.Text = "IdleMonitor - Form";
            ((System.ComponentModel.ISupportInitialize)(this.timeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox toggleMonitor;
        private System.Windows.Forms.ComboBox monitors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown timeout;
    }
}

