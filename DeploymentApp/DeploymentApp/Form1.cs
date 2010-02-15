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
    public partial class Form1 : Form
    {
        string executablePath = Application.StartupPath;
        XmlDocument interfaces = new XmlDocument();

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            #region Load interfaces xml
            try
            {
                interfaces.Load(executablePath + "\\" + Settings.Default.XMLFile);
            }

            catch(System.IO.FileNotFoundException)
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(Settings.Default.XMLFile, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                xmlWriter.WriteStartElement("applications");
                xmlWriter.Close();
                interfaces.Load(executablePath + "\\" + Settings.Default.XMLFile);
            }
            #endregion

            #region Load configuration xml
            try
            {
                interfaces.Load(executablePath + "\\" + Settings.Default.ConfigXMLFile);
            }

            catch (System.IO.FileNotFoundException)
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(Settings.Default.ConfigXMLFile, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                xmlWriter.WriteStartElement("settings");
                xmlWriter.Close();
                interfaces.Load(executablePath + "\\" + Settings.Default.ConfigXMLFile);

                ConfigureEmailForm configureEmail = new ConfigureEmailForm();
                configureEmail.ShowDialog();
            }
            #endregion

            loadComboBox();
            
            editLabel.Hide();
        }

        private void loadComboBox()
        {
            interfaces.Load(executablePath + "\\" + Settings.Default.XMLFile);
            XmlNodeList applicationList = interfaces.SelectNodes("applications/application");
            foreach (XmlNode application in applicationList)
            {
                applicationComboBox.Items.Add(application.Attributes["name"].Value);
            }
        }

        #region validation
        private bool validateApplicationComboBox()
        {
            bool applicationSelected = true;
            if (applicationComboBox.Text == "")
            {
                errorProvider1.SetError(applicationComboBox, "Select an application");
                applicationSelected = false;
            }
            else
            errorProvider1.Clear();
            return applicationSelected;
        }

        private bool validateReleaseNotesTextbox()
        {
            bool releaseNotes = true;
            if (releaseNotesTextbox.Text.Trim() == "")
            {
                errorProvider2.SetError(releaseNotesTextbox, "Enter release notes");
                releaseNotes = false;
            }
            else
            errorProvider2.Clear();
            return releaseNotes;
        }
        #endregion

        private void submit_button_Click(object sender, EventArgs e)
        {
            CreateReadMeFile createReadMeDocument = new CreateReadMeFile();
            FileCopy copyBuildFiles = new FileCopy();
            SendEmail email = new SendEmail();

            bool validApplicationSelected = validateApplicationComboBox();
            bool validReleaseNotes = validateReleaseNotesTextbox();

            if (validApplicationSelected && validReleaseNotes)
            {                
                application appClass = new application();
                appClass.ComboBoxValue = applicationComboBox.Text;
                appClass.ReleaseNotesText = releaseNotesTextbox.Text;

                #region Create ReadMe
                try
                {
                    createReadMeDocument.createReadMe(appClass);
                    copyBuildFiles.copyFiles(appClass);
                }
                catch//(Exception stuff)
                {
                    //MessageBox.Show(stuff.ToString());
                    MessageBox.Show("The selected application files could not be found");
                }
                #endregion

                #region Send Email Notification
                XmlDocument emailConfig = new XmlDocument();
                emailConfig.Load(executablePath + "\\" + Settings.Default.ConfigXMLFile);

                //check if email has been configured
                XmlNode hostNode = emailConfig.SelectSingleNode("settings/email/host");
                try
                {
                    if (hostNode != null)
                    {
                        email.sendEmailNotification(appClass);
                    }
                    else
                    {
                        if (MessageBox.Show("The email information has not configured and a notification will not be sent.\n\nWould you like to configure it now?", "Configure Email Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ConfigureEmailForm configureEmail = new ConfigureEmailForm();
                            configureEmail.ShowDialog();

                            email.sendEmailNotification(appClass);
                        }
                    }
                }

                catch
                {
                    MessageBox.Show("The email information was not configured correctly");
                }
                #endregion

                releaseNotesTextbox.Clear();
                applicationComboBox.ResetText();
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addNewLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddApplicationForm addNewApplicationForm = new AddApplicationForm(this);

            applicationComboBox.Items.Clear();
            addNewApplicationForm.FormClosed += (x, y) =>
                {
                    loadComboBox();
                };

            addNewApplicationForm.ShowDialog();
        }

        private void editLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {    
            UpdateApplicationForm editApplicationForm = new UpdateApplicationForm(this);
            applicationComboBox.Items.Clear();
            try
            {
                application appClass = new application();
                appClass.ComboBoxValue = applicationComboBox.Text;

                editApplicationForm.comboBoxValue = applicationComboBox.Text;
                editApplicationForm.loadApplication(appClass);

                editApplicationForm.FormClosed += (x, y) =>
                {
                    loadComboBox();
                };

                applicationComboBox.Text = "";

                editApplicationForm.ShowDialog();
            }
            catch(Exception)
            {
                MessageBox.Show("The selected application was not found");
                applicationComboBox.Text = "";
                loadComboBox();
            }  
        }

        private void applicationComboBox_TextChanged(object sender, EventArgs e)
        {
            applicationComboBox.GetItemText(applicationComboBox);
            if (applicationComboBox.Text != "")
            {
                editLabel.Show();
                errorProvider1.Clear();
            }
            else
            {
                editLabel.Hide();
            }
        }

        private void editEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConfigureEmailForm configureEmail = new ConfigureEmailForm();
            configureEmail.loadEmailSettings();
            configureEmail.ShowDialog();
        }
    }
}
