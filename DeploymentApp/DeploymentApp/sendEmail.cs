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
        public void sendEmailNotification(application appClass)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "192.168.4.11";
            client.Port = 25;
            client.EnableSsl = false;
            client.Credentials = new NetworkCredential("username", "password");

            client.Send("sender", "recipient", appClass.ComboBoxValue + " Release", appClass.ReleaseNotesText);
        }
    }
}
