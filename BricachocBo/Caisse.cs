using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBo
{
    public class Caisse
    {

        public string NomDuMagasin { get; set; }
        public decimal FondDeCaissse { get; set; }
        public string MessageClient { get; set; }
        
        public Catalogue LeCatalogue { get; set; }
        public Vente VenteEnCours { get; set; }
        public Vente VenteEnAttente { get; set; }

        // Prop calculéé
        public List<Famille> FamCatalogue
        {
            get { return LeCatalogue.Familles; }
        }

    }
}
