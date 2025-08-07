namespace VsRenamer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupPanel = new GroupBox();
            btnClear = new Button();
            btnRename = new Button();
            chkRename = new CheckBox();
            btnBrowse = new Button();
            txtNewName = new TextBox();
            txtProjectName = new TextBox();
            txtProjectPath = new TextBox();
            lblParent = new Label();
            lblNewName = new Label();
            lblProjectName = new Label();
            lblProjectPath = new Label();
            groupPanel.SuspendLayout();
            SuspendLayout();
            // 
            // groupPanel
            // 
            groupPanel.Controls.Add(btnClear);
            groupPanel.Controls.Add(btnRename);
            groupPanel.Controls.Add(chkRename);
            groupPanel.Controls.Add(btnBrowse);
            groupPanel.Controls.Add(txtNewName);
            groupPanel.Controls.Add(txtProjectName);
            groupPanel.Controls.Add(txtProjectPath);
            groupPanel.Controls.Add(lblParent);
            groupPanel.Controls.Add(lblNewName);
            groupPanel.Controls.Add(lblProjectName);
            groupPanel.Controls.Add(lblProjectPath);
            groupPanel.Location = new Point(12, 12);
            groupPanel.Name = "groupPanel";
            groupPanel.Size = new Size(410, 217);
            groupPanel.TabIndex = 0;
            groupPanel.TabStop = false;
            groupPanel.Text = "Panel";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(218, 172);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 30);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear fields";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // btnRename
            // 
            btnRename.Location = new Point(62, 172);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(150, 30);
            btnRename.TabIndex = 9;
            btnRename.Text = "Rename project";
            btnRename.UseVisualStyleBackColor = true;
            btnRename.Click += BtnRename_Click;
            // 
            // chkRename
            // 
            chkRename.AutoSize = true;
            chkRename.Checked = true;
            chkRename.CheckState = CheckState.Checked;
            chkRename.Location = new Point(128, 136);
            chkRename.Name = "chkRename";
            chkRename.Size = new Size(15, 14);
            chkRename.TabIndex = 8;
            chkRename.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(374, 34);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(30, 23);
            btnBrowse.TabIndex = 7;
            btnBrowse.Text = "...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += BtnBrowse_Click;
            // 
            // txtNewName
            // 
            txtNewName.Location = new Point(128, 102);
            txtNewName.Name = "txtNewName";
            txtNewName.Size = new Size(200, 23);
            txtNewName.TabIndex = 6;
            // 
            // txtProjectName
            // 
            txtProjectName.Location = new Point(128, 68);
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(200, 23);
            txtProjectName.TabIndex = 5;
            // 
            // txtProjectPath
            // 
            txtProjectPath.Location = new Point(128, 34);
            txtProjectPath.Name = "txtProjectPath";
            txtProjectPath.ReadOnly = true;
            txtProjectPath.Size = new Size(240, 23);
            txtProjectPath.TabIndex = 4;
            // 
            // lblParent
            // 
            lblParent.AutoSize = true;
            lblParent.Location = new Point(16, 136);
            lblParent.Name = "lblParent";
            lblParent.Size = new Size(97, 15);
            lblParent.TabIndex = 3;
            lblParent.Text = "Rename base dir:";
            // 
            // lblNewName
            // 
            lblNewName.AutoSize = true;
            lblNewName.Location = new Point(46, 103);
            lblNewName.Name = "lblNewName";
            lblNewName.Size = new Size(67, 15);
            lblNewName.TabIndex = 2;
            lblNewName.Text = "New name:";
            // 
            // lblProjectName
            // 
            lblProjectName.AutoSize = true;
            lblProjectName.Location = new Point(33, 70);
            lblProjectName.Name = "lblProjectName";
            lblProjectName.Size = new Size(80, 15);
            lblProjectName.TabIndex = 1;
            lblProjectName.Text = "Project name:";
            // 
            // lblProjectPath
            // 
            lblProjectPath.AutoSize = true;
            lblProjectPath.Location = new Point(39, 37);
            lblProjectPath.Name = "lblProjectPath";
            lblProjectPath.Size = new Size(74, 15);
            lblProjectPath.TabIndex = 0;
            lblProjectPath.Text = "Project path:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 241);
            Controls.Add(groupPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vs Renamer";
            groupPanel.ResumeLayout(false);
            groupPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupPanel;
        private Label lblParent;
        private Label lblNewName;
        private Label lblProjectName;
        private Label lblProjectPath;
        private Button btnBrowse;
        private TextBox txtNewName;
        private TextBox txtProjectName;
        private TextBox txtProjectPath;
        private Button btnClear;
        private Button btnRename;
        private CheckBox chkRename;
    }
}
