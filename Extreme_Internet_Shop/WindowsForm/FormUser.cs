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
    public partial class FormUser : Form
    {
        NewMessageBox newMessagebox = new NewMessageBox();
        ConnectDatabase db = new ConnectDatabase();
        public FormUser()
        {
            InitializeComponent();
        }

        private void Form_User_Load(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {                
                txtID.Text = db.auto_id("tb_user_login", "id").ToString();
                using (SqlCommand cmd = new SqlCommand("SelectUserLogin", db.conn)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(var myReader = cmd.ExecuteReader())
                    {
                        dataGridView1.Rows.Clear();
                        int i = 0;
                        while (myReader.Read())
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = myReader["id"];
                            dataGridView1.Rows[i].Cells[1].Value = myReader["name"];
                            dataGridView1.Rows[i].Cells[2].Value = myReader["lastname"];
                            dataGridView1.Rows[i].Cells[3].Value = myReader["phone"];
                            dataGridView1.Rows[i].Cells[4].Value = myReader["age"];
                            dataGridView1.Rows[i].Cells[5].Value = myReader["e_mail"];
                            dataGridView1.Rows[i].Cells[6].Value = myReader["address"];
                            dataGridView1.Rows[i].Cells[7].Value = myReader["username"];
                            dataGridView1.Rows[i].Cells[8].Value = myReader["password"];
                            dataGridView1.Rows[i].Cells[9].Value = myReader["comment"];
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtAge.Text = "";
            txtMail.Text = "";
            txtAddress.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComment.Text = "";
            Form_User_Load(null, null);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(db.conn.State == ConnectionState.Closed){db.conn.Open();}
            else if(txtPhone.Text == "")
            {
                newMessagebox.warring("กรุณาใส่ เบอร์โทรศัพท์");
                txtPhone.Focus();
            }
            else if(txtUsername.Text == "")
            {
                newMessagebox.warring("กรุณาใส่ Username");
                txtUsername.Focus();
            }
            else if (txtPassword.Text == "")
            {
                newMessagebox.warring("กรุณาใส่ Password");
                txtPassword.Focus();
            }
            else 
            {
                try
                {
                    using(SqlCommand cmd = new SqlCommand("InsertUserLogin",db.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@lastname", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text));
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@mail", txtMail.Text);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@comment", txtComment.Text);
                        cmd.ExecuteNonQuery();
                        newMessagebox.info("บันทึกข้อมูลเรียบร้อยแล้ว");
                        Form_User_Load(null, null);
                    }                 
                }
                catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
                catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
                finally { db.conn.Close(); }
            }           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if(e.RowIndex != -1)
                {
                    txtID.Text = dataGridView1["ID", e.RowIndex].Value.ToString();
                    txtName.Text = dataGridView1["ชื่อ", e.RowIndex].Value.ToString();
                    txtLastName.Text = dataGridView1["นามสกุล", e.RowIndex].Value.ToString();
                    txtPhone.Text = dataGridView1["เบอร์โทรศัพท์", e.RowIndex].Value.ToString();
                    txtAge.Text = dataGridView1["อายุ", e.RowIndex].Value.ToString();
                    txtAddress.Text = dataGridView1["ที่อยู่", e.RowIndex].Value.ToString();
                    txtMail.Text = dataGridView1["Mail", e.RowIndex].Value.ToString();
                    txtUsername.Text = dataGridView1["Username", e.RowIndex].Value.ToString();
                    txtPassword.Text = dataGridView1["Password", e.RowIndex].Value.ToString();
                    txtComment.Text = dataGridView1["หมายเหตุ", e.RowIndex].Value.ToString();
                }
            }
            catch(Exception){newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง");}
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if(db.conn.State == ConnectionState.Closed){db.conn.Open();}
            try
            {
                using(SqlCommand cmd = new SqlCommand("DeleteUserLogin", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("ลบข้อมูลเรียบร้อยแล้ว");
                    Form_User_Load(null, null);
                }          
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error" + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if(db.conn.State == ConnectionState.Closed){db.conn.Open();}
            try
            {
                using(SqlCommand cmd = new SqlCommand("UpdateUserLogin", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@lastname", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text));
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@mail", txtMail.Text);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@comment", txtComment.Text);
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("แก้ใขข้อมูลเรียบร้อยแล้ว");
                    Form_User_Load(null, null);
                }      
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error" + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            if(db.conn.State == ConnectionState.Closed){db.conn.Open();}
            try
            {           
                using(SqlCommand cmd = new SqlCommand("SearchUserLogin", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@phone", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@username", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@comment", txtSearch.Text);
                    using(var myReader = cmd.ExecuteReader())
                    {
                        dataGridView1.Rows.Clear();
                        int i = 0;
                        while (myReader.Read())
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = myReader["id"];
                            dataGridView1.Rows[i].Cells[1].Value = myReader["name"];
                            dataGridView1.Rows[i].Cells[2].Value = myReader["lastname"];
                            dataGridView1.Rows[i].Cells[3].Value = myReader["phone"];
                            dataGridView1.Rows[i].Cells[4].Value = myReader["age"];
                            dataGridView1.Rows[i].Cells[5].Value = myReader["address"];
                            dataGridView1.Rows[i].Cells[6].Value = myReader["e_mail"];
                            dataGridView1.Rows[i].Cells[7].Value = myReader["username"];
                            dataGridView1.Rows[i].Cells[8].Value = myReader["password"];
                            dataGridView1.Rows[i].Cells[9].Value = myReader["comment"];
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
    }
}
