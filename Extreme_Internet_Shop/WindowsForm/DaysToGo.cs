///////////////////////////////////////////////////////////////////////////
//                Developer By [Satit Prontepanon]                       //
//                Date Write : 19-06-2015                                //
//                Working in : Electronics Extreme                       //   
///////////////////////////////////////////////////////////////////////////                       
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
using System.Globalization;

namespace ExtremeInternetShop
{
    public partial class DaysToGo : Form
    {
        ConnectDatabase db = new ConnectDatabase();
        NewMessageBox newMessagebox = new NewMessageBox();
        DateTime today = DateTime.Now;
        List<DateTime> ls = new List<DateTime>();

        public DaysToGo()
        {
            InitializeComponent();
        }

        private void DaysToGo_Load(object sender, EventArgs e)
        {
            try 
            {
                MountCalederBold();                            
                SetItemComboboxShopStatus();
                BindData();
            }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
        }

        public void SetItemComboboxShopStatus() 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", "tb_shop_status");
                    using (var myReader = cmd.ExecuteReader())
                    {
                        cbShopStatus.Items.Clear();
                        while (myReader.Read())
                        {
                            cbShopStatus.Items.Add(myReader["shopStatus"]);
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

       public void SelectDateComment() 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try 
            {
                string sql = "SELECT date_comment FROM tb_comment_appointments WHERE date_appointments = '"+monthCalendarDayToGo.SelectionStart.ToString("yyyy-MM-dd")+"'";
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                using (var myReder = cmd.ExecuteReader())
                {
                    if (myReder.Read())
                    {
                        txtDateComment.Text = myReder["date_comment"].ToString();
                    }
                    else { txtDateComment.Text = ""; }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
        }

        /// <summary>
        /// Bind Data
        /// </summary>
        public void BindData() 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try 
            {
                SelectDateComment(); 
                using (SqlCommand cmd = new SqlCommand("SelectDayToGo", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Today", today);
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridViewDayToGo.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridViewDayToGo.Rows.Add();
                            dataGridViewDayToGo.Rows[i].Cells[0].Value = myReader["id"];
                            dataGridViewDayToGo.Rows[i].Cells[1].Value = myReader["shopStatus"];
                            dataGridViewDayToGo.Rows[i].Cells[2].Value = Convert.ToDateTime(myReader["date_appointment"]).ToString("dd-MM-yyyy");
                            dataGridViewDayToGo.Rows[i].Cells[3].Value = myReader["shop_id"];
                            dataGridViewDayToGo.Rows[i].Cells[4].Value = myReader["shop_name"];
                            dataGridViewDayToGo.Rows[i].Cells[5].Value = myReader["shop_master"];
                            dataGridViewDayToGo.Rows[i].Cells[6].Value = myReader["shop_phone"];
                            dataGridViewDayToGo.Rows[i].Cells[7].Value = myReader["num_home"];
                            dataGridViewDayToGo.Rows[i].Cells[8].Value = myReader["zone"];
                            dataGridViewDayToGo.Rows[i].Cells[9].Value = myReader["street"];
                            dataGridViewDayToGo.Rows[i].Cells[10].Value = myReader["district"];
                            dataGridViewDayToGo.Rows[i].Cells[11].Value = myReader["area"];
                            dataGridViewDayToGo.Rows[i].Cells[12].Value = myReader["county"];
                            dataGridViewDayToGo.Rows[i].Cells[13].Value = myReader["comment"];
                            i++;
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void monthCalendarDayToGo_DateChanged(object sender, DateRangeEventArgs e)
        {
            SelectDateComment();
            db.conn.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDateComment.Text = "";
            BindData();
        }

        public int GetIDForCombobox(string tableName, string Field, string Value) 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                string sql = "SELECT id FROM " + tableName + " WHERE " + Field + " = '" + Value + "'";
                using (SqlCommand cmd = new SqlCommand(sql, db.conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception) { return 1; }
        }

        private void dataGridViewDayToGo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if (e.RowIndex != -1)
                {
                    txtID.Text = dataGridViewDayToGo["ID", e.RowIndex].Value.ToString();
                    txtShopID.Text = dataGridViewDayToGo["ShopID", e.RowIndex].Value.ToString();
                    txtShopName.Text = dataGridViewDayToGo["ชื่อร้าน", e.RowIndex].Value.ToString();
                    txtShopMaster.Text = dataGridViewDayToGo["ผู้ติดต่อ", e.RowIndex].Value.ToString();
                    txtShopPhone.Text = dataGridViewDayToGo["เบอร์โทรศัพท์", e.RowIndex].Value.ToString();
                    txtNumHome.Text = dataGridViewDayToGo["เลขที่", e.RowIndex].Value.ToString();
                    txtZone.Text = dataGridViewDayToGo["ย่าน", e.RowIndex].Value.ToString();
                    txtStreet.Text = dataGridViewDayToGo["ถนน", e.RowIndex].Value.ToString();
                    txtDistrict.Text = dataGridViewDayToGo["แขวง", e.RowIndex].Value.ToString();
                    txtArea.Text = dataGridViewDayToGo["เขต", e.RowIndex].Value.ToString();
                    txtCounty.Text = dataGridViewDayToGo["จังหวัด", e.RowIndex].Value.ToString();
                    txtComment.Text = dataGridViewDayToGo["หมายเหตุ", e.RowIndex].Value.ToString();
                    cbShopStatus.SelectedIndex = GetIDForCombobox("tb_shop_status", "shopStatus", dataGridViewDayToGo["สถานะร้าน", e.RowIndex].Value.ToString())-1;
                }
            }
            catch (Exception) { newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง"); }
        }

        public void MountCalederBold () 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try 
            {
                string sql = "SELECT date_appointment FROM tb_appointment";
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                using (var myReader = cmd.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        ls.Add(Convert.ToDateTime(myReader["date_appointment"]));
                        monthCalendarDayToGo.BoldedDates = ls.ToArray();
                    }
                    myReader.Close();
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try 
            {
                if (string.IsNullOrEmpty(txtDateComment.Text))
                {
                    newMessagebox.warring("ไม่สามารถบันทึกหมายเหตุเป็นค่าว่างใด้");
                }
                else 
                {
                    string sql = "UPDATE tb_comment_appointments SET date_comment = '" + txtDateComment.Text + "'";
                    sql += " WHERE date_appointments = '" + monthCalendarDayToGo.SelectionStart.ToString("yyyy-MM-dd") + "'";
                    db.SQLStatment(sql);
                    newMessagebox.info("แก้ใขข้อมูลเรียบร้อยแล้ว");
                    BindData();
                }             
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnEditShopStatus_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try 
            {
                if (string.IsNullOrEmpty (txtShopID.Text))
                {
                    newMessagebox.warring("คุณยังไม่ใด้เลือกร้านเกมส์ที่จะแก้ใขสถานะ");
                }
                else 
                {
                    SqlCommand cmd = new SqlCommand("UpdateShopStatus", db.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ShopID", txtShopID.Text);
                    cmd.Parameters.AddWithValue("ShopStatus", Convert.ToInt32(cbShopStatus.SelectedIndex+1));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("แก้ใขสถานะร้านเกมส์เรียบร้อยแล้ว");
                    BindData();
                }              
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }
    }
}
