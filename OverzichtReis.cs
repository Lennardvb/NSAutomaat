using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public static class OverzichtReis
    {
        /*
        public static string BerekenReis(string Startplaats, string Eindbestemming)
        {
           
           string totaleReis = Startplaats + "-" + Eindbestemming;

            return totaleReis;
        }
        */

        private class Reis
        {
            public string Startplaats;
            public string Eindbestemming;

            public Reis(string start, string eind)
            {
                Startplaats = start;
                Eindbestemming = eind;
            }
        }

        private class ReisEqualityComparer : IEqualityComparer<Reis>
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

    }
}
