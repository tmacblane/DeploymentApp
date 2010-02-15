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
    public partial class AddApplicationForm : DeploymentApp.AddUpdateBaseForm
    {
        public AddApplicationForm(Form1 form1)
        {
            InitializeComponent();
        }

        protected bool validateDuplicateApplicationName()
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

                AddNewApplication addNew = new AddNewApplication();
                addNew.createNewApplication(appClass);

                Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            applicationNameTextbox.ResetText();
            executableFileTextbox.ResetText();
            dependenciesTextBox.ResetText();
            buildPathTextBox.ResetText();
            stagingPathTextBox.ResetText();
        }
    }
}
