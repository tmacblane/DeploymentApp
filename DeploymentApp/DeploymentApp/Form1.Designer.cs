namespace DeploymentApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.submit_button = new System.Windows.Forms.Button();
            this.applicationComboBox = new System.Windows.Forms.ComboBox();
            this.cancel_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.addNewLabel = new System.Windows.Forms.LinkLabel();
            this.editLabel = new System.Windows.Forms.LinkLabel();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.releaseNotesTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // submit_button
            // 
            this.submit_button.Location = new System.Drawing.Point(355, 231);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(75, 23);
            this.submit_button.TabIndex = 2;
            this.submit_button.Text = "Submit";
            this.submit_button.UseVisualStyleBackColor = true;
            this.submit_button.Click += new System.EventHandler(this.submit_button_Click);
            // 
            // applicationComboBox
            // 
            this.applicationComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.applicationComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.applicationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.applicationComboBox.FormattingEnabled = true;
            this.applicationComboBox.Items.AddRange(new object[] {
            ""});
            this.applicationComboBox.Location = new System.Drawing.Point(12, 28);
            this.applicationComboBox.Name = "applicationComboBox";
            this.applicationComboBox.Size = new System.Drawing.Size(245, 21);
            this.applicationComboBox.Sorted = true;
            this.applicationComboBox.TabIndex = 0;
            this.applicationComboBox.TextChanged += new System.EventHandler(this.applicationComboBox_TextChanged);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(274, 231);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "Close";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Release Notes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Application:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // addNewLabel
            // 
            this.addNewLabel.AutoSize = true;
            this.addNewLabel.Location = new System.Drawing.Point(310, 31);
            this.addNewLabel.Name = "addNewLabel";
            this.addNewLabel.Size = new System.Drawing.Size(51, 13);
            this.addNewLabel.TabIndex = 7;
            this.addNewLabel.TabStop = true;
            this.addNewLabel.Text = "Add New";
            this.addNewLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.addNewLabel_LinkClicked);
            // 
            // editLabel
            // 
            this.editLabel.AutoSize = true;
            this.editLabel.Location = new System.Drawing.Point(279, 31);
            this.editLabel.Name = "editLabel";
            this.editLabel.Size = new System.Drawing.Size(25, 13);
            this.editLabel.TabIndex = 8;
            this.editLabel.TabStop = true;
            this.editLabel.Text = "Edit";
            this.editLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editLabel_LinkClicked);
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // releaseNotesTextbox
            // 
            this.releaseNotesTextbox.Location = new System.Drawing.Point(12, 75);
            this.releaseNotesTextbox.Multiline = true;
            this.releaseNotesTextbox.Name = "releaseNotesTextbox";
            this.releaseNotesTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.releaseNotesTextbox.Size = new System.Drawing.Size(418, 149);
            this.releaseNotesTextbox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 266);
            this.Controls.Add(this.releaseNotesTextbox);
            this.Controls.Add(this.editLabel);
            this.Controls.Add(this.addNewLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.applicationComboBox);
            this.Controls.Add(this.submit_button);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 300);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Deployment";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button submit_button;
        public System.Windows.Forms.ComboBox applicationComboBox;
        public System.Windows.Forms.Button cancel_button;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.LinkLabel editLabel;
        public System.Windows.Forms.LinkLabel addNewLabel;
        public System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.TextBox releaseNotesTextbox;
    }
}

