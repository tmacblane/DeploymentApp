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
    public class CreateReadMeFile
    {
        string executablePath = Application.StartupPath;
        XmlDocument interfaces = new XmlDocument();

        public void createReadMe(application appClass)
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
                        sw.WriteLine("========================================");
                        sw.WriteLine(appClass.ComboBoxValue + " Release Notes " + System.DateTime.Today.ToShortDateString());
                        sw.WriteLine("");
                        sw.WriteLine(appClass.ReleaseNotesText);
                        sw.WriteLine("========================================");
                        sw.Close();
                    }
                }

                using (StreamWriter swReplace = File.CreateText(readMeFile))
                {
                    swReplace.WriteLine("========================================");
                    swReplace.WriteLine(appClass.ComboBoxValue + " Release Notes " + System.DateTime.Today.ToShortDateString());
                    swReplace.WriteLine("");
                    swReplace.WriteLine(appClass.ReleaseNotesText);
                    swReplace.WriteLine("========================================");
                    swReplace.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(readMeFile))
                {
                    sw.WriteLine("========================================");
                    sw.WriteLine(appClass.ComboBoxValue + " Release Notes " + System.DateTime.Today.ToShortDateString());
                    sw.WriteLine("");
                    sw.WriteLine(appClass.ReleaseNotesText);
                    sw.WriteLine("========================================");
                    sw.Close();
                }
            }            
        }
    }
}
