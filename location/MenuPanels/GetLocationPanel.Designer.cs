namespace mullak99.ACW.NetworkACW.location.MenuPanels
{
    partial class GetLocationPanel
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.responseLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.pseudoConsole = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.protocolComboBox = new System.Windows.Forms.ComboBox();
            this.devConsoleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.nameLabel.Location = new System.Drawing.Point(134, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(128, 20);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Person Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.ForeColor = System.Drawing.Color.Black;
            this.nameTextBox.Location = new System.Drawing.Point(268, 10);
            this.nameTextBox.MaxLength = 20;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(196, 27);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // responseLabel
            // 
            this.responseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.responseLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.responseLabel.Location = new System.Drawing.Point(38, 115);
            this.responseLabel.Name = "responseLabel";
            this.responseLabel.Size = new System.Drawing.Size(574, 86);
            this.responseLabel.TabIndex = 8;
            this.responseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.Teal;
            this.sendButton.Enabled = false;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.ForeColor = System.Drawing.SystemColors.Control;
            this.sendButton.Location = new System.Drawing.Point(3, 346);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(644, 73);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // pseudoConsole
            // 
            this.pseudoConsole.BackColor = System.Drawing.SystemColors.ControlText;
            this.pseudoConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pseudoConsole.Enabled = false;
            this.pseudoConsole.ForeColor = System.Drawing.SystemColors.Window;
            this.pseudoConsole.Location = new System.Drawing.Point(42, 229);
            this.pseudoConsole.Name = "pseudoConsole";
            this.pseudoConsole.ReadOnly = true;
            this.pseudoConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.pseudoConsole.Size = new System.Drawing.Size(570, 106);
            this.pseudoConsole.TabIndex = 10;
            this.pseudoConsole.TabStop = false;
            this.pseudoConsole.Text = "";
            this.pseudoConsole.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(177, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Protocol:";
            // 
            // protocolComboBox
            // 
            this.protocolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.protocolComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.protocolComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.protocolComboBox.FormattingEnabled = true;
            this.protocolComboBox.Items.AddRange(new object[] {
            "WHOIS",
            "HTTP/0.9",
            "HTTP/1.0",
            "HTTP/1.1"});
            this.protocolComboBox.Location = new System.Drawing.Point(268, 44);
            this.protocolComboBox.Name = "protocolComboBox";
            this.protocolComboBox.Size = new System.Drawing.Size(196, 28);
            this.protocolComboBox.TabIndex = 2;
            // 
            // devConsoleLabel
            // 
            this.devConsoleLabel.AutoSize = true;
            this.devConsoleLabel.Enabled = false;
            this.devConsoleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devConsoleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.devConsoleLabel.Location = new System.Drawing.Point(39, 209);
            this.devConsoleLabel.Name = "devConsoleLabel";
            this.devConsoleLabel.Size = new System.Drawing.Size(150, 17);
            this.devConsoleLabel.TabIndex = 13;
            this.devConsoleLabel.Text = "Developer Console:";
            this.devConsoleLabel.Visible = false;
            this.devConsoleLabel.Click += new System.EventHandler(this.DevConsoleLabel_Click);
            // 
            // GetLocationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.devConsoleLabel);
            this.Controls.Add(this.protocolComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pseudoConsole);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.responseLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Name = "GetLocationPanel";
            this.Size = new System.Drawing.Size(650, 422);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label responseLabel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.RichTextBox pseudoConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox protocolComboBox;
        private System.Windows.Forms.Label devConsoleLabel;
    }
}
