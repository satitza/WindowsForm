using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtremeInternetShop.Form_Report.ReportCafeThai
{
    public partial class FormReportCafeThaiAll : Form
    {
        public FormReportCafeThaiAll()
        {
            InitializeComponent();
        }

        private void FormReportCafeThaiAll_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetExtreme.tb_game_shopCafeThaiAll' table. You can move, or remove it, as needed.
            this.tb_game_shopCafeThaiAllTableAdapter.FillCafeThaiAll(this.dataSetExtreme.tb_game_shopCafeThaiAll);

            this.reportViewer1.RefreshReport();
        }
    }
}
