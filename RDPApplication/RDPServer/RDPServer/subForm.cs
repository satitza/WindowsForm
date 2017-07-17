using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDPServer
{
    public partial class subForm : Form
    {
        public int port;

        public subForm(int Port)
        {
            if (Port == null)
            {
                throw new ArgumentNullException();
            }
            else if(Port > 0xffff)
            {
                throw new Exception("Port number is over 65535");
            }
            this.port = Port;
            InitializeComponent();
        }
    }
}
