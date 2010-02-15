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
    public class UpdateApplication
    {
        string executablePath = Application.StartupPath;

        public void updateExistingApplication(application appClass)
        {
            XmlDocument interfaces = new XmlDocument();
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

            //Locates the elements from the xml
            XmlAttribute applicationName = node.Attributes["name"];
            XmlNode executableFile = node.SelectSingleNode("executable");
            XmlNode dependencyFiles = node.SelectSingleNode("dependencies");
            XmlNode buildPath = node.SelectSingleNode("build_path");
            XmlNode stagingPath = node.SelectSingleNode("staging_path");

            //Remove the dependency nodes from the xml
            dependencyFiles.RemoveAll();

            //Assigns strings to the textbox values
            string updatedApplicationName = appClass.ApplicationNameText;
            string updatedExecutableFile = appClass.ExecutableNameText;
            string updatedBuildPath = appClass.BuildPathText;
            string updatedStagingPath = appClass.StagingPathText;

            //Create a new dependency node            
            string[] dependencies = appClass.DependenciesText.Split(new char[] { '\n' });

            foreach (string dependency in dependencies)
            {
                XmlElement dependencyNode = interfaces.CreateElement("dependency");
                dependencyNode.InnerText = dependency.Trim().ToString();
                if (dependencyNode.InnerText.Trim() != "")
                {
                    dependencyFiles.AppendChild(dependencyNode);
                }
            }

            //Updates the xml with the updated values
            applicationName.Value = updatedApplicationName;
            executableFile.InnerText = updatedExecutableFile;
            buildPath.InnerText = updatedBuildPath;
            stagingPath.InnerText = updatedStagingPath;

            //Saves and updates the xml
            interfaces.Save(executablePath + "\\" + Settings.Default.XMLFile);
        }
    }
}
