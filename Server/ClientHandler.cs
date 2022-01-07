using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    [Serializable]
    public class ClientHandler
    {
        private readonly Socket socket;
        private List<ClientHandler> korisnici;
        private CommunicationHelper helper;
        public ClientHandler(Socket socket, List<ClientHandler> korisnici)
        {
            this.socket = socket;
            this.korisnici = korisnici;
            helper = new CommunicationHelper(socket);
        }


        public Korisnik ulogovanKorisnik { get; set; }


        public void HandleRequests()
        {
            try
            {
                bool kraj = false;
                while (!kraj)
                {
                    KlijentPoruka zahtev = helper.Receive<KlijentPoruka>();
                    switch (zahtev.Operacija)
                    {
                        case Operacija.PosaljiSvima:
                            PosaljiSvimKorisnicima(zahtev);
                            break;
                        case Operacija.PosaljiJednom:
                            PosaljiJednomKorisniku(zahtev);
                            break;
                    }
                }
            } 
            catch(IOException ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
            }
        }

        private void PosaljiJednomKorisniku(KlijentPoruka zahtev)
        {
            Poruka poruka = (Poruka)zahtev.Objekat;
            poruka.Poslao = ulogovanKorisnik;
            poruka.VremeSlanja = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");

            ServerPoruka odgovor = new ServerPoruka()
            {
                Operacija = Operacija.PosaljiJednom,
                Objekat = poruka
            };
            
            
            foreach(ClientHandler k in korisnici){
                if(k.ulogovanKorisnik.Email == poruka.Primio.Email && k.ulogovanKorisnik.Sifra == poruka.Primio.Sifra)
                {
                    k.helper.Send(odgovor);
                    return;
                }
            }

        }

        private void PosaljiSvimKorisnicima(KlijentPoruka zahtev)
        {
            Poruka poruka = (Poruka)zahtev.Objekat;
            poruka.Poslao = ulogovanKorisnik;
            poruka.VremeSlanja = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");

            ServerPoruka odgovor = new ServerPoruka
            {
                Objekat = poruka,
                Operacija = Operacija.PosaljiSvima,
                UspesnaObrada = true
            };

            foreach (ClientHandler k in korisnici)
            {
                k.helper.Send(odgovor);
            };
        }

        public bool UlogujKorisnika()
        {
            KlijentPoruka zahtev = helper.Receive<KlijentPoruka>();

            Korisnik korisnik = (Korisnik)zahtev.Objekat;
            ServerPoruka odgovor = new ServerPoruka();

            foreach (ClientHandler k in korisnici)
            {
                if (k.ulogovanKorisnik.Email == korisnik.Email && k.ulogovanKorisnik.Sifra == korisnik.Sifra)
                {
                    odgovor.UspesnaObrada = false;
                    odgovor.TekstOdgovora = "Korisnik je vec ulogovan!";
                    helper.Send(odgovor);
                    return false;
                }
            }

            korisnik = Repository.Instance.UlogujKorisnika(korisnik);

            if (korisnik == null)
            {
                odgovor.UspesnaObrada = false;
                odgovor.TekstOdgovora = "Korisnik ne postoji!";
                helper.Send(odgovor);
                return false;
            }

            ulogovanKorisnik = korisnik;

            odgovor.UspesnaObrada = true;
            helper.Send(odgovor);
            return true;
        }

        public void PosaljiUlogovane()
        {
            List<Korisnik> ulogovaniKorisnici = new List<Korisnik>();
            foreach (ClientHandler k in korisnici)
            {
                ulogovaniKorisnici.Add(k.ulogovanKorisnik);
            }

            ServerPoruka odgovor = new ServerPoruka
            {
                Operacija=Operacija.VratiUlogovaneKorisnike,
                Objekat=ulogovaniKorisnici
            };

            helper.Send(odgovor);
        }

        public void Stop()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}