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

namespace ExtremeInternetShop.Form_Report.ReportGameType
{
    public partial class FormGameType : Form
    {
        ConnectDatabase db = new ConnectDatabase();
        NewMessageBox newMessagebox = new NewMessageBox();

        public FormGameType()
        {
            InitializeComponent();
        }

        private void FormGameType_Load(object sender, EventArgs e)
        {
            SetItemComboboxGameType();
            this.reportViewer1.RefreshReport();
        }

        public void SetItemComboboxGameType()
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", "tb_game_type");
                    using (var myReader = cmd.ExecuteReader())
                    {
                        cbGameType.Items.Clear();
                        while (myReader.Read())
                        {
                            cbGameType.Items.Add(myReader["game_type"]);
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
                this.tb_game_shopGameTypeTableAdapter.FillGameType(this.dataSetExtreme.tb_game_shopGameType, Convert.ToInt32(cbGameType.SelectedIndex + 1));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception) { newMessagebox.error("ไม่สามารถโหลดรายงานใด้"); }
        }
    }
}
