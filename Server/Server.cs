using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private Socket osluskujuciSoket;
        public List<ClientHandler> Klijenti { get; set; } = new List<ClientHandler>();

        public void Start()
        {
            if (osluskujuciSoket == null)
            {
                osluskujuciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                osluskujuciSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
                osluskujuciSoket.Listen(5);
            }
        }

        public void HandleClients()
        {
            try
            {
                while (true)
                {
                    Socket klijentskiSoket = osluskujuciSoket.Accept();
                    ClientHandler klijent = new ClientHandler(klijentskiSoket, Klijenti);
                    if (klijent.UlogujKorisnika())
                    {
                        Klijenti.Add(klijent);
                        ObavestiKlijente();
                        Thread klijentNit = new Thread(klijent.HandleRequests);
                        klijentNit.IsBackground = true;
                        klijentNit.Start();
                    }
                   
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
            }
        }

        public void ObavestiKlijente()
        {
            foreach (ClientHandler klijent in Klijenti)
            {
                klijent.PosaljiUlogovane();
            }
        }

        public void Stop()
        {
            foreach(ClientHandler klijent in Klijenti)
            {
                klijent.Stop();
            }
            osluskujuciSoket?.Close();
            osluskujuciSoket = null;
        }


    }
}
