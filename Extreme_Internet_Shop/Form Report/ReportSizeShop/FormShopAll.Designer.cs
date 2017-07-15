namespace ExtremeInternetShop.Form_Report
{
    partial class FormShopAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShopAll));
            this.tbgameshopShopAllBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetExtreme = new ExtremeInternetShop.DataSetExtreme();
            this.tbgameshopShopAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_game_shopShopAllTableAdapter = new ExtremeInternetShop.DataSetExtremeTableAdapters.tb_game_shopShopAllTableAdapter();
            this.tb_game_shopShopAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopShopAllBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExtreme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopShopAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_game_shopShopAllBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbgameshopShopAllBindingSource1
            // 
            this.tbgameshopShopAllBindingSource1.DataMember = "tb_game_shopShopAll";
            this.tbgameshopShopAllBindingSource1.DataSource = this.dataSetExtreme;
            // 
            // dataSetExtreme
            // 
            this.dataSetExtreme.DataSetName = "DataSetExtreme";
            this.dataSetExtreme.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbgameshopShopAllBindingSource
            // 
            this.tbgameshopShopAllBindingSource.DataMember = "tb_game_shopShopAll";
            this.tbgameshopShopAllBindingSource.DataSource = this.dataSetExtreme;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbgameshopShopAllBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ExtremeInternetShop.Report.ReportSizeShop.ReportShopAll.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1082, 557);
            this.reportViewer1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.reportViewer1, "ข้อมูลรายงานห");
            // 
            // tb_game_shopShopAllTableAdapter
            // 
            this.tb_game_shopShopAllTableAdapter.ClearBeforeFill = true;
            // 
            // tb_game_shopShopAllBindingSource
            // 
            this.tb_game_shopShopAllBindingSource.DataMember = "tb_game_shopShopAll";
            this.tb_game_shopShopAllBindingSource.DataSource = this.dataSetExtreme;
            // 
            // FormShopAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormShopAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ปริ๊นรายงาน";
            this.toolTip1.SetToolTip(this, "ปริ๊นรายงาน");
            this.Load += new System.EventHandler(this.FormShopAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopShopAllBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExtreme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopShopAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_game_shopShopAllBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetExtreme dataSetExtreme;
        private System.Windows.Forms.BindingSource tbgameshopShopAllBindingSource;
        private DataSetExtremeTableAdapters.tb_game_shopShopAllTableAdapter tb_game_shopShopAllTableAdapter;
        private System.Windows.Forms.BindingSource tb_game_shopShopAllBindingSource;
        private System.Windows.Forms.BindingSource tbgameshopShopAllBindingSource1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}