using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_du_faune.Transport
{
    public class Partie
    {
        public List<Duel> DuelsJoues { get; set; }
        static public int NbPlis { get; set; }
        public Joueur Joueur1 { get; set; }
        public Joueur Joueur2 { get; set; }

        public Partie()
        { }

        public Partie(int nbPlis)
        {
            DuelsJoues = new List<Duel>();
            NbPlis = nbPlis;
        }
    }
}
