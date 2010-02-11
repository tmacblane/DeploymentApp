using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DeploymentApp
{
    public partial class configureEmailForm : Form
    {
        public configureEmailForm()
        {
            InitializeComponent();
        }

        #region Validate Textboxes
        private bool validateHostNameTextbox()
        {
            bool hostInformation = true;
            if (smtpHostTextbox.Text.Trim() == "")
            {
                errorProvider1.SetError(smtpHostTextbox, "Enter a host name");
                hostInformation = false;
            }
            else
                errorProvider1.Clear();
            return hostInformation;
        }

        private bool validatePortTextbox()
        {
            bool portInformation = true;
            if (portTextbox.Text.Trim() == "")
            {
                errorProvider2.SetError(portTextbox, "Enter a port number");
                portInformation = false;                                            
            }
            else
            {                
                try
                {
                    int i = int.Parse(portTextbox.Text);
                    portInformation = true;
                    errorProvider2.Clear();                    
                }
                catch
                {
                    errorProvider2.SetError(portTextbox, "Port must be a number");
                    portInformation = false;
                }
            }
            return portInformation;
        }

        private bool validateUsernameTextbox()
        {
            bool usernameInformation = true;
            if (usernameTextbox.Text.Trim() == "")
            {
                errorProvider3.SetError(usernameTextbox, "Enter an account username");
                usernameInformation = false;
            }
            else
                errorProvider3.Clear();
            return usernameInformation;
        }

        private bool validatePasswordTextbox()
        {
            bool passwordInformation = true;
            if (passwordTextbox.Text.Trim() == "")
            {
                errorProvider4.SetError(passwordTextbox, "Enter an account password");
                passwordInformation = false;
            }
            else
                errorProvider4.Clear();
            return passwordInformation;
        }

        private bool validateSenderTextbox()
        {
            bool senderInformation = true;
            if (senderTextbox.Text.Trim() == "")
            {
                errorProvider5.SetError(senderTextbox, "Enter the sender address");
                senderInformation = false;
            }
            else
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + 
                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

                Regex re = new Regex(strRegex);

                if (re.IsMatch(senderTextbox.Text))
                {              
                    senderInformation = true;
                    errorProvider5.Clear();
                }
                else
                {
                    errorProvider5.SetError(senderTextbox, "Email address must be in a valid format");
                    senderInformation = false;
                }
            }
            return senderInformation;
        }

        private bool validateRecipientTextbox()
        {
            bool recipientInformation = true;
            if (recipientTextbox.Text.Trim() == "")
            {
                errorProvider6.SetError(recipientTextbox, "Enter the recipient address");
                recipientInformation = false;
            }
            else
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

                Regex re = new Regex(strRegex);

                if (re.IsMatch(recipientTextbox.Text))
                {
                    recipientInformation = true;
                    errorProvider6.Clear();
                }
                else
                {
                    errorProvider6.SetError(recipientTextbox, "Email address must be in a valid format");
                    recipientInformation = false;
                }
            }
            return recipientInformation;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool validHostInformation = validateHostNameTextbox();
            bool validPortInformation = validatePortTextbox();
            bool validUsernameInformation = validateUsernameTextbox();
            bool validPasswordInformation = validatePasswordTextbox();
            bool validSenderInformation = validateSenderTextbox();
            bool validRecipientInformation = validateRecipientTextbox();

            if (validHostInformation && validPortInformation && validUsernameInformation && validPasswordInformation && validSenderInformation && validRecipientInformation)
            {  
                application appClass = new application();
                appClass.EmailHost = smtpHostTextbox.Text;
                appClass.EmailPort = portTextbox.Text;
                appClass.EmailUsername = usernameTextbox.Text;
                appClass.EmailPassword = passwordTextbox.Text;
                appClass.EmailSender = senderTextbox.Text;
                appClass.EmailRecipient = recipientTextbox.Text;

                updateConfigXML configureEmailInfo = new updateConfigXML();
                configureEmailInfo.configureEmailSettings(appClass);

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to cancel.  You will not be able to send emails when deploying applications.", "Cancel Email Configuration", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
