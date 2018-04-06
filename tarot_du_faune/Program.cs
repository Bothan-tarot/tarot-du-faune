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

        static void Main(string[] args)
        {
            Console.WriteLine("Tarot du faune");
            initGame();
        }

        static void initGame()
        {
            //Joueur thibault = new Joueur("Thibault");
            //Joueur jocelyn = new Joueur("Jocelyn");
            //thibault.Deck = deckBuilder();
            //jocelyn.Deck = deckBuilder();
            //showCardList(thibault.Deck);
            //Console.WriteLine("Main de " + thibault.Nom + " : \n");
            //Console.ReadKey();

            handGenerator(thibault, 5);
            handGenerator(jocelyn, 5);
            //showCardList(thibault.Hand);
            /*
             * Console.WriteLine("Piocher une carte ? (y/n)");
            Console.ReadKey();

            showCard(cardPicker(thibault.Deck));
            Console.ReadKey();
            */

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

        static void TourDeJeu(Joueur player1, Joueur player2)
        {
            Console.WriteLine("\n------------ Tour de " + player1.Nom + " ------------\n");
            showCardList(player1.Hand);
            Console.WriteLine("Quelle carte jouer ? (valeur de carte)");
            string cardPlayer1 = Console.ReadLine();

            Console.WriteLine("\n------------ Tour de " + player2.Nom + " ------------\n");
            showCardList(player2.Hand);
            Console.WriteLine("Quelle carte jouer ? (valeur de carte)");
            string cardPlayer2 = Console.ReadLine();

            Console.WriteLine("\n------------ Résolution du duel ------------\n");
            Carte playedCardPlayer1 = getCard(player1.Hand, int.Parse(cardPlayer1));
            Carte playedCardPlayer2 = getCard(player2.Hand, int.Parse(cardPlayer2));
            Console.WriteLine(player1.Nom + " a joué : \n");
            showCard(playedCardPlayer1);
            Console.WriteLine(player2.Nom + " a joué : \n");
            showCard(playedCardPlayer2);

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
        }

        static public List<Carte> deckBuilder()
        {
            List<Carte> myDeck = new List<Carte>();
            //BOIS
            Carte arthur = new Carte("BOIS", 2, "ARTHUR");
            Carte a54 = new Carte("BOIS", 7, "A54");
            Carte remi = new Carte("BOIS", 10, "REMI");
            Carte marcheur = new Carte("BOIS", 15, "MARCHEUR");

            //COEUR
            Carte leila = new Carte("COEUR", 1, "LEILA");
            Carte dafroza = new Carte("COEUR", 8, "DAFROZA");
            Carte homme_affaire = new Carte("COEUR", 9, "L'HOMME D'AFFAIRES");
            Carte viviane = new Carte("COEUR", 16, "VIVIANE");

            //YEUX
            Carte samuel = new Carte("YEUX", 3, "SAMUEL(1987)");
            Carte maud = new Carte("YEUX", 6, "MAUD");
            Carte eda = new Carte("YEUX", 11, "EDA");
            Carte jeanAvon = new Carte("YEUX", 14, "JEAN AVON");

            //FLAMME
            Carte brutus = new Carte("FLAMME", 12, "BRUTUS");
            Carte leMinot = new Carte("FLAMME", 5, "LE MINOT");
            Carte horn = new Carte("FLAMME", 12, "HORN");
            Carte lesJumeaux = new Carte("FLAMME", 13, "LES JUMEAUX");

            myDeck.Add(leila);
            myDeck.Add(arthur);
            myDeck.Add(samuel);
            myDeck.Add(brutus);
            myDeck.Add(leMinot);
            myDeck.Add(maud);
            myDeck.Add(a54);
            myDeck.Add(dafroza);
            myDeck.Add(homme_affaire);
            myDeck.Add(remi);
            myDeck.Add(eda);
            myDeck.Add(horn);
            myDeck.Add(lesJumeaux);
            myDeck.Add(jeanAvon);
            myDeck.Add(marcheur);
            myDeck.Add(viviane);

            return myDeck;
        }

        static public void handGenerator(Joueur player, int nbCards)
        {
            for(int i = 0; i < nbCards; i++)
            {
                cardPicker(player);
            }
        }

        static bool cardPicker(Joueur player)
        {
            if (player.Deck.Count > 0)
            {
                Random rnd = new Random();
                int i = rnd.Next(0, player.Deck.Count);
                player.Hand.Add(player.Deck[i]);
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
