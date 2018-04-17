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
        private static Partie dududududuel = new Partie();

        static void Main(string[] args)
        {
            Console.SetWindowSize(90, 60);
            Console.WriteLine("Tarot du faune");
            initGame();
        }

        static void initGame()
        {
            Console.WriteLine("Nom du premier joueur ?");
            string str = Console.ReadLine();
            dududududuel.Joueur1 = new Joueur(str);
            Console.WriteLine("Nom du deuxième joueur ?");
            str = Console.ReadLine();
            dududududuel.Joueur2 = new Joueur(str);

            bool finDuGame = false;
            bool vainqueurAuxPoints = false;
            bool joueur1peutJouer = true;
            bool joueur2peutJouer = true;
            while (!finDuGame)
            {
                //Calcul des cartes autorisées
                CarteHelper.setCartesAutorisees(dududududuel, dududududuel.Joueur1, dududududuel.Joueur2);
                //On lance le tour de jeu
                TourDeJeu(dududududuel.Joueur1, dududududuel.Joueur2);
                //A la fin du tour, on calcule s'il y a un vainqueur aux points
                vainqueurAuxPoints = (dududududuel.Joueur1.Score >= Partie.NbPlis || dududududuel.Joueur2.Score >= Partie.NbPlis);
                if(!vainqueurAuxPoints)
                {
                    //Chaque joueur pioche
                    dududududuel.Joueur1.pioche = cardPicker(dududududuel.Joueur1);
                    dududududuel.Joueur2.pioche = cardPicker(dududududuel.Joueur2);

                    //Ensuite on calcule si un des deux joueurs
                    joueur1peutJouer = dududududuel.Joueur1.pioche && dududududuel.Joueur1.CartesAutorisees.Count > 0;
                    joueur2peutJouer = dududududuel.Joueur2.pioche && dududududuel.Joueur2.CartesAutorisees.Count > 0;
                }
                //On vérifie si l'une des deux fins possibles est atteinte
                finDuGame = vainqueurAuxPoints || !joueur1peutJouer || !joueur2peutJouer;
            }

            PartieHelper.ShowFinDePartie(vainqueurAuxPoints, Partie.NbPlis, dududududuel.Joueur1, dududududuel.Joueur2);

            Console.ReadKey();
        }

        //TODO :
        //Ajout du duel à la Partie
        //Résolution du duel
        ///// Later : Gestion des pouvoirs
        //Calcul du score de la Partie

        //// Later : Faire des méthodes AfficherDuel() et AfficherPartie() ?

        static void TourDeJeu(Joueur player1, Joueur player2)
        {
            bool carteOK = false;
            string cardPlayer1 = string.Empty;
            string cardPlayer2 = string.Empty;

            Console.WriteLine("\n------------ Tour de " + player1.Nom + " ------------\n");
            showCardList(player1.Hand);
            //Vérification de la validité de la carte du joueur 1
            while(!carteOK)
            {
                Console.WriteLine("Quelle carte jouer ? (valeur de carte)");
                cardPlayer1 = Console.ReadLine();
                carteOK = player1.CartesAutorisees.Contains(getCard(player1.Hand, int.Parse(cardPlayer1)));
            }

            Console.WriteLine("\n------------ Tour de " + player2.Nom + " ------------\n");
            showCardList(player2.Hand);
            carteOK = false;
            //Vérification de la validité de la carte du joueur 2
            while (!carteOK)
            {
                Console.WriteLine("Quelle carte jouer ? (valeur de carte)");
                cardPlayer2 = Console.ReadLine();
                carteOK = player2.CartesAutorisees.Contains(getCard(player2.Hand, int.Parse(cardPlayer2)));
            }

            Console.WriteLine("\n------------ Résolution du duel ------------\n");
            Carte playedCardPlayer1 = getCard(player1.Hand, int.Parse(cardPlayer1));
            Carte playedCardPlayer2 = getCard(player2.Hand, int.Parse(cardPlayer2));

            Console.WriteLine(player1.Nom + " a joué : \n");
            showCard(playedCardPlayer1);
            Console.WriteLine(player2.Nom + " a joué : \n");
            showCard(playedCardPlayer2);

            Duel duel = new Duel(getCard(player1.Hand, int.Parse(cardPlayer1)), getCard(player2.Hand, int.Parse(cardPlayer2)));
            dududududuel = PartieHelper.ajouterDuel(dududududuel, duel);

            playCard(player1, int.Parse(cardPlayer1));
            playCard(player2, int.Parse(cardPlayer2));

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
            dududududuel = PartieHelper.CalculScorePartie(dududududuel);

            Console.ReadKey();
        }

        static bool cardPicker(Joueur player)
        {
            if (player.Deck.Count > 0)
            {
                Random rnd = new Random();
                int i = rnd.Next(0, player.Deck.Count);
                Carte c = getCard(player.Deck, i);
                player.Hand.Add(c);
                player.Deck.RemoveAt(i);
            }
            else
            {
                return false;
            }
            return true;
        }

        static void playCard(Joueur player, int value)
        {
            player.Hand.RemoveAt(getCardPosition(player.Hand, value));
        }

        static void showCardList(List<Carte> cards)
        {
            StringBuilder cardList = new StringBuilder();

            foreach (Carte card in cards)
            {
                showCard(card);
            }
        }

        static void showCard(Carte card)
        {
            StringBuilder cardDisplayed = new StringBuilder();
            cardDisplayed.AppendFormat("Carte : {0} - {1} - Famille : {2} \n", card.Valeur, card.Libelle, card.Famille);
            Console.WriteLine(cardDisplayed.ToString());
        }

        static Carte getCard(List<Carte> listCartes, int value)
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

        static int getCardPosition(List<Carte> listCartes, int value)
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
    }
}
