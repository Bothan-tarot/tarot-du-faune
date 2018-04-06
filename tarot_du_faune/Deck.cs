using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_du_faune
{
    class Deck
    {
        public List<Carte> deckBuilder()
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

            myDeck.Add(arthur);
            myDeck.Add(a54);
            myDeck.Add(remi);
            myDeck.Add(marcheur);
            myDeck.Add(leila);
            myDeck.Add(dafroza);
            myDeck.Add(homme_affaire);
            myDeck.Add(viviane);
            myDeck.Add(samuel);
            myDeck.Add(maud);
            myDeck.Add(eda);
            myDeck.Add(jeanAvon);
            myDeck.Add(brutus);
            myDeck.Add(leMinot);
            myDeck.Add(horn);
            myDeck.Add(lesJumeaux);

            return myDeck;
        }
    }
}
