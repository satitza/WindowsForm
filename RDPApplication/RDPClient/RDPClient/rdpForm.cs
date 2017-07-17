using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDPClient
{
    public partial class rdpForm : Form
    {
        private readonly TcpClient client = new TcpClient();
        private NetworkStream mainStream;
        private int PortNumber;

        private static Image GrabDesktop()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(screenshot);
            graphics.CopyFromScreen(bounds.X, bounds.X, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
            return screenshot;
        }

        private void SendDesktopImage()
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            mainStream = client.GetStream();
            binFormatter.Serialize(mainStream, GrabDesktop());
        }

        public rdpForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            PortNumber = int.Parse(txtPort.Text);
            try
            {
                client.Connect(txtAddress.Text, PortNumber);
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnScreen_Click(object sender, EventArgs e)
        {
            if (btnScreen.Text.StartsWith("Screen"))
            {
                timer1.Start();
                btnScreen.Text = "Stop Screen";
            }
            else
            {
                timer1.Stop();
                btnScreen.Text = "Screen";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SendDesktopImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error ตรงนี้ป่าววะ -*-");
            }
        }
    }
}
