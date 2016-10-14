using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public abstract class KiesRailcard
    {
        protected abstract string Railcard();
        public virtual string GetRailcard()
        {
            return Railcard();
        }

        protected abstract decimal RailcardKortingsPercentage();
        public virtual decimal GetRailcardKortingsPercentage()
        {
            return RailcardKortingsPercentage();
        }

        public static string[] KrijgRailcardSoorten()
        {
            IEnumerable<KiesRailcard> RailcardList = typeof(KiesRailcard)
             .Assembly.GetTypes()
             .Where(t => t.IsSubclassOf(typeof(KiesRailcard)) && !t.IsAbstract)
             .Select(t => (KiesRailcard)Activator.CreateInstance(t)).ToArray();
            List<string> RailcardNamen = new List<string>();
            foreach (KiesRailcard Railcard in RailcardList)
            {
                RailcardNamen.Add(Railcard.Railcard());
            }

            return RailcardNamen.ToArray();
        }

        public static KiesRailcard KrijgRailcard(string name)
        {
            // Find the array index of the requested Pay method
            int index = Array.FindIndex(KrijgRailcardSoorten(), w => w.Contains(name));
            // Create a list of the class names of the inherited Station classes
            IEnumerable<KiesRailcard> RailcardList = typeof(KiesRailcard)
       .Assembly.GetTypes()
       .Where(t => t.IsSubclassOf(typeof(KiesRailcard)) && !t.IsAbstract)
       .Select(t => (KiesRailcard)Activator.CreateInstance(t));
            // Use the index in the class name list to return the requested Station
            return RailcardList.ToArray()[index];
        }

    }

    public class GeenKorting : KiesRailcard
    {
        protected override string Railcard()
        {
            return "Geen Korting";
        }

        protected override decimal RailcardKortingsPercentage()
        {
            return 1m;
        }
    }

    public class TwintigProcentKorting : KiesRailcard
    {
        protected override string Railcard()
        {
            return "20% Korting";
        }

        protected override decimal RailcardKortingsPercentage()
        {
            return 0.20m;
        }
    }

    public class VeertigProcentKorting : KiesRailcard
    {
        protected override string Railcard()
        {
            return "40% Korting";
        }

        protected override decimal RailcardKortingsPercentage()
        {
            return 0.40m;
        }
    }
}
