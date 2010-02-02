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
    public partial class Form2 : Form
    {
        OpenFileDialog ofdg = new OpenFileDialog();
        FolderBrowserDialog fbd = new FolderBrowserDialog();

        public Form2(Form1 form1)
        {
            InitializeComponent();
        }

        #region Validate Textboxes
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private bool validateApplicationNameTextbox()
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

        private bool validateExecutableFileTextbox()
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

        private bool validateDependenciesTextbox()
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

        private bool validateBuildPathTextbox()
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

        private bool validateStagingPathTextbox()
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

        private void button1_Click(object sender, EventArgs e)
        {
            bool validApplicationName = validateApplicationNameTextbox();
            bool validExecutableFile = validateExecutableFileTextbox();
            bool validDependencyFile = validateDependenciesTextbox();
            bool validBuildPath = validateBuildPathTextbox();
            bool validStagingPath = validateStagingPathTextbox();            

            if (validApplicationName && validExecutableFile && validDependencyFile && validBuildPath && validStagingPath)
            {
                application appClass = new application();
                appClass.ApplicationNameText = applicationNameTextbox.Text;
                appClass.ExecutableNameText = executableFileTextbox.Text;
                appClass.DependenciesText = dependenciesTextBox.Text;
                appClass.BuildPathText = buildPathTextBox.Text;
                appClass.StagingPathText = stagingPathTextBox.Text;

                addNewApplication addNew = new addNewApplication();
                addNew.createNewApplication(appClass);

                Close();            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void executableButton_Click(object sender, EventArgs e)
        {
            ofdg.Title = "Add Executable File";
            ofdg.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
            if (buildPathTextBox.Text != "")
            {
                ofdg.InitialDirectory = buildPathTextBox.Text;
            }
            else
            {
                ofdg.InitialDirectory = @"c:\";
            }
            if (ofdg.ShowDialog() == DialogResult.OK)
            {
                executableFileTextbox.Text = ofdg.SafeFileName;
            }
            ofdg.Reset();
        }

        private void dependencyButton_Click(object sender, EventArgs e)
        {
            ofdg.Title = "Select Dependencies";
            ofdg.Filter = "All Files (*.*)|*.*";
            ofdg.Multiselect = true;
            if (buildPathTextBox.Text != "")
            {
                ofdg.InitialDirectory = buildPathTextBox.Text;
            }
            else
            {
                ofdg.InitialDirectory = @"c:\";
            }
            if (ofdg.ShowDialog() == DialogResult.OK)
            {
                foreach (string dependency in ofdg.SafeFileNames)
                {
                    dependenciesTextBox.Text = dependenciesTextBox.Text + dependency + ",";
                }
            }
            ofdg.Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fbd.Description = "Select the BuildPath directory";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = false;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                buildPathTextBox.Text = fbd.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fbd.Description = "Select the StagingPath directory";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                stagingPathTextBox.Text = fbd.SelectedPath;
            }
        }
    }
}
