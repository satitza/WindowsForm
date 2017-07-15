namespace ExtremeInternetShop.Form_Report.ReportCafeThai
{
    partial class FormReportCafeThaiAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportCafeThaiAll));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetExtreme = new ExtremeInternetShop.DataSetExtreme();
            this.tbgameshopCafeThaiAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_game_shopCafeThaiAllTableAdapter = new ExtremeInternetShop.DataSetExtremeTableAdapters.tb_game_shopCafeThaiAllTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExtreme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopCafeThaiAllBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbgameshopCafeThaiAllBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ExtremeInternetShop.Report.ReportCafeThai.ReportCafeThaiAll.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1082, 559);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetExtreme
            // 
            this.dataSetExtreme.DataSetName = "DataSetExtreme";
            this.dataSetExtreme.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbgameshopCafeThaiAllBindingSource
            // 
            this.tbgameshopCafeThaiAllBindingSource.DataMember = "tb_game_shopCafeThaiAll";
            this.tbgameshopCafeThaiAllBindingSource.DataSource = this.dataSetExtreme;
            // 
            // tb_game_shopCafeThaiAllTableAdapter
            // 
            this.tb_game_shopCafeThaiAllTableAdapter.ClearBeforeFill = true;
            // 
            // FormReportCafeThaiAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReportCafeThaiAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ปริ๊นรายงาน";
            this.Load += new System.EventHandler(this.FormReportCafeThaiAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExtreme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopCafeThaiAllBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetExtreme dataSetExtreme;
        private System.Windows.Forms.BindingSource tbgameshopCafeThaiAllBindingSource;
        private DataSetExtremeTableAdapters.tb_game_shopCafeThaiAllTableAdapter tb_game_shopCafeThaiAllTableAdapter;
    }
}