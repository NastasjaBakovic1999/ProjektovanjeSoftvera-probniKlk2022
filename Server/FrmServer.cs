using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server;
        public FrmServer()
        {
            InitializeComponent();
            server = new Server();
            btnZaustavi.Enabled = false;
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            try
            {
                server.Start();

                Thread nit = new Thread(server.HandleClients);
                nit.IsBackground = true;
                nit.Start();

                MessageBox.Show("Server je pokrenut");
                btnZaustavi.Enabled = true;
                btnPokreni.Enabled = false;
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            server.Stop();
            MessageBox.Show("Server je zaustavljen!");
            btnZaustavi.Enabled = false;
            btnPokreni.Enabled = true;
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Stop();
            MessageBox.Show("Server je ugasen!");
            Environment.Exit(0);
        }
    }
}
