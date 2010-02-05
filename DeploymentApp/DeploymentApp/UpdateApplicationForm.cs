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
    public partial class UpdateApplicationForm : DeploymentApp.AddUpdateBaseForm
    {
        public string comboBoxValue = "";

        XmlDocument interfaces = new XmlDocument();
        application appClass = new application();

        public UpdateApplicationForm(Form1 form1)
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

        private void button3_Click(object sender, EventArgs e)
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
