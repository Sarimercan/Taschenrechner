using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    internal class Rechnung
    {
        public int Id { get; set; }
        public double Zahl { get; set; }
        public double Zahl2 { get; set; }
        public double Ergebnis { get; set; }
        public string Operation { get; set; } = null!;
    }
}
