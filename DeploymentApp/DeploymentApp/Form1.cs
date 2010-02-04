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

        private void submit_button_Click(object sender, EventArgs e)
        {
            bool validApplicationSelected = validateApplicationComboBox();
            bool validReleaseNotes = validateReleaseNotesTextbox();

            if (validApplicationSelected && validReleaseNotes)
            {
                try
                {
                    createReadMe();

                    fileMove();
                }

                catch(Exception stuff)
                {
                    MessageBox.Show(stuff.ToString());
                    //MessageBox.Show("The selected application files could not be found");
                }
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fileMove()
        {
            interfaces.Load(executablePath + "\\" + Settings.Default.XMLFile);

            //Pulls the list of applications in the xml
            XmlNode node = null;
            XmlNodeList applicationList = interfaces.SelectNodes("applications/application");
            
            //Sets the base path for the node to what is selected in the combobox
            string selectedApplication = applicationComboBox.SelectedItem.ToString();
            foreach (XmlNode application in applicationList)
            {
                if (application.Attributes["name"].Value == selectedApplication)
                {
                    node = application;
                }
            }            

            //Get the build and staging path
            XmlNode buildPath = node.SelectSingleNode("build_path");
            XmlNode stagingPath = node.SelectSingleNode("staging_path");

            //Sets the source and destination path to a string variable
            string source = buildPath.InnerText;
            string destination = stagingPath.InnerText;
            
            //Gets the executable file and moves it
            XmlNode executableFile = node.SelectSingleNode("executable");
            FileInfo file = new FileInfo(executableFile.InnerText);

            string sourceFile = Path.Combine(source, file.Name);
            string destFile = Path.Combine(destination, file.Name);

            File.Copy(sourceFile, destFile, true);

            //Gets the dependency files and moves them
            XmlNodeList dependencyNodes = node.SelectNodes("dependencies/dependency");

            foreach (XmlNode dependencyNode in dependencyNodes)
            {
                var fileName = dependencyNode.InnerText;
                string sourcePath = Path.Combine(source, fileName);
                string destPath = Path.Combine(destination, fileName);
                
                File.Copy(sourcePath, destPath, true);

            }

            applicationComboBox.ResetText();
        }
        
        private void createReadMe()
        {
            interfaces.Load(executablePath + "\\" + Settings.Default.XMLFile);

            //Pulls the list of applications in the xml
            XmlNode node = null;
            XmlNodeList applicationList = interfaces.SelectNodes("applications/application");

            //Sets the base path for the node to what is selected in the combobox
            string selectedApplication = applicationComboBox.SelectedItem.ToString();
            foreach (XmlNode application in applicationList)
            {
                if (application.Attributes["name"].Value == selectedApplication)
                {
                    node = application;                    
                }
            }      

            XmlNode buildPath = node.SelectSingleNode("build_path");
            string readMeFile = buildPath.InnerText + "\\ReadMe.txt";
            string oldReadMeFile = buildPath.InnerText + "\\ReadMe_Old.txt";

            if (File.Exists(readMeFile))
            {
                if (File.Exists(oldReadMeFile))
                {
                    using (StreamWriter swAppend = File.AppendText(oldReadMeFile))
                    {
                        swAppend.WriteLine(File.ReadAllText(readMeFile));
                        swAppend.Close();
                    }
                }
                else
                {
                    File.Copy(@readMeFile, @oldReadMeFile);

                    using (StreamWriter sw = File.CreateText(readMeFile))
                    {
                        sw.WriteLine(releaseNotesTextbox.Text);
                        sw.Close();
                    }
                }

                using (StreamWriter swReplace = File.CreateText(readMeFile))
                {
                    swReplace.WriteLine(releaseNotesTextbox.Text);
                    swReplace.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(readMeFile))
                {
                    sw.WriteLine(releaseNotesTextbox.Text);
                    sw.Close();
                }
            }
            releaseNotesTextbox.Clear();
        }

        private void addNewLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 addNewApplicationForm = new Form2(this);

            applicationComboBox.Items.Clear();
            addNewApplicationForm.FormClosed += (x, y) =>
                {
                    loadComboBox();
                };

            addNewApplicationForm.ShowDialog();
        }

        private void editLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {    
            Form3 editApplicationForm = new Form3(this);
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
