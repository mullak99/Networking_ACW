namespace mullak99.ACW.NetworkACW.location.MenuPanels
{
    partial class ConnectPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serverAddressTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.NumericUpDown();
            this.addressLabel = new System.Windows.Forms.Label();
            this.colonLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeoutDelayTextBox = new System.Windows.Forms.NumericUpDown();
            this.errorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.portTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutDelayTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // serverAddressTextBox
            // 
            this.serverAddressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverAddressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverAddressTextBox.ForeColor = System.Drawing.Color.Black;
            this.serverAddressTextBox.Location = new System.Drawing.Point(133, 55);
            this.serverAddressTextBox.Name = "serverAddressTextBox";
            this.serverAddressTextBox.Size = new System.Drawing.Size(301, 27);
            this.serverAddressTextBox.TabIndex = 0;
            this.serverAddressTextBox.TextChanged += new System.EventHandler(this.ServerAddressTextBox_TextChanged);
            this.serverAddressTextBox.Enter += new System.EventHandler(this.ServerAddressTextBox_Enter);
            this.serverAddressTextBox.Leave += new System.EventHandler(this.ServerAddressTextBox_Leave);
            // 
            // portTextBox
            // 
            this.portTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.portTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTextBox.ForeColor = System.Drawing.Color.Black;
            this.portTextBox.Location = new System.Drawing.Point(461, 55);
            this.portTextBox.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.portTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(120, 27);
            this.portTextBox.TabIndex = 1;
            this.portTextBox.Value = new decimal(new int[] {
            43,
            0,
            0,
            0});
            this.portTextBox.ValueChanged += new System.EventHandler(this.PortTextBox_ValueChanged);
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.addressLabel.Location = new System.Drawing.Point(43, 57);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(84, 20);
            this.addressLabel.TabIndex = 2;
            this.addressLabel.Text = "Address:";
            // 
            // colonLabel
            // 
            this.colonLabel.AutoSize = true;
            this.colonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colonLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.colonLabel.Location = new System.Drawing.Point(440, 57);
            this.colonLabel.Name = "colonLabel";
            this.colonLabel.Size = new System.Drawing.Size(15, 20);
            this.colonLabel.TabIndex = 3;
            this.colonLabel.Text = ":";
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.ForestGreen;
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.ForeColor = System.Drawing.SystemColors.Control;
            this.connectButton.Location = new System.Drawing.Point(3, 345);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(644, 73);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(43, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Timeout:";
            // 
            // timeoutDelayTextBox
            // 
            this.timeoutDelayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeoutDelayTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeoutDelayTextBox.ForeColor = System.Drawing.Color.Black;
            this.timeoutDelayTextBox.Location = new System.Drawing.Point(133, 105);
            this.timeoutDelayTextBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.timeoutDelayTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeoutDelayTextBox.Name = "timeoutDelayTextBox";
            this.timeoutDelayTextBox.Size = new System.Drawing.Size(89, 27);
            this.timeoutDelayTextBox.TabIndex = 6;
            this.timeoutDelayTextBox.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.timeoutDelayTextBox.ValueChanged += new System.EventHandler(this.TimeoutDelayTextBox_ValueChanged);
            // 
            // errorLabel
            // 
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.errorLabel.Location = new System.Drawing.Point(38, 233);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(574, 102);
            this.errorLabel.TabIndex = 7;
            this.errorLabel.Text = "errorPlaceholder";
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(222, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "ms";
            // 
            // ConnectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.timeoutDelayTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.colonLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.serverAddressTextBox);
            this.Name = "ConnectPanel";
            this.Size = new System.Drawing.Size(650, 422);
            ((System.ComponentModel.ISupportInitialize)(this.portTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutDelayTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serverAddressTextBox;
        private System.Windows.Forms.NumericUpDown portTextBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label colonLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown timeoutDelayTextBox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label label2;
    }
}
