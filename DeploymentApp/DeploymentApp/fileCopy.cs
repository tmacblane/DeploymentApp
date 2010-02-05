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
    public class fileCopy
    {
        string executablePath = Application.StartupPath;
        XmlDocument interfaces = new XmlDocument();

        public void copyFiles(application appClass)
        {
            interfaces.Load(executablePath + "\\" + Settings.Default.XMLFile);

            //Pulls the list of applications in the xml
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
        }
    }
}
