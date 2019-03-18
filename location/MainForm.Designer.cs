namespace mullak99.ACW.NetworkACW.location
{
    partial class LocationClientForm
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
            this.components = new System.ComponentModel.Container();
            this.titleBar = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.settingsMenuButton = new mullak99.ACW.NetworkACW.LCHLib.mUI.CustomControls.SubMenuButton();
            this.setLocationMenuButton = new mullak99.ACW.NetworkACW.LCHLib.mUI.CustomControls.SubMenuButton();
            this.getLocationMenuButton = new mullak99.ACW.NetworkACW.LCHLib.mUI.CustomControls.SubMenuButton();
            this.connectMenuButton = new mullak99.ACW.NetworkACW.LCHLib.mUI.CustomControls.SubMenuButton();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.runtime = new System.Windows.Forms.Timer(this.components);
            this.settingsPanel = new mullak99.ACW.NetworkACW.location.MenuPanels.SettingsPanel();
            this.connectPanel = new mullak99.ACW.NetworkACW.location.MenuPanels.ConnectPanel();
            this.titleBar.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.titleBar.Controls.Add(this.titleLabel);
            this.titleBar.Controls.Add(this.quitButton);
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(800, 25);
            this.titleBar.TabIndex = 1;
            this.titleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.TitleBar_Paint);
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.titleLabel.Location = new System.Drawing.Point(3, 1);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(337, 25);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "LocationClient ";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.Transparent;
            this.quitButton.FlatAppearance.BorderSize = 0;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.LightGray;
            this.quitButton.Location = new System.Drawing.Point(776, 1);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(23, 23);
            this.quitButton.TabIndex = 1;
            this.quitButton.TabStop = false;
            this.quitButton.Text = "✖";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.QuitButton_Click);
            this.quitButton.MouseEnter += new System.EventHandler(this.QuitButton_MouseEnter);
            this.quitButton.MouseLeave += new System.EventHandler(this.QuitButton_MouseLeave);
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sidePanel.Controls.Add(this.panel1);
            this.sidePanel.Controls.Add(this.settingsMenuButton);
            this.sidePanel.Controls.Add(this.setLocationMenuButton);
            this.sidePanel.Controls.Add(this.getLocationMenuButton);
            this.sidePanel.Controls.Add(this.connectMenuButton);
            this.sidePanel.Controls.Add(this.copyrightLabel);
            this.sidePanel.Location = new System.Drawing.Point(0, 24);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(149, 426);
            this.sidePanel.TabIndex = 2;
            this.sidePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SidePanel_Paint);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(150, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 426);
            this.panel1.TabIndex = 3;
            // 
            // settingsMenuButton
            // 
            this.settingsMenuButton.BackColor = System.Drawing.Color.Transparent;
            this.settingsMenuButton.Location = new System.Drawing.Point(1, 245);
            this.settingsMenuButton.Name = "settingsMenuButton";
            this.settingsMenuButton.Selected = false;
            this.settingsMenuButton.Size = new System.Drawing.Size(147, 66);
            this.settingsMenuButton.TabIndex = 6;
            this.settingsMenuButton.Text = "Settings";
            this.settingsMenuButton.Click += new System.EventHandler(this.SettingsMenuButton_Click);
            // 
            // setLocationMenuButton
            // 
            this.setLocationMenuButton.BackColor = System.Drawing.Color.Transparent;
            this.setLocationMenuButton.Enabled = false;
            this.setLocationMenuButton.Location = new System.Drawing.Point(1, 177);
            this.setLocationMenuButton.Name = "setLocationMenuButton";
            this.setLocationMenuButton.Selected = false;
            this.setLocationMenuButton.Size = new System.Drawing.Size(147, 66);
            this.setLocationMenuButton.TabIndex = 5;
            this.setLocationMenuButton.Text = "Set Location";
            this.setLocationMenuButton.Click += new System.EventHandler(this.SetLocationMenuButton_Click);
            // 
            // getLocationMenuButton
            // 
            this.getLocationMenuButton.BackColor = System.Drawing.Color.Transparent;
            this.getLocationMenuButton.Enabled = false;
            this.getLocationMenuButton.Location = new System.Drawing.Point(1, 111);
            this.getLocationMenuButton.Name = "getLocationMenuButton";
            this.getLocationMenuButton.Selected = false;
            this.getLocationMenuButton.Size = new System.Drawing.Size(147, 66);
            this.getLocationMenuButton.TabIndex = 4;
            this.getLocationMenuButton.Text = "Get Location";
            this.getLocationMenuButton.Click += new System.EventHandler(this.GetLocationMenuButton_Click);
            // 
            // connectMenuButton
            // 
            this.connectMenuButton.BackColor = System.Drawing.Color.Transparent;
            this.connectMenuButton.Location = new System.Drawing.Point(1, 45);
            this.connectMenuButton.Name = "connectMenuButton";
            this.connectMenuButton.Selected = true;
            this.connectMenuButton.Size = new System.Drawing.Size(147, 66);
            this.connectMenuButton.TabIndex = 3;
            this.connectMenuButton.Text = "Connect";
            this.connectMenuButton.Click += new System.EventHandler(this.ConnectMenuButton_Click);
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.BackColor = System.Drawing.Color.Transparent;
            this.copyrightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyrightLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.copyrightLabel.Location = new System.Drawing.Point(3, 383);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(143, 37);
            this.copyrightLabel.TabIndex = 2;
            this.copyrightLabel.Text = "Apache 2.0 - 2019\r\nmullak99";
            this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // runtime
            // 
            this.runtime.Enabled = true;
            this.runtime.Tick += new System.EventHandler(this.Runtime_Tick);
            // 
            // settingsPanel
            // 
            this.settingsPanel.BackColor = System.Drawing.Color.Gray;
            this.settingsPanel.Location = new System.Drawing.Point(149, 26);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(650, 422);
            this.settingsPanel.TabIndex = 4;
            // 
            // connectPanel
            // 
            this.connectPanel.BackColor = System.Drawing.Color.Gray;
            this.connectPanel.Location = new System.Drawing.Point(149, 26);
            this.connectPanel.Name = "connectPanel";
            this.connectPanel.Size = new System.Drawing.Size(650, 422);
            this.connectPanel.TabIndex = 3;
            // 
            // LocationClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.connectPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "LocationClientForm";
            this.Text = "LocationClient";
            this.titleBar.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Label copyrightLabel;
        private LCHLib.mUI.CustomControls.SubMenuButton connectMenuButton;
        private LCHLib.mUI.CustomControls.SubMenuButton settingsMenuButton;
        private LCHLib.mUI.CustomControls.SubMenuButton setLocationMenuButton;
        private LCHLib.mUI.CustomControls.SubMenuButton getLocationMenuButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer runtime;
        private MenuPanels.ConnectPanel connectPanel;
        private MenuPanels.SettingsPanel settingsPanel;
    }
}

