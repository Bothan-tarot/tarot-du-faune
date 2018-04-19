using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_du_faune.Transport;

namespace tarot_du_faune.Business
{
    public static class PouvoirHelper
    {
        static public Partie GestionCiblePouvoir(Partie p, Carte c, bool joueur1, bool joueur2)
        {
            if(joueur1)
            {
                p.Joueur1 = GestionPouvoirs(p.Joueur1, c);
            }
            else if(joueur2)
            {
                p.Joueur2 = GestionPouvoirs(p.Joueur2, c);
            }
            return p;
        }
        static public Joueur GestionPouvoirs(Joueur j, Carte c)
        {
            switch(c.Libelle)
            {
                case "BRUTUS":
                    j.Deck = CarteHelper.DefausserCartes(j.Deck, 3);
                    break;
                case "LE MINOT":
                    j.Hand = CarteHelper.DefausserCartes(j.Hand, 2);
                    j.Deck.Add(CarteHelper.PiocherCarte(j));
                    break;
                case "HORN":
                    j.Hand = CarteHelper.DefausserCartes(j.Hand, 2);
                    j.Deck = CarteHelper.DefausserCartes(j.Deck, 1);
                    break;
                case "LES JUMEAUX":
                    j.CouleurInterdite = DemanderFamilleInterdite();
                    break;
            }
            
            return j;
        }

        static public string DemanderFamilleInterdite()
        {
            string fam = string.Empty;
            while(fam != "YEUX" && fam != "FLAMME" && fam != "BOIS" && fam != "COEUR")
            {
                Console.WriteLine("Quelle famille interdire ? (YEUX, FLAMME, BOIS, COEUR)");
                fam = Console.ReadLine().ToUpper();
            }
            return fam;
        }
    }
}
