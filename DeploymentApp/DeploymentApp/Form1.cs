﻿using DeploymentApp.Properties;
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
            createReadMeFile createReadMeDocument = new createReadMeFile();
            fileCopy copyBuildFiles = new fileCopy();
            sendEmail email = new sendEmail();

            bool validApplicationSelected = validateApplicationComboBox();
            bool validReleaseNotes = validateReleaseNotesTextbox();

            if (validApplicationSelected && validReleaseNotes)
            {                
                application appClass = new application();
                appClass.ComboBoxValue = applicationComboBox.Text;
                appClass.ReleaseNotesText = releaseNotesTextbox.Text;
                try
                {
                    createReadMeDocument.createReadMe(appClass);
                    copyBuildFiles.copyFiles(appClass);
                }
                catch(Exception stuff)
                {
                    MessageBox.Show(stuff.ToString());
                    //MessageBox.Show("The selected application files could not be found");
                }

                try
                {
                    email.sendEmailNotification(appClass);
                }

                catch
                {
                    MessageBox.Show("Configure the email information");
                }
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
    }
}
