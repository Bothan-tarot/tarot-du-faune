using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_du_faune
{
    public class Joueur
    {
        public string Nom { get; set; }
        public int Score { get; set; }
        public List<Carte> Hand { get; set; }
        public List<Carte> Deck { get; set; }
        public List<Carte> CarteAutorisees { get; set; }
        public bool pioche { get; set; }
        public Joueur(string nom)
        {
            Nom = nom;
            Score = 0;
            pioche = true;
            Deck = Program.deckBuilder();
            Hand = new List<Carte>();
            CarteAutorisees = new List<Carte>();
        }
    }
}
