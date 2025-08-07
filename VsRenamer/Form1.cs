using System.Text.RegularExpressions;
using VsRenamer.Logic;

namespace VsRenamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using var folderDialog = new FolderBrowserDialog();

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtProjectPath.Text = folderDialog.SelectedPath;
                txtProjectName.Text = Path.GetFileName(txtProjectPath.Text);
            }
        }

        private async void BtnRename_Click(object sender, EventArgs e)
        {
            if (!HasValidInput())
            {
                MessageBox.Show("You haven't provided proper input.Please check your fields again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var project = new ProjectRenamer
            {
                ProjectPath = txtProjectPath.Text,
                ProjectName = txtProjectName.Text,
                NewName = txtNewName.Text,
                RenameParent = chkRename.Checked
            };

            if (project.HasProjectFile())
            {
                groupPanel.Enabled = false;
                await project.RenameProjectAsync();
                groupPanel.Enabled = true;

                project.RemoveVsDirectory();

                if (project.RenameParent)
                {
                    project.RenameParentDirectory();
                }

                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sorry, the project file could not be found in the specified directory.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtProjectPath.Clear();
            txtProjectName.Clear();
            txtNewName.Clear();
            chkRename.Checked = true;
        }

        private bool HasValidInput()
        {
            const string projectNameRegex = @"^[A-Za-z_][A-Za-z0-9_]*$";

            return !string.IsNullOrWhiteSpace(txtProjectPath.Text)
                && Regex.IsMatch(txtProjectName.Text, projectNameRegex)
                && Regex.IsMatch(txtNewName.Text, projectNameRegex);
        }
    }
}