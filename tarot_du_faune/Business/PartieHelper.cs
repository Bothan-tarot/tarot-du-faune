using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_du_faune.Transport;

namespace tarot_du_faune.Business
{
    public static class PartieHelper
    {
        static public Partie ajouterDuel(Partie partie, Duel duel)
        {
            partie.DuelsJoues.Add(duel);
            return partie;
        }

        static public void JouerUneCarte()
        {

        }

        static public void ImpactCartePrecedente()
        {

        }

        static public void ComparerValeur()
        {

        }

        static public void ActiverPouvoir()
        {

        }

        static public Partie CalculScorePartie(Partie partie)
        {
            Partie partieEnCours = partie;
            int valeurCarteJoueur1 = 0;
            int valeurCarteJoueur2 = 0;
            int scoreJoueur1 = 0;
            int scoreJoueur2 = 0;
            for (int i = 0; i < partie.duelsJoues.Count; i++)
            {
                valeurCarteJoueur1 = partie.duelsJoues[i].carteJoueur1.Valeur;
                valeurCarteJoueur2 = partie.duelsJoues[i].carteJoueur2.Valeur;

                if (valeurCarteJoueur1 > valeurCarteJoueur2)
                {
                    scoreJoueur1++;
                }
                else if (valeurCarteJoueur2 > valeurCarteJoueur1)
                {
                    scoreJoueur2++;
                }
            }
            partieEnCours.joueur1.Score = scoreJoueur1;
            partieEnCours.joueur2.Score = scoreJoueur2;

            return partieEnCours;
        }

        static public void ShowFinDePartie(bool vainqueurAuxPoints, int nbPlis, Joueur joueur1, Joueur joueur2)
        {
            if (vainqueurAuxPoints)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                if (joueur1.Score >= nbPlis)
                {
                    Console.WriteLine("\tVictoire de " + joueur1.Nom + " !!");
                }
                else
                {
                    Console.WriteLine("\tVictoire de " + joueur2.Nom + " !!");
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            else
            {
                bool joueur1peutJouer = joueur1.pioche && joueur1.CartesAutorisees.Count > 0;
                bool joueur2peutJouer = joueur2.pioche && joueur2.CartesAutorisees.Count > 0;
                if (!joueur1peutJouer)
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("\tVictoire de " + joueur2.Nom + " !!");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
                else if (!joueur2peutJouer)
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("\tVictoire de " + joueur1.Nom + " !!");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
        }
    }
}
