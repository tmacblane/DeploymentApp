namespace DeploymentApp
{
    partial class AddUpdateBaseForm
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
            this.errorProvider5 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnStagingPath = new System.Windows.Forms.Button();
            this.btnBuildPath = new System.Windows.Forms.Button();
            this.btnExecutable = new System.Windows.Forms.Button();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDependency = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider6 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.stagingPathTextBox = new System.Windows.Forms.TextBox();
            this.buildPathTextBox = new System.Windows.Forms.TextBox();
            this.dependenciesTextBox = new System.Windows.Forms.TextBox();
            this.executableFileTextbox = new System.Windows.Forms.TextBox();
            this.applicationNameTextbox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider6)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider5
            // 
            this.errorProvider5.ContainerControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnStagingPath
            // 
            this.btnStagingPath.Location = new System.Drawing.Point(355, 181);
            this.btnStagingPath.Name = "btnStagingPath";
            this.btnStagingPath.Size = new System.Drawing.Size(75, 23);
            this.btnStagingPath.TabIndex = 21;
            this.btnStagingPath.Text = "Browse";
            this.btnStagingPath.UseVisualStyleBackColor = true;
            this.btnStagingPath.Click += new System.EventHandler(this.btnStagingPath_Click);
            // 
            // btnBuildPath
            // 
            this.btnBuildPath.Location = new System.Drawing.Point(355, 48);
            this.btnBuildPath.Name = "btnBuildPath";
            this.btnBuildPath.Size = new System.Drawing.Size(75, 23);
            this.btnBuildPath.TabIndex = 14;
            this.btnBuildPath.Text = "Browse";
            this.btnBuildPath.UseVisualStyleBackColor = true;
            this.btnBuildPath.Click += new System.EventHandler(this.btnBuildPath_Click);
            // 
            // btnExecutable
            // 
            this.btnExecutable.Location = new System.Drawing.Point(355, 74);
            this.btnExecutable.Name = "btnExecutable";
            this.btnExecutable.Size = new System.Drawing.Size(75, 23);
            this.btnExecutable.TabIndex = 16;
            this.btnExecutable.Text = "Browse";
            this.btnExecutable.UseVisualStyleBackColor = true;
            this.btnExecutable.Click += new System.EventHandler(this.btnExecutable_Click);
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
            // btnDependency
            // 
            this.btnDependency.Location = new System.Drawing.Point(355, 100);
            this.btnDependency.Name = "btnDependency";
            this.btnDependency.Size = new System.Drawing.Size(75, 23);
            this.btnDependency.TabIndex = 18;
            this.btnDependency.Text = "Browse";
            this.btnDependency.UseVisualStyleBackColor = true;
            this.btnDependency.Click += new System.EventHandler(this.btnDependency_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Staging Path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Build Path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Dependency:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Executable:";
            // 
            // errorProvider6
            // 
            this.errorProvider6.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Application Name:";
            // 
            // stagingPathTextBox
            // 
            this.stagingPathTextBox.Location = new System.Drawing.Point(123, 183);
            this.stagingPathTextBox.Name = "stagingPathTextBox";
            this.stagingPathTextBox.Size = new System.Drawing.Size(200, 20);
            this.stagingPathTextBox.TabIndex = 19;
            // 
            // buildPathTextBox
            // 
            this.buildPathTextBox.Location = new System.Drawing.Point(123, 50);
            this.buildPathTextBox.Name = "buildPathTextBox";
            this.buildPathTextBox.Size = new System.Drawing.Size(200, 20);
            this.buildPathTextBox.TabIndex = 13;
            // 
            // dependenciesTextBox
            // 
            this.dependenciesTextBox.Location = new System.Drawing.Point(123, 102);
            this.dependenciesTextBox.Multiline = true;
            this.dependenciesTextBox.Name = "dependenciesTextBox";
            this.dependenciesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dependenciesTextBox.Size = new System.Drawing.Size(200, 75);
            this.dependenciesTextBox.TabIndex = 17;
            // 
            // executableFileTextbox
            // 
            this.executableFileTextbox.Location = new System.Drawing.Point(123, 76);
            this.executableFileTextbox.Name = "executableFileTextbox";
            this.executableFileTextbox.Size = new System.Drawing.Size(200, 20);
            this.executableFileTextbox.TabIndex = 15;
            // 
            // applicationNameTextbox
            // 
            this.applicationNameTextbox.Location = new System.Drawing.Point(123, 24);
            this.applicationNameTextbox.Name = "applicationNameTextbox";
            this.applicationNameTextbox.Size = new System.Drawing.Size(200, 20);
            this.applicationNameTextbox.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 231);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 28;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(274, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AddUpdateBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 266);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStagingPath);
            this.Controls.Add(this.btnBuildPath);
            this.Controls.Add(this.btnExecutable);
            this.Controls.Add(this.btnDependency);
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
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 300);
            this.Name = "AddUpdateBaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Button btnStagingPath;
        private System.Windows.Forms.Button btnBuildPath;
        private System.Windows.Forms.Button btnExecutable;
        private System.Windows.Forms.Button btnDependency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox stagingPathTextBox;
        protected System.Windows.Forms.TextBox buildPathTextBox;
        protected System.Windows.Forms.TextBox dependenciesTextBox;
        protected System.Windows.Forms.TextBox executableFileTextbox;
        protected System.Windows.Forms.TextBox applicationNameTextbox;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
        protected System.Windows.Forms.ErrorProvider errorProvider2;
        protected System.Windows.Forms.ErrorProvider errorProvider3;
        protected System.Windows.Forms.ErrorProvider errorProvider4;
        protected System.Windows.Forms.ErrorProvider errorProvider5;
        protected System.Windows.Forms.ErrorProvider errorProvider6;
        protected System.Windows.Forms.Button button3;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button button1;
    }
}