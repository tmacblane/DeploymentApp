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
    public partial class Form2 : Form
    {
        OpenFileDialog ofdg = new OpenFileDialog();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        string executablePath = Application.StartupPath;

        public Form2(Form1 form1)
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        #region Validate Textboxes
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

        private bool validateDuplicateApplicationName()
        {
            XmlDocument interfaces = new XmlDocument();
            interfaces.Load(executablePath + "\\" + Settings.Default.XMLFile);
            XmlNodeList applicationList = interfaces.SelectNodes("applications/application");
            string duplicateApp = null;

            foreach (XmlNode application in applicationList)
            {
                if (application.Attributes["name"].Value == applicationNameTextbox.Text)
                {
                    duplicateApp = applicationNameTextbox.Text;
                }
            }

            bool applicationNameDuplicate = true;
            if (duplicateApp != null)
            {
                errorProvider6.SetError(applicationNameTextbox, "An application with that name already exists");
                applicationNameDuplicate = false;
            }

            else
            errorProvider6.Clear();
            return applicationNameDuplicate;
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
            bool validDuplicateApplicationName = validateDuplicateApplicationName();
            bool validExecutableFile = validateExecutableFileTextbox();
            bool validDependencyFile = validateDependenciesTextbox();
            bool validBuildPath = validateBuildPathTextbox();
            bool validStagingPath = validateStagingPathTextbox();            

            if (validApplicationName && validDuplicateApplicationName && validExecutableFile && validDependencyFile && validBuildPath && validStagingPath)
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
                //executableFileTextbox.Text = ofdg.SafeFileName;
                executableFileTextbox.Text = ofdg.FileName.Remove(0, buildPathTextBox.Text.Length+1);
                //executableFileTextbox.Text = executableFileTextbox.Text.Substring(0, buildPathTextBox.Text.Length);// Replace(buildPathTextBox.Text, '');
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
                foreach (string dependency in ofdg.FileNames)
                {
                    dependenciesTextBox.Text = dependenciesTextBox.Text + dependency.Remove(0, buildPathTextBox.Text.Length+1) + ",";
                }
            }
            ofdg.Reset();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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
    }
}
