namespace mullak99.ACW.NetworkACW.locationserver
{
    partial class LocationServerForm
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
            this.databaseMenuButton = new mullak99.ACW.NetworkACW.LCHLib.mUI.CustomControls.SubMenuButton();
            this.consoleMenuButton = new mullak99.ACW.NetworkACW.LCHLib.mUI.CustomControls.SubMenuButton();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.runtime = new System.Windows.Forms.Timer(this.components);
            this.consolePanel = new mullak99.ACW.NetworkACW.locationserver.MenuPanels.ConsolePanel();
            this.settingsPanel = new mullak99.ACW.NetworkACW.locationserver.MenuPanels.SettingsPanel();
            this.databasePanel = new mullak99.ACW.NetworkACW.locationserver.MenuPanels.DatabasePanel();
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
            this.titleBar.TabIndex = 3;
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
            this.titleLabel.Text = "LocationServer ";
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
            this.sidePanel.Controls.Add(this.databaseMenuButton);
            this.sidePanel.Controls.Add(this.consoleMenuButton);
            this.sidePanel.Controls.Add(this.copyrightLabel);
            this.sidePanel.Location = new System.Drawing.Point(0, 24);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(149, 426);
            this.sidePanel.TabIndex = 4;
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
            this.settingsMenuButton.Location = new System.Drawing.Point(1, 180);
            this.settingsMenuButton.Name = "settingsMenuButton";
            this.settingsMenuButton.Selected = false;
            this.settingsMenuButton.Size = new System.Drawing.Size(147, 66);
            this.settingsMenuButton.TabIndex = 6;
            this.settingsMenuButton.Text = "Settings";
            this.settingsMenuButton.Click += new System.EventHandler(this.SettingsMenuButton_Click);
            // 
            // databaseMenuButton
            // 
            this.databaseMenuButton.BackColor = System.Drawing.Color.Transparent;
            this.databaseMenuButton.Location = new System.Drawing.Point(1, 111);
            this.databaseMenuButton.Name = "databaseMenuButton";
            this.databaseMenuButton.Selected = false;
            this.databaseMenuButton.Size = new System.Drawing.Size(147, 66);
            this.databaseMenuButton.TabIndex = 4;
            this.databaseMenuButton.Text = "Database";
            this.databaseMenuButton.Click += new System.EventHandler(this.DatabaseMenuButton_Click);
            // 
            // consoleMenuButton
            // 
            this.consoleMenuButton.BackColor = System.Drawing.Color.Transparent;
            this.consoleMenuButton.Location = new System.Drawing.Point(1, 45);
            this.consoleMenuButton.Name = "consoleMenuButton";
            this.consoleMenuButton.Selected = true;
            this.consoleMenuButton.Size = new System.Drawing.Size(147, 66);
            this.consoleMenuButton.TabIndex = 3;
            this.consoleMenuButton.Text = "Console";
            this.consoleMenuButton.Click += new System.EventHandler(this.ConsoleMenuButton_Click);
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
            // consolePanel
            // 
            this.consolePanel.BackColor = System.Drawing.Color.Gray;
            this.consolePanel.Location = new System.Drawing.Point(149, 26);
            this.consolePanel.Name = "consolePanel";
            this.consolePanel.Size = new System.Drawing.Size(650, 422);
            this.consolePanel.TabIndex = 5;
            // 
            // settingsPanel
            // 
            this.settingsPanel.BackColor = System.Drawing.Color.Gray;
            this.settingsPanel.Location = new System.Drawing.Point(149, 26);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(650, 422);
            this.settingsPanel.TabIndex = 6;
            // 
            // databasePanel
            // 
            this.databasePanel.BackColor = System.Drawing.Color.Gray;
            this.databasePanel.Location = new System.Drawing.Point(149, 26);
            this.databasePanel.Name = "databasePanel";
            this.databasePanel.Size = new System.Drawing.Size(650, 422);
            this.databasePanel.TabIndex = 7;
            // 
            // LocationServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.databasePanel);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.consolePanel);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.sidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LocationServerForm";
            this.Text = "LocationServer";
            this.titleBar.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel panel1;
        private LCHLib.mUI.CustomControls.SubMenuButton settingsMenuButton;
        private LCHLib.mUI.CustomControls.SubMenuButton databaseMenuButton;
        private LCHLib.mUI.CustomControls.SubMenuButton consoleMenuButton;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Timer runtime;
        private MenuPanels.ConsolePanel consolePanel;
        private MenuPanels.SettingsPanel settingsPanel;
        private MenuPanels.DatabasePanel databasePanel;
    }
}

