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
            decimal price = 0;

            price = info.Klasse.GetKlassePrijs() * 0.02m * Tariefeenheden.getTariefeenheden(info.StartPlaats, info.EindBestemming);
            price = price;

            MessageBox.Show(Convert.ToString(price));
            return Math.Round(price, 2);

        }
    }
}

