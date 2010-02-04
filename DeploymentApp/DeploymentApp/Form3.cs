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
    public partial class Form3 : Form
    {
        string executablePath = Application.StartupPath;

        XmlDocument interfaces = new XmlDocument();
        OpenFileDialog ofdg = new OpenFileDialog();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        application appClass = new application();

        public string comboBoxValue = "";

        public Form3(Form1 form1)
        {
            InitializeComponent();
        }

        public void loadApplication(application appClass)
        {
            interfaces.Load(executablePath + "\\" + Settings.Default.XMLFile);

            XmlNode node = null;
            XmlNodeList applicationList = interfaces.SelectNodes("applications/application");

            //Sets the base path for the node to what is selected in the combobox
            string selectedApplication = appClass.ComboBoxValue;

            foreach (XmlNode application in applicationList)
            {
                if (application.Attributes["name"].Value == selectedApplication)
                {
                    node = application;
                }
            }

            //Gets the values from the xml file
            XmlAttribute applicationName = node.Attributes["name"];
            XmlNode executableFile = node.SelectSingleNode("executable");
            XmlNodeList dependencyFiles = node.SelectNodes("dependencies/dependency");
            XmlNode buildPath = node.SelectSingleNode("build_path");
            XmlNode stagingPath = node.SelectSingleNode("staging_path");

            //Populates the values into the textboxes
            applicationNameTextbox.Text = applicationName.Value;
            executableFileTextbox.Text = executableFile.InnerText;
            buildPathTextBox.Text = buildPath.InnerText;
            stagingPathTextBox.Text = stagingPath.InnerText;

            foreach (XmlNode dependencyNode in dependencyFiles)
            {
                string fileName = dependencyNode.InnerText;
                dependenciesTextBox.Text = dependenciesTextBox.Text + fileName + ",";
            }
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
                appClass.ApplicationNameText = applicationNameTextbox.Text;
                appClass.ExecutableNameText = executableFileTextbox.Text;
                appClass.DependenciesText = dependenciesTextBox.Text;
                appClass.BuildPathText = buildPathTextBox.Text;
                appClass.StagingPathText = stagingPathTextBox.Text;
                appClass.ComboBoxValue = comboBoxValue;

                updateApplication updateApp = new updateApplication();
                updateApp.updateExistingApplication(appClass);

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dependenciesTextBox.Clear();
        }

        private void deleteAppButton_Click(object sender, EventArgs e)
        {
            appClass.ComboBoxValue = comboBoxValue;

            if (MessageBox.Show("Are you sure you want to delete this application?", "Delete Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                deleteApplication deleteApp = new deleteApplication();
                deleteApp.deleteExistingApplication(appClass);

                Close();
            }
        }
    }
}