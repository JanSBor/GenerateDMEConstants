namespace GenerateDMEConstants
{
    partial class Main
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
            this.ExtensionFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.GenerateFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ExtensionFileName = new System.Windows.Forms.TextBox();
            this.SelectExtFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TypeEnum = new System.Windows.Forms.RadioButton();
            this.TypeClass = new System.Windows.Forms.RadioButton();
            this.SelectOutputFile = new System.Windows.Forms.Button();
            this.OutputFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LanguageVB = new System.Windows.Forms.RadioButton();
            this.LanguageCSharp = new System.Windows.Forms.RadioButton();
            this.tnamespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OutputFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExtensionFileDlg
            // 
            this.ExtensionFileDlg.FileName = "openFileDialog1";
            // 
            // GenerateFile
            // 
            this.GenerateFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(0)))));
            this.GenerateFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(0)))));
            this.GenerateFile.FlatAppearance.BorderSize = 0;
            this.GenerateFile.Location = new System.Drawing.Point(273, 237);
            this.GenerateFile.Name = "GenerateFile";
            this.GenerateFile.Size = new System.Drawing.Size(114, 44);
            this.GenerateFile.TabIndex = 0;
            this.GenerateFile.Text = "Generate File";
            this.GenerateFile.UseVisualStyleBackColor = false;
            this.GenerateFile.Click += new System.EventHandler(this.GenerateFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Extension file:";
            // 
            // ExtensionFileName
            // 
            this.ExtensionFileName.Location = new System.Drawing.Point(101, 18);
            this.ExtensionFileName.Name = "ExtensionFileName";
            this.ExtensionFileName.Size = new System.Drawing.Size(240, 20);
            this.ExtensionFileName.TabIndex = 2;
            // 
            // SelectExtFile
            // 
            this.SelectExtFile.Location = new System.Drawing.Point(347, 14);
            this.SelectExtFile.Name = "SelectExtFile";
            this.SelectExtFile.Size = new System.Drawing.Size(40, 26);
            this.SelectExtFile.TabIndex = 3;
            this.SelectExtFile.Text = "...";
            this.SelectExtFile.UseVisualStyleBackColor = true;
            this.SelectExtFile.Click += new System.EventHandler(this.SelectExtFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TypeEnum);
            this.groupBox1.Controls.Add(this.TypeClass);
            this.groupBox1.Location = new System.Drawing.Point(26, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 46);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type of structure";
            // 
            // TypeEnum
            // 
            this.TypeEnum.AutoSize = true;
            this.TypeEnum.Location = new System.Drawing.Point(96, 19);
            this.TypeEnum.Name = "TypeEnum";
            this.TypeEnum.Size = new System.Drawing.Size(52, 17);
            this.TypeEnum.TabIndex = 1;
            this.TypeEnum.Text = "Enum";
            this.TypeEnum.UseVisualStyleBackColor = true;
            // 
            // TypeClass
            // 
            this.TypeClass.AutoSize = true;
            this.TypeClass.Checked = true;
            this.TypeClass.Location = new System.Drawing.Point(6, 19);
            this.TypeClass.Name = "TypeClass";
            this.TypeClass.Size = new System.Drawing.Size(50, 17);
            this.TypeClass.TabIndex = 0;
            this.TypeClass.TabStop = true;
            this.TypeClass.Text = "Class";
            this.TypeClass.UseVisualStyleBackColor = true;
            // 
            // SelectOutputFile
            // 
            this.SelectOutputFile.Location = new System.Drawing.Point(347, 159);
            this.SelectOutputFile.Name = "SelectOutputFile";
            this.SelectOutputFile.Size = new System.Drawing.Size(40, 26);
            this.SelectOutputFile.TabIndex = 7;
            this.SelectOutputFile.Text = "...";
            this.SelectOutputFile.UseVisualStyleBackColor = true;
            this.SelectOutputFile.Click += new System.EventHandler(this.SelectOutputFile_Click);
            // 
            // OutputFileName
            // 
            this.OutputFileName.Location = new System.Drawing.Point(101, 163);
            this.OutputFileName.Name = "OutputFileName";
            this.OutputFileName.Size = new System.Drawing.Size(240, 20);
            this.OutputFileName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output file:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LanguageVB);
            this.groupBox2.Controls.Add(this.LanguageCSharp);
            this.groupBox2.Location = new System.Drawing.Point(26, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 46);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Language";
            // 
            // LanguageVB
            // 
            this.LanguageVB.AutoSize = true;
            this.LanguageVB.Location = new System.Drawing.Point(96, 19);
            this.LanguageVB.Name = "LanguageVB";
            this.LanguageVB.Size = new System.Drawing.Size(62, 17);
            this.LanguageVB.TabIndex = 1;
            this.LanguageVB.Text = "VB .Net";
            this.LanguageVB.UseVisualStyleBackColor = true;
            // 
            // LanguageCSharp
            // 
            this.LanguageCSharp.AutoSize = true;
            this.LanguageCSharp.Checked = true;
            this.LanguageCSharp.Location = new System.Drawing.Point(6, 19);
            this.LanguageCSharp.Name = "LanguageCSharp";
            this.LanguageCSharp.Size = new System.Drawing.Size(39, 17);
            this.LanguageCSharp.TabIndex = 0;
            this.LanguageCSharp.TabStop = true;
            this.LanguageCSharp.Text = "C#";
            this.LanguageCSharp.UseVisualStyleBackColor = true;
            // 
            // tnamespace
            // 
            this.tnamespace.Location = new System.Drawing.Point(101, 189);
            this.tnamespace.Name = "tnamespace";
            this.tnamespace.Size = new System.Drawing.Size(240, 20);
            this.tnamespace.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Namespace:";
            // 
            // OutputFileDlg
            // 
            this.OutputFileDlg.CheckFileExists = false;
            this.OutputFileDlg.FileName = "openFileDialog1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 330);
            this.Controls.Add(this.tnamespace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SelectOutputFile);
            this.Controls.Add(this.OutputFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SelectExtFile);
            this.Controls.Add(this.ExtensionFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GenerateFile);
            this.Name = "Main";
            this.Text = "Main";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ExtensionFileDlg;
        private System.Windows.Forms.Button GenerateFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ExtensionFileName;
        private System.Windows.Forms.Button SelectExtFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton TypeEnum;
        private System.Windows.Forms.RadioButton TypeClass;
        private System.Windows.Forms.Button SelectOutputFile;
        private System.Windows.Forms.TextBox OutputFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton LanguageVB;
        private System.Windows.Forms.RadioButton LanguageCSharp;
        private System.Windows.Forms.TextBox tnamespace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog OutputFileDlg;
    }
}

