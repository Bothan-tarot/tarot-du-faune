using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_du_faune.Business;

namespace tarot_du_faune.Transport
{
    public class Joueur
    {
        public string Nom { get; set; }
        public int Score { get; set; }
        public List<Carte> Deck { get; set; }
        public List<Carte> Hand { get; set; }
        public List<Carte> CartesAutorisees { get; set; }
        public bool pioche { get; set; }
        public bool GagneLesEgalites { get; set; }
        public bool MarcheurActif { get; set; }
        public string CouleurInterdite { get; set; }
        public bool Victoire { get; set; }
        public Joueur(string nom)
        {
            Nom = nom;
            Score = 0;
            pioche = true;
            Deck = JoueurHelper.deckBuilder();
            Hand = JoueurHelper.getFuckingRandomHand(this, Deck, 5);
            CartesAutorisees = new List<Carte>();
        }
    }
}
