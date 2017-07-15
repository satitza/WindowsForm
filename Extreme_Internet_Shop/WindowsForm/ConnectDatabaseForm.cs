using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtremeInternetShop
{
    public partial class ConnectDatabaseForm : Form
    {
        NewMessageBox newMessage = new NewMessageBox();
        MainForm main_form = new MainForm();

        public static string LoginMode { get; set; }

        public ConnectDatabaseForm()
        {
            InitializeComponent();
        }

        private void txt_connect_Click(object sender, EventArgs e)
        {
            try 
            {
                if (cbLoginMode.SelectedIndex + 1 == 1)
                {
                    LoginMode = "WindowsMode";
                    ConnectDatabase.dbHost = txtHost.Text.Trim();
                    ConnectDatabase.dbName = txtDBName.Text.Trim();
                    ConnectDatabase db = new ConnectDatabase();
                    if (db.conn.State == ConnectionState.Open)
                    {
                        this.Hide();
                        main_form.Show();
                    }
                }
                else if (cbLoginMode.SelectedIndex+1 == 2) 
                {
                    LoginMode = "SQLServerMode";
                    ConnectDatabase.dbHost = txtHost.Text.Trim();
                    ConnectDatabase.dbName = txtDBName.Text.Trim();
                    ConnectDatabase.dbUser = txtUserDB.Text.Trim();
                    ConnectDatabase.dbPassword = txtPassDB.Text.Trim();
                    ConnectDatabase db = new ConnectDatabase();
                    if (db.conn.State == ConnectionState.Open)
                    {
                        this.Hide();
                        main_form.Show();
                    }
                }                           
            }
            catch(Exception ex){newMessage.error("Error Exception"+ex.ToString());}       
        }

        private void Connect_Database_Form_Load(object sender, EventArgs e)
        {

        }

        public void HideButton() 
        {
            btnConnect.Visible = false;
        }

        private void cbLoginMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoginMode.SelectedIndex + 1 == 1)
            {
                txtUserDB.Hide();
                txtPassDB.Hide();
            }
            else if (cbLoginMode.SelectedIndex +1 == 2) 
            {
                txtUserDB.Show();
                txtPassDB.Show();
            }
        }

    }
}
