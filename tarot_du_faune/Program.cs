using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_du_faune
{
    public static class Program
    {
        private static Joueur thibault = new Joueur("Thibault");
        private static Joueur jocelyn = new Joueur("Jocelyn");
        private static int nbPlis = 2;
        private static Partie dududududuel = new Partie();

        static void Main(string[] args)
        {
            Console.WriteLine("Tarot du faune");
            initGame();
        }

        static void initGame()
        {
            bool finDuGame = false;
            bool vainqueurAuxPoints = false;
            while(!finDuGame)
            {
                TourDeJeu(thibault, jocelyn);
                vainqueurAuxPoints = (thibault.Score >= nbPlis || jocelyn.Score >= nbPlis);
                thibault.pioche = cardPicker(thibault);
                jocelyn.pioche = cardPicker(jocelyn);
                finDuGame = vainqueurAuxPoints || !thibault.pioche || !jocelyn.pioche;
            }

            if(vainqueurAuxPoints)
            {
                if(thibault.Score >= nbPlis)
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("\tVictoire de " + thibault.Nom + " !!");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
                else
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("\tVictoire de " + jocelyn.Nom + " !!");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }

            Console.ReadKey();
        }

        //TODO :
        //Lors d'un tour de jeu :
        //Chaque joueur pioche
        //Les cartes autorisées sont mises à jours
        //Chaque joueur joue une carte dont l'autorisation est vérifiée
        //Résolution du duel
        //Ajout du duel à la Partie
        ///// Later : Gestion des pouvoirs
        //Calcul du score de la Partie

        //// Later : Faire des méthodes AfficherDuel() et AfficherPartie() pour faire joli ?

        static void TourDeJeu(Joueur player1, Joueur player2)
        {
            bool carteOK = false;
            string cardPlayer1 = string.Empty;
            string cardPlayer2 = string.Empty;

            //Calcul des cartes autorisées
            Carte.setCartesAutorisees(dududududuel, player1, player2);

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
            dududududuel.ajouterDuel(dududududuel, duel);

            playCard(player1, int.Parse(cardPlayer1));
            playCard(player2, int.Parse(cardPlayer2));

            if (playedCardPlayer1.Valeur > playedCardPlayer2.Valeur)
            {
                player1.Score++;
                Console.WriteLine(player1.Score.ToString() + " point pour " + player1.Nom + "\n");
            }
            else
            {
                if(playedCardPlayer2.Valeur > playedCardPlayer1.Valeur)
                {
                    player2.Score++;
                    Console.WriteLine(player2.Score.ToString() + " point pour " + player2.Nom + "\n");
                }
                else
                {
                    Console.WriteLine("1 point pour Griffondor \n");
                }
            }
            Console.ReadKey();
        }

        static public void handGenerator(Joueur player, int nbCards)
        {
            List<int> listRandomCartes = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < nbCards; i++)
            {
                int rdm = rnd.Next(0, player.Deck.Count);
                listRandomCartes.Add(rdm);
                player.Hand.Add(player.Deck[i]);
                player.Deck.RemoveAt(i);
            }
        }

        static bool cardPicker(Joueur player)
        {
            if (player.Deck.Count > 0)
            {
                Random rnd = new Random();
                int i = rnd.Next(0, player.Deck.Count);
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
