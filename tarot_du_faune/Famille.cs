using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_du_faune
{
    class Famille
    {
        public string Libelle { get; set; }
        public string LibelleFamilleOpposee { get; set; }

        public Famille(string libelle, string familleOpposee)
        {
            Libelle = libelle;
            LibelleFamilleOpposee = familleOpposee;
        }
    }
}
