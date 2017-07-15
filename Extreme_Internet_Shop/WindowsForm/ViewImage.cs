using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using ExtremeInternetShop;
using System.IO;

namespace ExtremeInternetShop
{
    public partial class ViewImage : Form
    {
        ConnectDatabase db = new ConnectDatabase();
        NewMessageBox newMessagebox = new NewMessageBox();
        FileStream fileStream;

        public string ShopID { get; set; }
        public string PathImageSelected { get; set; }
        public string PathID;
 
        public ViewImage()
        {
            InitializeComponent();
        }

        private void ViewImage_Load(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            try
            {
                pictureBox1.Image = null;
                using (SqlCommand cmd = new SqlCommand("SelectPathImage", db.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ShopID", ShopID);
                    using (var myReader = cmd.ExecuteReader())
                    {
                        dataGridView1.Rows.Clear();
                        int i = 0;
                        while (myReader.Read())
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = myReader["id"];
                            dataGridView1.Rows[i].Cells[1].Value = myReader["path_image"];
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if (e.RowIndex != -1)
                {
                    PathID = dataGridView1["ID", e.RowIndex].Value.ToString();
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    PathImageSelected = dataGridView1["PathImage", e.RowIndex].Value.ToString();
                    fileStream = new FileStream(dataGridView1["PathImage", e.RowIndex].Value.ToString(), FileMode.Open, FileAccess.Read);                   
                    pictureBox1.Image = System.Drawing.Image.FromStream(fileStream);                   
                    fileStream.Close();
                }
            }
            catch (FileNotFoundException) { newMessagebox.error("ไม่พบไฟล์ที่จะแสดง ไฟล์อาจถูกลบไปแล้ว  กรุณาลบพาทในตาราง"); }
            catch (Exception){ newMessagebox.error("คุณเลือกแถวไม่ถูกต้อง"); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (db.conn.State == ConnectionState.Closed) { db.conn.Open(); }
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
            try
            {    
                 File.Delete(PathImageSelected);
                 using (SqlCommand cmd = new SqlCommand("DeletePathImage", db.conn))
                 {
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@id", Convert.ToInt32(PathID));
                      cmd.ExecuteNonQuery();
                      newMessagebox.info("ลบรูปภาพเรียบร้อยแล้ว");
                      ViewImage_Load(null, null);
                 }     
            }
            catch (SqlException ex) { newMessagebox.error("SQL Error " + ex.ToString()); }
            catch (Exception ex) { newMessagebox.error("Exception Error " + ex.ToString()); }
            finally { db.conn.Close(); }
        }
    }
}
