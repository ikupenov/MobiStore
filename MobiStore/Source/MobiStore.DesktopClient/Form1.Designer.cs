using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

using MobiStore.Data;
using MobiStore.Utilities.Importers;

namespace MobiStore.DesktopClient
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
            this.LoadExcelReportsButton = new System.Windows.Forms.Button();
            this.LoadDataFromMongoButton = new System.Windows.Forms.Button();
            this.GenerateXmlReportsButton = new System.Windows.Forms.Button();
            this.GenerateJsonReportsButton = new System.Windows.Forms.Button();
            this.LoadDataFromXmlButton = new System.Windows.Forms.Button();
            this.SQLiteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadExcelReportsButton
            // 
            this.LoadExcelReportsButton.Location = new System.Drawing.Point(395, 15);
            this.LoadExcelReportsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadExcelReportsButton.Name = "LoadExcelReportsButton";
            this.LoadExcelReportsButton.Size = new System.Drawing.Size(223, 50);
            this.LoadExcelReportsButton.TabIndex = 0;
            this.LoadExcelReportsButton.Text = "Load Excel Reports";
            this.LoadExcelReportsButton.UseVisualStyleBackColor = true;
            this.LoadExcelReportsButton.Click += new System.EventHandler(this.LoadExcelReportsButton_Click);
            // 
            // LoadDataFromMongoButton
            // 
            this.LoadDataFromMongoButton.Location = new System.Drawing.Point(395, 90);
            this.LoadDataFromMongoButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadDataFromMongoButton.Name = "LoadDataFromMongoButton";
            this.LoadDataFromMongoButton.Size = new System.Drawing.Size(223, 52);
            this.LoadDataFromMongoButton.TabIndex = 1;
            this.LoadDataFromMongoButton.Text = "Load Data from MongoDB";
            this.LoadDataFromMongoButton.UseVisualStyleBackColor = true;
            this.LoadDataFromMongoButton.Click += new System.EventHandler(this.LoadDataFromMongoButton_Click);
            // 
            // GenerateXmlReportsButton
            // 
            this.GenerateXmlReportsButton.Location = new System.Drawing.Point(395, 162);
            this.GenerateXmlReportsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GenerateXmlReportsButton.Name = "GenerateXmlReportsButton";
            this.GenerateXmlReportsButton.Size = new System.Drawing.Size(223, 50);
            this.GenerateXmlReportsButton.TabIndex = 2;
            this.GenerateXmlReportsButton.Text = "Generate XML Reports";
            this.GenerateXmlReportsButton.UseVisualStyleBackColor = true;
            this.GenerateXmlReportsButton.Click += new System.EventHandler(this.GenerateXmlReportsButton_Click);
            // 
            // GenerateJsonReportsButton
            // 
            this.GenerateJsonReportsButton.Location = new System.Drawing.Point(395, 239);
            this.GenerateJsonReportsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GenerateJsonReportsButton.Name = "GenerateJsonReportsButton";
            this.GenerateJsonReportsButton.Size = new System.Drawing.Size(223, 49);
            this.GenerateJsonReportsButton.TabIndex = 3;
            this.GenerateJsonReportsButton.Text = "Generate JSON Reports";
            this.GenerateJsonReportsButton.UseVisualStyleBackColor = true;
            this.GenerateJsonReportsButton.Click += new System.EventHandler(this.GenerateJsonReportsButton_Click);
            // 
            // LoadDataFromXmlButton
            // 
            this.LoadDataFromXmlButton.Location = new System.Drawing.Point(395, 316);
            this.LoadDataFromXmlButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadDataFromXmlButton.Name = "LoadDataFromXmlButton";
            this.LoadDataFromXmlButton.Size = new System.Drawing.Size(223, 48);
            this.LoadDataFromXmlButton.TabIndex = 4;
            this.LoadDataFromXmlButton.Text = "Load data from XML";
            this.LoadDataFromXmlButton.UseVisualStyleBackColor = true;
            this.LoadDataFromXmlButton.Click += new System.EventHandler(this.LoadDataFromXmlButton_Click);
            // 
            // SQLiteButton
            // 
            this.SQLiteButton.Location = new System.Drawing.Point(16, 15);
            this.SQLiteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SQLiteButton.Name = "SQLiteButton";
            this.SQLiteButton.Size = new System.Drawing.Size(349, 555);
            this.SQLiteButton.TabIndex = 5;
            this.SQLiteButton.Text = "Автомонтьор - златни ръце,\r\nще ремонтирам всичко по теб.\r\nАвтомонтьор, супер разб" +
    "ирач,\r\nще те работя аз от сутрин до здрач.\r\n\r\n";
            this.SQLiteButton.UseVisualStyleBackColor = true;
            this.SQLiteButton.Click += new System.EventHandler(this.SQLiteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 585);
            this.Controls.Add(this.SQLiteButton);
            this.Controls.Add(this.LoadDataFromXmlButton);
            this.Controls.Add(this.GenerateJsonReportsButton);
            this.Controls.Add(this.GenerateXmlReportsButton);
            this.Controls.Add(this.LoadDataFromMongoButton);
            this.Controls.Add(this.LoadExcelReportsButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadExcelReportsButton;
        private Button LoadDataFromMongoButton;
        private Button GenerateXmlReportsButton;
        private Button GenerateJsonReportsButton;
        private Button LoadDataFromXmlButton;
        private Button SQLiteButton;
    }
}

