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
        public List<Carte> Deck { get; set; }
        public List<Carte> Hand { get; set; }
        public List<Carte> CartesAutorisees { get; set; }
        public bool pioche { get; set; }
        public Joueur(string nom)
        {
            Nom = nom;
            Score = 0;
            pioche = true;
            Deck = deckBuilder();
            Hand = getFuckingRandomHand(this, Deck, 5);
            CartesAutorisees = new List<Carte>();
        }

        static public List<Carte> deckBuilder()
        {
            List<Carte> myDeck = new List<Carte>();
            //BOIS
            Carte arthur = new Carte("BOIS", 2, "ARTHUR", new Pouvoir(2, "Si vous jouez une carte de Coeur immédiatement après Arthur, la force de ce Coeur est doublée.", "SABLIER"));
            Carte a54 = new Carte("BOIS", 7, "A54", new Pouvoir(7, "Si la carte jouée immédiatement après A54 n'est pas une carte Bois, ajoutez +5 à sa force.", "SABLIER"));
            Carte remi = new Carte("BOIS", 10, "REMI", new Pouvoir(10, "Si la carte jouée immédiatement après Rémi est une carte de Flamme, ajoutez +5 à la force de Rémi", "SABLIER"));
            Carte marcheur = new Carte("BOIS", 15, "MARCHEUR", new Pouvoir(15, "Toutes vos cartes ont +3 de force.", "PERMANENT"));

            //COEUR
            Carte leila = new Carte("COEUR", 1, "LEILA", new Pouvoir(1, "La force de Leila est toujours égale à celle de la carte après elle.", "SABLIER"));
            Carte dafroza = new Carte("COEUR", 8, "DAFROZA", new Pouvoir(8, "Cherchez une carte dans votre pioche, révélez-là à votre adversaire et mettez là dans votre main. Mélangez votre pioche.", "INSTANT"));
            Carte homme_affaire = new Carte("COEUR", 9, "L'HOMME D'AFFAIRES", new Pouvoir(9, "Piochez une carte. La prochaine carte que vous jouez gagne +3 de force.", "SABLIER"));
            Carte viviane = new Carte("COEUR", 16, "VIVIANE", new Pouvoir(16, "Vous gagnez la partie.", "INSTANT"));

            //YEUX
            Carte samuel = new Carte("YEUX", 3, "SAMUEL(1987)", new Pouvoir(3, "Si vous deviez gagner un pli avec Samuel (1987) à n'importe quel moment, vous remportez la partie. (Vous n'avez pas besoin de perdre un pli pour activer ce pouvoir)", "SABLIER"));
            Carte maud = new Carte("YEUX", 6, "MAUD", new Pouvoir(6, "Vous remporter toutes les égalités en tant que plis gagnés (futures et passées). (L'abversaire ne gagne aucun pouvoir en cas d'égalité.)", "INSTANT"));
            Carte eda = new Carte("YEUX", 11, "EDA", new Pouvoir(11, "Activez le pouvoir instantané d'une de vos cartes déjà jouées.", "INSTANT"));
            Carte jeanAvon = new Carte("YEUX", 14, "JEAN AVON", new Pouvoir(14, "A partir du prochain pli, l'adversaire vous montre la carte qu'il a choisie avant que vous choisissiez la vôtre.", "SABLIER"));

            //FLAMME
            Carte brutus = new Carte("FLAMME", 12, "BRUTUS", new Pouvoir(4, "L'adversaire défausse les trois premières cartes de son paquet.", "INSTANT"));
            Carte leMinot = new Carte("FLAMME", 5, "LE MINOT", new Pouvoir(5, "L'adversaire d'afausse deux cartes de sa main, puis pioche une carte.", "INSTANT"));
            Carte horn = new Carte("FLAMME", 12, "HORN", new Pouvoir(12, "L'adversaire défausse deux cartes de sa main et la première carte de sa pioche.", "INSTANT"));
            Carte lesJumeaux = new Carte("FLAMME", 13, "LES JUMEAUX", new Pouvoir(13, "Choisissez une famille. A partir du prochain pli, l'adversaire ne peut plus jouer de carte de cette famille.", "SABLIER"));

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

        static public List<Carte> getFuckingRandomHand(Joueur player, List<Carte> deck, int nbCartes)
        {
            List<Carte> handOfTheKing = new List<Carte>();

            for(int i = 0; i < nbCartes; i++)
            {
                Random rnd = new Random();
                int rdm = rnd.Next(deck.Count);
                handOfTheKing.Add(player.Deck[rdm]);
                player.Deck.RemoveAt(rdm);
            }
            return handOfTheKing;
        }
    }
}
