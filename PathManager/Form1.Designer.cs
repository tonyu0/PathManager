namespace PathManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ContentTabControl = new TabControl();
            menuStrip1 = new MenuStrip();
            NewToolStripMenuItem = new ToolStripMenuItem();
            CreateNewTabToolStripMenuItem = new ToolStripMenuItem();
            SettingsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ContentTabControl
            // 
            ContentTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ContentTabControl.Location = new Point(12, 53);
            ContentTabControl.Name = "ContentTabControl";
            ContentTabControl.SelectedIndex = 0;
            ContentTabControl.Size = new Size(856, 442);
            ContentTabControl.TabIndex = 4;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { NewToolStripMenuItem, SettingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(880, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // NewToolStripMenuItem
            // 
            NewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CreateNewTabToolStripMenuItem });
            NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            NewToolStripMenuItem.Size = new Size(43, 20);
            NewToolStripMenuItem.Text = "New";
            // 
            // CreateNewTabToolStripMenuItem
            // 
            CreateNewTabToolStripMenuItem.Name = "CreateNewTabToolStripMenuItem";
            CreateNewTabToolStripMenuItem.Size = new Size(161, 22);
            CreateNewTabToolStripMenuItem.Text = "Create a new tab";
            CreateNewTabToolStripMenuItem.Click += createNewTabToolStripMenuItem_Click;
            // 
            // SettingsToolStripMenuItem
            // 
            SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            SettingsToolStripMenuItem.Size = new Size(61, 20);
            SettingsToolStripMenuItem.Text = "Settings";
            SettingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 507);
            Controls.Add(ContentTabControl);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Path Manager";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private TabControl ContentTabControl;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem NewToolStripMenuItem;
        private ToolStripMenuItem CreateNewTabToolStripMenuItem;
        private ToolStripMenuItem SettingsToolStripMenuItem;
    }
}
