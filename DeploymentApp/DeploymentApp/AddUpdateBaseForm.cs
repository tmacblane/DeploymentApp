using DeploymentApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DeploymentApp
{
    public partial class AddUpdateBaseForm : Form
    {
        OpenFileDialog ofdg = new OpenFileDialog();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        protected string executablePath = Application.StartupPath;

        public AddUpdateBaseForm()
        {
            InitializeComponent();
        }

        #region Validate Textboxes
        protected bool validateApplicationNameTextbox()
        {
            bool applicationName = true;
            if (applicationNameTextbox.Text.Trim() == "")
            {
                errorProvider1.SetError(applicationNameTextbox, "Enter an application name");
                applicationName = false;
            }
            else
                errorProvider1.Clear();
            return applicationName;
        }

        protected bool validateExecutableFileTextbox()
        {
            bool executableFile = true;
            if (executableFileTextbox.Text.Trim() == "")
            {
                errorProvider2.SetError(executableFileTextbox, "Select an executable file");
                executableFile = false;
            }
            else
                errorProvider2.Clear();
            return executableFile;
        }

        protected bool validateDependenciesTextbox()
        {
            bool dependencyFile = true;
            if (dependenciesTextBox.Text.Trim() == "")
            {
                errorProvider3.SetError(dependenciesTextBox, "Select dependencies");
                dependencyFile = false;
            }
            else
                errorProvider3.Clear();
            return dependencyFile;
        }

        protected bool validateBuildPathTextbox()
        {
            bool buildPath = true;
            if (buildPathTextBox.Text.Trim() == "")
            {
                errorProvider4.SetError(buildPathTextBox, "Enter a build path");
                buildPath = false;
            }
            else
                errorProvider4.Clear();
            return buildPath;
        }

        protected bool validateStagingPathTextbox()
        {
            bool stagingPath = true;
            if (stagingPathTextBox.Text.Trim() == "")
            {
                errorProvider5.SetError(stagingPathTextBox, "Enter a staging path");
                stagingPath = false;
            }
            else
                errorProvider5.Clear();
            return stagingPath;
        }
        #endregion

        private void btnBuildPath_Click(object sender, EventArgs e)
        {
            fbd.Description = "Select the BuildPath directory";
            fbd.ShowNewFolderButton = false;

            if (buildPathTextBox.Text == null)
            {
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
            }
            else
            {
                fbd.SelectedPath = buildPathTextBox.Text;
            }

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                buildPathTextBox.Text = fbd.SelectedPath;
            }
        }

        private void btnExecutable_Click(object sender, EventArgs e)
        {
            ofdg.Title = "Add Executable File";
            ofdg.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
            if (buildPathTextBox.Text != "")
            {
                ofdg.InitialDirectory = buildPathTextBox.Text;
                if (ofdg.ShowDialog() == DialogResult.OK)
                {
                    executableFileTextbox.Text = ofdg.FileName.Remove(0, buildPathTextBox.Text.Length + 1);
                }
                errorProvider2.Clear();
            }
            else
            {
                errorProvider2.SetError(executableFileTextbox, "Select a buildPath first");
            }
        }

        private void btnDependency_Click(object sender, EventArgs e)
        {
            ofdg.Title = "Select Dependencies";
            ofdg.Filter = "All Files (*.*)|*.*";
            ofdg.Multiselect = true;

            if (buildPathTextBox.Text != "")
            {
                ofdg.InitialDirectory = buildPathTextBox.Text;
                if (ofdg.ShowDialog() == DialogResult.OK)
                {
                    foreach (string dependency in ofdg.FileNames)
                    {
                        dependenciesTextBox.Text = dependenciesTextBox.Text + dependency.Remove(0, buildPathTextBox.Text.Length + 1) + Environment.NewLine;
                    }                    
                }
                errorProvider3.Clear();
            }
            else
            {
                errorProvider3.SetError(dependenciesTextBox, "Select a buildPath first");
            }
        }

        private void btnStagingPath_Click(object sender, EventArgs e)
        {
            fbd.Description = "Select the StagingPath directory";
            fbd.ShowNewFolderButton = true;

            if (stagingPathTextBox.Text == null)
            {
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
            }
            else
            {
                fbd.SelectedPath = stagingPathTextBox.Text;
            }

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                stagingPathTextBox.Text = fbd.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
