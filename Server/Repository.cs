using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Repository
    {
        public static Repository instance;
        private Repository()
        {

        }

        public static Repository Instance
        {
            get
            {
                if (instance == null) instance = new Repository();
                return instance;
            }
        }

        List<Korisnik> korisnici = new List<Korisnik>()
        {
            new Korisnik {Ime="K1", Prezime="k1", Email="k1@gmail.com", Sifra="sifra1"},
            new Korisnik {Ime="K2", Prezime="k2", Email="k2@gmail.com", Sifra="sifra2"},
            new Korisnik {Ime="K3", Prezime="k3", Email="k3@gmail.com", Sifra="sifra3"},
            new Korisnik {Ime="K4", Prezime="k4", Email="k4@gmail.com", Sifra="sifra4"},
        };

        public List<Korisnik> vratiSveKorisnike()
        {
            return korisnici;
        }

        public Korisnik UlogujKorisnika(Korisnik k)
        {
            return korisnici.SingleOrDefault(korisnik => korisnik.Email==k.Email && korisnik.Sifra==k.Sifra);
        }

    }
}
