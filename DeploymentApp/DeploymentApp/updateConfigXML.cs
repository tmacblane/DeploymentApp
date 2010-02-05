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
    public class updateConfigXML
    {
        string executablePath = Application.StartupPath;

        public void configureEmailSettings(application appClass)
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
