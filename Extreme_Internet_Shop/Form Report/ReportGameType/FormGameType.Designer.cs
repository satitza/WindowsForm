namespace ExtremeInternetShop.Form_Report.ReportGameType
{
    partial class FormGameType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameType));
            this.tbgameshopGameTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetExtreme = new ExtremeInternetShop.DataSetExtreme();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.cbGameType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_game_shopGameTypeTableAdapter = new ExtremeInternetShop.DataSetExtremeTableAdapters.tb_game_shopGameTypeTableAdapter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopGameTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExtreme)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbgameshopGameTypeBindingSource
            // 
            this.tbgameshopGameTypeBindingSource.DataMember = "tb_game_shopGameType";
            this.tbgameshopGameTypeBindingSource.DataSource = this.dataSetExtreme;
            // 
            // dataSetExtreme
            // 
            this.dataSetExtreme.DataSetName = "DataSetExtreme";
            this.dataSetExtreme.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbgameshopGameTypeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ExtremeInternetShop.Report.ReportGameType.ReportGameType.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 38);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1081, 521);
            this.reportViewer1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.reportViewer1, "ข้อมูลรายงาน");
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnLoadReport);
            this.panel1.Controls.Add(this.cbGameType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 30);
            this.panel1.TabIndex = 1;
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadReport.Image")));
            this.btnLoadReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadReport.Location = new System.Drawing.Point(247, 2);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(118, 23);
            this.btnLoadReport.TabIndex = 2;
            this.btnLoadReport.Text = "Load Report";
            this.toolTip1.SetToolTip(this.btnLoadReport, "โหลดข้อมูลรายงาน");
            this.btnLoadReport.UseVisualStyleBackColor = true;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // cbGameType
            // 
            this.cbGameType.FormattingEnabled = true;
            this.cbGameType.Location = new System.Drawing.Point(83, 2);
            this.cbGameType.Name = "cbGameType";
            this.cbGameType.Size = new System.Drawing.Size(158, 21);
            this.cbGameType.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cbGameType, "ประเภทรายงาน");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ประเภทเกมส์";
            // 
            // tb_game_shopGameTypeTableAdapter
            // 
            this.tb_game_shopGameTypeTableAdapter.ClearBeforeFill = true;
            // 
            // FormGameType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGameType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ปริ๊นรายงาน";
            this.toolTip1.SetToolTip(this, "ปริ๊นรายงาน");
            this.Load += new System.EventHandler(this.FormGameType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopGameTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExtreme)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.ComboBox cbGameType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource tbgameshopGameTypeBindingSource;
        private DataSetExtreme dataSetExtreme;
        private DataSetExtremeTableAdapters.tb_game_shopGameTypeTableAdapter tb_game_shopGameTypeTableAdapter;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}