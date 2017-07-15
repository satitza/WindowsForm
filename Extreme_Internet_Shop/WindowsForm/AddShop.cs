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
    public partial class AddShop : Form
    {
        NewMessageBox newMessagebox = new NewMessageBox();
        ConnectDatabase db = new ConnectDatabase();

        public AddShop()
        {
            InitializeComponent();
        }


        private void Add_Shop_Load(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed){db.conn.Open();}
            try
            {
                    txtID.Text = db.auto_id("tb_game_shop", "id").ToString();
                    SetItemComboboxMemberStatus();
                    SetItemComboboxShopSupport();
                    SetItemComboboxPrinter();
                    SetItemComboboxGameType();
                    SetItemComboboxAirpay();
                    SetItemComboboxAutoUpdateCafeThai();            
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
                    using(var myReader = cmd.ExecuteReader())
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


        /// <summary>
        /// Insert data into database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {            
                if(txtShopID.Text == "")
                {
                    newMessagebox.warring("กรุณาใส่ Shop ID");
                    txtShopID.Focus();
                }
                else if(txtShopName.Text == "")
                {
                    newMessagebox.warring("กรูณาใส่ ชื่อร้าน");
                    txtShopName.Focus();
                }
                else if(txtPhone.Text == "")
                {
                    newMessagebox.warring("กรุณาใส่ เบอร์โทรศัพท์");
                    txtPhone.Focus();
                }
                else if(cbSupport.Text == "")
                {
                    newMessagebox.warring("กรุณาใส่ข้อมูล จ้างผู้ดูแล");
                }
                else if(rbIPBonus.Checked == true && txtIPBonus.Text == "")
                {
                    newMessagebox.warring("กรุณาใส่ IP Bonus");
                    txtIPBonus.Focus();
                }
                else if(rbNoIPBonus.Checked == true && txtIPBonus.Text != "")
                {
                    txtIPBonus.Text = "";
                }
                else if(cbMemberStatus.Text == "")
                {
                    newMessagebox.warring("กรุณาใส่ข้อมูล สถานะสมาชิก");
                }
                else if(txtPC.Text == "")
                {
                    newMessagebox.warring("กรุณาใส่ จำนวนเครื่อง PC");
                }
                else if(cbPrinter.Text == "")
                {
                    newMessagebox.warring("กรูณาใส่ข้อมูล ปริ๊นเตอร์");
                }
                else if(cbGameType.Text == "")
                {
                    newMessagebox.warring("กรุณาใส่ข้อมูล Game Type");
                }
                else if(cbAirpay.Text == "")
                {
                    newMessagebox.warring("กรุณาใส่ข้อมูล Airpay");
                }
                else if (cbCafeThai.Text == "")
                {
                    newMessagebox.warring("กรุณาใส่ข้อมูล Auto Update Cafe Thai");
                }
                else 
                {
                    string ipBonus = null;
                    if (rbNoIPBonus.Checked == true) { ipBonus = rbNoIPBonus.Text; }
                    else if (rbIPBonus.Checked == true) { ipBonus = txtIPBonus.Text; }
                    int ShopSupport = cbSupport.SelectedIndex + 1;
                    int MemStatus = cbMemberStatus.SelectedIndex + 1;
                    int Printer = cbPrinter.SelectedIndex + 1;
                    int GameType = cbGameType.SelectedIndex + 1;
                    int AirpayService = cbAirpay.SelectedIndex + 1; 
                    int AutoCaftThai = cbCafeThai.SelectedIndex + 1;
                    int ShopStatus = 1;
                    var dateAdd = DateAdd.Value.Date.ToString("dd-MM-yyyy");
                    using(SqlCommand cmd = new SqlCommand("InsertAddShop", db.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));
                        cmd.Parameters.AddWithValue("@ShopID", txtShopID.Text);
                        cmd.Parameters.AddWithValue("@ShopName", txtShopName.Text);
                        cmd.Parameters.AddWithValue("@ShopMaster", txtShopMaster.Text);
                        cmd.Parameters.AddWithValue("@ShopPhone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@DateAdd", Convert.ToDateTime(dateAdd));
                        cmd.Parameters.AddWithValue("@ShopSupport", ShopSupport);
                        cmd.Parameters.AddWithValue("@IPBonus", ipBonus);
                        cmd.Parameters.AddWithValue("@MemberStatus", MemStatus);
                        cmd.Parameters.AddWithValue("@ShopPC", Convert.ToInt32(txtPC.Text));
                        cmd.Parameters.AddWithValue("@Printer", Printer);
                        cmd.Parameters.AddWithValue("@GameType", GameType);
                        cmd.Parameters.AddWithValue("@Airpay", AirpayService);
                        cmd.Parameters.AddWithValue("CafeThai", AutoCaftThai);
                        cmd.Parameters.AddWithValue("@NumHome", txtNumHome.Text);
                        cmd.Parameters.AddWithValue("@Zone", txtZone.Text);
                        cmd.Parameters.AddWithValue("@Street", txtStreet.Text);
                        cmd.Parameters.AddWithValue("@District", txtDistrict.Text);
                        cmd.Parameters.AddWithValue("@Area", txtArea.Text);
                        cmd.Parameters.AddWithValue("@County", cbCounty.Text);
                        cmd.Parameters.AddWithValue("@Comment", txtComment.Text);
                        cmd.Parameters.AddWithValue("@ShopStatus", ShopStatus);
                        cmd.ExecuteNonQuery();
                        newMessagebox.info("บันทึกข้อมูลเรียบร้อยแล้ว");
                    }                                
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }


        private void rb_ip_bonus_CheckedChanged_1(object sender, EventArgs e)
        {
            try 
            {
                if (rbIPBonus.Checked == true)
                {
                    txtIPBonus.ReadOnly = false;
                }
                else if(rbIPBonus.Checked == false)
                {
                    txtIPBonus.ReadOnly = true;
                }
            }
            catch(Exception ex){newMessagebox.error("Exception Error "+ex.ToString());}
        }

        private void txtClear_Click(object sender, EventArgs e)
        {
            txtShopID.Text = "";
            txtShopName.Text = "";
            txtShopMaster.Text = "";
            txtPhone.Text = "";
            DateAdd.Value = DateTime.Now;
            cbSupport.Text = "";
            rbNoIPBonus.Checked = true;
            txtIPBonus.Text = "";
            cbMemberStatus.Text = "";
            txtPC.Text = "";
            cbPrinter.Text = "";
            cbGameType.Text = "";
            cbAirpay.Text = "";
            cbCafeThai.Text = "";
            txtNumHome.Text = "";
            txtZone.Text = "";
            txtStreet.Text = "";
            txtDistrict.Text = "";
            txtArea.Text = "";
            cbCounty.Text = "";
            txtComment.Text = "";
            Add_Shop_Load(null, null);
        }

        private void txtPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) &&  !Char.IsDigit(e.KeyChar))
                e.Handled = true;
            base.OnKeyPress(e); 
        }
    }
}