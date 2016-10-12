using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class PrijsBerekenaar
    {
        // Twijfel over de datatypes van de Parameters
        public static Decimal BerekenPrijs(int tariefeenheden, decimal KlassePrijsToevoeging, double KortingsPercentage,
            double BetalingsMethodeToevoeging, string Reistype)
        {
            double price = 0;
           decimal StandaardTicketPrijs = 2.10m; // Volgens mij is deze ook niet nodig.

            price = tariefeenheden * 0.02 * ((StandaardTicketPrijs + KlassePrijsToevoeging));
            price = price * KortingsPercentage + BetalingsMethodeToevoeging;

            return (decimal)Math.Round(price, 2);
        }
    }
}
