using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_du_faune
{
    public class Hand
    {
        private List<Carte> mainDuJoueur = new List<Carte>();

        public Hand()
        {
            Carte carte = null;
            Deck deck = new Deck();
            for (int i = 0; i < 5; i++)
            {
                mainDuJoueur.Add(carte);
            }
        }
    }
}
