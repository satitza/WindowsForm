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

        {
            mainStream = client.GetStream();
            binFormatter.Serialize(mainStream, GrabDesktop());
        }

        public rdpForm()
        {
            InitializeComponent();
        }

    }
}
