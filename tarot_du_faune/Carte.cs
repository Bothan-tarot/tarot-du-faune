using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_du_faune
{
    public class Carte
    {
        public string Libelle { get; set; }
        public string Famille { get; set; }
        public int Valeur { get; set; }
        public Pouvoir Pouvoir { get; set; }

        public Carte(){ }

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

        static bool isCarteJouable(List<Carte> cartesAutorisees, Carte carteJouee)
        {
            return cartesAutorisees.Contains(carteJouee);
        }

        static bool isFamilleOpposee(string familleCarteEnCours, string familleCartePrecedente)
        {
            bool familleOpposee = false;
            if(familleCarteEnCours == "BOIS" && familleCarteEnCours == "YEUX")
            {
                familleOpposee = true;
            }
            else if(familleCarteEnCours == "YEUX" && familleCartePrecedente == "BOIS")
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

        static public void setCartesAutorisees(Partie partie, Joueur joueur1, Joueur joueur2)
        {
            string famillePrecedenteJoueur1 = string.Empty;
            string famillePrecedenteJoueur2 = string.Empty;
            joueur1.CartesAutorisees = new List<Carte>();
            joueur2.CartesAutorisees = new List<Carte>();

            Duel duelPrecedent = new Duel();
            if (partie.duelsJoues.Count > 0)
            {
                duelPrecedent = partie.duelsJoues[partie.duelsJoues.Count-1];
                famillePrecedenteJoueur1 = duelPrecedent.carteJoueur1.Famille;
                famillePrecedenteJoueur2 = duelPrecedent.carteJoueur2.Famille;
            }
            //Cas du joueur 1
            //Famille de la dernière carte jouée
            foreach(Carte c in joueur1.Hand)
            {
                //Si la famille d'une carte de la main n'est pas opposée à celle de la carte jouée au dernier tour, alors on l'ajoute à la liste
                if (string.IsNullOrEmpty(famillePrecedenteJoueur1) || !isFamilleOpposee(c.Famille, famillePrecedenteJoueur1))
                {
                    joueur1.CartesAutorisees.Add(c);
                }
            }

            //Cas du joueur 2
            foreach (Carte c in joueur2.Hand)
            {
                //Si la famille d'une carte de la main n'est pas opposée à celle de la carte jouée au dernier tour, alors on l'ajoute à la liste
                if (!isFamilleOpposee(c.Famille, famillePrecedenteJoueur2))
                {
                    joueur2.CartesAutorisees.Add(c);
                }
            }
        }
    }
}
