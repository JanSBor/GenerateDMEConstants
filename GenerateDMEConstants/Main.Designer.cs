﻿namespace GenerateDMEConstants
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
            this.GetExtensionFile = new System.Windows.Forms.OpenFileDialog();
            this.GenerateFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetExtensionFile
            // 
            this.GetExtensionFile.FileName = "openFileDialog1";
            // 
            // GenerateFile
            // 
            this.GenerateFile.Location = new System.Drawing.Point(359, 252);
            this.GenerateFile.Name = "GenerateFile";
            this.GenerateFile.Size = new System.Drawing.Size(114, 44);
            this.GenerateFile.TabIndex = 0;
            this.GenerateFile.Text = "Generate File";
            this.GenerateFile.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 307);
            this.Controls.Add(this.GenerateFile);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog GetExtensionFile;
        private System.Windows.Forms.Button GenerateFile;
    }
}
