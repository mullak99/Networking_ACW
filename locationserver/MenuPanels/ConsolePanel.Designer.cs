namespace mullak99.ACW.NetworkACW.locationserver.MenuPanels
{
    partial class ConsolePanel
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
            this.consoleWindow = new System.Windows.Forms.RichTextBox();
            this.clearConsoleButton = new System.Windows.Forms.Button();
            this.stopServer = new System.Windows.Forms.Button();
            this.rebootServer = new System.Windows.Forms.Button();
            this.startServer = new System.Windows.Forms.Button();
            this.serverPowerLabel = new System.Windows.Forms.Label();
            this.uptimeLabel = new System.Windows.Forms.Label();
            this.upTimeCount = new System.Windows.Forms.Label();
            this.consoleManLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.portTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // consoleWindow
            // 
            this.consoleWindow.BackColor = System.Drawing.SystemColors.ControlText;
            this.consoleWindow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleWindow.ForeColor = System.Drawing.SystemColors.Window;
            this.consoleWindow.Location = new System.Drawing.Point(3, 3);
            this.consoleWindow.Name = "consoleWindow";
            this.consoleWindow.ReadOnly = true;
            this.consoleWindow.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.consoleWindow.Size = new System.Drawing.Size(644, 336);
            this.consoleWindow.TabIndex = 11;
            this.consoleWindow.TabStop = false;
            this.consoleWindow.Text = "";
            this.consoleWindow.TextChanged += new System.EventHandler(this.ConsoleWindow_TextChanged);
            // 
            // clearConsoleButton
            // 
            this.clearConsoleButton.BackColor = System.Drawing.Color.Teal;
            this.clearConsoleButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearConsoleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearConsoleButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clearConsoleButton.Location = new System.Drawing.Point(3, 366);
            this.clearConsoleButton.Name = "clearConsoleButton";
            this.clearConsoleButton.Size = new System.Drawing.Size(261, 53);
            this.clearConsoleButton.TabIndex = 12;
            this.clearConsoleButton.Text = "Clear Console";
            this.clearConsoleButton.UseVisualStyleBackColor = false;
            this.clearConsoleButton.Click += new System.EventHandler(this.ClearConsoleButton_Click);
            // 
            // stopServer
            // 
            this.stopServer.BackColor = System.Drawing.Color.Red;
            this.stopServer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stopServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopServer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.stopServer.Location = new System.Drawing.Point(564, 366);
            this.stopServer.Name = "stopServer";
            this.stopServer.Size = new System.Drawing.Size(83, 29);
            this.stopServer.TabIndex = 13;
            this.stopServer.Text = "Stop";
            this.stopServer.UseVisualStyleBackColor = false;
            this.stopServer.Click += new System.EventHandler(this.StopServer_Click);
            // 
            // rebootServer
            // 
            this.rebootServer.BackColor = System.Drawing.Color.Goldenrod;
            this.rebootServer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rebootServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rebootServer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rebootServer.Location = new System.Drawing.Point(475, 366);
            this.rebootServer.Name = "rebootServer";
            this.rebootServer.Size = new System.Drawing.Size(83, 29);
            this.rebootServer.TabIndex = 14;
            this.rebootServer.Text = "Reboot";
            this.rebootServer.UseVisualStyleBackColor = false;
            this.rebootServer.Click += new System.EventHandler(this.RebootServer_Click);
            // 
            // startServer
            // 
            this.startServer.BackColor = System.Drawing.Color.ForestGreen;
            this.startServer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startServer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.startServer.Location = new System.Drawing.Point(386, 366);
            this.startServer.Name = "startServer";
            this.startServer.Size = new System.Drawing.Size(83, 29);
            this.startServer.TabIndex = 15;
            this.startServer.Text = "Start";
            this.startServer.UseVisualStyleBackColor = false;
            this.startServer.Click += new System.EventHandler(this.StartServer_Click);
            // 
            // serverPowerLabel
            // 
            this.serverPowerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverPowerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.serverPowerLabel.Location = new System.Drawing.Point(386, 343);
            this.serverPowerLabel.Name = "serverPowerLabel";
            this.serverPowerLabel.Size = new System.Drawing.Size(261, 17);
            this.serverPowerLabel.TabIndex = 16;
            this.serverPowerLabel.Text = "Server Controls";
            this.serverPowerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uptimeLabel
            // 
            this.uptimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uptimeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.uptimeLabel.Location = new System.Drawing.Point(270, 343);
            this.uptimeLabel.Name = "uptimeLabel";
            this.uptimeLabel.Size = new System.Drawing.Size(110, 17);
            this.uptimeLabel.TabIndex = 17;
            this.uptimeLabel.Text = "Uptime";
            this.uptimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upTimeCount
            // 
            this.upTimeCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upTimeCount.ForeColor = System.Drawing.SystemColors.Control;
            this.upTimeCount.Location = new System.Drawing.Point(270, 366);
            this.upTimeCount.Name = "upTimeCount";
            this.upTimeCount.Size = new System.Drawing.Size(110, 53);
            this.upTimeCount.TabIndex = 18;
            this.upTimeCount.Text = "00:00:00";
            this.upTimeCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // consoleManLabel
            // 
            this.consoleManLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleManLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.consoleManLabel.Location = new System.Drawing.Point(3, 343);
            this.consoleManLabel.Name = "consoleManLabel";
            this.consoleManLabel.Size = new System.Drawing.Size(261, 17);
            this.consoleManLabel.TabIndex = 19;
            this.consoleManLabel.Text = "Console Management";
            this.consoleManLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // portLabel
            // 
            this.portLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.portLabel.Location = new System.Drawing.Point(418, 400);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(51, 17);
            this.portLabel.TabIndex = 20;
            this.portLabel.Text = "Port:";
            this.portLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // portTextBox
            // 
            this.portTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.portTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTextBox.ForeColor = System.Drawing.Color.Black;
            this.portTextBox.Location = new System.Drawing.Point(475, 398);
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
            this.portTextBox.Size = new System.Drawing.Size(83, 21);
            this.portTextBox.TabIndex = 21;
            this.portTextBox.Value = new decimal(new int[] {
            43,
            0,
            0,
            0});
            // 
            // ConsolePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.consoleManLabel);
            this.Controls.Add(this.upTimeCount);
            this.Controls.Add(this.uptimeLabel);
            this.Controls.Add(this.serverPowerLabel);
            this.Controls.Add(this.startServer);
            this.Controls.Add(this.rebootServer);
            this.Controls.Add(this.stopServer);
            this.Controls.Add(this.clearConsoleButton);
            this.Controls.Add(this.consoleWindow);
            this.Name = "ConsolePanel";
            this.Size = new System.Drawing.Size(650, 422);
            ((System.ComponentModel.ISupportInitialize)(this.portTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox consoleWindow;
        private System.Windows.Forms.Button clearConsoleButton;
        private System.Windows.Forms.Button stopServer;
        private System.Windows.Forms.Button rebootServer;
        private System.Windows.Forms.Button startServer;
        private System.Windows.Forms.Label serverPowerLabel;
        private System.Windows.Forms.Label uptimeLabel;
        private System.Windows.Forms.Label upTimeCount;
        private System.Windows.Forms.Label consoleManLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.NumericUpDown portTextBox;
    }
}
