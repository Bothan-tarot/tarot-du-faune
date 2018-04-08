using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_du_faune
{
    public class Partie
    {
        public List<Duel> duelsJoues { get; set; }

        public Partie()
        {
            duelsJoues = new List<Duel>();
        }

        public void ajouterDuel(Partie partie, Duel duel)
        {
            partie.duelsJoues.Add(duel);
        }
    }
}
