using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class ServerPoruka
    {
        public object Objekat { get; set; }
        public Operacija Operacija { get; set; }
        public string TekstOdgovora { get; set; }
        public bool UspesnaObrada { get; set; }
    }
}
