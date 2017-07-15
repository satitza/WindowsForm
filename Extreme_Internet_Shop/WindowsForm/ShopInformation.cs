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
using System.IO;

namespace ExtremeInternetShop
{
    public partial class ShopInformation : Form
    {
        ConnectDatabase db = new ConnectDatabase();
        NewMessageBox newMessagebox = new NewMessageBox();
        
        public string FileSelected { get; set; }
        public string PathSelected { get; set; }
        public int ShopStatusID { get; set; }
        public ShopInformation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShopInformation_Load(object sender, EventArgs e)
        {
            try
            {
                CheckFolder();
                BindData();
                SetItemComboboxMemberStatus();
                SetItemComboboxShopSupport();
                SetItemComboboxPrinter();
                SetItemComboboxGameType();
                SetItemComboboxAirpay();
                SetItemComboboxAutoUpdateCafeThai();
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
        }

        public void BindData ()
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SelectGameShop", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridView1.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = myReader["id"];
                            dataGridView1.Rows[i].Cells[1].Value = myReader["shop_id"];
                            dataGridView1.Rows[i].Cells[2].Value = myReader["shop_name"];
                            dataGridView1.Rows[i].Cells[3].Value = myReader["shop_master"];
                            dataGridView1.Rows[i].Cells[4].Value = myReader["shop_phone"];
                            dataGridView1.Rows[i].Cells[5].Value = Convert.ToDateTime(myReader["date_add"]).ToString("dd-MM-yyyy");
                            dataGridView1.Rows[i].Cells[6].Value = myReader["shop_support"];
                            dataGridView1.Rows[i].Cells[7].Value = myReader["ip_bonus"];
                            dataGridView1.Rows[i].Cells[8].Value = myReader["mem_status"];
                            dataGridView1.Rows[i].Cells[9].Value = myReader["shop_pc"];
                            dataGridView1.Rows[i].Cells[10].Value = myReader["printer"];
                            dataGridView1.Rows[i].Cells[11].Value = myReader["game_type"];
                            dataGridView1.Rows[i].Cells[12].Value = myReader["airpay"];
                            dataGridView1.Rows[i].Cells[13].Value = myReader["cafe_thai"];
                            dataGridView1.Rows[i].Cells[14].Value = myReader["num_home"];
                            dataGridView1.Rows[i].Cells[15].Value = myReader["zone"];
                            dataGridView1.Rows[i].Cells[16].Value = myReader["street"];
                            dataGridView1.Rows[i].Cells[17].Value = myReader["district"];
                            dataGridView1.Rows[i].Cells[18].Value = myReader["area"];
                            dataGridView1.Rows[i].Cells[19].Value = myReader["county"];
                            dataGridView1.Rows[i].Cells[20].Value = myReader["comment"];
                            dataGridView1.Rows[i].Cells[21].Value = myReader["shopStatus"];
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

        /// <summary>
        /// Set Item Shop Support combobox
        /// </summary>
        public void SetItemComboboxShopSupport()
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", "tb_shop_support");
                    using (var myReader = cmd.ExecuteReader())
                    {
                        cbSupport.Items.Clear();
                        while (myReader.Read())
                        {
                            cbSupport.Items.Add(myReader["shop_support"]);
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        /// <summary>
        /// Set Item Member Status Combobox
        /// </summary>
        public void SetItemComboboxMemberStatus()
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", "tb_member_status");
                    using (var myReader = cmd.ExecuteReader())
                    {
                        cbMemberStatus.Items.Clear();
                        while (myReader.Read())
                        {
                            cbMemberStatus.Items.Add(myReader["mem_status"]);
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        /// <summary>
        /// Set Item Printer Combobox
        /// </summary>
        public void SetItemComboboxPrinter()
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", "tb_printer");
                    using (var myReader = cmd.ExecuteReader())
                    {
                        cbPrinter.Items.Clear();
                        while (myReader.Read())
                        {
                            cbPrinter.Items.Add(myReader["printer"]);
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        /// <summary>
        /// Set Item Game Type Combobox
        /// </summary>
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

        /// <summary>
        /// Set Item Airpay combobox
        /// </summary>
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

        /// <summary>
        /// Set Item Cafe Thai Combobox
        /// </summary>
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


        private void rbIPBonus_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbIPBonus.Checked == true) { txtIPBonus.ReadOnly = false; }
                else if (rbIPBonus.Checked == false)
                {
                    txtIPBonus.Text = "";
                    txtIPBonus.ReadOnly = true;
                }
            }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
        }

        /// <summary>
        /// Get ID For Combobox
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="Field"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public int GetIDForCombobox(string tableName,string Field, string Value) 
        {
            if (db.conn.State == ConnectionState.Closed){db.conn.Open();}
            try
            {
                string sql = "SELECT id FROM "+tableName+" WHERE "+Field+" = '"+Value+"'";
                using (SqlCommand cmd = new SqlCommand(sql, db.conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }          
            }
            catch (Exception) { return 1; }        
        }

        public void GetDateAppointment(string ShopIDDateAppointment) 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try 
            {
                string sql = "SELECT date_appointment FROM tb_appointment WHERE appointment_shop_id = '"+ShopIDDateAppointment+"'";
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                using (var myReader = cmd.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        DateAppointment.Value = Convert.ToDateTime(myReader["date_appointment"]);
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    txtID.Text = dataGridView1["ID", e.RowIndex].Value.ToString();
                    txtShopID.Text = dataGridView1["ShopID", e.RowIndex].Value.ToString();
                    txtShopName.Text = dataGridView1["ชื่อร้าน", e.RowIndex].Value.ToString();
                    txtShopMaster.Text = dataGridView1["เจ้าของร้าน", e.RowIndex].Value.ToString();
                    txtPhone.Text = dataGridView1["เบอร์โทรศัพท์", e.RowIndex].Value.ToString();
                    DateAdd.Value = Convert.ToDateTime(dataGridView1["วันที่เพิ่ม", e.RowIndex].Value.ToString());
                    cbSupport.SelectedIndex = GetIDForCombobox("tb_shop_support", "shop_support", dataGridView1["ผู้ดูแล", e.RowIndex].Value.ToString())-1;
                    if (dataGridView1["IPBonus", e.RowIndex].Value.ToString() == "ไม่มี") { rbNoIPBonus.Checked = true; }
                    else if (dataGridView1["IPBonus", e.RowIndex].Value.ToString() != "ไม่มี")
                    {
                        rbIPBonus.Checked = true;
                        txtIPBonus.Text = dataGridView1["IPBonus", e.RowIndex].Value.ToString();
                    }
                    cbMemberStatus.SelectedIndex = GetIDForCombobox("tb_member_status", "mem_status", dataGridView1["สถานะสมาชิก", e.RowIndex].Value.ToString())-1;
                    txtPC.Text = dataGridView1["PC", e.RowIndex].Value.ToString();
                    cbPrinter.SelectedIndex = GetIDForCombobox("tb_printer", "printer", dataGridView1["Printer", e.RowIndex].Value.ToString())-1;
                    cbGameType.SelectedIndex = GetIDForCombobox("tb_game_type", "game_type", dataGridView1["GameType", e.RowIndex].Value.ToString())-1;
                    cbAirpay.SelectedIndex = GetIDForCombobox("tb_airpay", "airpay", dataGridView1["Airpay", e.RowIndex].Value.ToString())-1;
                    cbCafeThai.SelectedIndex = GetIDForCombobox("tb_cafethai", "cafethai", dataGridView1["CafeThai", e.RowIndex].Value.ToString())-1;
                    txtNumHome.Text = dataGridView1["บ้านเลขที่", e.RowIndex].Value.ToString();
                    txtZone.Text = dataGridView1["ย่าน", e.RowIndex].Value.ToString();
                    txtStreet.Text = dataGridView1["ถนน", e.RowIndex].Value.ToString();
                    txtDistrict.Text = dataGridView1["แขวง", e.RowIndex].Value.ToString();
                    txtArea.Text = dataGridView1["เขต", e.RowIndex].Value.ToString();
                    cbCounty.Text = dataGridView1["จังหวัด", e.RowIndex].Value.ToString();
                    txtComment.Text = dataGridView1["หมายเหตุ", e.RowIndex].Value.ToString();
                    lbShopStatus.Text = dataGridView1["สถานะร้าน", e.RowIndex].Value.ToString();
                    ShopStatusID = GetShopStatus(lbShopStatus.Text);
                    GetDateAppointment(txtShopID.Text);
                }
            }
            catch (Exception) { newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง"); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (newMessagebox.confirmWarring("ร้านเกมส์ที่คุณเลือกอาจมีไฟล์รูปภาพที่อัพโหลดใว้  คุณต้องการที่จะลบหรือไม่ ถ้าคุณลบไฟล์รูปภาพจะยังไม่ถูกลบไปด้วย (ตรวจสอบไฟล์ภาพใด้ที่ C:/ExtremeImage)") == true)
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteGameShop", db.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        cmd.ExecuteNonQuery();
                    }
                    newMessagebox.info("ลบข้อมูลร้านเกมส์เรียบร้อยแล้ว");
                    BindData();
                }               
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtShopID.Text = "";
            txtShopName.Text = "";
            txtShopMaster.Text = "";
            txtPhone.Text = "";
            DateAdd.Value = DateTime.Now;
            rbNoIPBonus.Checked = true;
            txtPC.Text = "";
            txtNumHome.Text = "";
            txtZone.Text = "";
            txtStreet.Text = "";
            txtDistrict.Text = "";
            txtArea.Text = "";
            txtComment.Text = "";
            lbShopStatus.Text = "ShopStatus";
            txtFileName.Text = "";
            txtSearch.Text = "";
            DateAppointment.Value = DateTime.Now;
            FileSelected = null;
            BindData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                string ipBonus = null;
                if (rbNoIPBonus.Checked == true) { ipBonus = rbNoIPBonus.Text; }  
                else if (rbIPBonus.Checked == true) { ipBonus = txtIPBonus.Text; }
                var dateAdd = DateAdd.Value.Date.ToString("dd-MM-yyyy");
                int ShopStatus = 1;
                using (SqlCommand cmd = new SqlCommand("UpdateGameShop", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));
                    cmd.Parameters.AddWithValue("@ShopID", txtShopID.Text);
                    cmd.Parameters.AddWithValue("@ShopName", txtShopName.Text);
                    cmd.Parameters.AddWithValue("@ShopMaster", txtShopMaster.Text);
                    cmd.Parameters.AddWithValue("@ShopPhone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@DateAdd", Convert.ToDateTime(dateAdd));
                    cmd.Parameters.AddWithValue("@ShopSupport", Convert.ToInt32(cbSupport.SelectedIndex+1));
                    cmd.Parameters.AddWithValue("@IPBonus", ipBonus);
                    cmd.Parameters.AddWithValue("@MemberStatus", Convert.ToInt32(cbMemberStatus.SelectedIndex+1));
                    cmd.Parameters.AddWithValue("@ShopPC", Convert.ToInt32(txtPC.Text));
                    cmd.Parameters.AddWithValue("@Printer", Convert.ToInt32(cbPrinter.SelectedIndex+1));
                    cmd.Parameters.AddWithValue("@GameType", Convert.ToInt32(cbGameType.SelectedIndex+1));
                    cmd.Parameters.AddWithValue("@Airpay", Convert.ToInt32(cbAirpay.SelectedIndex+1));
                    cmd.Parameters.AddWithValue("CafeThai", Convert.ToInt32(cbCafeThai.SelectedIndex+1));
                    cmd.Parameters.AddWithValue("@NumHome", txtNumHome.Text);
                    cmd.Parameters.AddWithValue("@Zone", txtZone.Text);
                    cmd.Parameters.AddWithValue("@Street", txtStreet.Text);
                    cmd.Parameters.AddWithValue("@District", txtDistrict.Text);
                    cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                    cmd.Parameters.AddWithValue("@County", cbCounty.Text);
                    cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                    cmd.Parameters.AddWithValue("@ShopStatus", ShopStatus);
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("แก้ใขข้อมูลร้านเกมส์แล้ว");
                    BindData();
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SearchGameShop", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ShopID", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@ShopName", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@ShopMaster", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@ShopPhone", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@IPBonus", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@Zone", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@County", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@Comment", txtSearch.Text);
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridView1.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = myReader["id"];
                            dataGridView1.Rows[i].Cells[1].Value = myReader["shop_id"];
                            dataGridView1.Rows[i].Cells[2].Value = myReader["shop_name"];
                            dataGridView1.Rows[i].Cells[3].Value = myReader["shop_master"];
                            dataGridView1.Rows[i].Cells[4].Value = myReader["shop_phone"];
                            dataGridView1.Rows[i].Cells[5].Value = Convert.ToDateTime(myReader["date_add"]).ToString("dd-MM-yyyy");
                            dataGridView1.Rows[i].Cells[6].Value = myReader["shop_support"];
                            dataGridView1.Rows[i].Cells[7].Value = myReader["ip_bonus"];
                            dataGridView1.Rows[i].Cells[8].Value = myReader["mem_status"];
                            dataGridView1.Rows[i].Cells[9].Value = myReader["shop_pc"];
                            dataGridView1.Rows[i].Cells[10].Value = myReader["printer"];
                            dataGridView1.Rows[i].Cells[11].Value = myReader["game_type"];
                            dataGridView1.Rows[i].Cells[12].Value = myReader["airpay"];
                            dataGridView1.Rows[i].Cells[13].Value = myReader["cafe_thai"];
                            dataGridView1.Rows[i].Cells[14].Value = myReader["num_home"];
                            dataGridView1.Rows[i].Cells[15].Value = myReader["zone"];
                            dataGridView1.Rows[i].Cells[16].Value = myReader["street"];
                            dataGridView1.Rows[i].Cells[17].Value = myReader["district"];
                            dataGridView1.Rows[i].Cells[18].Value = myReader["area"];
                            dataGridView1.Rows[i].Cells[19].Value = myReader["county"];
                            dataGridView1.Rows[i].Cells[20].Value = myReader["comment"];
                            dataGridView1.Rows[i].Cells[21].Value = myReader["shopStatus"];
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

        /// <summary>
        /// Upload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewImage_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (txtShopID.Text == "") { newMessagebox.warring("คุณยังไม่ใด้เลือกร้านเกมส์ที่จะเพิ่มรูปภาพ"); }
                else if (FileSelected == null) { newMessagebox.warring("คุณยังไม่ใด้เลือกไฟล์ภาพที่จะเพิ่ม"); }
                else if (txtFileName.Text == "") { newMessagebox.warring("คุณยังไม่ใด้ตั้งชื่อไฟล์ร้าน"); }
                else
                {
                    if (File.Exists(PathSelected + "/" + txtFileName.Text + ".jpg"))
                    {
                        newMessagebox.warring("มีไฟล์ชื่อนี้อยู่แล้ว");
                    }
                    else 
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertPathImage", db.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ShopID", txtShopID.Text);
                            cmd.Parameters.AddWithValue("@PathImage", PathSelected + "/" + txtFileName.Text + ".jpg");
                            cmd.ExecuteNonQuery();
                        }
                        File.Copy(FileSelected, PathSelected + "/" + txtFileName.Text + ".jpg");
                        newMessagebox.info("บันทึกรูปภาพเรียบร้อยแล้ว");
                    }                   
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        /// <summary>
        /// Select ImageFile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "jpg (*.jpg)|*.jpg";
                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
                {
                    FileSelected = ofd.FileName;
                }
                else { newMessagebox.error("คุณเลือกไฟล์ไม่ถูกต้อง"); }
            }
            catch (Exception) { newMessagebox.error("คุณเลือกไฟล์ไม่ถูกต้อง"); }
        }

        private void btnViewImage_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (ViewImage viewImage = new ViewImage())
                {
                    if (txtShopID.Text == "") { newMessagebox.warring("คุณยังไม่ใด้เลือกร้านเกมส์ที่จะดูรูปภาพ"); }
                    else 
                    {
                        viewImage.ShopID = txtShopID.Text;
                        viewImage.ShowDialog();
                    }                 
                }
            }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
        }

        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                string sql = "SELECT * FROM tb_game_shop"; 
	            sql += " INNER JOIN tb_shop_support ON tb_game_shop.game_shop_support = tb_shop_support.id ";
	            sql += " INNER JOIN tb_member_status ON tb_game_shop.member_status = tb_member_status.id ";
	            sql += " INNER JOIN tb_printer ON tb_game_shop.shop_printer = tb_printer.id ";
	            sql += " INNER JOIN tb_game_type ON tb_game_shop.shop_game_type = tb_game_type.id ";
	            sql += " INNER JOIN tb_airpay ON tb_game_shop.shop_airpay = tb_airpay.id ";
	            sql += " INNER JOIN tb_cafethai ON tb_game_shop.shop_cafe_thai = tb_cafethai.id ";
	            sql +=" INNER JOIN tb_shop_status ON tb_game_shop.shop_status = tb_shop_status.id ";
                sql += " where tb_game_shop.date_add ";
                sql += " BETWEEN '" +DateFrom.Value.Date.ToString("yyyy-MM-dd")+ "' AND '" +DateTo.Value.Date.ToString("yyyy-MM-dd")+ "'" ;
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                using (var myReader = cmd.ExecuteReader())
                {
                    int i = 0;
                    dataGridView1.Rows.Clear();
                    while (myReader.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = myReader["id"];
                        dataGridView1.Rows[i].Cells[1].Value = myReader["shop_id"];
                        dataGridView1.Rows[i].Cells[2].Value = myReader["shop_name"];
                        dataGridView1.Rows[i].Cells[3].Value = myReader["shop_master"];
                        dataGridView1.Rows[i].Cells[4].Value = myReader["shop_phone"];
                        dataGridView1.Rows[i].Cells[5].Value = Convert.ToDateTime(myReader["date_add"]).ToString("dd-MM-yyyy");
                        dataGridView1.Rows[i].Cells[6].Value = myReader["shop_support"];
                        dataGridView1.Rows[i].Cells[7].Value = myReader["ip_bonus"];
                        dataGridView1.Rows[i].Cells[8].Value = myReader["mem_status"];
                        dataGridView1.Rows[i].Cells[9].Value = myReader["shop_pc"];
                        dataGridView1.Rows[i].Cells[10].Value = myReader["printer"];
                        dataGridView1.Rows[i].Cells[11].Value = myReader["game_type"];
                        dataGridView1.Rows[i].Cells[12].Value = myReader["airpay"];
                        dataGridView1.Rows[i].Cells[13].Value = myReader["cafe_thai"];
                        dataGridView1.Rows[i].Cells[14].Value = myReader["num_home"];
                        dataGridView1.Rows[i].Cells[15].Value = myReader["zone"];
                        dataGridView1.Rows[i].Cells[16].Value = myReader["street"];
                        dataGridView1.Rows[i].Cells[17].Value = myReader["district"];
                        dataGridView1.Rows[i].Cells[18].Value = myReader["area"];
                        dataGridView1.Rows[i].Cells[19].Value = myReader["county"];
                        dataGridView1.Rows[i].Cells[20].Value = myReader["comment"];
                        dataGridView1.Rows[i].Cells[21].Value = myReader["shopStatus"];
                        i++;
                    }
                    myReader.Close();
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        public void CheckFolder() 
        {
            bool exists = System.IO.Directory.Exists(@"C:\ExtremeImage");
            if (!exists)
                System.IO.Directory.CreateDirectory(@"C:\ExtremeImage");
            PathSelected = @"C:\ExtremeImage";
        }

        private void txtFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsLetter(e.KeyChar) && !Char.IsDigit(e.KeyChar))            
                e.Handled = true;
            base.OnKeyPress(e);          
        }


        private void txtPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
            base.OnKeyPress(e);
        }

        public int GetShopStatus(string Value) 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                string sql = "SELECT id FROM tb_shop_status WHERE shopStatus = '"+Value+"'";
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception) { return 1; }         
        }

        private void btnSaveDate_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (txtShopID.Text == "") { newMessagebox.warring("คุณยังไม่ใด้เลือกร้านเกมส์ที่นัดหมาย"); }
                else
                {
                    if (db.ChackDateAppointment(Convert.ToInt32(txtID.Text)) == true)
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertDateAppointment", db.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
                            cmd.Parameters.AddWithValue("@ShopID", txtShopID.Text);
                            cmd.Parameters.AddWithValue("DateAppointment", Convert.ToDateTime(DateAppointment.Value.Date.ToString("dd-MM-yyyy")));
                            cmd.Parameters.AddWithValue("@ShopStatus", ShopStatusID);
                            cmd.ExecuteNonQuery();
                            newMessagebox.info("เพิ่มวันที่นัดหมายกับร้าน " + txtShopName.Text + " เรียบร้อยแล้ว   วันที่จะไปคือ " + DateAppointment.Value.Date.ToString("dd-MM-yyyy"));
                        }
                    }
                    else
                    {
                        newMessagebox.warring("คุณใด้ทำการนัดวันที่กับทางร้าน " + txtShopName.Text + " ก่อนหน้านี้แล้ว");
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnEditDate_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (txtShopID.Text == "") { newMessagebox.warring("คุณยังไม่ใด้เลือกร้านเกมส์ที่นัดหมาย"); }
                else 
                {
                    if (db.ChackDateAppointment(Convert.ToInt32(txtID.Text)) == false)
                    {
                        using (SqlCommand cmd = new SqlCommand("UpdateDateAppointment", db.conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
                            cmd.Parameters.AddWithValue("@ShopID", txtShopID.Text);
                            cmd.Parameters.AddWithValue("@DateAppointment", Convert.ToDateTime(DateAppointment.Value.Date.ToString("dd-MM-yyyy")));
                            cmd.ExecuteNonQuery();
                            newMessagebox.info("ทำการแก้ใขวันนัดหมายกับทางร้าน " + txtShopName.Text + " แล้ว   แก้ใขเป็นวันที่ " + DateAppointment.Value.Date.ToString("dd-MM-yyyy"));
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
      }
  }