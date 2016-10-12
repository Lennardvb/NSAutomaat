using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public interface KiesBetaalmethode
    {
        string KiesBetaalmethode();
        decimal ExtraKostenBetaalmethode();
    }

    public class Debitcard : KiesBetaalmethode
    {
        public string KiesBetaalmethode()
        {
            return "Debitcard";
        }

        public decimal ExtraKostenBetaalmethode()
        {
            return 0;
        }
    }

    public class Creditcard : KiesBetaalmethode
    {
        public string KiesBetaalmethode()
        {
            return "Creditcard";
        }

        public decimal ExtraKostenBetaalmethode()
        {
            return 0.50m;
        }
    }

    public class Contant : KiesBetaalmethode
    {
        public string KiesBetaalmethode()
        {
            return "Contant";
        }

        public decimal ExtraKostenBetaalmethode()
        {
            return 0;
        }
    }
}
