using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace ExtremeInternetShop.Form_Report.ReportCafeThai
{
    public partial class FormReportCafeThai : Form
    {
        ConnectDatabase db = new ConnectDatabase();
        NewMessageBox newMessagebox = new NewMessageBox();

        public FormReportCafeThai()
        {
            InitializeComponent();
        }

        private void FormReportCafeThai_Load(object sender, EventArgs e)
        {
            SetItemComboboxAutoUpdateCafeThai();
            this.reportViewer1.RefreshReport();
        }
        public void SetItemComboboxAutoUpdateCafeThai()
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", "tb_cafethai");
                    using (var myReader = cmd.ExecuteReader())
                    {
                        cbCafeThai.Items.Clear();
                        while (myReader.Read())
                        {
                            cbCafeThai.Items.Add(myReader["cafe_thai"]);
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.tb_game_shopCafeThaiTableAdapter.FillCafeThai(this.dataSetExtreme.tb_game_shopCafeThai, Convert.ToInt32(cbCafeThai.SelectedIndex + 1));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception) { newMessagebox.error("ไม่สามารถโหลดรายงานใด้"); }
        }
    }
}
