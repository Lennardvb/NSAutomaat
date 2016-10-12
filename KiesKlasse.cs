using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
   public interface KiesKlasse
    {
        String KiesSoortKlasse();
        decimal KlassePrijsToevoeging();
    }

    public class TweedeKlasse : KiesKlasse
    {
        public string KiesSoortKlasse()
        {
            return "Tweede Klasse";
        }

        public decimal KlassePrijsToevoeging()
        {
            return 2.10m;
        }
    }

    public class EersteKlasse : KiesKlasse
    {
        public string KiesSoortKlasse()
        {
            return "Eerste Klasse";
        }

        public decimal KlassePrijsToevoeging()
        {
            return 3.60m;
        }
    }
}
