using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Poruka
    {
        
        public string TekstPoruke { get; set; }
        public Korisnik Poslao { get; set; }
        public Korisnik Primio { get; set; }
        public string VremeSlanja { get; set; }
        public TipSlanja TipSlanja { get; set; }
    }
}
