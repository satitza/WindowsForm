namespace ExtremeInternetShop.Form_Report
{
    partial class FormShopBig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShopBig));
            this.tbgameshopBigBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetExtreme = new ExtremeInternetShop.DataSetExtreme();
            this.tbgameshopBigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_game_shopBigTableAdapter = new ExtremeInternetShop.DataSetExtremeTableAdapters.tb_game_shopBigTableAdapter();
            this.tb_game_shopBigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopBigBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExtreme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopBigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_game_shopBigBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbgameshopBigBindingSource1
            // 
            this.tbgameshopBigBindingSource1.DataMember = "tb_game_shopBig";
            this.tbgameshopBigBindingSource1.DataSource = this.dataSetExtreme;
            // 
            // dataSetExtreme
            // 
            this.dataSetExtreme.DataSetName = "DataSetExtreme";
            this.dataSetExtreme.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbgameshopBigBindingSource
            // 
            this.tbgameshopBigBindingSource.DataMember = "tb_game_shopBig";
            this.tbgameshopBigBindingSource.DataSource = this.dataSetExtreme;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbgameshopBigBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ExtremeInternetShop.Report.ReportSizeShop.ReportShopBig.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1081, 558);
            this.reportViewer1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.reportViewer1, "ปริ๊นรายงาน");
            // 
            // tb_game_shopBigTableAdapter
            // 
            this.tb_game_shopBigTableAdapter.ClearBeforeFill = true;
            // 
            // tb_game_shopBigBindingSource
            // 
            this.tb_game_shopBigBindingSource.DataMember = "tb_game_shopBig";
            this.tb_game_shopBigBindingSource.DataSource = this.dataSetExtreme;
            // 
            // FormShopBig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormShopBig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ปริ๊นรายงาน";
            this.toolTip1.SetToolTip(this, "ปริ๊นรายงาน");
            this.Load += new System.EventHandler(this.FormShopBig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopBigBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExtreme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopBigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_game_shopBigBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetExtreme dataSetExtreme;
        private System.Windows.Forms.BindingSource tbgameshopBigBindingSource;
        private DataSetExtremeTableAdapters.tb_game_shopBigTableAdapter tb_game_shopBigTableAdapter;
        private System.Windows.Forms.BindingSource tb_game_shopBigBindingSource;
        private System.Windows.Forms.BindingSource tbgameshopBigBindingSource1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}