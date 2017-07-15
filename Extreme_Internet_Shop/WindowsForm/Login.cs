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
    public partial class Login : Form
    {
        ConnectDatabase db = new ConnectDatabase();       
        NewMessageBox newMessage = new NewMessageBox();
        MainForm mainForm = new MainForm();

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(db.conn.State == ConnectionState.Closed){db.conn.Open();}
           try
           {
               string user = txtUsername.Text.Trim().ToString();
               string pass = txtPassword.Text.Trim().ToString();

               using(SqlCommand cmd = new SqlCommand("CheckLogin", db.conn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                   cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                   using(var myReader = cmd.ExecuteReader())
                   {
                       if (myReader.Read() == true)
                       {
                           this.Hide();
                           mainForm.Show();
                           myReader.Close();
                           this.Hide();
                       }
                       else { newMessage.error("Username หรือ Password ไม่ถูกต้อง"); }
                   }
               }             
           }
           catch (SqlException ex) { newMessage.error("SQL Error " + ex.ToString()); }
           catch (Exception ex) { newMessage.error("Error Exception " + ex.ToString()); }
           finally { db.conn.Close(); }
        }

        private void Login_Load(object sender, EventArgs e)
        {
                //txtUsername.Text = "anonymous";//prep_user.ToString();
                //txtPassword.Text = "dr823c1HEE";// prep_pass.ToString();                    
        }
    }
}
