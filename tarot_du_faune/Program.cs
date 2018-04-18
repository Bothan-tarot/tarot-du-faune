using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_du_faune.Transport;
using tarot_du_faune.Business;

namespace tarot_du_faune
{
    public static class Program
    {
        private static Partie Game = new Partie();

        static void Main(string[] args)
        {
            Console.SetWindowSize(90, 60);
            Console.WriteLine("Tarot du faune");
            
            Console.ReadKey();

            //initGame();
        }

        static void initGame()
        {
            Console.WriteLine("Nom du premier joueur ?");
            string str = Console.ReadLine();
            Game.Joueur1 = new Joueur(str);
            Console.WriteLine("Nom du deuxième joueur ?");
            str = Console.ReadLine();
            Game.Joueur2 = new Joueur(str);

            bool finDuGame = false;
            bool vainqueurAuxPoints = false;
            bool joueur1peutJouer = true;
            bool joueur2peutJouer = true;
            while (!finDuGame)
            {
                //Calcul des cartes autorisées
                Game = CarteHelper.MajCartesAutorisees(Game);
                //On lance le tour de jeu
                Game = PartieHelper.TourDeJeu(Game);
                //A la fin du tour, on calcule s'il y a un vainqueur aux points
                vainqueurAuxPoints = (Game.Joueur1.Score >= Partie.NbPlis || Game.Joueur2.Score >= Partie.NbPlis);
                if(!vainqueurAuxPoints)
                {
                    //Chaque joueur pioche
                    /*
                    Game.Joueur1.pioche = PiocherCarte(Game.Joueur1);
                    Game.Joueur2.pioche = PiocherCarte(Game.Joueur2);
                    */

                    //Ensuite on calcule si un des deux joueurs
                    joueur1peutJouer = Game.Joueur1.pioche && Game.Joueur1.CartesAutorisees.Count > 0;
                    joueur2peutJouer = Game.Joueur2.pioche && Game.Joueur2.CartesAutorisees.Count > 0;
                }
                //On vérifie si l'une des deux fins possibles est atteinte
                finDuGame = vainqueurAuxPoints || !joueur1peutJouer || !joueur2peutJouer;
            }

            PartieHelper.ShowFinDePartie(vainqueurAuxPoints, Partie.NbPlis, Game.Joueur1, Game.Joueur2);

            Console.ReadKey();
        }

        static void TourDeJeu(Joueur player1, Joueur player2)
        {
            bool carteOK = false;
            string cardPlayer1 = string.Empty;
            string cardPlayer2 = string.Empty;

            Console.WriteLine("\n------------ Résolution du duel ------------\n");
            Carte playedCardPlayer1 = CarteHelper.ObtenirCarte(player1.Hand, int.Parse(cardPlayer1));
            Carte playedCardPlayer2 = CarteHelper.ObtenirCarte(player2.Hand, int.Parse(cardPlayer2));

            /*
            Console.WriteLine(player1.Nom + " a joué : \n");
            AffichageHelper.AfficherCarte(playedCardPlayer1);
            Console.WriteLine(player2.Nom + " a joué : \n");
            AffichageHelper.AfficherCarte(playedCardPlayer2);
            */

            Duel duel = new Duel(CarteHelper.ObtenirCarte(player1.Hand, int.Parse(cardPlayer1)), CarteHelper.ObtenirCarte(player2.Hand, int.Parse(cardPlayer2)));
            Game = PartieHelper.ajouterDuel(Game, duel);

            /*
            CarteHelper.JouerCarte(player1, int.Parse(cardPlayer1));
            CarteHelper.JouerCarte(player2, int.Parse(cardPlayer2));
            */

            if (playedCardPlayer1.Valeur > playedCardPlayer2.Valeur)
            {
                Console.WriteLine(player1.Nom + " remporte ce duel\n");
                Console.WriteLine(player2.Nom + " active le pouvoir suivant : " + playedCardPlayer2.Pouvoir.Libelle);
            }
            else
            {
                if(playedCardPlayer2.Valeur > playedCardPlayer1.Valeur)
                {
                    Console.WriteLine(player2.Nom + " remporte ce duel\n");
                    Console.WriteLine(player1.Nom + " active le pouvoir suivant : " + playedCardPlayer1.Pouvoir.Libelle);
                }
                else
                {
                    Console.WriteLine("1 point pour Griffondor \n");
                }
            }

            //Mise à jour des scores
            Game = PartieHelper.CalculScorePartie(Game);

            Console.ReadKey();
        }
    }
}
