using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeploymentApp
{
    public partial class AddApplicationForm : DeploymentApp.AddUpdateBaseForm
    {
        public AddApplicationForm(Form1 form1)
        {
            InitializeComponent();
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

                addNewApplication addNew = new addNewApplication();
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
