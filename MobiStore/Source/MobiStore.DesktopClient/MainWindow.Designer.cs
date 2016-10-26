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
        private Button loadDataFromMongoButton;
        private Button generateJsonReportsButton;
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
            this.loadDataFromMongoButton = new System.Windows.Forms.Button();
            this.generateJsonReportsButton = new System.Windows.Forms.Button();
            this.sqliteButton = new System.Windows.Forms.Button();
            this.pdfReportButton = new System.Windows.Forms.Button();
            this.loadExcelReportsButton = new System.Windows.Forms.Button();
            this.loadDataFromXmlButton = new System.Windows.Forms.Button();
            this.generateXmlReportsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadDataFromMongoButton
            // 
            this.loadDataFromMongoButton.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.loadDataFromMongoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadDataFromMongoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadDataFromMongoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadDataFromMongoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadDataFromMongoButton.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.loadDataFromMongoButton.Location = new System.Drawing.Point(418, 211);
            this.loadDataFromMongoButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadDataFromMongoButton.Name = "loadDataFromMongoButton";
            this.loadDataFromMongoButton.Size = new System.Drawing.Size(312, 52);
            this.loadDataFromMongoButton.TabIndex = 1;
            this.loadDataFromMongoButton.Text = "Load data from MongoDB";
            this.loadDataFromMongoButton.UseVisualStyleBackColor = false;
            this.loadDataFromMongoButton.Click += new System.EventHandler(this.LoadDataFromMongoButton_Click);
            // 
            // generateJsonReportsButton
            // 
            this.generateJsonReportsButton.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.generateJsonReportsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.generateJsonReportsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateJsonReportsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateJsonReportsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateJsonReportsButton.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.generateJsonReportsButton.Location = new System.Drawing.Point(418, 302);
            this.generateJsonReportsButton.Margin = new System.Windows.Forms.Padding(4);
            this.generateJsonReportsButton.Name = "generateJsonReportsButton";
            this.generateJsonReportsButton.Size = new System.Drawing.Size(312, 49);
            this.generateJsonReportsButton.TabIndex = 3;
            this.generateJsonReportsButton.Text = "Generate JSON Reports";
            this.generateJsonReportsButton.UseVisualStyleBackColor = false;
            this.generateJsonReportsButton.Click += new System.EventHandler(this.GenerateJsonReportsButton_Click);
            // 
            // sqliteButton
            // 
            this.sqliteButton.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.sqliteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sqliteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sqliteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sqliteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqliteButton.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.sqliteButton.Location = new System.Drawing.Point(418, 359);
            this.sqliteButton.Margin = new System.Windows.Forms.Padding(4);
            this.sqliteButton.Name = "sqliteButton";
            this.sqliteButton.Size = new System.Drawing.Size(312, 50);
            this.sqliteButton.TabIndex = 5;
            this.sqliteButton.Text = "Generate Excel Reports";
            this.sqliteButton.UseVisualStyleBackColor = false;
            this.sqliteButton.Click += new System.EventHandler(this.SQLiteButton_Click);
            // 
            // pdfReportButton
            // 
            this.pdfReportButton.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.pdfReportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pdfReportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pdfReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pdfReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pdfReportButton.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.pdfReportButton.Location = new System.Drawing.Point(418, 417);
            this.pdfReportButton.Margin = new System.Windows.Forms.Padding(4);
            this.pdfReportButton.Name = "pdfReportButton";
            this.pdfReportButton.Size = new System.Drawing.Size(312, 49);
            this.pdfReportButton.TabIndex = 6;
            this.pdfReportButton.Text = "Generate PDF Report";
            this.pdfReportButton.UseVisualStyleBackColor = false;
            this.pdfReportButton.Click += new System.EventHandler(this.PdfReportButton_Click);
            // 
            // loadExcelReportsButton
            // 
            this.loadExcelReportsButton.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.loadExcelReportsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadExcelReportsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadExcelReportsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadExcelReportsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadExcelReportsButton.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.loadExcelReportsButton.Location = new System.Drawing.Point(418, 57);
            this.loadExcelReportsButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadExcelReportsButton.Name = "loadExcelReportsButton";
            this.loadExcelReportsButton.Size = new System.Drawing.Size(312, 50);
            this.loadExcelReportsButton.TabIndex = 0;
            this.loadExcelReportsButton.Text = "Load Excel Reports";
            this.loadExcelReportsButton.UseVisualStyleBackColor = false;
            this.loadExcelReportsButton.Click += new System.EventHandler(this.LoadExcelReportsButton_Click);
            // 
            // loadDataFromXmlButton
            // 
            this.loadDataFromXmlButton.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.loadDataFromXmlButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadDataFromXmlButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadDataFromXmlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadDataFromXmlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadDataFromXmlButton.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.loadDataFromXmlButton.Location = new System.Drawing.Point(418, 155);
            this.loadDataFromXmlButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadDataFromXmlButton.Name = "loadDataFromXmlButton";
            this.loadDataFromXmlButton.Size = new System.Drawing.Size(312, 48);
            this.loadDataFromXmlButton.TabIndex = 4;
            this.loadDataFromXmlButton.Text = "Load data from XML";
            this.loadDataFromXmlButton.UseVisualStyleBackColor = false;
            this.loadDataFromXmlButton.Click += new System.EventHandler(this.LoadDataFromXmlButton_Click);
            // 
            // generateXmlReportsButton
            // 
            this.generateXmlReportsButton.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.generateXmlReportsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.generateXmlReportsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateXmlReportsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateXmlReportsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateXmlReportsButton.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.generateXmlReportsButton.Location = new System.Drawing.Point(418, 474);
            this.generateXmlReportsButton.Margin = new System.Windows.Forms.Padding(4);
            this.generateXmlReportsButton.Name = "generateXmlReportsButton";
            this.generateXmlReportsButton.Size = new System.Drawing.Size(312, 50);
            this.generateXmlReportsButton.TabIndex = 2;
            this.generateXmlReportsButton.Text = "Generate XML Reports";
            this.generateXmlReportsButton.UseVisualStyleBackColor = false;
            this.generateXmlReportsButton.Click += new System.EventHandler(this.GenerateXmlReportsButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::MobiStore.DesktopClient.Properties.Resources.orig_81790;
            this.ClientSize = new System.Drawing.Size(1068, 585);
            this.Controls.Add(this.pdfReportButton);
            this.Controls.Add(this.sqliteButton);
            this.Controls.Add(this.loadDataFromXmlButton);
            this.Controls.Add(this.generateJsonReportsButton);
            this.Controls.Add(this.generateXmlReportsButton);
            this.Controls.Add(this.loadDataFromMongoButton);
            this.Controls.Add(this.loadExcelReportsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "MobiStore";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button loadExcelReportsButton;
        private Button loadDataFromXmlButton;
        private Button generateXmlReportsButton;
    }
}
