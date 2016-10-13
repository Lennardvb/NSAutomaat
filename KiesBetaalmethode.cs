using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public abstract class KiesBetaalmethode
    {
        protected abstract string Betaalmethode();
        public virtual string BetaalmethodeNaam()
        {
            return Betaalmethode();
        }

        protected abstract decimal ExtraKostenBetaalmethode();
        public virtual decimal GetExtraKostenBetaalmethode()
        {
            return ExtraKostenBetaalmethode();
        }

        public static string[] KrijgBetaalmethodeSoorten()
        {
            IEnumerable<KiesBetaalmethode> BetaalmethodeList = typeof(KiesBetaalmethode)
             .Assembly.GetTypes()
             .Where(t => t.IsSubclassOf(typeof(KiesBetaalmethode)) && !t.IsAbstract)
             .Select(t => (KiesBetaalmethode)Activator.CreateInstance(t)).ToArray();
            List<string> BetaalmethodeNamen = new List<string>();
            foreach (KiesBetaalmethode pay in BetaalmethodeList)
            {
                BetaalmethodeNamen.Add(pay.Betaalmethode());
            }

            return BetaalmethodeNamen.ToArray();
        }

        public static KiesBetaalmethode KrijgBetaalmethode(string name)
        {
            // Find the array index of the requested Pay method
            int index = Array.FindIndex(KrijgBetaalmethodeSoorten(), w => w.Contains(name));
            // Create a list of the class names of the inherited Station classes
            IEnumerable<KiesBetaalmethode> BetaalmethodeList = typeof(KiesBetaalmethode)
       .Assembly.GetTypes()
       .Where(t => t.IsSubclassOf(typeof(KiesBetaalmethode)) && !t.IsAbstract)
       .Select(t => (KiesBetaalmethode)Activator.CreateInstance(t));
            // Use the index in the class name list to return the requested Station
            return BetaalmethodeList.ToArray()[index];
        }

    }

    public class Debitcard : KiesBetaalmethode
    {
        protected override string Betaalmethode()
        {
            return "Debit card";
        }

        protected override decimal ExtraKostenBetaalmethode()
        {
            return 0;
        }

    }

    public class Creditcard : KiesBetaalmethode
    {
        protected override string Betaalmethode()
        {
            return "Credit card";
        }

        protected override decimal ExtraKostenBetaalmethode()
        {
            return 0.50m;
        }
    }

    public class Contant : KiesBetaalmethode
    {
        protected override string Betaalmethode()
        {
            return "Contant";
        }

        protected override decimal ExtraKostenBetaalmethode()
        {
            return 0;
        }
    }
}
