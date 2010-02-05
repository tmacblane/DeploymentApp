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
    public class application
    {
        #region textbox values
        //AddUpdateBaseForm values
        private string applicationNameText;
        private string executableNameText;
        private string dependenciesText;
        private string buildPathText;
        private string stagingPathText;

        //Form1 values
        private string comboBoxValue;
        private string releaseNotesText;

        //Email information
        private string emailHost;
        private string emailPort;
        private string emailUsername;
        private string emailPassword;
        private string emailSender;
        private string emailRecipient;
        #endregion

        #region set values
        //AddUpdateBaseForm values
        public string ApplicationNameText
        {
            get { return applicationNameText; }
            set { applicationNameText = value; }
        }

        public string ExecutableNameText
        {
            get { return executableNameText; }
            set { executableNameText = value; }
        }

        public string DependenciesText
        {
            get { return dependenciesText; }
            set { dependenciesText = value; }
        }

        public string BuildPathText
        {
            get { return buildPathText; }
            set { buildPathText = value; }
        }

        public string StagingPathText
        {
            get { return stagingPathText; }
            set { stagingPathText = value; }
        }

        //Form1 values
        public string ComboBoxValue
        {
            get { return comboBoxValue; }
            set { comboBoxValue = value; }
        }

        public string ReleaseNotesText
        {
            get { return releaseNotesText; }
            set { releaseNotesText = value; }
        }

        //Email information
        public string EmailHost
        {
            get { return emailHost; }
            set { emailHost = value; }
        }

        public string EmailPort
        {
            get { return emailPort; }
            set { emailPort = value; }
        }

        public string EmailUsername
        {
            get { return emailUsername; }
            set { emailUsername = value; }
        }

        public string EmailPassword
        {
            get { return emailPassword; }
            set { emailPassword = value; }
        }

        public string EmailSender
        {
            get { return emailSender; }
            set { emailSender = value; }
        }

        public string EmailRecipient
        {
            get { return emailRecipient; }
            set { emailRecipient = value; }
        }
        #endregion
    }
}
