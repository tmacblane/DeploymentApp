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
    public class UpdateConfigXML
    {
        string executablePath = Application.StartupPath;

        public void configureEmailSettings(application appClass)
        {
            XmlDocument emailConfig = new XmlDocument();
            emailConfig.Load(executablePath + "\\" + Settings.Default.ConfigXMLFile);
            
            XmlNode hostNode = emailConfig.SelectSingleNode("settings/email/host");

            //check if email has been configured
            if (hostNode != null)
            {
                updateEmailSettings(appClass);
            }
            //configure email settings
            else
            {
                setupEmailSettings(appClass);
            }
        }

        public void updateEmailSettings(application appClass)
        {
            XmlDocument emailConfig = new XmlDocument();
            emailConfig.Load(executablePath + "\\" + Settings.Default.ConfigXMLFile);

            //Set the base path
            XmlNode node = emailConfig.SelectSingleNode("settings/email");

            //Get XML Nodes
            XmlNode hostNode = node.SelectSingleNode("host");
            XmlNode portNode = node.SelectSingleNode("port");
            XmlNode usernameNode = node.SelectSingleNode("username");
            XmlNode passwordNode = node.SelectSingleNode("password");
            XmlNode senderNode = node.SelectSingleNode("sender");
            XmlNode recipientNode = node.SelectSingleNode("recipient");

            //Update the XML with the new values
            hostNode.InnerText = appClass.EmailHost;
            portNode.InnerText = appClass.EmailPort;
            usernameNode.InnerText = appClass.EmailUsername;
            passwordNode.InnerText = appClass.EmailPassword;
            senderNode.InnerText = appClass.EmailSender;
            recipientNode.InnerText = appClass.EmailRecipient;

            //Update and save the changes
            emailConfig.Save(executablePath + "\\" + Settings.Default.ConfigXMLFile);
        }

        public void setupEmailSettings(application appClass)
        {
            XmlDocument emailConfig = new XmlDocument();
            emailConfig.Load(executablePath + "\\" + Settings.Default.ConfigXMLFile);

            //Create a new email information node
            XmlElement emailNode = emailConfig.CreateElement("email");

            //Create a new host node
            XmlElement hostNode = emailConfig.CreateElement("host");
            hostNode.InnerText = appClass.EmailHost;
            emailNode.AppendChild(hostNode);

            //Create a new port node
            XmlElement portNode = emailConfig.CreateElement("port");
            portNode.InnerText = appClass.EmailPort;
            emailNode.AppendChild(portNode);

            //Create a new username node
            XmlElement usernameNode = emailConfig.CreateElement("username");
            usernameNode.InnerText = appClass.EmailUsername;
            emailNode.AppendChild(usernameNode);

            //Create a new password node
            XmlElement passwordNode = emailConfig.CreateElement("password");
            passwordNode.InnerText = appClass.EmailPassword;
            emailNode.AppendChild(passwordNode);

            //Create a new sender node
            XmlElement senderNode = emailConfig.CreateElement("sender");
            senderNode.InnerText = appClass.EmailSender;
            emailNode.AppendChild(senderNode);

            //Create a new recipient node
            XmlElement recipientNode = emailConfig.CreateElement("recipient");
            recipientNode.InnerText = appClass.EmailRecipient;
            emailNode.AppendChild(recipientNode);

            emailConfig.DocumentElement.InsertAfter(emailNode, emailConfig.DocumentElement.LastChild);

            emailConfig.Save(executablePath + "\\" + Settings.Default.ConfigXMLFile);
            emailConfig = null;
        }
    }
}
