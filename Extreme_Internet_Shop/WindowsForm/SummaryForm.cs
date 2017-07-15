///////////////////////////////////////////////////////////////////////////////////////
//                            Devleper By : Satit Prontepanon                        //
//                            Date Write : 24-06-2015                                //
//                            Working in : Electronics Extreme                       //
//                            By : Anonymous Hacker                                  //
///////////////////////////////////////////////////////////////////////////////////////
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
using System.Windows.Forms.DataVisualization.Charting;

namespace ExtremeInternetShop
{
    public partial class SummaryForm : Form
    {
        private static  ConnectDatabase db = new ConnectDatabase();
        NewMessageBox newMessagebox = new NewMessageBox();

        public string GetDate {get; set;}

        public SummaryForm()
        {
            InitializeComponent();
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            try 
            {
                SetItemComboboxPrinter();
                SetItemComboboxGameType();
                SetItemComboboxAirpay();
                SetItemComboboxAutoUpdateCafeThai();
                SetItemComboboxShopStatus();
            }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
        }

//------------------------------------------------------Get Item For Combobox------------------------------------------------------------------//
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
                            cbSizeShopAirpay.Items.Add(myReader["airpay"]);
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
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
                            cbSizeShopCafeThai.Items.Add(myReader["cafe_thai"]);
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
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
 
//---------------------------------------------------------------------------------------------------------------------------------------------//

        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewSummary.Rows.Clear();
            txtIPBonus.Text = string.Empty;
            txtSizeGameShop.Text = string.Empty;
            txtPrinter.Text = string.Empty;
            txtGameType.Text = string.Empty;
            txtShopAirpay.Text = string.Empty;
            txtCafeThai.Text = string.Empty;
            txtShopStatus.Text = string.Empty;
            txtComment.Text = string.Empty;
        }

        public void SelectAllSummary
            (
               string dateStatus,
               string dateAdd,
               string IPBonus,
               string ShopPC,
               int    Printer,
               int    GameType,
               int    Airpay,
               int    CafeThai,
               int    ShopStatus
            ) 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try 
            {
                using (SqlCommand cmd = new SqlCommand("SelectAllSummary", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dateStatus", SqlDbType.VarChar, 50).Value = dateStatus;
                    cmd.Parameters.Add("@dateAdd", SqlDbType.Date).Value = Convert.ToDateTime(dateAdd);
                    cmd.Parameters.Add("@IPBonus", SqlDbType.VarChar, 50).Value = IPBonus;
                    cmd.Parameters.Add("@ShopPC", SqlDbType.VarChar, 50).Value = ShopPC;
                    cmd.Parameters.Add("@Printer", SqlDbType.Int).Value = Printer;
                    cmd.Parameters.Add("@GameType", SqlDbType.Int).Value = GameType;
                    cmd.Parameters.Add("@Airpay", SqlDbType.Int).Value = Airpay;
                    cmd.Parameters.Add("@CafeThai", SqlDbType.Int).Value = CafeThai;
                    cmd.Parameters.Add("@ShopStatus", SqlDbType.Int).Value = ShopPC;
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridViewSummary.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridViewSummary.Rows.Add();
                            dataGridViewSummary.Rows[i].Cells[0].Value = myReader["id"];
                            dataGridViewSummary.Rows[i].Cells[1].Value = myReader["shop_id"];
                            dataGridViewSummary.Rows[i].Cells[2].Value = myReader["shop_name"];
                            dataGridViewSummary.Rows[i].Cells[3].Value = myReader["shop_master"];
                            dataGridViewSummary.Rows[i].Cells[4].Value = myReader["shop_phone"];
                            dataGridViewSummary.Rows[i].Cells[5].Value = myReader["ip_bonus"];
                            dataGridViewSummary.Rows[i].Cells[6].Value = myReader["shop_pc"];
                            dataGridViewSummary.Rows[i].Cells[7].Value = myReader["printer"];
                            dataGridViewSummary.Rows[i].Cells[8].Value = myReader["game_type"];
                            dataGridViewSummary.Rows[i].Cells[9].Value = myReader["airpay"];
                            dataGridViewSummary.Rows[i].Cells[10].Value = myReader["cafe_thai"];
                            dataGridViewSummary.Rows[i].Cells[11].Value = myReader["num_home"];
                            dataGridViewSummary.Rows[i].Cells[12].Value = myReader["zone"];
                            dataGridViewSummary.Rows[i].Cells[13].Value = myReader["street"];
                            dataGridViewSummary.Rows[i].Cells[14].Value = myReader["district"];
                            dataGridViewSummary.Rows[i].Cells[15].Value = myReader["area"];
                            dataGridViewSummary.Rows[i].Cells[16].Value = myReader["county"];
                            dataGridViewSummary.Rows[i].Cells[17].Value = myReader["shopStatus"];
                            dataGridViewSummary.Rows[i].Cells[18].Value = myReader["comment"];
                            i++;
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error" + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnShopInfo_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try 
            {
                if (string.IsNullOrEmpty(cbIPBonus.Text)) { newMessagebox.warring("เงือนใขในการค้นหาไม่ครบ กรูณาเลือกเงือนใข"); }
                else if (string.IsNullOrEmpty(cbSizeGameShop.Text)) { newMessagebox.warring("เงือนใขในการค้นหาไม่ครบ กรูณาเลือกเงือนใข"); }
                else if (string.IsNullOrEmpty(cbPrinter.Text)) { newMessagebox.warring("เงือนใขในการค้นหาไม่ครบ กรูณาเลือกเงือนใข"); }
                else if (string.IsNullOrEmpty(cbGameType.Text)) { newMessagebox.warring("เงือนใขในการค้นหาไม่ครบ กรูณาเลือกเงือนใข"); }
                else if (string.IsNullOrEmpty(cbAirpay.Text)) { newMessagebox.warring("เงือนใขในการค้นหาไม่ครบ กรูณาเลือกเงือนใข"); }
                else if (string.IsNullOrEmpty(cbCafeThai.Text)){ newMessagebox.warring("เงือนใขในการค้นหาไม่ครบ กรูณาเลือกเงือนใข");}
                else if (string.IsNullOrEmpty(cbShopStatus.Text)) { newMessagebox.warring("เงือนใขในการค้นหาไม่ครบ กรูณาเลือกเงือนใข"); }
                else 
                {
                    if (checkBoxDate.Checked != true)
                    {
                        if (cbIPBonus.SelectedIndex + 1 == 1) //มี IP Bonus
                        {
                            if (cbSizeGameShop.SelectedIndex + 1 == 1) //PC <= 20
                            {
                                SelectAllSummary
                                    (
                                        "false",
                                        dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"),
                                        "1",
                                        "1",
                                        Convert.ToInt32(cbPrinter.SelectedIndex + 1),
                                        Convert.ToInt32(cbGameType.SelectedIndex + 1),
                                        Convert.ToInt32(cbAirpay.SelectedIndex + 1),
                                        Convert.ToInt32(cbCafeThai.SelectedIndex + 1),
                                        Convert.ToInt32(cbShopStatus.SelectedIndex + 1)
                                    );
                            }
                            else if (cbSizeGameShop.SelectedIndex + 1 == 2) // PC 21 To 40
                            {
                                SelectAllSummary
                                    (
                                        "false",
                                        dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"),
                                        "1",
                                        "2",
                                        Convert.ToInt32(cbPrinter.SelectedIndex + 1),
                                        Convert.ToInt32(cbGameType.SelectedIndex + 1),
                                        Convert.ToInt32(cbAirpay.SelectedIndex + 1),
                                        Convert.ToInt32(cbCafeThai.SelectedIndex + 1),
                                        Convert.ToInt32(cbShopStatus.SelectedIndex + 1)
                                    );
                            }
                            else if (cbSizeGameShop.SelectedIndex + 1 == 3) //PC >= 41
                            {
                                SelectAllSummary
                                    (
                                        "false",
                                        dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"),
                                        "1",
                                        "3",
                                        Convert.ToInt32(cbPrinter.SelectedIndex + 1),
                                        Convert.ToInt32(cbGameType.SelectedIndex + 1),
                                        Convert.ToInt32(cbAirpay.SelectedIndex + 1),
                                        Convert.ToInt32(cbCafeThai.SelectedIndex + 1),
                                        Convert.ToInt32(cbShopStatus.SelectedIndex + 1)
                                    );
                            }
                        }
                        else if (cbIPBonus.SelectedIndex + 1 == 2) //ไม่มี IP Bonus
                        {
                            if (cbSizeGameShop.SelectedIndex + 1 == 1) //PC <= 20
                            {
                                SelectAllSummary
                                    (
                                        "false",
                                        dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"),
                                        "2",
                                        "1",
                                        Convert.ToInt32(cbPrinter.SelectedIndex + 1),
                                        Convert.ToInt32(cbGameType.SelectedIndex + 1),
                                        Convert.ToInt32(cbAirpay.SelectedIndex + 1),
                                        Convert.ToInt32(cbCafeThai.SelectedIndex + 1),
                                        Convert.ToInt32(cbShopStatus.SelectedIndex + 1)
                                    );
                            }
                            else if (cbSizeGameShop.SelectedIndex + 1 == 2) // PC 21 To 40
                            {
                                SelectAllSummary
                                    (
                                        "false",
                                        dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"),
                                        "2",
                                        "2",
                                        Convert.ToInt32(cbPrinter.SelectedIndex + 1),
                                        Convert.ToInt32(cbGameType.SelectedIndex + 1),
                                        Convert.ToInt32(cbAirpay.SelectedIndex + 1),
                                        Convert.ToInt32(cbCafeThai.SelectedIndex + 1),
                                        Convert.ToInt32(cbShopStatus.SelectedIndex + 1)
                                    );
                            }
                            else if (cbSizeGameShop.SelectedIndex + 1 == 3) //PC >= 41
                            {
                                SelectAllSummary
                                    (
                                        "false",
                                        dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"),
                                        "2",
                                        "3",
                                        Convert.ToInt32(cbPrinter.SelectedIndex + 1),
                                        Convert.ToInt32(cbGameType.SelectedIndex + 1),
                                        Convert.ToInt32(cbAirpay.SelectedIndex + 1),
                                        Convert.ToInt32(cbCafeThai.SelectedIndex + 1),
                                        Convert.ToInt32(cbShopStatus.SelectedIndex + 1)
                                    );
                            }
                         }                   
                    }//if checkbox
                    else if (checkBoxDate.Checked == true)
                    {
                        if (cbIPBonus.SelectedIndex + 1 == 1) //มี IP Bonus
                        {
                            if (cbSizeGameShop.SelectedIndex + 1 == 1) //PC <= 20
                            {
                                SelectAllSummary
                                    (
                                        "true",
                                        dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"),
                                        "1",
                                        "1",
                                        Convert.ToInt32(cbPrinter.SelectedIndex + 1),
                                        Convert.ToInt32(cbGameType.SelectedIndex + 1),
                                        Convert.ToInt32(cbAirpay.SelectedIndex + 1),
                                        Convert.ToInt32(cbCafeThai.SelectedIndex + 1),
                                        Convert.ToInt32(cbShopStatus.SelectedIndex + 1)
                                    );
                            }
                            else if (cbSizeGameShop.SelectedIndex + 1 == 2) // PC 21 To 40
                            {
                                SelectAllSummary
                                    (
                                        "true",
                                        dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"),
                                        "1",
                                        "2",
                                        Convert.ToInt32(cbPrinter.SelectedIndex + 1),
                                        Convert.ToInt32(cbGameType.SelectedIndex + 1),
                                        Convert.ToInt32(cbAirpay.SelectedIndex + 1),
                                        Convert.ToInt32(cbCafeThai.SelectedIndex + 1),
                                        Convert.ToInt32(cbShopStatus.SelectedIndex + 1)
                                    );
                            }
                            else if (cbSizeGameShop.SelectedIndex + 1 == 3) //PC >= 41
                            {
                                SelectAllSummary
                                    (
                                        "true",
                                        dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"),
                                        "1",
                                        "3",
                                        Convert.ToInt32(cbPrinter.SelectedIndex + 1),
                                        Convert.ToInt32(cbGameType.SelectedIndex + 1),
                                        Convert.ToInt32(cbAirpay.SelectedIndex + 1),
                                        Convert.ToInt32(cbCafeThai.SelectedIndex + 1),
                                        Convert.ToInt32(cbShopStatus.SelectedIndex + 1)
                                    );
                            }
                        }
                        else if (cbIPBonus.SelectedIndex + 1 == 2) //ไม่มี IP Bonus
                        {
                            if (cbSizeGameShop.SelectedIndex + 1 == 1) //PC <= 20
                            {
                                SelectAllSummary
                                    (
                                        "true",
                                        dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"),
                                        "2",
                                        "1",
                                        Convert.ToInt32(cbPrinter.SelectedIndex + 1),
                                        Convert.ToInt32(cbGameType.SelectedIndex + 1),
                                        Convert.ToInt32(cbAirpay.SelectedIndex + 1),
                                        Convert.ToInt32(cbCafeThai.SelectedIndex + 1),
                                        Convert.ToInt32(cbShopStatus.SelectedIndex + 1)
                                    );
                            }
                            else if (cbSizeGameShop.SelectedIndex + 1 == 2) // PC 21 To 40
                            {
                                SelectAllSummary
                                    (
                                        "true",
                                        dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"),
                                        "2",
                                        "2",
                                        Convert.ToInt32(cbPrinter.SelectedIndex + 1),
                                        Convert.ToInt32(cbGameType.SelectedIndex + 1),
                                        Convert.ToInt32(cbAirpay.SelectedIndex + 1),
                                        Convert.ToInt32(cbCafeThai.SelectedIndex + 1),
                                        Convert.ToInt32(cbShopStatus.SelectedIndex + 1)
                                    );
                            }
                            else if (cbSizeGameShop.SelectedIndex + 1 == 3) //PC >= 41
                            {
                                SelectAllSummary
                                    (
                                        "true",
                                        dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"),
                                        "2",
                                        "3",
                                        Convert.ToInt32(cbPrinter.SelectedIndex + 1),
                                        Convert.ToInt32(cbGameType.SelectedIndex + 1),
                                        Convert.ToInt32(cbAirpay.SelectedIndex + 1),
                                        Convert.ToInt32(cbCafeThai.SelectedIndex + 1),
                                        Convert.ToInt32(cbShopStatus.SelectedIndex + 1)
                                    );
                            }
                        }
                    }//if checkbox
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error" + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void dateTimePickerDateAdd_ValueChanged_1(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                string s1 = "tb_game_shop";
                string s2 = "date_add";
                string s3 = dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd");
                txtShopToDay.Text = GetCountFromDatabase<string>.GetCountFromDatanaseMethod(ref  s1, ref  s2, ref  s3).ToString();
                Select2Where("null", "date_add", dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"), "",dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                txtComment.Text = string.Empty;
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error" + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void cbIPBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                string where = null;                            
                if (cbIPBonus.SelectedIndex == 0) { 
                    where = "!= 'ไม่มี'";
                    if (checkBoxDate.Checked == true)
                    {
                        where = "!= 'ไม่มี' AND date_add = '" +dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd")+ "'";
                    }
                }
                else if(cbIPBonus.SelectedIndex == 1) {
                    where = "= 'ไม่มี'";
                    if (checkBoxDate.Checked == true)
                    {
                        where = "= 'ไม่มี' AND date_add = '" + dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd") + "'";
                    }
                }
                string sql = "SELECT COUNT (ip_bonus) FROM  tb_game_shop WHERE ip_bonus "+where;
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                txtIPBonus.Text = cmd.ExecuteScalar().ToString();
                ChartIPBonus();
                dataGridViewSummary.Rows.Clear();
                txtComment.Text = string.Empty;              
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error" + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void cbSizeGameShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                string where = null;
                if (cbSizeGameShop.SelectedIndex == 0)
                {
                    where  = "<=  20";
                    if (checkBoxDate.Checked == true)
                    {
                        where = "<=  20 AND date_add = '" + dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd") + "'";
                    }
                }
                else if (cbSizeGameShop.SelectedIndex == 1)
                { 
                    where = "BETWEEN 21 AND 40";
                    if (checkBoxDate.Checked == true)
                    {
                        where = "BETWEEN 21 AND 40 AND date_add = '" + dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd") + "'";
                    }
                }
                else if (cbSizeGameShop.SelectedIndex == 2)
                { 
                    where = "> 41";
                    if (checkBoxDate.Checked == true)
                    {
                        where = "> 41 AND date_add = '" + dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd") + "'";
                    }
                }
                string sql = "SELECT COUNT (shop_pc) FROM  tb_game_shop WHERE shop_pc " + where;
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                txtSizeGameShop.Text = cmd.ExecuteScalar().ToString();
                ChartSizeShop();
                dataGridViewSummary.Rows.Clear();
                txtComment.Text = string.Empty;
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error" + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        public static void ChartSummary(Chart chart, ComboBox combobox, string TableName, string FieldName, string TableCount, string FieldCount)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                chart.Series["Series1"].Points.Clear();
                foreach (object o in combobox.Items)
                {
                    string sql = "SELECT id FROM " + TableName + " WHERE " + FieldName + " = '" + o.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    int idCafeThai = Convert.ToInt32(cmd.ExecuteScalar());

                    string sql2 = "SELECT COUNT (" + FieldCount + ") FROM  " + TableCount + " WHERE " + FieldCount + " = " + idCafeThai;
                    SqlCommand cmd2 = new SqlCommand(sql2, db.conn);
                    int countCafeThai = Convert.ToInt32(cmd2.ExecuteScalar());

                    chart.Series["Series1"].Points.AddXY(o.ToString(), countCafeThai);
                }
            }
            finally { db.conn.Close(); }
        }

        private void cbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                int cbSelect = cbPrinter.SelectedIndex + 1;
                string s1 = "tb_game_shop";
                string s2 = "shop_printer";
                string s3 = Convert.ToString(cbSelect);
                string s4 = dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd");
                if (checkBoxDate.Checked == true)
                {
                    txtPrinter.Text = GetCountFromDatabase<string>.GetCountFromDatanaseMethod(ref  s1, ref  s2, ref  s3, ref s4).ToString();
                    ChartSummary(chartSummary, cbPrinter, "tb_printer", "printer", "tb_game_shop", "shop_printer");
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;
                }
                else 
                {
                    txtPrinter.Text = GetCountFromDatabase<string>.GetCountFromDatanaseMethod(ref  s1, ref  s2, ref  s3).ToString();
                    ChartSummary(chartSummary, cbPrinter, "tb_printer", "printer", "tb_game_shop", "shop_printer");
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;
                }            
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void cbGameType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                int cbSelect = cbGameType.SelectedIndex + 1;
                string s1 = "tb_game_shop";
                string s2 = "shop_game_type";
                string s3 = Convert.ToString(cbSelect);
                string s4 = dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd");
                if (checkBoxDate.Checked == true)
                {
                    txtGameType.Text = GetCountFromDatabase<string>.GetCountFromDatanaseMethod(ref  s1, ref  s2, ref  s3, ref s4).ToString();
                    ChartSummary(chartSummary, cbGameType, "tb_game_type", "game_type", "tb_game_shop", "shop_game_type");
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;                 
                }
                else
                {
                    txtGameType.Text = GetCountFromDatabase<string>.GetCountFromDatanaseMethod(ref  s1, ref  s2, ref  s3).ToString();
                    ChartSummary(chartSummary, cbGameType, "tb_game_type", "game_type", "tb_game_shop", "shop_game_type");
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;                    
                }  
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error" + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void cbAirpay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                int cbSelect = cbAirpay.SelectedIndex + 1;
                string s1 = "tb_game_shop";
                string s2 = "shop_airpay";
                string s3 = Convert.ToString(cbSelect);
                string s4 = dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd");
                if (checkBoxDate.Checked == true)
                {
                    txtShopAirpay.Text = GetCountFromDatabase<string>.GetCountFromDatanaseMethod(ref  s1, ref  s2, ref  s3, ref s4).ToString();
                    ChartSummary(chartSummary, cbAirpay, "tb_airpay", "airpay", "tb_game_shop", "shop_airpay");
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;               
                }
                else
                {
                    txtShopAirpay.Text = GetCountFromDatabase<string>.GetCountFromDatanaseMethod(ref  s1, ref  s2, ref  s3).ToString();
                    ChartSummary(chartSummary, cbAirpay, "tb_airpay", "airpay", "tb_game_shop", "shop_airpay");
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;               
                } 
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void cbCafeThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                int cbSelect = cbCafeThai.SelectedIndex + 1;
                string s1 = "tb_game_shop";
                string s2 = "shop_cafe_thai";
                string s3 = Convert.ToString(cbSelect);
                string s4 = dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd");
                if (checkBoxDate.Checked == true)
                {
                    txtCafeThai.Text = GetCountFromDatabase<string>.GetCountFromDatanaseMethod(ref  s1, ref  s2, ref  s3, ref s4).ToString();
                    ChartSummary(chartSummary, cbCafeThai, "tb_cafethai", "cafe_thai", "tb_game_shop", "shop_cafe_thai");
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;
                    
                }
                else
                {
                    txtCafeThai.Text = GetCountFromDatabase<string>.GetCountFromDatanaseMethod(ref  s1, ref  s2, ref  s3).ToString();
                    ChartSummary(chartSummary, cbCafeThai, "tb_cafethai", "cafe_thai", "tb_game_shop", "shop_cafe_thai");
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;
                    
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void cbShopStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                int cbSelect = cbShopStatus.SelectedIndex + 1;
                string s1 = "tb_game_shop";
                string s2 = "shop_status";
                string s3 = Convert.ToString(cbSelect);
                string s4 = dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd");
                if (checkBoxDate.Checked == true)
                {
                    txtShopStatus.Text = GetCountFromDatabase<string>.GetCountFromDatanaseMethod(ref  s1, ref  s2, ref  s3, ref s4).ToString();
                    ChartSummary(chartSummary, cbShopStatus, "tb_shop_status", "shopStatus", "tb_game_shop", "shop_status");
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;                    
                }
                else
                {
                    txtShopStatus.Text = GetCountFromDatabase<string>.GetCountFromDatanaseMethod(ref  s1, ref  s2, ref  s3).ToString();
                    ChartSummary(chartSummary, cbShopStatus, "tb_shop_status", "shopStatus", "tb_game_shop", "shop_status");
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;                    
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void cbSizeShopAirpay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try 
            {
                string where;
                string index = Convert.ToString(cbSizeShopAirpay.SelectedIndex + 1);
                if (rbShopSmall.Checked == true)
                {
                    where = "<= 20";
                    string sql = "SELECT COUNT (shop_airpay) FROM  tb_game_shop WHERE shop_airpay = "+index+" AND shop_pc "+where;
                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    txtSizeShopAirpay.Text = cmd.ExecuteScalar().ToString();
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;
                    
                }
                else if (rbShopMe.Checked == true)
                {
                    where = "BETWEEN 21 AND 40";
                    string sql = "SELECT COUNT (shop_airpay) FROM  tb_game_shop WHERE shop_airpay = " + index + " AND shop_pc " + where;
                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    txtSizeShopAirpay.Text = cmd.ExecuteScalar().ToString();
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;
                    
                }
                else if (rbShopBig.Checked == true)
                {
                    where = ">= 41";
                    string sql = "SELECT COUNT (shop_airpay) FROM  tb_game_shop WHERE shop_airpay = " + index + " AND shop_pc " + where;
                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    txtSizeShopAirpay.Text = cmd.ExecuteScalar().ToString();
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;
                    
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void cbSizeShopCafeThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                string where;
                string index = Convert.ToString(cbSizeShopCafeThai.SelectedIndex + 1);
                if (rbShopSmall.Checked == true)
                {
                    where = "<= 20";
                    string sql = "SELECT COUNT (shop_cafe_thai) FROM  tb_game_shop WHERE shop_cafe_thai = " + index + " AND shop_pc " + where;
                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    txtSizeShopCafeThai.Text = cmd.ExecuteScalar().ToString();
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;
                    
                }
                else if (rbShopMe.Checked == true)
                {
                    where = "BETWEEN 21 AND 40";
                    string sql = "SELECT COUNT (shop_cafe_thai) FROM  tb_game_shop WHERE shop_cafe_thai = " + index + " AND shop_pc " + where;
                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    txtSizeShopCafeThai.Text = cmd.ExecuteScalar().ToString();
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;
                    
                }
                else if (rbShopBig.Checked == true)
                {
                    where = ">= 41";
                    string sql = "SELECT COUNT (shop_cafe_thai) FROM  tb_game_shop WHERE shop_cafe_thai = " + index + " AND shop_pc " + where;
                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    txtSizeShopCafeThai.Text = cmd.ExecuteScalar().ToString();
                    dataGridViewSummary.Rows.Clear();
                    txtComment.Text = string.Empty;
                    
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        /// <summary>
        /// Select data from database 2 where for summary
        /// </summary>
        /// <param name="dateStatus"></param>
        /// <param name="FieldName"></param>
        /// <param name="Where"></param>
        /// <param name="date"></param>
        public void Select2Where(string dateStatus, string FieldName, string Where, string Where2 , string date)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("SelectSummary2Where", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dateStatus", SqlDbType.VarChar, 50).Value = dateStatus;  //dateStatus
                    cmd.Parameters.Add("@FieldName", SqlDbType.VarChar, 50).Value = FieldName;  //FieldName
                    cmd.Parameters.Add("@Where", SqlDbType.VarChar, 50).Value = Where;  //Where
                    cmd.Parameters.Add("@Where2", SqlDbType.VarChar, 50).Value = Where2;  //Where
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = Convert.ToDateTime(date);  //date
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridViewSummary.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridViewSummary.Rows.Add();
                            dataGridViewSummary.Rows[i].Cells[0].Value = myReader["id"];
                            dataGridViewSummary.Rows[i].Cells[1].Value = myReader["shop_id"];
                            dataGridViewSummary.Rows[i].Cells[2].Value = myReader["shop_name"];
                            dataGridViewSummary.Rows[i].Cells[3].Value = myReader["shop_master"];
                            dataGridViewSummary.Rows[i].Cells[4].Value = myReader["shop_phone"];
                            dataGridViewSummary.Rows[i].Cells[5].Value = myReader["ip_bonus"];
                            dataGridViewSummary.Rows[i].Cells[6].Value = myReader["shop_pc"];
                            dataGridViewSummary.Rows[i].Cells[7].Value = myReader["printer"];
                            dataGridViewSummary.Rows[i].Cells[8].Value = myReader["game_type"];
                            dataGridViewSummary.Rows[i].Cells[9].Value = myReader["airpay"];
                            dataGridViewSummary.Rows[i].Cells[10].Value = myReader["cafe_thai"];
                            dataGridViewSummary.Rows[i].Cells[11].Value = myReader["num_home"];
                            dataGridViewSummary.Rows[i].Cells[12].Value = myReader["zone"];
                            dataGridViewSummary.Rows[i].Cells[13].Value = myReader["street"];
                            dataGridViewSummary.Rows[i].Cells[14].Value = myReader["district"];
                            dataGridViewSummary.Rows[i].Cells[15].Value = myReader["area"];
                            dataGridViewSummary.Rows[i].Cells[16].Value = myReader["county"];
                            dataGridViewSummary.Rows[i].Cells[17].Value = myReader["shopStatus"];
                            dataGridViewSummary.Rows[i].Cells[18].Value = myReader["comment"];
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

        //IP Bonus
        private void button1_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try 
            {
                if (checkBoxDate.Checked != true)
                {
                    Select2Where("false", "ip_bonus", Convert.ToString(cbIPBonus.SelectedIndex+1), "", dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
                else if (checkBoxDate.Checked == true)
                {
                    Select2Where("true", "ip_bonus", Convert.ToString(cbIPBonus.SelectedIndex+1), "",dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        public void ChartIPBonus() 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                string sql1 = "SELECT COUNT (ip_bonus) FROM  tb_game_shop WHERE ip_bonus != 'ไม่มี'";
                SqlCommand cmd1 = new SqlCommand(sql1, db.conn);
                int NoIPBonus = Convert.ToInt32(cmd1.ExecuteScalar());

                string sql2 = "SELECT COUNT (ip_bonus) FROM  tb_game_shop WHERE ip_bonus = 'ไม่มี'";
                SqlCommand cmd2 = new SqlCommand(sql2, db.conn);
                int HaveIPBonus = Convert.ToInt32(cmd2.ExecuteScalar());

                this.chartSummary.Series["Series1"].Points.Clear();
                this.chartSummary.Series["Series1"].Points.AddXY(cbIPBonus.Items[0].ToString(), NoIPBonus);
                this.chartSummary.Series["Series1"].Points.AddXY(cbIPBonus.Items[1].ToString(), HaveIPBonus);
            }
            catch (Exception ex) { newMessagebox.error("Error : " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        //Size Shop
        private void button2_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (checkBoxDate.Checked != true)
                {
                    Select2Where("false", "shop_pc", Convert.ToString(cbSizeGameShop.SelectedIndex + 1), "", dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
                else if (checkBoxDate.Checked == true)
                {
                    Select2Where("true", "shop_pc", Convert.ToString(cbSizeGameShop.SelectedIndex + 1), "", dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }    
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        public void ChartSizeShop() 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                string sql1 = "SELECT COUNT (shop_pc) FROM  tb_game_shop WHERE shop_pc <= 20";
                SqlCommand cmd1 = new SqlCommand(sql1, db.conn);
                int SmallShop = Convert.ToInt32(cmd1.ExecuteScalar());

                string sql2 = "SELECT COUNT (shop_pc) FROM  tb_game_shop WHERE shop_pc BETWEEN 21 AND 40";
                SqlCommand cmd2 = new SqlCommand(sql2, db.conn);
                int MeShop = Convert.ToInt32(cmd2.ExecuteScalar());

                string sql3 = "SELECT COUNT (shop_pc) FROM  tb_game_shop WHERE shop_pc > 41";
                SqlCommand cmd3 = new SqlCommand(sql3, db.conn);
                int BigShop = Convert.ToInt32(cmd3.ExecuteScalar());

                this.chartSummary.Series["Series1"].Points.Clear();
                this.chartSummary.Series["Series1"].Points.AddXY(cbSizeGameShop.Items[0].ToString(), SmallShop);
                this.chartSummary.Series["Series1"].Points.AddXY(cbSizeGameShop.Items[1].ToString(), MeShop);
                this.chartSummary.Series["Series1"].Points.AddXY(cbSizeGameShop.Items[2].ToString(), BigShop);
            }
            catch (Exception ex) { newMessagebox.error("Error : " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        //Printer
        private void button3_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (checkBoxDate.Checked != true)
                {
                    Select2Where("false", "shop_printer", Convert.ToString(cbPrinter.SelectedIndex+1), "", dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
                else if (checkBoxDate.Checked == true)
                {
                    Select2Where("true", "shop_printer", Convert.ToString(cbPrinter.SelectedIndex + 1), "", dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }              
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        //Game Type
        private void button4_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (checkBoxDate.Checked != true)
                {
                    Select2Where("false", "shop_game_type", Convert.ToString(cbGameType.SelectedIndex + 1), string.Empty, dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
                else if (checkBoxDate.Checked == true)
                {
                    Select2Where("true", "shop_game_type", Convert.ToString(cbGameType.SelectedIndex + 1), string.Empty, dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                } 
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        //Airpay
        private void button5_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (checkBoxDate.Checked != true)
                {
                    Select2Where("false", "shop_airpay", Convert.ToString(cbAirpay.SelectedIndex + 1), string.Empty, dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
                else if (checkBoxDate.Checked == true)
                {
                    Select2Where("true", "shop_airpay", Convert.ToString(cbAirpay.SelectedIndex + 1), string.Empty, dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        //Cafe Thai
        private void button6_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (checkBoxDate.Checked != true)
                {
                    Select2Where("false", "shop_cafe_thai", Convert.ToString(cbCafeThai.SelectedIndex + 1), string.Empty, dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
                else if (checkBoxDate.Checked == true)
                {
                    Select2Where("true", "shop_cafe_thai", Convert.ToString(cbCafeThai.SelectedIndex + 1), string.Empty, dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        //Shop Status
        private void button7_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (checkBoxDate.Checked != true)
                {
                    Select2Where("false", "shop_status", Convert.ToString(cbShopStatus.SelectedIndex + 1), string.Empty, dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
                else if (checkBoxDate.Checked == true)
                {
                    Select2Where("true", "shop_status", Convert.ToString(cbShopStatus.SelectedIndex + 1), string.Empty, dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }


        private void rbShopSmall_CheckedChanged(object sender, EventArgs e)
        {
            txtSizeShopAirpay.Text = string.Empty;
            txtSizeShopCafeThai.Text = string.Empty;
            dataGridViewSummary.Rows.Clear();
        }
        private void rbShopMe_CheckedChanged(object sender, EventArgs e)
        {
            txtSizeShopAirpay.Text = string.Empty;
            txtSizeShopCafeThai.Text = string.Empty;
            dataGridViewSummary.Rows.Clear();
        }

        private void rbShopBig_CheckedChanged(object sender, EventArgs e)
        {
            txtSizeShopAirpay.Text = string.Empty;
            txtSizeShopCafeThai.Text = string.Empty;
            dataGridViewSummary.Rows.Clear();
        }

        //Size Shop Airpay
        private void btnAirpayInfo_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (rbShopSmall.Checked == true)
                {
                    Select2Where("false", "size_shop_airpay", Convert.ToString(cbSizeShopAirpay.SelectedIndex + 1), "1", dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
                else if (rbShopMe.Checked == true)
                {
                    Select2Where("false", "size_shop_airpay", Convert.ToString(cbSizeShopAirpay.SelectedIndex + 1), "2", dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
                else if (rbShopBig.Checked == true)
                {
                    Select2Where("false", "size_shop_airpay", Convert.ToString(cbSizeShopAirpay.SelectedIndex + 1), "3", dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        //Size Shop Cafe Thai
        private void btnCafeThaiInfo_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (rbShopSmall.Checked == true)
                {
                    Select2Where("false", "size_shop_cafe_thai", Convert.ToString(cbSizeShopCafeThai.SelectedIndex + 1), "1", dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
                else if (rbShopMe.Checked == true)
                {
                    Select2Where("false", "size_shop_cafe_thai", Convert.ToString(cbSizeShopCafeThai.SelectedIndex + 1), "2", dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
                else if (rbShopBig.Checked == true)
                {
                    Select2Where("false", "size_shop_cafe_thai", Convert.ToString(cbSizeShopCafeThai.SelectedIndex + 1), "3", dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd"));
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void dataGridViewSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if (e.RowIndex != -1)
                {
                    txtComment.Text = dataGridViewSummary["หมายเหตุ", e.RowIndex].Value.ToString();
                }
            }
            catch (Exception) { newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง"); }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                txtComment.Text = string.Empty;
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
                        dataGridViewSummary.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridViewSummary.Rows.Add();
                            dataGridViewSummary.Rows[i].Cells[0].Value = myReader["id"];
                            dataGridViewSummary.Rows[i].Cells[1].Value = myReader["shop_id"];
                            dataGridViewSummary.Rows[i].Cells[2].Value = myReader["shop_name"];
                            dataGridViewSummary.Rows[i].Cells[3].Value = myReader["shop_master"];
                            dataGridViewSummary.Rows[i].Cells[4].Value = myReader["shop_phone"];
                            dataGridViewSummary.Rows[i].Cells[5].Value = myReader["ip_bonus"];
                            dataGridViewSummary.Rows[i].Cells[6].Value = myReader["shop_pc"];
                            dataGridViewSummary.Rows[i].Cells[7].Value = myReader["printer"];
                            dataGridViewSummary.Rows[i].Cells[8].Value = myReader["game_type"];
                            dataGridViewSummary.Rows[i].Cells[9].Value = myReader["airpay"];
                            dataGridViewSummary.Rows[i].Cells[10].Value = myReader["cafe_thai"];
                            dataGridViewSummary.Rows[i].Cells[11].Value = myReader["num_home"];
                            dataGridViewSummary.Rows[i].Cells[12].Value = myReader["zone"];
                            dataGridViewSummary.Rows[i].Cells[13].Value = myReader["street"];
                            dataGridViewSummary.Rows[i].Cells[14].Value = myReader["district"];
                            dataGridViewSummary.Rows[i].Cells[15].Value = myReader["area"];
                            dataGridViewSummary.Rows[i].Cells[16].Value = myReader["county"];
                            dataGridViewSummary.Rows[i].Cells[17].Value = myReader["shopStatus"];
                            dataGridViewSummary.Rows[i].Cells[18].Value = myReader["comment"];
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
        private void button8_Click_1(object sender, EventArgs e)
        {
            
        }
//--------------------------------------------------------------------------------------//
        private void rb2D_CheckedChanged(object sender, EventArgs e)
        {
            Show3D();
        }
        private void rb3D_CheckedChanged(object sender, EventArgs e)
        {
            Show3D();
        }
//-------------------------------------------------------------------------------------//
        private void rbColumn_CheckedChanged(object sender, EventArgs e)
        {
            chartType();
        }

        private void rbBar_CheckedChanged(object sender, EventArgs e)
        {
            chartType();
        }

        private void rbPie_CheckedChanged(object sender, EventArgs e)
        {
            chartType();
        }

        private void rbLine_CheckedChanged(object sender, EventArgs e)
        {
            chartType();
        }
//--------------------------------------------------------------------------------------------//
        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            skinStyle();
        }

        private void rbRaised_CheckedChanged(object sender, EventArgs e)
        {
            skinStyle();
        }

        private void rbSunken_CheckedChanged(object sender, EventArgs e)
        {
            skinStyle();
        }

        private void rbEmboss_CheckedChanged(object sender, EventArgs e)
        {
            skinStyle();
        }

        private void rbFrameThin1_CheckedChanged(object sender, EventArgs e)
        {
            skinStyle();
        }

        private void rbFrameThin2_CheckedChanged(object sender, EventArgs e)
        {
            skinStyle();
        }
//--------------------------------------------------------------------------------------------------//

        //Chart Skin
        private void skinStyle()
        {
            try
            {
                if (rbNone.Checked == true)
                {
                    chartSummary.BorderSkin.SkinStyle = BorderSkinStyle.None;
                }
                else if (rbRaised.Checked == true)
                {
                    chartSummary.BorderSkin.SkinStyle = BorderSkinStyle.Raised;
                }
                else if (rbSunken.Checked == true)
                {
                    chartSummary.BorderSkin.SkinStyle = BorderSkinStyle.Sunken;
                }
                else if (rbEmboss.Checked == true)
                {
                    chartSummary.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                }
                else if (rbFrameThin1.Checked == true)
                {
                    chartSummary.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin1;
                }
                else if (rbFrameThin2.Checked == true)
                {
                    chartSummary.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin2;
                }
            }
            catch (Exception ex) { newMessagebox.error(ex.Message); }
        }
        //Chart Type
        private void chartType()
        {
            try
            {
                if (rbColumn.Checked == true)
                {
                    chartSummary.Series["Series1"].ChartType = SeriesChartType.Column;
                }
                else if (rbBar.Checked == true)
                {
                    chartSummary.Series["Series1"].ChartType = SeriesChartType.Bar;
                }
                else if (rbPie.Checked == true)
                {
                    chartSummary.Series["Series1"].ChartType = SeriesChartType.Pie;
                }
                else if (rbLine.Checked == true)
                {
                    if (rb3D.Checked == true)
                    {
                        newMessagebox.warring("ไม่สามารถแสดงเป็นรูปแบบ 3D ใด้");
                    }
                    else
                    {
                        chartSummary.Series["Series1"].ChartType = SeriesChartType.Line;
                    }
                }
            }
            catch (Exception ex) { newMessagebox.error(ex.Message); }
        }

        //Chart 2D or 3D
        private void Show3D()
        {
            try
            {
                if (rb2D.Checked == true)
                {
                    chartSummary.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                }
                else if (rb3D.Checked == true)
                {
                    if (rbLine.Checked == true)
                    {
                        newMessagebox.warring("ไม่สามารถแสดงเป็นรูปแบบ 3D ใด้");
                    }
                    else
                    {
                        chartSummary.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                    }
                }
            }
            catch (Exception ex) { newMessagebox.error(ex.Message); }
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Class Get Count From Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static class GetCountFromDatabase<T>
        {
            public static int GetCountFromDatanaseMethod(ref T tableName, ref T colunm, ref T  where)
            {
                try
                {
                    string sql = "SELECT COUNT (" + colunm + ") FROM " + tableName + " WHERE "+colunm+" = '" + where + "'";
                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception) { return 0; }
            }

            public static int GetCountFromDatanaseMethod(ref T tableName, ref T colunm, ref T where, ref T date)
            {
                try
                {
                    string sql = "SELECT COUNT (" + colunm + ") FROM " + tableName + " WHERE " + colunm + " = '" + where + "' AND date_add = '" + date + "'";
                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception) { return 0; }
            }
        }//end class GetCountFromDatabase<T>           
    }
}
