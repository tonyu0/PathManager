namespace PathManager.Controls
{
    partial class CreateTabDialog
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
            CreateTabLabel = new Label();
            NewTabNameTextBox = new TextBox();
            OKButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // CreateTabLabel
            // 
            CreateTabLabel.AutoSize = true;
            CreateTabLabel.Location = new Point(12, 14);
            CreateTabLabel.Name = "CreateTabLabel";
            CreateTabLabel.Size = new Size(112, 15);
            CreateTabLabel.TabIndex = 0;
            CreateTabLabel.Text = "Input new tab name";
            // 
            // NewTabNameTextBox
            // 
            NewTabNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NewTabNameTextBox.Location = new Point(12, 32);
            NewTabNameTextBox.Name = "NewTabNameTextBox";
            NewTabNameTextBox.Size = new Size(410, 23);
            NewTabNameTextBox.TabIndex = 1;
            // 
            // OKButton
            // 
            OKButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OKButton.DialogResult = DialogResult.OK;
            OKButton.Location = new Point(266, 61);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(75, 23);
            OKButton.TabIndex = 2;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(347, 61);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // CreateTabDialog
            // 
            AcceptButton = OKButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 96);
            Controls.Add(CancelButton);
            Controls.Add(OKButton);
            Controls.Add(NewTabNameTextBox);
            Controls.Add(CreateTabLabel);
            Name = "CreateTabDialog";
            Text = "Create Tab";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CreateTabLabel;
        private TextBox NewTabNameTextBox;
        private Button OKButton;
        private Button CancelButton;
    }
}