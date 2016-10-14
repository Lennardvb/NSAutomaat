using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    class PrijsBerekenaar
    {

        // Twijfel over de datatypes van de Parameters
        public static Decimal BerekenPrijs(UIInfo info)
        {
            decimal prijs = 0;

            prijs = info.Klasse.GetKlassePrijs() * 0.02m * Tariefeenheden.getTariefeenheden(info.StartPlaats, info.EindBestemming);
            prijs = prijs * info.Railcard.GetRailcardKortingsPercentage();
            prijs = prijs * info.ReisType.GetReisTypePrijsVermenigvuldiging() + info.Betaalmethode.GetExtraKostenBetaalmethode();

            
            // De Prijs wordt afgerond op 2 decimalen.
            decimal PrijsAfgerond = decimal.Round(prijs,2);
            return PrijsAfgerond;

        }
    }
}

