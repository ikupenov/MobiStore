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
            this.loadExcelReportsButton = new System.Windows.Forms.Button();
            this.loadDataFromMongoButton = new System.Windows.Forms.Button();
            this.generateXmlReportsButton = new System.Windows.Forms.Button();
            this.generateJsonReportsButton = new System.Windows.Forms.Button();
            this.loadDataFromXmlButton = new System.Windows.Forms.Button();
            this.sqliteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadExcelReportsButton
            // 
            this.loadExcelReportsButton.Location = new System.Drawing.Point(261, 12);
            this.loadExcelReportsButton.Name = "LoadExcelReportsButton";
            this.loadExcelReportsButton.Size = new System.Drawing.Size(234, 41);
            this.loadExcelReportsButton.TabIndex = 0;
            this.loadExcelReportsButton.Text = "Load Excel Reports";
            this.loadExcelReportsButton.UseVisualStyleBackColor = true;
            this.loadExcelReportsButton.Click += new System.EventHandler(this.LoadExcelReportsButton_Click);
            // 
            // LoadDataFromMongoButton
            // 
            this.loadDataFromMongoButton.Location = new System.Drawing.Point(261, 72);
            this.loadDataFromMongoButton.Name = "LoadDataFromMongoButton";
            this.loadDataFromMongoButton.Size = new System.Drawing.Size(234, 42);
            this.loadDataFromMongoButton.TabIndex = 1;
            this.loadDataFromMongoButton.Text = "Load Data from MongoDB";
            this.loadDataFromMongoButton.UseVisualStyleBackColor = true;
            this.loadDataFromMongoButton.Click += new System.EventHandler(this.LoadDataFromMongoButton_Click);
            // 
            // GenerateXmlReportsButton
            // 
            this.generateXmlReportsButton.Location = new System.Drawing.Point(261, 136);
            this.generateXmlReportsButton.Name = "GenerateXmlReportsButton";
            this.generateXmlReportsButton.Size = new System.Drawing.Size(234, 41);
            this.generateXmlReportsButton.TabIndex = 2;
            this.generateXmlReportsButton.Text = "Generate XML Reports";
            this.generateXmlReportsButton.UseVisualStyleBackColor = true;
            this.generateXmlReportsButton.Click += new System.EventHandler(this.GenerateXmlReportsButton_Click);
            // 
            // GenerateJsonReportsButton
            // 
            this.generateJsonReportsButton.Location = new System.Drawing.Point(261, 195);
            this.generateJsonReportsButton.Name = "GenerateJsonReportsButton";
            this.generateJsonReportsButton.Size = new System.Drawing.Size(234, 40);
            this.generateJsonReportsButton.TabIndex = 3;
            this.generateJsonReportsButton.Text = "Generate JSON Reports";
            this.generateJsonReportsButton.UseVisualStyleBackColor = true;
            this.generateJsonReportsButton.Click += new System.EventHandler(this.GenerateJsonReportsButton_Click);
            // 
            // LoadDataFromXmlButton
            // 
            this.loadDataFromXmlButton.Location = new System.Drawing.Point(261, 255);
            this.loadDataFromXmlButton.Name = "LoadDataFromXmlButton";
            this.loadDataFromXmlButton.Size = new System.Drawing.Size(234, 39);
            this.loadDataFromXmlButton.TabIndex = 4;
            this.loadDataFromXmlButton.Text = "Load data from XML";
            this.loadDataFromXmlButton.UseVisualStyleBackColor = true;
            this.loadDataFromXmlButton.Click += new System.EventHandler(this.LoadDataFromXmlButton_Click);
            // 
            // SQLiteButton
            // 
            this.sqliteButton.Location = new System.Drawing.Point(261, 312);
            this.sqliteButton.Name = "SQLiteButton";
            this.sqliteButton.Size = new System.Drawing.Size(234, 41);
            this.sqliteButton.TabIndex = 5;
            this.sqliteButton.Text = "Generate Reports fromSQLite and MySQL";
            this.sqliteButton.UseVisualStyleBackColor = true;
            this.sqliteButton.Click += new System.EventHandler(this.SQLiteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 475);
            this.Controls.Add(this.sqliteButton);
            this.Controls.Add(this.loadDataFromXmlButton);
            this.Controls.Add(this.generateJsonReportsButton);
            this.Controls.Add(this.generateXmlReportsButton);
            this.Controls.Add(this.loadDataFromMongoButton);
            this.Controls.Add(this.loadExcelReportsButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
