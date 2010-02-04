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
    public class deleteApplication
    {
        string executablePath = Application.StartupPath;

        public void deleteExistingApplication(application appClass)
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

            node.ParentNode.RemoveChild(node);

            interfaces.Save(executablePath + "\\" + Settings.Default.XMLFile);
        }
    }
}
