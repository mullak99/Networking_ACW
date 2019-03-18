namespace mullak99.ACW.NetworkACW.locationserver.MenuPanels
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
            this.writeLogPanel = new System.Windows.Forms.Panel();
            this.autoStartDesc = new System.Windows.Forms.Label();
            this.autoStartButton = new System.Windows.Forms.Button();
            this.autoStartLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.writeLogDesc = new System.Windows.Forms.Label();
            this.writeLogButton = new System.Windows.Forms.Button();
            this.writeLogLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.writeDbDesc = new System.Windows.Forms.Label();
            this.writeDbButton = new System.Windows.Forms.Button();
            this.writeDbLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.devModeDesc = new System.Windows.Forms.Label();
            this.devModeButton = new System.Windows.Forms.Button();
            this.devModeLabel = new System.Windows.Forms.Label();
            this.writeLogPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // writeLogPanel
            // 
            this.writeLogPanel.BackColor = System.Drawing.Color.Gray;
            this.writeLogPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.writeLogPanel.Controls.Add(this.autoStartDesc);
            this.writeLogPanel.Controls.Add(this.autoStartButton);
            this.writeLogPanel.Controls.Add(this.autoStartLabel);
            this.writeLogPanel.Location = new System.Drawing.Point(0, 2);
            this.writeLogPanel.Name = "writeLogPanel";
            this.writeLogPanel.Size = new System.Drawing.Size(650, 105);
            this.writeLogPanel.TabIndex = 4;
            // 
            // autoStartDesc
            // 
            this.autoStartDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoStartDesc.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.autoStartDesc.Location = new System.Drawing.Point(7, 38);
            this.autoStartDesc.Name = "autoStartDesc";
            this.autoStartDesc.Size = new System.Drawing.Size(640, 23);
            this.autoStartDesc.TabIndex = 2;
            this.autoStartDesc.Text = "Automatically starts the server upon launch.";
            // 
            // autoStartButton
            // 
            this.autoStartButton.BackColor = System.Drawing.Color.Red;
            this.autoStartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.autoStartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoStartButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.autoStartButton.Location = new System.Drawing.Point(7, 65);
            this.autoStartButton.Name = "autoStartButton";
            this.autoStartButton.Size = new System.Drawing.Size(640, 34);
            this.autoStartButton.TabIndex = 1;
            this.autoStartButton.Text = "Disabled";
            this.autoStartButton.UseVisualStyleBackColor = false;
            this.autoStartButton.Click += new System.EventHandler(this.AutoStartButton_Click);
            // 
            // autoStartLabel
            // 
            this.autoStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoStartLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.autoStartLabel.Location = new System.Drawing.Point(3, 5);
            this.autoStartLabel.Name = "autoStartLabel";
            this.autoStartLabel.Size = new System.Drawing.Size(644, 23);
            this.autoStartLabel.TabIndex = 0;
            this.autoStartLabel.Text = "Auto-Start Server";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.writeLogDesc);
            this.panel1.Controls.Add(this.writeLogButton);
            this.panel1.Controls.Add(this.writeLogLabel);
            this.panel1.Location = new System.Drawing.Point(0, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 105);
            this.panel1.TabIndex = 4;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.writeDbDesc);
            this.panel2.Controls.Add(this.writeDbButton);
            this.panel2.Controls.Add(this.writeDbLabel);
            this.panel2.Location = new System.Drawing.Point(0, 210);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 105);
            this.panel2.TabIndex = 5;
            // 
            // writeDbDesc
            // 
            this.writeDbDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writeDbDesc.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.writeDbDesc.Location = new System.Drawing.Point(7, 38);
            this.writeDbDesc.Name = "writeDbDesc";
            this.writeDbDesc.Size = new System.Drawing.Size(640, 23);
            this.writeDbDesc.TabIndex = 2;
            this.writeDbDesc.Text = "Saves all person names and their locations to a SQLite DB file (LocationServer_DB" +
    ".db). Allows for persistent storage.";
            // 
            // writeDbButton
            // 
            this.writeDbButton.BackColor = System.Drawing.Color.Red;
            this.writeDbButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.writeDbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writeDbButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.writeDbButton.Location = new System.Drawing.Point(7, 65);
            this.writeDbButton.Name = "writeDbButton";
            this.writeDbButton.Size = new System.Drawing.Size(640, 34);
            this.writeDbButton.TabIndex = 1;
            this.writeDbButton.Text = "Disabled";
            this.writeDbButton.UseVisualStyleBackColor = false;
            this.writeDbButton.Click += new System.EventHandler(this.WriteDbButton_Click);
            // 
            // writeDbLabel
            // 
            this.writeDbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writeDbLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.writeDbLabel.Location = new System.Drawing.Point(3, 5);
            this.writeDbLabel.Name = "writeDbLabel";
            this.writeDbLabel.Size = new System.Drawing.Size(644, 23);
            this.writeDbLabel.TabIndex = 0;
            this.writeDbLabel.Text = "Write Database File";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.devModeDesc);
            this.panel3.Controls.Add(this.devModeButton);
            this.panel3.Controls.Add(this.devModeLabel);
            this.panel3.Location = new System.Drawing.Point(0, 314);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(650, 105);
            this.panel3.TabIndex = 6;
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
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.writeLogPanel);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(650, 422);
            this.writeLogPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel writeLogPanel;
        private System.Windows.Forms.Label autoStartDesc;
        private System.Windows.Forms.Button autoStartButton;
        private System.Windows.Forms.Label autoStartLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label writeLogDesc;
        private System.Windows.Forms.Button writeLogButton;
        private System.Windows.Forms.Label writeLogLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label writeDbDesc;
        private System.Windows.Forms.Button writeDbButton;
        private System.Windows.Forms.Label writeDbLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label devModeDesc;
        private System.Windows.Forms.Button devModeButton;
        private System.Windows.Forms.Label devModeLabel;
    }
}
