using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_du_faune.Transport
{
    public class Pouvoir
    {
        public int Identifiant { get; set; }
        public string Libelle { get; set; }
        public string Type { get; set; }

        public Pouvoir()
        { }

        public Pouvoir(int id, string libelle, string type)
        {
            Identifiant = id;
            Libelle = libelle;
            Type = type;
        }
    }
}
