using System.ComponentModel;
using System.Windows.Forms;

namespace MobiStore.DesktopClient
{
    public partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;
        private Button loadExcelReportsButton;
        private Button loadDataFromMongoButton;
        private Button generateXmlReportsButton;
        private Button generateJsonReportsButton;
        private Button loadDataFromXmlButton;
        private Button sqliteButton;
        private Button pdfReportButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.loadExcelReportsButton = new System.Windows.Forms.Button();
            this.loadDataFromMongoButton = new System.Windows.Forms.Button();
            this.generateXmlReportsButton = new System.Windows.Forms.Button();
            this.generateJsonReportsButton = new System.Windows.Forms.Button();
            this.loadDataFromXmlButton = new System.Windows.Forms.Button();
            this.sqliteButton = new System.Windows.Forms.Button();
            this.pdfReportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadExcelReportsButton
            // 
            this.loadExcelReportsButton.Location = new System.Drawing.Point(418, 13);
            this.loadExcelReportsButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadExcelReportsButton.Name = "loadExcelReportsButton";
            this.loadExcelReportsButton.Size = new System.Drawing.Size(312, 50);
            this.loadExcelReportsButton.TabIndex = 0;
            this.loadExcelReportsButton.Text = "Load Excel Reports";
            this.loadExcelReportsButton.UseVisualStyleBackColor = true;
            this.loadExcelReportsButton.Click += new System.EventHandler(this.LoadExcelReportsButton_Click);
            // 
            // loadDataFromMongoButton
            // 
            this.loadDataFromMongoButton.Location = new System.Drawing.Point(418, 167);
            this.loadDataFromMongoButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadDataFromMongoButton.Name = "loadDataFromMongoButton";
            this.loadDataFromMongoButton.Size = new System.Drawing.Size(312, 52);
            this.loadDataFromMongoButton.TabIndex = 1;
            this.loadDataFromMongoButton.Text = "Load data from MongoDB";
            this.loadDataFromMongoButton.UseVisualStyleBackColor = true;
            this.loadDataFromMongoButton.Click += new System.EventHandler(this.LoadDataFromMongoButton_Click);
            // 
            // generateXmlReportsButton
            // 
            this.generateXmlReportsButton.Location = new System.Drawing.Point(418, 430);
            this.generateXmlReportsButton.Margin = new System.Windows.Forms.Padding(4);
            this.generateXmlReportsButton.Name = "generateXmlReportsButton";
            this.generateXmlReportsButton.Size = new System.Drawing.Size(312, 50);
            this.generateXmlReportsButton.TabIndex = 2;
            this.generateXmlReportsButton.Text = "Generate XML Reports";
            this.generateXmlReportsButton.UseVisualStyleBackColor = true;
            this.generateXmlReportsButton.Click += new System.EventHandler(this.GenerateXmlReportsButton_Click);
            // 
            // generateJsonReportsButton
            // 
            this.generateJsonReportsButton.Location = new System.Drawing.Point(418, 258);
            this.generateJsonReportsButton.Margin = new System.Windows.Forms.Padding(4);
            this.generateJsonReportsButton.Name = "generateJsonReportsButton";
            this.generateJsonReportsButton.Size = new System.Drawing.Size(312, 49);
            this.generateJsonReportsButton.TabIndex = 3;
            this.generateJsonReportsButton.Text = "Generate JSON Reports";
            this.generateJsonReportsButton.UseVisualStyleBackColor = true;
            this.generateJsonReportsButton.Click += new System.EventHandler(this.GenerateJsonReportsButton_Click);
            // 
            // loadDataFromXmlButton
            // 
            this.loadDataFromXmlButton.Location = new System.Drawing.Point(418, 111);
            this.loadDataFromXmlButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadDataFromXmlButton.Name = "loadDataFromXmlButton";
            this.loadDataFromXmlButton.Size = new System.Drawing.Size(312, 48);
            this.loadDataFromXmlButton.TabIndex = 4;
            this.loadDataFromXmlButton.Text = "Load data from XML";
            this.loadDataFromXmlButton.UseVisualStyleBackColor = true;
            this.loadDataFromXmlButton.Click += new System.EventHandler(this.LoadDataFromXmlButton_Click);
            // 
            // sqliteButton
            // 
            this.sqliteButton.Location = new System.Drawing.Point(418, 315);
            this.sqliteButton.Margin = new System.Windows.Forms.Padding(4);
            this.sqliteButton.Name = "sqliteButton";
            this.sqliteButton.Size = new System.Drawing.Size(312, 50);
            this.sqliteButton.TabIndex = 5;
            this.sqliteButton.Text = "Generate Excel Reports";
            this.sqliteButton.UseVisualStyleBackColor = true;
            this.sqliteButton.Click += new System.EventHandler(this.SQLiteButton_Click);
            // 
            // pdfReportButton
            // 
            this.pdfReportButton.Location = new System.Drawing.Point(418, 373);
            this.pdfReportButton.Margin = new System.Windows.Forms.Padding(4);
            this.pdfReportButton.Name = "pdfReportButton";
            this.pdfReportButton.Size = new System.Drawing.Size(312, 49);
            this.pdfReportButton.TabIndex = 6;
            this.pdfReportButton.Text = "Generate PDF Report";
            this.pdfReportButton.UseVisualStyleBackColor = true;
            this.pdfReportButton.Click += new System.EventHandler(this.PdfReportButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1068, 585);
            this.Controls.Add(this.pdfReportButton);
            this.Controls.Add(this.sqliteButton);
            this.Controls.Add(this.loadDataFromXmlButton);
            this.Controls.Add(this.generateJsonReportsButton);
            this.Controls.Add(this.generateXmlReportsButton);
            this.Controls.Add(this.loadDataFromMongoButton);
            this.Controls.Add(this.loadExcelReportsButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "MobiStore";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
