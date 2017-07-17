using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace RDPServer
{
    public partial class subForm : Form
    {
        public int port;
        private TcpClient client;
        private TcpListener server;
        private NetworkStream mainStream;

        private readonly Thread Listening;
        private readonly Thread GetImage;

        public subForm(int Port)
        {
            if(Port > 0xffff)
            {
                throw new Exception("Port number is over 65535");
            }
            try
            {
                this.port = Port;
                client = new TcpClient();
                Listening = new Thread(StratListening);
                GetImage = new Thread(ReceiveImage);
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void StratListening()
        {
            try
            {
                while (!client.Connected)
                {
                    server.Start();
                    client = server.AcceptTcpClient();
                }
                GetImage.Start();
            }
            catch (Exception)
            {
                throw new SocketException();
            }
        }

        private void StopListening()
        {
            try
            {
                server.Stop();
                client = null;
                if (Listening.IsAlive)
                {
                    Listening.Abort();
                }
                else if (GetImage.IsAlive)
                {
                    GetImage.Abort();
                }
            }
            catch (Exception)
            {
                throw new SocketException();
            }
        }
    }
}
