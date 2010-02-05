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
    public class addNewApplication
    {
        string executablePath = Application.StartupPath;

        public void createNewApplication(application appClass)
        {
            XmlDocument interfaces = new XmlDocument();
            interfaces.Load(executablePath + "\\" + Settings.Default.XMLFile);

            //Create a new application node
            XmlElement applicationNode = interfaces.CreateElement("application");

            //Set the attribute for the application node
            XmlAttribute applicationName = interfaces.CreateAttribute("name");

            //Assign a value to the attribute and associated it with the application node
            applicationName.Value = appClass.ApplicationNameText;
            applicationNode.SetAttributeNode(applicationName);

            //Create a new executable node
            XmlElement executableNode = interfaces.CreateElement("executable");
            executableNode.InnerText = appClass.ExecutableNameText;
            applicationNode.AppendChild(executableNode);

            //Create a new dependencies node
            XmlElement dependenciesNode = interfaces.CreateElement("dependencies");
            applicationNode.AppendChild(dependenciesNode);

            //Create a new dependency node
            string[] dependencies = appClass.DependenciesText.Split(new char[] { '\n' });

            foreach (string dependency in dependencies)
            {
                XmlElement dependencyNode = interfaces.CreateElement("dependency");
                dependencyNode.InnerText = dependency.ToString();
                if (dependencyNode.InnerText != "")
                {
                    dependenciesNode.AppendChild(dependencyNode);
                }
            }            

            //Create a new build path node
            XmlElement buildPathNode = interfaces.CreateElement("build_path");
            buildPathNode.InnerText = appClass.BuildPathText;
            applicationNode.AppendChild(buildPathNode);

            //Create a new staging path node
            XmlElement stagingPathNode = interfaces.CreateElement("staging_path");
            stagingPathNode.InnerText = appClass.StagingPathText;
            applicationNode.AppendChild(stagingPathNode);

            interfaces.DocumentElement.InsertAfter(applicationNode, interfaces.DocumentElement.LastChild);

            interfaces.Save(executablePath + "\\" + Settings.Default.XMLFile);
            interfaces = null;
        }        
    }
}