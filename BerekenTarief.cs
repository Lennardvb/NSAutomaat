using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    class BerekenTarief
    {
        // !! Dit is een alternatief voor het berekenen van het tarief !!// !! Dit is een alternatief voor het berekenen van het tarief !!
        public static int BerekenReisTarief(String Start, String Eind)
        {
            int Tarief = 0;
            // De reis wordt opgesteld. Deze waarde wordt daarna opgezocht in de tarief dictionary.
            string Reis = Start + "-" + Eind;
            if (AlternatiefOverzichtTarief.TariefDictionary.ContainsKey(Reis))
            {
               Tarief = AlternatiefOverzichtTarief.TariefDictionary[Reis];
            }
            // Als de reis zich niet in de tarief dictionary bevindt, wordt de reis omgedraaid om te kijken
            // of hij er andersom wel in zit.
            else
            {
                Reis = Eind + "-" + Start;

                Tarief = AlternatiefOverzichtTarief.TariefDictionary[Reis];

            }
            return Tarief;
        }
       



    }
}
