namespace ExtremeInternetShop.Form_Report.ReportGameType
{
    partial class FormGameTypeAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameTypeAll));
            this.tbgameshopGameTypeAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetExtreme = new ExtremeInternetShop.DataSetExtreme();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_game_shopGameTypeAllTableAdapter = new ExtremeInternetShop.DataSetExtremeTableAdapters.tb_game_shopGameTypeAllTableAdapter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopGameTypeAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExtreme)).BeginInit();
            this.SuspendLayout();
            // 
            // tbgameshopGameTypeAllBindingSource
            // 
            this.tbgameshopGameTypeAllBindingSource.DataMember = "tb_game_shopGameTypeAll";
            this.tbgameshopGameTypeAllBindingSource.DataSource = this.dataSetExtreme;
            // 
            // dataSetExtreme
            // 
            this.dataSetExtreme.DataSetName = "DataSetExtreme";
            this.dataSetExtreme.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbgameshopGameTypeAllBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ExtremeInternetShop.Report.ReportGameType.ReportGameTypeAll.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1081, 556);
            this.reportViewer1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.reportViewer1, "ข้อมูลรายงาน");
            // 
            // tb_game_shopGameTypeAllTableAdapter
            // 
            this.tb_game_shopGameTypeAllTableAdapter.ClearBeforeFill = true;
            // 
            // FormGameTypeAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGameTypeAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ปริ๊นรายงาน";
            this.toolTip1.SetToolTip(this, "ปริีนรายงาน");
            this.Load += new System.EventHandler(this.FormGameTypeAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbgameshopGameTypeAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetExtreme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetExtreme dataSetExtreme;
        private System.Windows.Forms.BindingSource tbgameshopGameTypeAllBindingSource;
        private DataSetExtremeTableAdapters.tb_game_shopGameTypeAllTableAdapter tb_game_shopGameTypeAllTableAdapter;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}