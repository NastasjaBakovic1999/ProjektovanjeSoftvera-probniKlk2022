using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class KlijentPoruka
    {
        public Operacija Operacija { get; set; }
        public object Objekat { get; set; }
    }
}
