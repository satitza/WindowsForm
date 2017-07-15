using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtremeInternetShop.Form_Report.ReportAirpay
{
    public partial class FormReportAirpayAll : Form
    {
        public FormReportAirpayAll()
        {
            InitializeComponent();
        }

        private void FormReportAirpayAll_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetExtreme.tb_game_shopAirpayAll' table. You can move, or remove it, as needed.
            this.tb_game_shopAirpayAllTableAdapter.FillAirpayAll(this.dataSetExtreme.tb_game_shopAirpayAll);

            this.reportViewer1.RefreshReport();
        }
    }
}
