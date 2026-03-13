namespace PathManager.Controls
{
    partial class ContentTabPage
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
            components = new System.ComponentModel.Container();
            AddRowButton = new Button();
            RemoveRowButton = new Button();
            DataGridView = new DataGridView();
            RefBtn = new DataGridViewButtonColumn();
            PathItemBindingSource = new BindingSource(components);
            DeleteTabButton = new Button();
            RenameTabButton = new Button();
            FilterTextBox = new TextBox();
            label1 = new Label();
            MoveTabLeft = new Button();
            MoveTabRight = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PathItemBindingSource).BeginInit();
            SuspendLayout();
            // 
            // AddRowButton
            // 
            AddRowButton.Location = new Point(3, 5);
            AddRowButton.Name = "AddRowButton";
            AddRowButton.Size = new Size(130, 25);
            AddRowButton.TabIndex = 0;
            AddRowButton.Text = "Add New Row";
            AddRowButton.UseVisualStyleBackColor = true;
            AddRowButton.Click += AddRowButton_Click;
            // 
            // RemoveRowButton
            // 
            RemoveRowButton.Location = new Point(139, 5);
            RemoveRowButton.Name = "RemoveRowButton";
            RemoveRowButton.Size = new Size(130, 25);
            RemoveRowButton.TabIndex = 1;
            RemoveRowButton.Text = "Remove Selected Row";
            RemoveRowButton.UseVisualStyleBackColor = true;
            RemoveRowButton.Click += RemoveRowButton_Click;
            // 
            // DataGridView
            // 
            DataGridView.AllowUserToAddRows = false;
            DataGridView.AllowUserToDeleteRows = false;
            DataGridView.AllowUserToResizeColumns = false;
            DataGridView.AllowUserToResizeRows = false;
            DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridView.Columns.AddRange(new DataGridViewColumn[] { RefBtn });
            DataGridView.Location = new Point(0, 78);
            DataGridView.MultiSelect = false;
            DataGridView.Name = "DataGridView";
            DataGridView.RowHeadersVisible = false;
            DataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DataGridView.Size = new Size(761, 230);
            DataGridView.TabIndex = 2;
            DataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // RefBtn
            // 
            RefBtn.FillWeight = 2F;
            RefBtn.HeaderText = "";
            RefBtn.Name = "RefBtn";
            RefBtn.Text = "Open";
            RefBtn.UseColumnTextForButtonValue = true;
            // 
            // PathItemBindingSource
            // 
            PathItemBindingSource.DataSource = typeof(Utils.PathItem);
            // 
            // DeleteTabButton
            // 
            DeleteTabButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DeleteTabButton.ForeColor = Color.OrangeRed;
            DeleteTabButton.Location = new Point(661, 5);
            DeleteTabButton.Name = "DeleteTabButton";
            DeleteTabButton.Size = new Size(100, 23);
            DeleteTabButton.TabIndex = 3;
            DeleteTabButton.Text = "Delete This Tab";
            DeleteTabButton.UseVisualStyleBackColor = true;
            DeleteTabButton.Click += DeleteTabButton_Click;
            // 
            // RenameTabButton
            // 
            RenameTabButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RenameTabButton.ForeColor = SystemColors.ControlText;
            RenameTabButton.Location = new Point(535, 5);
            RenameTabButton.Name = "RenameTabButton";
            RenameTabButton.Size = new Size(120, 23);
            RenameTabButton.TabIndex = 4;
            RenameTabButton.Text = "Rename This Tab";
            RenameTabButton.UseVisualStyleBackColor = true;
            RenameTabButton.Click += RenameTabButton_Click;
            // 
            // FilterTextBox
            // 
            FilterTextBox.Location = new Point(83, 49);
            FilterTextBox.Name = "FilterTextBox";
            FilterTextBox.Size = new Size(396, 23);
            FilterTextBox.TabIndex = 5;
            FilterTextBox.TextChanged += FilterTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(3, 50);
            label1.Name = "label1";
            label1.Size = new Size(84, 17);
            label1.TabIndex = 6;
            label1.Text = "Search filter: ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MoveTabLeft
            // 
            MoveTabLeft.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MoveTabLeft.Location = new Point(389, 5);
            MoveTabLeft.Name = "MoveTabLeft";
            MoveTabLeft.Size = new Size(23, 23);
            MoveTabLeft.TabIndex = 7;
            MoveTabLeft.Text = "＜";
            MoveTabLeft.UseVisualStyleBackColor = true;
            MoveTabLeft.Click += MoveTabLeft_Click;
            // 
            // MoveTabRight
            // 
            MoveTabRight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MoveTabRight.Location = new Point(506, 5);
            MoveTabRight.Name = "MoveTabRight";
            MoveTabRight.Size = new Size(23, 23);
            MoveTabRight.TabIndex = 8;
            MoveTabRight.Text = "＞";
            MoveTabRight.UseVisualStyleBackColor = true;
            MoveTabRight.Click += MoveTabRight_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(418, 9);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 9;
            label2.Text = "Move This Tab";
            // 
            // ContentTabPage
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            Controls.Add(label2);
            Controls.Add(MoveTabRight);
            Controls.Add(MoveTabLeft);
            Controls.Add(label1);
            Controls.Add(FilterTextBox);
            Controls.Add(RenameTabButton);
            Controls.Add(DeleteTabButton);
            Controls.Add(DataGridView);
            Controls.Add(RemoveRowButton);
            Controls.Add(AddRowButton);
            Name = "ContentTabPage";
            Size = new Size(764, 311);
            Load += ContentTabPage_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)PathItemBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button AddRowButton;
        private Button RemoveRowButton;
        private DataGridView DataGridView;
        private Button DeleteTabButton;
        private Button RenameTabButton;
        private BindingSource PathItemBindingSource;
        private TextBox FilterTextBox;
        private Label label1;
        private DataGridViewButtonColumn RefBtn;
        private Button MoveTabLeft;
        private Button MoveTabRight;
        private Label label2;
    }
}
