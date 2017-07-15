using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtremeInternetShop;
using ExtremeInternetShop.Form_Report;
using ExtremeInternetShop.Form_Report.ReportIPBonus;
using ExtremeInternetShop.Form_Report.ReportGameType;
using ExtremeInternetShop.Form_Report.ReportAirpay;
using ExtremeInternetShop.Form_Report.ReportCafeThai;

namespace ExtremeInternetShop
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;
        NewMessageBox newMessagebox = new NewMessageBox();

        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }


        private void จดการเชอมตอฐานขอมลToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }
            ConnectDatabaseForm connect = new ConnectDatabaseForm();
            connect.MdiParent = this;
            connect.Show();
            connect.HideButton();
        }

        private void ออกจากโปรแรกมToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(newMessagebox.confirm("ยืนยันการออกจากระบบ")==true)
            {
                this.Dispose();
                Application.Exit();
            }       
        }

        private void จดการผเขาใชงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }
            Login login = new Login();
            login.MdiParent = this;
            login.Show();
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string information = "บริษัท อิเลคทรอนิคส์ เอ็กซ์ตรีม จำกัด (Electronics Extreme Limited)";
            information += "  20/99 อาคารสำนักงาน ธนวัชร ชั้น 8 ซ.งามวงศ์วาน ต.บางเขน อ.เมือง จ.นนทบุรี 11000";
            information += "  โทร 0-2951-8818 www.Extreme.co.th เลขประจำตัวผู้เสียภาษี 0-1255-57011-57-8";
            newMessagebox.info(information.ToString());
        }

        private void จดการผใชงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }
            FormUser form_user = new FormUser();
            form_user.MdiParent = this;
            form_user.Show();
        }

        private void บนทกขอมลรานเกมสใหมToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }
            AddShop add_shop = new AddShop();
            add_shop.MdiParent = this;
            add_shop.Show();
        }

        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (newMessagebox.confirm("ยืนยันการออกจากระบบ") == true)
            {
                this.Dispose();
                Application.Exit();
            }  
        }

        private void แกใขขอมลรานเกมสToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }
            ShopInformation shopInformation = new ShopInformation();
            shopInformation.MdiParent = this;
            shopInformation.Show();
        }


        private void ตงคาItemComboboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            ItemComboboxSetting itemCombobox = new ItemComboboxSetting();
            itemCombobox.MdiParent = this;         
            itemCombobox.Show();
        }

        private void รานเกมสทจะไปวนนToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            DaysToGo  dtg = new DaysToGo();
            dtg.MdiParent = this;
            dtg.Show();
        }

        private void ดนดหมายทงหมดToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            AllAppointments AllDate = new AllAppointments();
            AllDate.MdiParent = this;
            AllDate.Show();
        }

        private void สรปประจำวนToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            SummaryForm mmr = new SummaryForm();
            mmr.MdiParent = this;
            mmr.Show();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void รานเกมสขนาดเลกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormShopSmall sm = new FormShopSmall();
            sm.MdiParent = this;
            sm.Show();
        }

        private void รานเกมสขนาดกลางToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormShopMe sme = new FormShopMe();
            sme.MdiParent = this;
            sme.Show();
        }

        private void รานเกมสขนาดใหญToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormShopBig sb = new FormShopBig();
            sb.MdiParent = this;
            sb.Show();
        }

        private void รานเกมสทงหมดToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormShopAll sa = new FormShopAll();
            sa.MdiParent = this;
            sa.Show();
        }

        private void มIPBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormIPBonus ib = new FormIPBonus();
            ib.MdiParent = this;
            ib.Show();
        }

        private void ไมมIPBonusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormNoIPBonus ni = new FormNoIPBonus();
            ni.MdiParent = this;
            ni.Show();
        }

        private void ปรนทงหมดToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormIPBonusAll ia = new FormIPBonusAll();
            ia.MdiParent = this;
            ia.Show();
        }

        private void ปรนขอมลทงหมดToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormGameTypeAll gta = new FormGameTypeAll();
            gta.MdiParent = this;
            gta.Show();
        }

        private void ปรนแบบใสตวเลอกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormGameType gt = new FormGameType();
            gt.MdiParent = this;
            gt.Show();
        }

        private void ปรนขอมลทงหมดToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormReportAirpayAll apa = new FormReportAirpayAll();
            apa.MdiParent = this;
            apa.Show();
        }

        private void ปรนขอมลบางประเภทToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormReportAirpay ap = new FormReportAirpay();
            ap.MdiParent = this;
            ap.Show();
        }

        private void ปรนขอมลทงหมดToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormReportCafeThaiAll cta = new FormReportCafeThaiAll();
            cta.MdiParent = this;
            cta.Show();
        }

        private void ปรนขอมลบางประเภทToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }

            FormReportCafeThai ct = new FormReportCafeThai();
            ct.MdiParent = this;
            ct.Show();
        }
    }
}
