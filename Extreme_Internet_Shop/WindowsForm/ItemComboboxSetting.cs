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
    public partial class ItemComboboxSetting : Form
    {
        ConnectDatabase db = new ConnectDatabase();
        NewMessageBox newMessagebox = new NewMessageBox();

        public int PropID { get; set; }


        public ItemComboboxSetting()
        {
            InitializeComponent();
        }

        private void ItemComboboxSetting_Load(object sender, EventArgs e)
        {
            try
            {
                SelectDataComboboxSupport("tb_shop_support", "id", "shop_support");
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error "+ex.ToString()); }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageSupport"])
                {   
                    SelectDataComboboxSupport ("tb_shop_support", "id", "shop_support");
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageMemStatus"])
                {
                    SelectDataComboboxMemberStatus ("tb_member_status", "id", "mem_status");
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPagePrinter"])
                {
                    SelectDataComboboxPrinter ("tb_printer", "id", "printer");
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageGameType"])
                {
                    SelectDataComboboxGameType("tb_game_type", "id", "game_type");
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageAirpay"])
                {
                    SelectDataComboboxAirpay("tb_airpay", "id", "airpay");
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageCafeThai"])
                {
                    SelectDataComboboxCafeThai("tb_cafethai", "id", "cafe_thai");
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageShopStatus"])
                {
                    SelectDataComboboxShopStatus("tb_shop_status", "id", "shopStatus");
                }
            }
            catch (Exception ex) { newMessagebox.error("Exception Error "+ex.ToString()); }
        }

        /// <summary>
        /// PageSupport
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ID"></param>
        /// <param name="Value"></param>
        public void SelectDataComboboxSupport (string tableName, string ID, string Value) 
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                txtSupportID.Text = db.auto_id (tableName, ID).ToString();
                using (SqlCommand cmd = new SqlCommand ("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue ("@tableName", tableName);
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridViewSupport.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridViewSupport.Rows.Add();
                            dataGridViewSupport.Rows[i].Cells[0].Value = myReader[ID];
                            dataGridViewSupport.Rows[i].Cells[1].Value = myReader[Value];
                            i++;
                        }
                        myReader.Close();
                    }
                } 
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error "+ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error "+ex.ToString()); }
        }

        /// <summary>
        /// Page Member Status
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ID"></param>
        /// <param name="Value"></param>
        public void SelectDataComboboxMemberStatus(string tableName, string ID, string Value)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                txtMemStatusID.Text = db.auto_id(tableName, ID).ToString();
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", tableName);
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridViewMemberStatus.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridViewMemberStatus.Rows.Add();
                            dataGridViewMemberStatus.Rows[i].Cells[0].Value = myReader[ID];
                            dataGridViewMemberStatus.Rows[i].Cells[1].Value = myReader[Value];
                            i++;
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
        }

        /// <summary>
        /// Page Printer
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ID"></param>
        /// <param name="Value"></param>
        public void SelectDataComboboxPrinter(string tableName, string ID, string Value)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                txtPrinterID.Text = db.auto_id(tableName, ID).ToString();
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", tableName);
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridViewPrinter.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridViewPrinter.Rows.Add();
                            dataGridViewPrinter.Rows[i].Cells[0].Value = myReader[ID];
                            dataGridViewPrinter.Rows[i].Cells[1].Value = myReader[Value];
                            i++;
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
        }

        /// <summary>
        /// Page Game Type
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ID"></param>
        /// <param name="Value"></param>
        public void SelectDataComboboxGameType(string tableName, string ID, string Value)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                txtGameTypeID.Text = db.auto_id(tableName, ID).ToString();
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", tableName);
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridViewGameType.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridViewGameType.Rows.Add();
                            dataGridViewGameType.Rows[i].Cells[0].Value = myReader[ID];
                            dataGridViewGameType.Rows[i].Cells[1].Value = myReader[Value];
                            i++;
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
        }

        /// <summary>
        /// Page Airpay
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ID"></param>
        /// <param name="Value"></param>
        public void SelectDataComboboxAirpay(string tableName, string ID, string Value)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                txtAirpayID.Text = db.auto_id(tableName, ID).ToString();
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", tableName);
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridViewAirpay.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridViewAirpay.Rows.Add();
                            dataGridViewAirpay.Rows[i].Cells[0].Value = myReader[ID];
                            dataGridViewAirpay.Rows[i].Cells[1].Value = myReader[Value];
                            i++;
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
        }


        /// <summary>
        /// Page Cafe Thai
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ID"></param>
        /// <param name="Value"></param>
        public void SelectDataComboboxCafeThai(string tableName, string ID, string Value)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                txtCafeThaiID.Text = db.auto_id(tableName, ID).ToString();
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", tableName);
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridViewCafeThai.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridViewCafeThai.Rows.Add();
                            dataGridViewCafeThai.Rows[i].Cells[0].Value = myReader[ID];
                            dataGridViewCafeThai.Rows[i].Cells[1].Value = myReader[Value];
                            i++;
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
        }

        /// <summary>
        /// Page Shop Status
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ID"></param>
        /// <param name="Value"></param>
        public void SelectDataComboboxShopStatus(string tableName, string ID, string Value)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                txtShopStatusID.Text = db.auto_id(tableName, ID).ToString();
                using (SqlCommand cmd = new SqlCommand("SelectDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", tableName);
                    using (var myReader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        dataGridViewShopStatus.Rows.Clear();
                        while (myReader.Read())
                        {
                            dataGridViewShopStatus.Rows.Add();
                            dataGridViewShopStatus.Rows[i].Cells[0].Value = myReader[ID];
                            dataGridViewShopStatus.Rows[i].Cells[1].Value = myReader[Value];
                            i++;
                        }
                        myReader.Close();
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
        }


        //--------------------------------------------Page Shop Support------------------------------------------------------------------------------//

        private void btnsSupportSave_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (txtSupportValue.Text == "")
                {
                    newMessagebox.warring("คุณยังไม่ใด้ใส่ Value");
                    txtSupportValue.Focus();
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("InsertDataForCombobox", db.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TableName", "tb_shop_support");
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtSupportID.Text));
                        cmd.Parameters.AddWithValue("@Value", txtSupportValue.Text);
                        cmd.ExecuteNonQuery();
                        newMessagebox.info("บันทึกข้อมูลเรียบร้อยแล้ว");
                        SelectDataComboboxSupport("tb_shop_support", "id", "shop_support");
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Exception " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }
        private void dataGridViewSupport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    txtSupportID.Text = dataGridViewSupport["SupportID", e.RowIndex].Value.ToString();
                    PropID = Convert.ToInt32(dataGridViewSupport["SupportID", e.RowIndex].Value.ToString());
                    txtSupportValue.Text = dataGridViewSupport["SupportValue", e.RowIndex].Value.ToString();
                }
            }
            catch (Exception) { newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง"); }
        }
        private void btnSupportClear_Click(object sender, EventArgs e)
        {
            txtSupportValue.Text = "";
            SelectDataComboboxSupport("tb_shop_support", "id", "shop_support");
        }
        private void btnSupportEdit_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_shop_support");
                    cmd.Parameters.AddWithValue("@NewID", Convert.ToInt32(txtSupportID.Text));
                    cmd.Parameters.AddWithValue("@Value", txtSupportValue.Text);
                    cmd.Parameters.AddWithValue("@OldID", Convert.ToInt32(PropID));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("แก้ใขข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxSupport("tb_shop_support", "id", "shop_support");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnSupportDelete_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_shop_support");
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtSupportID.Text));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("ลบข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxSupport("tb_shop_support", "id", "shop_support");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }
       
        //-------------------------------------------------------------------------------------------------------------------------------------------//
        
        //-------------------------------------------Page Member Status------------------------------------------------------------------------------//
        private void btnMemStatusSave_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (txtMemStatusValue.Text == "")
                {
                    newMessagebox.warring("คุณยังไม่ใด้ใส่ Value");
                    txtMemStatusValue.Focus();
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("InsertDataForCombobox", db.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TableName", "tb_member_status");
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtMemStatusID.Text));
                        cmd.Parameters.AddWithValue("@Value", txtMemStatusValue.Text);
                        cmd.ExecuteNonQuery();
                        newMessagebox.info("บันทึกข้อมูลเรียบร้อยแล้ว");
                        SelectDataComboboxMemberStatus("tb_member_status", "id", "mem_status");
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Exception " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void dataGridViewMemberStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    txtMemStatusID.Text = dataGridViewMemberStatus["MemberStatusID", e.RowIndex].Value.ToString();
                    PropID = Convert.ToInt32(dataGridViewMemberStatus["MemberStatusID", e.RowIndex].Value.ToString());
                    txtMemStatusValue.Text = dataGridViewMemberStatus["MemberStatusValue", e.RowIndex].Value.ToString();
                }
            }
            catch (Exception) { newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง"); }
        }

        private void btnMemStatusClear_Click(object sender, EventArgs e)
        {
            txtMemStatusValue.Text = "";
            SelectDataComboboxMemberStatus("tb_member_status", "id", "mem_status");
        }

        private void btnMemStatusEdit_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_member_status");
                    cmd.Parameters.AddWithValue("@NewID", Convert.ToInt32(txtMemStatusID.Text));
                    cmd.Parameters.AddWithValue("@Value", txtMemStatusValue.Text);
                    cmd.Parameters.AddWithValue("@OldID", Convert.ToInt32(PropID));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("แก้ใขข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxMemberStatus("tb_member_status", "id", "mem_status");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnMemStatusDelete_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_member_status");
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtMemStatusID.Text));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("ลบข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxMemberStatus("tb_member_status", "id", "mem_status");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        

        //-------------------------------------------------------------------------------------------------------------------------------------------//

        //-----------------------------------------------Page printer--------------------------------------------------------------------------------//
        private void btnPrinterSave_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (txtPrinterValue.Text == "")
                {
                    newMessagebox.warring("คุณยังไม่ใด้ใส่ Value");
                    txtPrinterValue.Focus();
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("InsertDataForCombobox", db.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TableName", "tb_printer");
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtPrinterID.Text));
                        cmd.Parameters.AddWithValue("@Value", txtPrinterValue.Text);
                        cmd.ExecuteNonQuery();
                        newMessagebox.info("บันทึกข้อมูลเรียบร้อยแล้ว");
                        SelectDataComboboxPrinter("tb_printer", "id", "printer");
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Exception " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void dataGridViewPrinter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    txtPrinterID.Text = dataGridViewPrinter["PrinterID", e.RowIndex].Value.ToString();
                    PropID = Convert.ToInt32(dataGridViewPrinter["PrinterID", e.RowIndex].Value.ToString());
                    txtPrinterValue.Text = dataGridViewPrinter["PrinterValue", e.RowIndex].Value.ToString();
                }
            }
            catch (Exception) { newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง"); }
        }

        private void btnPrinterClear_Click(object sender, EventArgs e)
        {
            txtPrinterValue.Text = "";
            SelectDataComboboxPrinter("tb_printer", "id", "printer");
        }

        private void btnPrinterEdit_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_printer");
                    cmd.Parameters.AddWithValue("@NewID", Convert.ToInt32(txtPrinterID.Text));
                    cmd.Parameters.AddWithValue("@Value", txtPrinterValue.Text);
                    cmd.Parameters.AddWithValue("@OldID", Convert.ToInt32(PropID));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("แก้ใขข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxPrinter("tb_printer", "id", "printer");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnPrinterDelete_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_printer");
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtPrinterID.Text));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("ลบข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxPrinter("tb_printer", "id", "printer");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

       

        //-------------------------------------------------------------------------------------------------------------------------------------------//

        //--------------------------------------------------Page Game Type---------------------------------------------------------------------------//

        private void btnGameTypeSave_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (txtGameTypeValue.Text == "")
                {
                    newMessagebox.warring("คุณยังไม่ใด้ใส่ Value");
                    txtGameTypeValue.Focus();
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("InsertDataForCombobox", db.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TableName", "tb_game_type");
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtGameTypeID.Text));
                        cmd.Parameters.AddWithValue("@Value", txtGameTypeValue.Text);
                        cmd.ExecuteNonQuery();
                        newMessagebox.info("บันทึกข้อมูลเรียบร้อยแล้ว");
                        SelectDataComboboxGameType("tb_game_type", "id", "game_type");
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Exception " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void dataGridViewGameType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    txtGameTypeID.Text = dataGridViewGameType["GameTypeID", e.RowIndex].Value.ToString();
                    PropID = Convert.ToInt32(dataGridViewGameType["GameTypeID", e.RowIndex].Value.ToString());
                    txtGameTypeValue.Text = dataGridViewGameType["GameTypeValue", e.RowIndex].Value.ToString();
                }
            }
            catch (Exception) { newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง"); }
        }

        private void btnGamteTypeClear_Click(object sender, EventArgs e)
        {
            txtGameTypeValue.Text = "";
            SelectDataComboboxGameType("tb_game_type", "id", "game_type");
        }

        private void btnGameTypeEdit_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_game_type");
                    cmd.Parameters.AddWithValue("@NewID", Convert.ToInt32(txtGameTypeID.Text));
                    cmd.Parameters.AddWithValue("@Value", txtGameTypeValue.Text);
                    cmd.Parameters.AddWithValue("@OldID", Convert.ToInt32(PropID));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("แก้ใขข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxGameType("tb_game_type", "id", "game_type");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnGameTypeDelete_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_game_type");
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtGameTypeID.Text));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("ลบข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxGameType("tb_game_type", "id", "game_type");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------//

        //-------------------------------------------------------Page Airpay-------------------------------------------------------------------------//
        private void btnAirpaySave_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (txtAirpayValue.Text == "")
                {
                    newMessagebox.warring("คุณยังไม่ใด้ใส่ Value");
                    txtAirpayValue.Focus();
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("InsertDataForCombobox", db.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TableName", "tb_airpay");
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtAirpayID.Text));
                        cmd.Parameters.AddWithValue("@Value", txtAirpayValue.Text);
                        cmd.ExecuteNonQuery();
                        newMessagebox.info("บันทึกข้อมูลเรียบร้อยแล้ว");
                        SelectDataComboboxAirpay("tb_airpay", "id", "airpay");
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Exception " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void dataGridViewAirpay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    txtAirpayID.Text = dataGridViewAirpay["AirpayID", e.RowIndex].Value.ToString();
                    PropID = Convert.ToInt32(dataGridViewAirpay["AirpayID", e.RowIndex].Value.ToString());
                    txtAirpayValue.Text = dataGridViewAirpay["AirpayValue", e.RowIndex].Value.ToString();
                }
            }
            catch (Exception) { newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง"); }
        }

        private void btnAirpayClear_Click(object sender, EventArgs e)
        {
            txtAirpayValue.Text = "";
            SelectDataComboboxAirpay("tb_airpay", "id", "airpay");
        }

        private void btnAirpayEdit_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_airpay");
                    cmd.Parameters.AddWithValue("@NewID", Convert.ToInt32(txtAirpayID.Text));
                    cmd.Parameters.AddWithValue("@Value", txtAirpayValue.Text);
                    cmd.Parameters.AddWithValue("@OldID", Convert.ToInt32(PropID));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("แก้ใขข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxAirpay("tb_airpay", "id", "airpay");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnAirpayDelete_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_airpay");
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtAirpayID.Text));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("ลบข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxAirpay("tb_airpay", "id", "airpay");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        

        //-------------------------------------------------------------------------------------------------------------------------------------------//
        
        //-----------------------------------------------Page Auto Update Cafe Thai------------------------------------------------------------------//
        private void btnCafeThaiSave_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (txtCafeThaiValue.Text == "")
                {
                    newMessagebox.warring("คุณยังไม่ใด้ใส่ Value");
                    txtCafeThaiValue.Focus();
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("InsertDataForCombobox", db.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TableName", "tb_cafethai");
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtCafeThaiID.Text));
                        cmd.Parameters.AddWithValue("@Value", txtCafeThaiValue.Text);
                        cmd.ExecuteNonQuery();
                        newMessagebox.info("บันทึกข้อมูลเรียบร้อยแล้ว");
                        SelectDataComboboxCafeThai("tb_cafethai", "id", "cafe_thai");
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Exception " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }
        private void dataGridViewCafeThai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    txtCafeThaiID.Text = dataGridViewCafeThai["CafeThaiID", e.RowIndex].Value.ToString();
                    PropID = Convert.ToInt32(dataGridViewCafeThai["CafeThaiID", e.RowIndex].Value.ToString());
                    txtCafeThaiValue.Text = dataGridViewCafeThai["CafeThaiValue", e.RowIndex].Value.ToString();
                }
            }
            catch (Exception) { newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง"); }
        }

        private void btnCafeThaiClear_Click(object sender, EventArgs e)
        {
            txtCafeThaiValue.Text = "";
            SelectDataComboboxCafeThai("tb_cafethai", "id", "cafe_thai");
        }

        private void btnCafeThaiEdit_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_cafethai");
                    cmd.Parameters.AddWithValue("@NewID", Convert.ToInt32(txtCafeThaiID.Text));
                    cmd.Parameters.AddWithValue("@Value", txtCafeThaiValue.Text);
                    cmd.Parameters.AddWithValue("@OldID", Convert.ToInt32(PropID));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("แก้ใขข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxCafeThai("tb_cafethai", "id", "cafe_thai");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnCafeThaiDelete_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_cafethai");
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtCafeThaiID.Text));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("ลบข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxCafeThai("tb_cafethai", "id", "cafe_thai");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        

        
        //-------------------------------------------------------------------------------------------------------------------------------------------//

        //---------------------------------------------------Page Shop Status------------------------------------------------------------------------//
        private void btnShopStatusSave_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                if (txtShopStatusValue.Text == "")
                {
                    newMessagebox.warring("คุณยังไม่ใด้ใส่ Value");
                    txtShopStatusValue.Focus();
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("InsertDataForCombobox", db.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TableName", "tb_shop_status");
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtShopStatusID.Text));
                        cmd.Parameters.AddWithValue("@Value", txtShopStatusValue.Text);
                        cmd.ExecuteNonQuery();
                        newMessagebox.info("บันทึกข้อมูลเรียบร้อยแล้ว");
                        SelectDataComboboxShopStatus("tb_shop_status", "id", "shopStatus");
                    }
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Exception " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void dataGridViewShopStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    txtShopStatusID.Text = dataGridViewShopStatus["ShopStatusID", e.RowIndex].Value.ToString();
                    PropID = Convert.ToInt32(dataGridViewShopStatus["ShopStatusID", e.RowIndex].Value.ToString());
                    txtShopStatusValue.Text = dataGridViewShopStatus["ShopStatusValue", e.RowIndex].Value.ToString();
                }
            }
            catch (Exception) { newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง"); }
        }

        private void btnShopStatusClear_Click(object sender, EventArgs e)
        {
            txtShopStatusValue.Text = "";
            SelectDataComboboxShopStatus("tb_shop_status", "id", "shopStatus");
        }

        private void btnShopStatusEdit_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_shop_status");
                    cmd.Parameters.AddWithValue("@NewID", Convert.ToInt32(txtShopStatusID.Text));
                    cmd.Parameters.AddWithValue("@Value", txtShopStatusValue.Text);
                    cmd.Parameters.AddWithValue("@OldID", Convert.ToInt32(PropID));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("แก้ใขข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxShopStatus("tb_shop_status", "id", "shopStatus");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }

        private void btnShopStatusDelete_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDataForCombobox", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tb_shop_status");
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtShopStatusID.Text));
                    cmd.ExecuteNonQuery();
                    newMessagebox.info("ลบข้อมูลเรียบร้อยแล้ว");
                    SelectDataComboboxShopStatus("tb_shop_status", "id", "shopStatus");
                }
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------//

    }
}
