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
    public class SendEmail
    {
        string executablePath = Application.StartupPath;

        public void sendEmailNotification(application appClass)
        {
            XmlDocument emailConfig = new XmlDocument();
            emailConfig.Load(executablePath + "\\" + Settings.Default.ConfigXMLFile);
            
            XmlNode emailList = emailConfig.SelectSingleNode("settings/email");

            //Locate elements from the XML
            XmlNode hostInformation = emailList.SelectSingleNode("host");
            XmlNode portInformation = emailList.SelectSingleNode("port");
            XmlNode usernameInformation = emailList.SelectSingleNode("username");
            XmlNode passwordInformation = emailList.SelectSingleNode("password");
            XmlNode senderInformation = emailList.SelectSingleNode("sender");
            XmlNode recipientInformation = emailList.SelectSingleNode("recipient");

            string host = hostInformation.InnerText;
            int port = Convert.ToInt32(portInformation.InnerText);
            string username = usernameInformation.InnerText;
            string password = passwordInformation.InnerText;
            string sender = senderInformation.InnerText;
            string recipient = recipientInformation.InnerText;

            SmtpClient client = new SmtpClient();
            client.Host = host;
            client.Port = port;
            client.EnableSsl = false;
            client.Credentials = new NetworkCredential(username, password);

            client.Send(sender, recipient, appClass.ComboBoxValue + " Release", appClass.ReleaseNotesText);
        }
    }
}
