using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
   public abstract class KiesKlasse
    {
        protected abstract String SoortKlasse();
        public virtual string GetSoortKlasse()
        {
            return SoortKlasse();
        }
        protected abstract decimal KlassePrijs();
        public virtual decimal GetKlassePrijs()
        {
            return KlassePrijs();
        }

        public static string[] KrijgKlasseSoorten()
        {
            IEnumerable<KiesKlasse> KlasseList = typeof(KiesKlasse)
             .Assembly.GetTypes()
             .Where(t => t.IsSubclassOf(typeof(KiesKlasse)) && !t.IsAbstract)
             .Select(t => (KiesKlasse)Activator.CreateInstance(t)).ToArray();
            List<string> KlasseSoorten = new List<string>();
            foreach (KiesKlasse Klasse in KlasseList)
            {
                KlasseSoorten.Add(Klasse.SoortKlasse());
            }

            return KlasseSoorten.ToArray();
        }

        public static KiesKlasse KrijgKlasse(string name)
        {
            // Find the array index of the requested Pay method
            int index = Array.FindIndex(KrijgKlasseSoorten(), w => w.Contains(name));
            // Create a list of the class names of the inherited Station classes
            IEnumerable<KiesKlasse> KlasseList = typeof(KiesKlasse)
       .Assembly.GetTypes()
       .Where(t => t.IsSubclassOf(typeof(KiesKlasse)) && !t.IsAbstract)
       .Select(t => (KiesKlasse)Activator.CreateInstance(t));
            // Use the index in the class name list to return the requested Station
            return KlasseList.ToArray()[index];
        }

    }

    public class TweedeKlasse : KiesKlasse
    {
        protected override string SoortKlasse()
        {
            return "Tweede Klasse";
        }

        protected override decimal KlassePrijs()
        {
            return 2.10m;
        }
    }

    public class EersteKlasse : KiesKlasse
    {
        protected override string SoortKlasse()
        {
            return "Eerste Klasse";
        }

        protected override decimal KlassePrijs()
        {
            return 3.60m;
        }
    }
}
