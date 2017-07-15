using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtremeInternetShop.Form_Report
{
    public partial class FormShopSmall : Form
    {
        public FormShopSmall()
        {
            InitializeComponent();
        }

        private void FormShopSmall_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetExtreme.tb_game_shopShopSmall' table. You can move, or remove it, as needed.
            this.tb_game_shopShopSmallTableAdapter.FillShopSmall(this.dataSetExtreme.tb_game_shopShopSmall);

            this.reportViewer1.RefreshReport();
        }
    }
}
