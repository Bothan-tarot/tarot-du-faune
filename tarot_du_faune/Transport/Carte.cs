using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_du_faune.Transport
{
    public class Carte
    {
        public string Libelle { get; set; }
        public string Famille { get; set; }
        public int Valeur { get; set; }
        public Pouvoir Pouvoir { get; set; }

        public Carte() { }

        public Carte(string famille, int valeur, string libelle)
        {
            Famille = famille;
            Valeur = valeur;
            Libelle = libelle;
        }

        public Carte(string famille, int valeur, string libelle, Pouvoir pouvoir)
        {
            Famille = famille;
            Valeur = valeur;
            Libelle = libelle;
            Pouvoir = pouvoir;
        }
    }
}
