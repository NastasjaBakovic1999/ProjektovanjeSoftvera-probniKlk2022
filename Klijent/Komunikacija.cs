using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public class Komunikacija
    {
        private static Komunikacija instance;
        private Socket socket;
        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();
        private Komunikacija()
        {

        }
        public static Komunikacija Instance
        {
            get
            {
                if (instance == null) instance = new Komunikacija();
                return instance;
            }
        }

        public DialogResult PrijaviSe(string email, string sifra)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("127.0.0.1", 9999);
                stream = new NetworkStream(socket);

                KlijentPoruka zahtev = new KlijentPoruka
                {
                    Objekat = new Korisnik
                    {
                        Email = email,
                        Sifra = sifra
                    }
                };

                formatter.Serialize(stream, zahtev);
                ServerPoruka odgovor = (ServerPoruka)formatter.Deserialize(stream);

                if (odgovor.UspesnaObrada == false)
                {
                    socket.Close();
                    MessageBox.Show(odgovor.TekstOdgovora);
                    return DialogResult.Cancel;
                }
                else
                {
                    MessageBox.Show("Uspesno povezan sa serverom!");
                    return DialogResult.OK;
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(">>>>" + ex.Message);
                return DialogResult.Cancel;
            }
        }

        public void PosaljiPoruku(KlijentPoruka zahtev)
        {
            formatter.Serialize(stream, zahtev);
        }

        public ServerPoruka ProcitajPorukuOdServera()
        {
            return (ServerPoruka)formatter.Deserialize(stream);
        }
    }
}
