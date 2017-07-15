namespace ExtremeInternetShop.Form_Report.ReportAirpay
{
    partial class FormReportAirpay
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportAirpay));
            this.tbgameshopAirpayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetExtreme = new ExtremeInternetShop.DataSetExtreme();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.cbAirpay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_game_shopAirpayTableAdapter = new ExtremeInternetShop.DataSetExtremeTableAdapters.tb_game_shopAirpayTableAdapter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopAirpayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExtreme)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbgameshopAirpayBindingSource
            // 
            this.tbgameshopAirpayBindingSource.DataMember = "tb_game_shopAirpay";
            this.tbgameshopAirpayBindingSource.DataSource = this.dataSetExtreme;
            // 
            // dataSetExtreme
            // 
            this.dataSetExtreme.DataSetName = "DataSetExtreme";
            this.dataSetExtreme.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbgameshopAirpayBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ExtremeInternetShop.Report.ReportAirpay.ReportAirpay.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 41);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1078, 516);
            this.reportViewer1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.reportViewer1, "ข้อมูลรายงาน");
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnLoadReport);
            this.panel1.Controls.Add(this.cbAirpay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 32);
            this.panel1.TabIndex = 1;
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadReport.Image")));
            this.btnLoadReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadReport.Location = new System.Drawing.Point(195, 3);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(112, 23);
            this.btnLoadReport.TabIndex = 2;
            this.btnLoadReport.Text = "Load Report";
            this.toolTip1.SetToolTip(this.btnLoadReport, "โหลดรายงาน");
            this.btnLoadReport.UseVisualStyleBackColor = true;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // cbAirpay
            // 
            this.cbAirpay.FormattingEnabled = true;
            this.cbAirpay.Location = new System.Drawing.Point(49, 4);
            this.cbAirpay.Name = "cbAirpay";
            this.cbAirpay.Size = new System.Drawing.Size(140, 21);
            this.cbAirpay.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cbAirpay, "เลือกประเภทรายงาน");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Airpay";
            // 
            // tb_game_shopAirpayTableAdapter
            // 
            this.tb_game_shopAirpayTableAdapter.ClearBeforeFill = true;
            // 
            // FormReportAirpay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReportAirpay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ปริ๊นรายงาน";
            this.toolTip1.SetToolTip(this, "ปริีนรายงาน");
            this.Load += new System.EventHandler(this.FormReportAirpay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopAirpayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExtreme)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.ComboBox cbAirpay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource tbgameshopAirpayBindingSource;
        private DataSetExtreme dataSetExtreme;
        private DataSetExtremeTableAdapters.tb_game_shopAirpayTableAdapter tb_game_shopAirpayTableAdapter;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}