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
        private string applicationNameText;
        private string executableNameText;
        private string dependenciesText;
        private string buildPathText;
        private string stagingPathText;

        private string comboBoxValue;
        private string releaseNotesText;
        #endregion

        #region set values
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
        #endregion
    }
}
