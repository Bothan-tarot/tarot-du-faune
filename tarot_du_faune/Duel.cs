using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_du_faune
{
    public class Duel
    {
        public Carte carteJoueur1 { get; set; }
        public Carte carteJoueur2 { get; set; }

        public Duel()
        {

        }

        public Duel(Carte carte1, Carte carte2)
        {
            carteJoueur1 = carte1;
            carteJoueur2 = carte2;
        }
    }
}
