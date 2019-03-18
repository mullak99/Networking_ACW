namespace mullak99.ACW.NetworkACW.location.MenuPanels
{
    partial class SettingsPanel
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
            this.persistentAddrPanel = new System.Windows.Forms.Panel();
            this.persistentAddrDesc = new System.Windows.Forms.Label();
            this.persistentAddrButton = new System.Windows.Forms.Button();
            this.persistentAddrLabel = new System.Windows.Forms.Label();
            this.writeLogPanel = new System.Windows.Forms.Panel();
            this.writeLogDesc = new System.Windows.Forms.Label();
            this.writeLogButton = new System.Windows.Forms.Button();
            this.writeLogLabel = new System.Windows.Forms.Label();
            this.devModePanel = new System.Windows.Forms.Panel();
            this.devModeDesc = new System.Windows.Forms.Label();
            this.devModeButton = new System.Windows.Forms.Button();
            this.devModeLabel = new System.Windows.Forms.Label();
            this.autoConnPanel = new System.Windows.Forms.Panel();
            this.autoConnDesc = new System.Windows.Forms.Label();
            this.autoConnButton = new System.Windows.Forms.Button();
            this.autoConnLabel = new System.Windows.Forms.Label();
            this.persistentAddrPanel.SuspendLayout();
            this.writeLogPanel.SuspendLayout();
            this.devModePanel.SuspendLayout();
            this.autoConnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // persistentAddrPanel
            // 
            this.persistentAddrPanel.BackColor = System.Drawing.Color.Gray;
            this.persistentAddrPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.persistentAddrPanel.Controls.Add(this.persistentAddrDesc);
            this.persistentAddrPanel.Controls.Add(this.persistentAddrButton);
            this.persistentAddrPanel.Controls.Add(this.persistentAddrLabel);
            this.persistentAddrPanel.Location = new System.Drawing.Point(0, 3);
            this.persistentAddrPanel.Name = "persistentAddrPanel";
            this.persistentAddrPanel.Size = new System.Drawing.Size(650, 105);
            this.persistentAddrPanel.TabIndex = 0;
            // 
            // persistentAddrDesc
            // 
            this.persistentAddrDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.persistentAddrDesc.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.persistentAddrDesc.Location = new System.Drawing.Point(7, 38);
            this.persistentAddrDesc.Name = "persistentAddrDesc";
            this.persistentAddrDesc.Size = new System.Drawing.Size(640, 22);
            this.persistentAddrDesc.TabIndex = 2;
            this.persistentAddrDesc.Text = "Saves the last connected-to server address, port and time-out. Ensures that it is" +
    " kept across launches.\r\n";
            // 
            // persistentAddrButton
            // 
            this.persistentAddrButton.BackColor = System.Drawing.Color.Red;
            this.persistentAddrButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.persistentAddrButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.persistentAddrButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.persistentAddrButton.Location = new System.Drawing.Point(7, 65);
            this.persistentAddrButton.Name = "persistentAddrButton";
            this.persistentAddrButton.Size = new System.Drawing.Size(640, 34);
            this.persistentAddrButton.TabIndex = 1;
            this.persistentAddrButton.Text = "Disabled";
            this.persistentAddrButton.UseVisualStyleBackColor = false;
            this.persistentAddrButton.Click += new System.EventHandler(this.PersistentAddrButton_Click);
            // 
            // persistentAddrLabel
            // 
            this.persistentAddrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.persistentAddrLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.persistentAddrLabel.Location = new System.Drawing.Point(3, 5);
            this.persistentAddrLabel.Name = "persistentAddrLabel";
            this.persistentAddrLabel.Size = new System.Drawing.Size(644, 23);
            this.persistentAddrLabel.TabIndex = 0;
            this.persistentAddrLabel.Text = "Persistent Server Address";
            // 
            // writeLogPanel
            // 
            this.writeLogPanel.BackColor = System.Drawing.Color.Gray;
            this.writeLogPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.writeLogPanel.Controls.Add(this.writeLogDesc);
            this.writeLogPanel.Controls.Add(this.writeLogButton);
            this.writeLogPanel.Controls.Add(this.writeLogLabel);
            this.writeLogPanel.Location = new System.Drawing.Point(0, 107);
            this.writeLogPanel.Name = "writeLogPanel";
            this.writeLogPanel.Size = new System.Drawing.Size(650, 105);
            this.writeLogPanel.TabIndex = 3;
            // 
            // writeLogDesc
            // 
            this.writeLogDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writeLogDesc.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.writeLogDesc.Location = new System.Drawing.Point(7, 38);
            this.writeLogDesc.Name = "writeLogDesc";
            this.writeLogDesc.Size = new System.Drawing.Size(640, 23);
            this.writeLogDesc.TabIndex = 2;
            this.writeLogDesc.Text = "Saves all logging messages to a dedicated log file (LocationClient.log). Can be u" +
    "seful to diagnose errors.";
            // 
            // writeLogButton
            // 
            this.writeLogButton.BackColor = System.Drawing.Color.Red;
            this.writeLogButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.writeLogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writeLogButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.writeLogButton.Location = new System.Drawing.Point(7, 65);
            this.writeLogButton.Name = "writeLogButton";
            this.writeLogButton.Size = new System.Drawing.Size(640, 34);
            this.writeLogButton.TabIndex = 1;
            this.writeLogButton.Text = "Disabled";
            this.writeLogButton.UseVisualStyleBackColor = false;
            this.writeLogButton.Click += new System.EventHandler(this.WriteLogButton_Click);
            // 
            // writeLogLabel
            // 
            this.writeLogLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writeLogLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.writeLogLabel.Location = new System.Drawing.Point(3, 5);
            this.writeLogLabel.Name = "writeLogLabel";
            this.writeLogLabel.Size = new System.Drawing.Size(644, 23);
            this.writeLogLabel.TabIndex = 0;
            this.writeLogLabel.Text = "Write Log File";
            // 
            // devModePanel
            // 
            this.devModePanel.BackColor = System.Drawing.Color.Gray;
            this.devModePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.devModePanel.Controls.Add(this.devModeDesc);
            this.devModePanel.Controls.Add(this.devModeButton);
            this.devModePanel.Controls.Add(this.devModeLabel);
            this.devModePanel.Location = new System.Drawing.Point(0, 211);
            this.devModePanel.Name = "devModePanel";
            this.devModePanel.Size = new System.Drawing.Size(650, 105);
            this.devModePanel.TabIndex = 4;
            // 
            // devModeDesc
            // 
            this.devModeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devModeDesc.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.devModeDesc.Location = new System.Drawing.Point(7, 38);
            this.devModeDesc.Name = "devModeDesc";
            this.devModeDesc.Size = new System.Drawing.Size(640, 23);
            this.devModeDesc.TabIndex = 2;
            this.devModeDesc.Text = "Toggles Developer Mode. Enabled some \'advanced\' features and enables verbose logg" +
    "ing. Useful with \'Write Log File\'.";
            // 
            // devModeButton
            // 
            this.devModeButton.BackColor = System.Drawing.Color.Red;
            this.devModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.devModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devModeButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.devModeButton.Location = new System.Drawing.Point(7, 65);
            this.devModeButton.Name = "devModeButton";
            this.devModeButton.Size = new System.Drawing.Size(640, 34);
            this.devModeButton.TabIndex = 1;
            this.devModeButton.Text = "Disabled";
            this.devModeButton.UseVisualStyleBackColor = false;
            this.devModeButton.Click += new System.EventHandler(this.DevModeButton_Click);
            // 
            // devModeLabel
            // 
            this.devModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devModeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.devModeLabel.Location = new System.Drawing.Point(3, 5);
            this.devModeLabel.Name = "devModeLabel";
            this.devModeLabel.Size = new System.Drawing.Size(644, 23);
            this.devModeLabel.TabIndex = 0;
            this.devModeLabel.Text = "Developer Mode";
            // 
            // autoConnPanel
            // 
            this.autoConnPanel.BackColor = System.Drawing.Color.Gray;
            this.autoConnPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.autoConnPanel.Controls.Add(this.autoConnDesc);
            this.autoConnPanel.Controls.Add(this.autoConnButton);
            this.autoConnPanel.Controls.Add(this.autoConnLabel);
            this.autoConnPanel.Location = new System.Drawing.Point(0, 315);
            this.autoConnPanel.Name = "autoConnPanel";
            this.autoConnPanel.Size = new System.Drawing.Size(650, 105);
            this.autoConnPanel.TabIndex = 5;
            // 
            // autoConnDesc
            // 
            this.autoConnDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoConnDesc.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoConnDesc.Location = new System.Drawing.Point(7, 38);
            this.autoConnDesc.Name = "autoConnDesc";
            this.autoConnDesc.Size = new System.Drawing.Size(640, 23);
            this.autoConnDesc.TabIndex = 2;
            this.autoConnDesc.Text = "Automatically connect to the default server on launch. Useful with \'Persistant Se" +
    "rver Address\' if you only need to use one server.";
            // 
            // autoConnButton
            // 
            this.autoConnButton.BackColor = System.Drawing.Color.Red;
            this.autoConnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.autoConnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoConnButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.autoConnButton.Location = new System.Drawing.Point(7, 65);
            this.autoConnButton.Name = "autoConnButton";
            this.autoConnButton.Size = new System.Drawing.Size(640, 34);
            this.autoConnButton.TabIndex = 1;
            this.autoConnButton.Text = "Disabled";
            this.autoConnButton.UseVisualStyleBackColor = false;
            this.autoConnButton.Click += new System.EventHandler(this.AutoConnButton_Click);
            // 
            // autoConnLabel
            // 
            this.autoConnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoConnLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.autoConnLabel.Location = new System.Drawing.Point(3, 5);
            this.autoConnLabel.Name = "autoConnLabel";
            this.autoConnLabel.Size = new System.Drawing.Size(644, 23);
            this.autoConnLabel.TabIndex = 0;
            this.autoConnLabel.Text = "Auto-Connect";
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.autoConnPanel);
            this.Controls.Add(this.devModePanel);
            this.Controls.Add(this.writeLogPanel);
            this.Controls.Add(this.persistentAddrPanel);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(650, 422);
            this.persistentAddrPanel.ResumeLayout(false);
            this.writeLogPanel.ResumeLayout(false);
            this.devModePanel.ResumeLayout(false);
            this.autoConnPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel persistentAddrPanel;
        private System.Windows.Forms.Label persistentAddrDesc;
        private System.Windows.Forms.Button persistentAddrButton;
        private System.Windows.Forms.Label persistentAddrLabel;
        private System.Windows.Forms.Panel writeLogPanel;
        private System.Windows.Forms.Label writeLogDesc;
        private System.Windows.Forms.Button writeLogButton;
        private System.Windows.Forms.Label writeLogLabel;
        private System.Windows.Forms.Panel devModePanel;
        private System.Windows.Forms.Label devModeDesc;
        private System.Windows.Forms.Button devModeButton;
        private System.Windows.Forms.Label devModeLabel;
        private System.Windows.Forms.Panel autoConnPanel;
        private System.Windows.Forms.Label autoConnDesc;
        private System.Windows.Forms.Button autoConnButton;
        private System.Windows.Forms.Label autoConnLabel;
    }
}
