using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_du_faune.Transport;

namespace tarot_du_faune.Business
{
    public static class CarteHelper
    {
        static bool isFamilleOpposee(string familleCarteEnCours, string familleCartePrecedente)
        {
            bool familleOpposee = false;
            if (familleCarteEnCours == "BOIS" && familleCarteEnCours == "YEUX")
            {
                familleOpposee = true;
            }
            else if (familleCarteEnCours == "YEUX" && familleCartePrecedente == "BOIS")
            {
                familleOpposee = true;
            }
            else if (familleCarteEnCours == "COEUR" && familleCartePrecedente == "FLAMME")
            {
                familleOpposee = true;
            }
            else if (familleCarteEnCours == "FLAMME" && familleCartePrecedente == "COEUR")
            {
                familleOpposee = true;
            }
            return familleOpposee;
        }

        static public Partie MajCartesAutorisees(Partie partie)
        {
            string famillePrecedenteJoueur1 = string.Empty;
            string famillePrecedenteJoueur2 = string.Empty;
            partie.Joueur1.CartesAutorisees = new List<Carte>();
            partie.Joueur2.CartesAutorisees = new List<Carte>();

            if (partie.DuelsJoues.Count > 0)
            {
                Duel duelPrecedent = new Duel();
                duelPrecedent = partie.DuelsJoues[partie.DuelsJoues.Count - 1];
                famillePrecedenteJoueur1 = duelPrecedent.carteJoueur1.Famille;
                famillePrecedenteJoueur2 = duelPrecedent.carteJoueur2.Famille;
            }
            //Cas du joueur 1
            //Famille de la dernière carte jouée
            foreach (Carte c in partie.Joueur1.Hand)
            {
                //Si la famille d'une carte de la main n'est pas opposée à celle de la carte jouée au dernier tour, alors on l'ajoute à la liste
                if (string.IsNullOrEmpty(famillePrecedenteJoueur1) || !isFamilleOpposee(c.Famille, famillePrecedenteJoueur1))
                {
                    if(!string.Equals(partie.Joueur1.CouleurInterdite, c.Famille))
                    {
                        partie.Joueur1.CartesAutorisees.Add(c);
                    }
                }
            }

            //Cas du joueur 2
            foreach (Carte c in partie.Joueur2.Hand)
            {
                //Si la famille d'une carte de la main n'est pas opposée à celle de la carte jouée au dernier tour, alors on l'ajoute à la liste
                if (!isFamilleOpposee(c.Famille, famillePrecedenteJoueur2))
                {
                    if (!string.Equals(partie.Joueur2.CouleurInterdite, c.Famille))
                    {
                        partie.Joueur2.CartesAutorisees.Add(c);
                    }
                }
            }

            return partie;
        }

        public static Carte ObtenirCarte(List<Carte> listCartes, int value)
        {
            Carte card = new Carte();

            foreach (Carte carte in listCartes)
            {
                if (carte.Valeur == value)
                {
                    card = carte;
                    break;
                }
            }
            return card;
        }

        public static int ObtenirPositionCarte(List<Carte> listCartes, int value)
        {
            int pos = 0;

            for (int i = 0; i < listCartes.Count; i++)
            {
                if (listCartes[i].Valeur == value)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public static Carte PiocherCarte(Joueur player)
        {
            Carte c = null;
            if (player.Deck.Count > 0)
            {
                Random rnd = new Random();
                int i = rnd.Next(0, player.Deck.Count);
                c = ObtenirCarte(player.Deck, i);
            }
            return c;
        }

        public static List<Carte> RetirerCarteListe(List<Carte> l, int valeurCarte)
        {
            List<Carte> liste = l;
            l.RemoveAt(ObtenirPositionCarte(l, valeurCarte));
            return liste;
        }

        public static List<Carte> DefausserCartes(List<Carte> l, int nbCartes)
        {
            l.RemoveRange(0, nbCartes-1);
            return l;
        }

        public static List<Carte> AjouterCarteListe(List<Carte> l, Carte c)
        {
            List<Carte> liste = l;
            l.Add(c);
            return liste;
        }

        public static Joueur JouerCarte(Joueur j, Carte c)
        {
            j.Hand = RetirerCarteListe(j.Hand, c.Valeur);
            return j;
        }
    }
}
