using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public static class OverzichtTarief
    {

       public static Dictionary<string, int> Tarief = new Dictionary<string, int>()
        {
            // Hieronder worden al de reizen gespecificeerd vanuit elk station.
            // Er komen geen dubbele reizen voor. Bv dus niet Utrect Centraal - Gouda en Gouda - Utrecht Centraal
            
            // Alle reizen vanuit Utrecht
            { "Utrecht Centraal-Gouda", 32 },
            { "Utrecht Centraal-Geldermalsen", 26 },
            { "Utrecht Centraal-Hilversum", 18 },
            { "Utrecht Centraal-Duivendrecht", 31 },
            { "Utrecht Centraal-Weesp", 57 },
            { "Utrecht Centraal-Utrecht Centraal", 0 },
            
            // Alle reizen vanaf Geldermalsen
            { "Geldermalsen-Hilversum", 44 },
            { "Geldermalsen-Duivendrecht", 57 },
            { "Geldermalsen-Weesp", 59 },
            { "Geldermalsen-Geldermalsen", 0 },
            // Alle reizen vanuit Hilversum
            { "Hilversum-Duivendrecht", 18 },
            { "Hilversum-Weesp", 15 },
            { "Hilversum-Hilversum", 0 },
            // Alle reizen vanuit Duivendrecht
            { "Duivendrecht-Weesp", 3 },
            { "Duivendrecht-Duivendrecht", 0 },

            // Alle reizen vanuit Weesp
            { "Weesp-Weesp", 0 },
        };

        /*
        public class Reis
        {
            public string Startplaats;
            public string Eindbestemming;

            public Reis(string start, string eind)
            {
                Startplaats = start;
                Eindbestemming = eind;
            }
        }

        public class ReisEqualityComparer : IEqualityComparer<Reis>
        {
            #region IEqualityComparer<Reis> Members

            public bool Equals(Reis x, Reis y)
            {
                return ((x.Startplaats == y.Startplaats) & (x.Eindbestemming == y.Eindbestemming));
            }

            public int GetHashCode(Reis obj)
            {
                string combined = obj.Startplaats + "|" + obj.Eindbestemming.ToString();
                return (combined.GetHashCode());
            }

            #endregion
        }
        */

    }
}
