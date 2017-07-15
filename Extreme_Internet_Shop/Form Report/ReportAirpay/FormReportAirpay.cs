using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace ExtremeInternetShop.Form_Report.ReportAirpay
{
    public partial class FormReportAirpay : Form
    {
        ConnectDatabase db = new ConnectDatabase();
        NewMessageBox newMessagebox = new NewMessageBox();

        public FormReportAirpay()
        {
            InitializeComponent();
        }

        private void FormReportAirpay_Load(object sender, EventArgs e)
        {
            SetItemComboboxAirpay();
            this.reportViewer1.RefreshReport();
        }

        public void SetItemComboboxAirpay()
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", "tb_airpay");
                    using (var myReader = cmd.ExecuteReader())
                    {
                        cbAirpay.Items.Clear();
                        while (myReader.Read())
                        {
                            cbAirpay.Items.Add(myReader["airpay"]);
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
                this.tb_game_shopAirpayTableAdapter.FillAirpay(this.dataSetExtreme.tb_game_shopAirpay, Convert.ToInt32(cbAirpay.SelectedIndex + 1));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception) { newMessagebox.error("ไม่สามารถโหลดรายงานใด้"); }
        }
    }
}
