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

namespace Extreme_Internet_Shop
{
    public partial class ImagePath : Form
    {
        ConnectDatabase db = new ConnectDatabase();
        NewMessageBox newMessagebox = new NewMessageBox();
        //public string pathSelected = null;
        public string path { get; set; }
        public ImagePath()
        {
            InitializeComponent();
        }

        public void btnBrowse_Click(object sender, EventArgs e)
        {
             folderBrowserDialog1.ShowDialog();
             string pathSeleted = folderBrowserDialog1.SelectedPath.Trim();
             lbImagePath.Text = pathSeleted;                
        }

        /// <summary>
        /// Form >Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImagePath_Load(object sender, EventArgs e)
        {
            if(db.conn.State == ConnectionState.Closed)
            {
                db.conn.Open();
            }
            try 
            {
                    string sql = "SELECT path FROM tb_image_path";
                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    using (var myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            if (myReader["path"] != null)
                            {
                                lbImagePath.Text = myReader["path"].ToString();                             
                                path = lbImagePath.ToString();
                            }
                        }     
                    }              
                    db.conn.Close();     
            }
            catch(SqlException ex)
            {
                newMessagebox.error("SQL Error "+ex.ToString());
            }
            catch(Exception ex)
            {
                newMessagebox.error("Exception Error "+ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(db.conn.State == ConnectionState.Closed)
            {
                db.conn.Open();
            }
            try 
            {
                if (path == null)
                {
                    string sql = "INSERT INTO tb_image_path VALUES(1,'" + lbImagePath.Text + "')";
                    db.SQLStatment(sql);
                    newMessagebox.info("บันทึกพาทเก็บไฟล์ภาพเรียบร้อยแล้ว");
                    ImagePath_Load(null, null);
                }
                else if(path != null)
                {
                    string sql = "UPDATE tb_image_path SET path = '"+lbImagePath.Text+"' WHERE id = 1";
                    db.SQLStatment(sql);
                    newMessagebox.info("แก้ใขพาทเก็บไฟล์ภาพเรียบร้อยแล้ว");
                    ImagePath_Load(null, null);
                }

                db.conn.Close();
            }
            catch(SqlException ex)
            {
                newMessagebox.error("SQL Error " + ex.ToString());
            }
            catch(Exception ex)
            {
                newMessagebox.error("Exception Error " + ex.ToString());
            }
        }
    }
}
