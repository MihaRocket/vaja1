using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DruštvoWPF
{
    [Serializable]
    public class Darovi
    {
        public int ZapŠt { get; set; }
        public DateTime Datum { get; set; }
        public string Namen { get; set; }
        public double Znesek { get; set; }
        public string Opombe { get; set; }
        public Darovi()
        {
            Datum = DateTime.Now;
        }
    }
}
