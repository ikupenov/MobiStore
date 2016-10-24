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
            this.LoadExcelReportsButton.Location = new System.Drawing.Point(296, 12);
            this.LoadExcelReportsButton.Name = "LoadExcelReportsButton";
            this.LoadExcelReportsButton.Size = new System.Drawing.Size(167, 41);
            this.LoadExcelReportsButton.TabIndex = 0;
            this.LoadExcelReportsButton.Text = "Load Excel Reports";
            this.LoadExcelReportsButton.UseVisualStyleBackColor = true;
            this.LoadExcelReportsButton.Click += new System.EventHandler(this.LoadExcelReportsButton_Click);
            // 
            // LoadDataFromMongoButton
            // 
            this.LoadDataFromMongoButton.Location = new System.Drawing.Point(296, 73);
            this.LoadDataFromMongoButton.Name = "LoadDataFromMongoButton";
            this.LoadDataFromMongoButton.Size = new System.Drawing.Size(167, 42);
            this.LoadDataFromMongoButton.TabIndex = 1;
            this.LoadDataFromMongoButton.Text = "Load Data from MongoDB";
            this.LoadDataFromMongoButton.UseVisualStyleBackColor = true;
            this.LoadDataFromMongoButton.Click += new System.EventHandler(this.LoadDataFromMongoButton_Click);
            // 
            // GenerateXmlReportsButton
            // 
            this.GenerateXmlReportsButton.Location = new System.Drawing.Point(296, 132);
            this.GenerateXmlReportsButton.Name = "GenerateXmlReportsButton";
            this.GenerateXmlReportsButton.Size = new System.Drawing.Size(167, 41);
            this.GenerateXmlReportsButton.TabIndex = 2;
            this.GenerateXmlReportsButton.Text = "Generate XML Reports";
            this.GenerateXmlReportsButton.UseVisualStyleBackColor = true;
            this.GenerateXmlReportsButton.Click += new System.EventHandler(this.GenerateXmlReportsButton_Click);
            // 
            // GenerateJsonReportsButton
            // 
            this.GenerateJsonReportsButton.Location = new System.Drawing.Point(296, 194);
            this.GenerateJsonReportsButton.Name = "GenerateJsonReportsButton";
            this.GenerateJsonReportsButton.Size = new System.Drawing.Size(167, 40);
            this.GenerateJsonReportsButton.TabIndex = 3;
            this.GenerateJsonReportsButton.Text = "Generate JSON Reports";
            this.GenerateJsonReportsButton.UseVisualStyleBackColor = true;
            this.GenerateJsonReportsButton.Click += new System.EventHandler(this.GenerateJsonReportsButton_Click);
            // 
            // LoadDataFromXmlButton
            // 
            this.LoadDataFromXmlButton.Location = new System.Drawing.Point(296, 257);
            this.LoadDataFromXmlButton.Name = "LoadDataFromXmlButton";
            this.LoadDataFromXmlButton.Size = new System.Drawing.Size(167, 39);
            this.LoadDataFromXmlButton.TabIndex = 4;
            this.LoadDataFromXmlButton.Text = "Load data from XML";
            this.LoadDataFromXmlButton.UseVisualStyleBackColor = true;
            this.LoadDataFromXmlButton.Click += new System.EventHandler(this.LoadDataFromXmlButton_Click);
            // 
            // SQLiteButton
            // 
            this.SQLiteButton.Location = new System.Drawing.Point(12, 12);
            this.SQLiteButton.Name = "SQLiteButton";
            this.SQLiteButton.Size = new System.Drawing.Size(262, 451);
            this.SQLiteButton.TabIndex = 5;
            this.SQLiteButton.Text = "Автомонтьор - златни ръце,\r\nще ремонтирам всичко по теб.\r\nАвтомонтьор, супер разб" +
    "ирач,\r\nще те работя аз от сутрин до здрач.\r\n\r\n";
            this.SQLiteButton.UseVisualStyleBackColor = true;
            this.SQLiteButton.Click += new System.EventHandler(this.SQLiteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 475);
            this.Controls.Add(this.SQLiteButton);
            this.Controls.Add(this.LoadDataFromXmlButton);
            this.Controls.Add(this.GenerateJsonReportsButton);
            this.Controls.Add(this.GenerateXmlReportsButton);
            this.Controls.Add(this.LoadDataFromMongoButton);
            this.Controls.Add(this.LoadExcelReportsButton);
            this.Name = "Form1";
            this.Text = "Form1";
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

