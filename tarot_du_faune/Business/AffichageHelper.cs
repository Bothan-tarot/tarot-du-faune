using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_du_faune.Transport;
using tarot_du_faune.Business;

namespace tarot_du_faune.Business
{
    public static class AffichageHelper
    {
        public static Carte DemanderCarte(Joueur j)
        {
            Console.WriteLine("Quelle carte jouer ? (valeur de carte)");
            string cardPlayer1 = Console.ReadLine();
            Carte c = CarteHelper.ObtenirCarte(j.Hand, int.Parse(cardPlayer1));
            return c;
        }

        public static void AfficherCarte(Carte c)
        {
            StringBuilder affichageCarte = new StringBuilder();
            affichageCarte.AppendFormat("Carte : {0} - {1} - Famille : {2} \n", c.Valeur, c.Libelle, c.Famille);
            Console.WriteLine(affichageCarte.ToString());
        }

        public static void AfficherListeCartes(List<Carte> cartes)
        {
            foreach (Carte carte in cartes)
            {
                AfficherCarte(carte);
            }
        }

        public static void AfficherDuel(Partie p, Carte carteJoueur1, Carte carteJoueur2)
        {
            Console.WriteLine(p.Joueur1.Nom + " a joué : \n");
            AffichageHelper.AfficherCarte(carteJoueur1);
            Console.WriteLine(p.Joueur2.Nom + " a joué : \n");
            AffichageHelper.AfficherCarte(carteJoueur2);
        }

        public static void AfficherPlateau(Partie p)
        {
            string ligneCartes = string.Empty;
            string cotesCartes = string.Empty;
            string valeursCartesJ1 = string.Empty;
            string valeursCartesJ2 = string.Empty;
            for (int i = 0; i < p.DuelsJoues.Count; i ++)
            {
                ligneCartes += "------ ";
                cotesCartes += "|    | ";
                string valJ1 = string.Format("{0:00}", p.DuelsJoues[i].carteJoueur1.Valeur);
                string valJ2 = string.Format("{0:00}", p.DuelsJoues[i].carteJoueur2.Valeur);
                valeursCartesJ1 += "| " + valJ1 + " | ";
                valeursCartesJ2 += "| " + valJ2 + " | ";
            }
            Console.WriteLine(ligneCartes);
            Console.WriteLine(cotesCartes);
            Console.WriteLine(valeursCartesJ1);
            Console.WriteLine(cotesCartes);
            Console.WriteLine(ligneCartes);

            Console.WriteLine(ligneCartes);
            Console.WriteLine(cotesCartes);
            Console.WriteLine(valeursCartesJ2);
            Console.WriteLine(cotesCartes);
            Console.WriteLine(ligneCartes);
        }
    }
}
