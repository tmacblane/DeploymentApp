﻿namespace DeploymentApp
{
    partial class Form2
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.applicationNameTextbox = new System.Windows.Forms.TextBox();
            this.executableFileTextbox = new System.Windows.Forms.TextBox();
            this.dependenciesTextBox = new System.Windows.Forms.TextBox();
            this.buildPathTextBox = new System.Windows.Forms.TextBox();
            this.stagingPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.executableButton = new System.Windows.Forms.Button();
            this.dependencyButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider5 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // applicationNameTextbox
            // 
            this.applicationNameTextbox.Location = new System.Drawing.Point(123, 24);
            this.applicationNameTextbox.Name = "applicationNameTextbox";
            this.applicationNameTextbox.Size = new System.Drawing.Size(200, 20);
            this.applicationNameTextbox.TabIndex = 0;
            // 
            // executableFileTextbox
            // 
            this.executableFileTextbox.Location = new System.Drawing.Point(123, 51);
            this.executableFileTextbox.Name = "executableFileTextbox";
            this.executableFileTextbox.Size = new System.Drawing.Size(200, 20);
            this.executableFileTextbox.TabIndex = 1;
            // 
            // dependenciesTextBox
            // 
            this.dependenciesTextBox.Location = new System.Drawing.Point(123, 78);
            this.dependenciesTextBox.Multiline = true;
            this.dependenciesTextBox.Name = "dependenciesTextBox";
            this.dependenciesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dependenciesTextBox.Size = new System.Drawing.Size(200, 50);
            this.dependenciesTextBox.TabIndex = 3;
            // 
            // buildPathTextBox
            // 
            this.buildPathTextBox.Location = new System.Drawing.Point(123, 134);
            this.buildPathTextBox.Name = "buildPathTextBox";
            this.buildPathTextBox.Size = new System.Drawing.Size(200, 20);
            this.buildPathTextBox.TabIndex = 5;
            // 
            // stagingPathTextBox
            // 
            this.stagingPathTextBox.Location = new System.Drawing.Point(123, 161);
            this.stagingPathTextBox.Name = "stagingPathTextBox";
            this.stagingPathTextBox.Size = new System.Drawing.Size(200, 20);
            this.stagingPathTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Application Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Executable:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Dependency:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Build Path:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Staging Path:";
            // 
            // executableButton
            // 
            this.executableButton.Location = new System.Drawing.Point(355, 49);
            this.executableButton.Name = "executableButton";
            this.executableButton.Size = new System.Drawing.Size(75, 23);
            this.executableButton.TabIndex = 2;
            this.executableButton.Text = "Browse";
            this.executableButton.UseVisualStyleBackColor = true;
            this.executableButton.Click += new System.EventHandler(this.executableButton_Click);
            // 
            // dependencyButton
            // 
            this.dependencyButton.Location = new System.Drawing.Point(355, 76);
            this.dependencyButton.Name = "dependencyButton";
            this.dependencyButton.Size = new System.Drawing.Size(75, 23);
            this.dependencyButton.TabIndex = 4;
            this.dependencyButton.Text = "Browse";
            this.dependencyButton.UseVisualStyleBackColor = true;
            this.dependencyButton.Click += new System.EventHandler(this.dependencyButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            // 
            // errorProvider5
            // 
            this.errorProvider5.ContainerControl = this;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(355, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(355, 159);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Browse";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 266);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dependencyButton);
            this.Controls.Add(this.executableButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stagingPathTextBox);
            this.Controls.Add(this.buildPathTextBox);
            this.Controls.Add(this.dependenciesTextBox);
            this.Controls.Add(this.executableFileTextbox);
            this.Controls.Add(this.applicationNameTextbox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Application";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox applicationNameTextbox;
        public System.Windows.Forms.TextBox executableFileTextbox;
        public System.Windows.Forms.TextBox dependenciesTextBox;
        public System.Windows.Forms.TextBox buildPathTextBox;
        public System.Windows.Forms.TextBox stagingPathTextBox;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button executableButton;
        public System.Windows.Forms.Button dependencyButton;
        public System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.ErrorProvider errorProvider2;
        public System.Windows.Forms.ErrorProvider errorProvider3;
        public System.Windows.Forms.ErrorProvider errorProvider4;
        public System.Windows.Forms.ErrorProvider errorProvider5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}