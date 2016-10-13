using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public abstract class KiesReisType
    {
        protected abstract String ReisType();
        public virtual string GetReisType()
        {
            return ReisType();
        }

        protected abstract int ReisTypePrijsVermenigvuldiging();
        public virtual int GetReisTypePrijsVermenigvuldiging()
        {
            return ReisTypePrijsVermenigvuldiging();
        }


        public static string[] KrijgReisTypeSoorten()
        {
            IEnumerable<KiesReisType> ReisTypeList = typeof(KiesReisType)
             .Assembly.GetTypes()
             .Where(t => t.IsSubclassOf(typeof(KiesReisType)) && !t.IsAbstract)
             .Select(t => (KiesReisType)Activator.CreateInstance(t)).ToArray();
            List<string> ReistypeSoorten = new List<string>();
            foreach (KiesReisType ReisType in ReisTypeList)
            {
                ReistypeSoorten.Add(ReisType.ReisType());
            }

            return ReistypeSoorten.ToArray();
        }

        public static KiesReisType KrijgReisType(string name)
        {
            // Find the array index of the requested Pay method
            int index = Array.FindIndex(KrijgReisTypeSoorten(), w => w.Contains(name));
            // Create a list of the class names of the inherited Station classes
            IEnumerable<KiesReisType> ReisTypeList = typeof(KiesReisType)
       .Assembly.GetTypes()
       .Where(t => t.IsSubclassOf(typeof(KiesReisType)) && !t.IsAbstract)
       .Select(t => (KiesReisType)Activator.CreateInstance(t));
            // Use the index in the class name list to return the requested Station
            return ReisTypeList.ToArray()[index];
        }
    }

    public class EnkeleReis : KiesReisType
    {
        protected override string ReisType()
        {
            return "Enkele Reis";
        }

        protected override int ReisTypePrijsVermenigvuldiging()
        {
            return 1;
        }
    }

    public class RetourReis : KiesReisType
    {
        protected override string ReisType()
        {
            return "Retour Reis";
        }

        protected override int ReisTypePrijsVermenigvuldiging()
        {
            return 2;
        }
    }
}
