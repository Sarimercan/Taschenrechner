using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    internal class Benutzer
    {
        public int Id { get; set; }
        public string Benutzername { get; set; } = null!;
        public string Passwort { get; set; } = null!;
        public string vorherigeOprationen { get; set; } = null!;
        public string eigabePasswort { get; set; } = null!;
    }
}
