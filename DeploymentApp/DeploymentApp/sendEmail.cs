using DeploymentApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DeploymentApp
{
    public class sendEmail
    {
        string executablePath = Application.StartupPath;

        public void sendEmailNotification(application appClass)
        {
            XmlDocument interfaces = new XmlDocument();
            interfaces.Load(executablePath + "\\" + Settings.Default.ConfigXMLFile);
            XmlNodeList applicationList = interfaces.SelectNodes("settings/email");

            //Locate elements from the XML
            XmlNode hostInformation = interfaces.SelectSingleNode("host");
            XmlNode portInformation = interfaces.SelectSingleNode("port");
            XmlNode usernameInformation = interfaces.SelectSingleNode("username");
            XmlNode passwordInformation = interfaces.SelectSingleNode("password");
            XmlNode senderInformation = interfaces.SelectSingleNode("sender");
            XmlNode recipientInformation = interfaces.SelectSingleNode("recipient");

            SmtpClient client = new SmtpClient();
            client.Host = hostInformation.InnerText;
            client.Port = Convert.ToInt32(portInformation.InnerText);
            client.EnableSsl = false;
            client.Credentials = new NetworkCredential(usernameInformation.InnerText, passwordInformation.InnerText);

            client.Send(senderInformation.InnerText, recipientInformation.InnerText, appClass.ComboBoxValue + " Release", appClass.ReleaseNotesText);
        }
    }
}
