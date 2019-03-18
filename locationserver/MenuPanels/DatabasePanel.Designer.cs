namespace mullak99.ACW.NetworkACW.locationserver.MenuPanels
{
    partial class DatabasePanel
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
            this.databaseList = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // databaseList
            // 
            this.databaseList.BackColor = System.Drawing.Color.Gray;
            this.databaseList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.databaseList.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseList.ForeColor = System.Drawing.Color.White;
            this.databaseList.Location = new System.Drawing.Point(3, 3);
            this.databaseList.Name = "databaseList";
            this.databaseList.Size = new System.Drawing.Size(644, 416);
            this.databaseList.TabIndex = 0;
            this.databaseList.Text = "";
            // 
            // DatabasePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.databaseList);
            this.Name = "DatabasePanel";
            this.Size = new System.Drawing.Size(650, 422);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox databaseList;
    }
}
