﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarot_du_faune.Transport;

namespace tarot_du_faune.Business
{
    public static class CarteHelper
    {
        static bool isFamilleOpposee(string familleCarteEnCours, string familleCartePrecedente)
        {
            bool familleOpposee = false;
            if (familleCarteEnCours == "BOIS" && familleCarteEnCours == "YEUX")
            {
                familleOpposee = true;
            }
            else if (familleCarteEnCours == "YEUX" && familleCartePrecedente == "BOIS")
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

            if (partie.duelsJoues.Count > 0)
            {
                Duel duelPrecedent = new Duel();
                duelPrecedent = partie.duelsJoues[partie.duelsJoues.Count - 1];
                famillePrecedenteJoueur1 = duelPrecedent.carteJoueur1.Famille;
                famillePrecedenteJoueur2 = duelPrecedent.carteJoueur2.Famille;
            }
            //Cas du joueur 1
            //Famille de la dernière carte jouée
            foreach (Carte c in joueur1.Hand)
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