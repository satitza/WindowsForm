//////////////////////////////////////////////////////////////////////////////////////
//                           Develop By : Satit Prontepanon                         //
//                           Date : 22-6-2015                                       //
//                           Working in : Electronics Extreme                       //
//////////////////////////////////////////////////////////////////////////////////////
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

namespace ExtremeInternetShop
{  
    public partial class AllAppointments : Form
    {      
        ConnectDatabase db = new ConnectDatabase();
        NewMessageBox newMessagebox = new NewMessageBox();
        List<DateTime> ls = new List<DateTime>();

        public AllAppointments()
        {
            InitializeComponent();
        }

        private void AllAppointments_Load(object sender, EventArgs e)
        {
            try 
            {
                MountCalederBold();
                BindData();
            }
            catch (Exception ex) { newMessagebox.error("Exception Error "+ex.ToString()); }
        }

        public void BindData () 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                SelectDateComment();
                SqlCommand cmd = new SqlCommand("SelectAllAppointment", db.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var myReader = cmd.ExecuteReader())
                {
                    int i = 0;
                    dataGridViewAll.Rows.Clear();
                    while (myReader.Read())
                    {
                        dataGridViewAll.Rows.Add();
                        dataGridViewAll.Rows[i].Cells[0].Value = myReader["id"];
                        dataGridViewAll.Rows[i].Cells[1].Value = myReader["shopStatus"];
                        dataGridViewAll.Rows[i].Cells[2].Value = Convert.ToDateTime(myReader["date_appointment"]).ToString("dd-MM-yyyy");
                        dataGridViewAll.Rows[i].Cells[3].Value = myReader["shop_id"];
                        dataGridViewAll.Rows[i].Cells[4].Value = myReader["shop_name"];
                        dataGridViewAll.Rows[i].Cells[5].Value = myReader["shop_master"];
                        dataGridViewAll.Rows[i].Cells[6].Value = myReader["shop_phone"];
                        dataGridViewAll.Rows[i].Cells[7].Value = myReader["num_home"];
                        dataGridViewAll.Rows[i].Cells[8].Value = myReader["zone"];
                        dataGridViewAll.Rows[i].Cells[9].Value = myReader["street"];
                        dataGridViewAll.Rows[i].Cells[10].Value = myReader["district"];
                        dataGridViewAll.Rows[i].Cells[11].Value = myReader["area"];
                        dataGridViewAll.Rows[i].Cells[12].Value = myReader["county"];
                        dataGridViewAll.Rows[i].Cells[13].Value = myReader["comment"];
                        i++;
                    }
                    myReader.Close();
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        public void SelectDateFromDate(DateTime SelectDate) 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                SelectDateComment();
                using (SqlCommand cmd = new SqlCommand("SelectDayToGo", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Today", SelectDate);
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridViewAll.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridViewAll.Rows.Add();
                            dataGridViewAll.Rows[i].Cells[0].Value = myReader["id"];
                            dataGridViewAll.Rows[i].Cells[1].Value = myReader["shopStatus"];
                            dataGridViewAll.Rows[i].Cells[2].Value = Convert.ToDateTime(myReader["date_appointment"]).ToString("dd-MM-yyyy");
                            dataGridViewAll.Rows[i].Cells[3].Value = myReader["shop_id"];
                            dataGridViewAll.Rows[i].Cells[4].Value = myReader["shop_name"];
                            dataGridViewAll.Rows[i].Cells[5].Value = myReader["shop_master"];
                            dataGridViewAll.Rows[i].Cells[6].Value = myReader["shop_phone"];
                            dataGridViewAll.Rows[i].Cells[7].Value = myReader["num_home"];
                            dataGridViewAll.Rows[i].Cells[8].Value = myReader["zone"];
                            dataGridViewAll.Rows[i].Cells[9].Value = myReader["street"];
                            dataGridViewAll.Rows[i].Cells[10].Value = myReader["district"];
                            dataGridViewAll.Rows[i].Cells[11].Value = myReader["area"];
                            dataGridViewAll.Rows[i].Cells[12].Value = myReader["county"];
                            dataGridViewAll.Rows[i].Cells[13].Value = myReader["comment"];
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

        public void MountCalederBold()
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
                        monthCalendarAll.BoldedDates = ls.ToArray();
                    }
                    myReader.Close();
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void monthCalendarAll_DateChanged(object sender, DateRangeEventArgs e)
        {
            SelectDateFromDate(Convert.ToDateTime(monthCalendarAll.SelectionStart.ToString("yyyy-MM-dd")));
            SelectDateComment();
        }

        public void SelectDateComment()
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                string sql = "SELECT date_comment FROM tb_comment_appointments WHERE date_appointments = '" + monthCalendarAll.SelectionStart.ToString("yyyy-MM-dd") + "'";
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

        private void dataGridViewAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if (e.RowIndex != -1)
                {
                    txtID.Text = dataGridViewAll["ID", e.RowIndex].Value.ToString();
                    dateTimePickerAll.Value = Convert.ToDateTime(dataGridViewAll["วันที่นัด", e.RowIndex].Value.ToString());
                    txtShopID.Text = dataGridViewAll["ShopID", e.RowIndex].Value.ToString();
                    txtShopName.Text = dataGridViewAll["ชื่อร้าน", e.RowIndex].Value.ToString();
                    txtShopMaster.Text = dataGridViewAll["ผู้ติดต่อ", e.RowIndex].Value.ToString();
                    txtShopPhone.Text = dataGridViewAll["เบอร์โทรศัพท์", e.RowIndex].Value.ToString();
                    txtNumHome.Text = dataGridViewAll["เลขที่", e.RowIndex].Value.ToString();
                    txtZone.Text = dataGridViewAll["ย่าน", e.RowIndex].Value.ToString();
                    txtStreet.Text = dataGridViewAll["ถนน", e.RowIndex].Value.ToString();
                    txtDistrict.Text = dataGridViewAll["แขวง", e.RowIndex].Value.ToString();
                    txtArea.Text = dataGridViewAll["เขต", e.RowIndex].Value.ToString();
                    txtCounty.Text = dataGridViewAll["จังหวัด", e.RowIndex].Value.ToString();
                    txtShopComment.Text = dataGridViewAll["หมายเหตุ", e.RowIndex].Value.ToString();
                }
            }
            catch (Exception) { newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง"); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtShopID.Text = "";
            txtShopName.Text = "";
            txtShopMaster.Text = "";
            txtShopPhone.Text = "";
            txtNumHome.Text = "";
            txtZone.Text = "";
            txtStreet.Text = "";
            txtDistrict.Text = "";
            txtArea.Text = "";
            txtCounty.Text = "";
            txtShopComment.Text = "";
            dateTimePickerAll.Value = DateTime.Now;
            BindData();
        }

        private void btnEditDate_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (string.IsNullOrEmpty(txtShopID.Text)) { newMessagebox.warring("คุณยังไม่ใด้เลือกร้านเกมส์ที่นัดหมาย"); }
                else
                {
                    if (db.ChackDateAppointment(Convert.ToInt32(txtID.Text)) == false)
                    {
                        using (SqlCommand cmd = new SqlCommand("UpdateDateAppointment", db.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
                            cmd.Parameters.AddWithValue("@ShopID", txtShopID.Text);
                            cmd.Parameters.AddWithValue("@DateAppointment", Convert.ToDateTime(dateTimePickerAll.Value.Date.ToString("dd-MM-yyyy")));
                            cmd.ExecuteNonQuery();
                            newMessagebox.info("ทำการแก้ใขวันนัดหมายกับทางร้าน " + txtShopName.Text + " แล้ว   แก้ใขเป็นวันที่ " + dateTimePickerAll.Value.Date.ToString("dd-MM-yyyy"));
                            BindData();
                            MountCalederBold();
                        }
                    }
                    else
                    {
                        newMessagebox.warring("ไม่สามารถแก้ใขวันที่  เนื่องจากคุณยังไม่ใด้กำหนดวันนัดหมาย");
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnDeleteDate_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try 
            {
                if (string.IsNullOrEmpty(txtShopID.Text)) { newMessagebox.warring("คุณยังไม่ใด้เลือกร้านเกมส์ที่นัดหมาย"); }
                else 
                {
                    SqlCommand cmd = new SqlCommand("DeleteDateAppointment", db.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ShopID", txtShopID.Text);
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("ลบวันที่นัดหมายเรียบร้อยแล้ว");
                    BindData();
                    MountCalederBold();
                }             
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                    string sql = "INSERT INTO  tb_comment_appointments VALUES ('" + monthCalendarAll.SelectionStart.ToString("yyyy-MM-dd") + "', '" + txtDateComment.Text + "')";
                    db.SQLStatment(sql);
                    newMessagebox.info("แก้ใขข้อมูลเรียบร้อยแล้ว");
                    SelectDateComment();
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
                    sql += " WHERE date_appointments = '" + monthCalendarAll.SelectionStart.ToString("yyyy-MM-dd") + "'";
                    db.SQLStatment(sql);
                    newMessagebox.info("แก้ใขข้อมูลเรียบร้อยแล้ว");
                    SelectDateComment();
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (string.IsNullOrEmpty(txtDateComment.Text))
                {
                    newMessagebox.warring("ไม่มีหมายเหตุวันที่คุณเลือก");
                }
                else
                {
                    string sql = "DELETE FROM  tb_comment_appointments WHERE date_appointments = '" + monthCalendarAll.SelectionStart.ToString("yyyy-MM-dd") + "'";
                    db.SQLStatment(sql);
                    newMessagebox.info("ลบหมายเหตุเรียบร้อยแล้ว");
                    SelectDateComment();
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }
    }
}
