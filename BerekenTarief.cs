using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    class BerekenTarief
    {
       
        public static int BerekenReisTarief(String Start, String Eind)
        {
            int Tarief = 0;
            // De reis wordt opgesteld. Deze waarde wordt daarna opgezocht in de tarief dictionary.
            string Reis = Start + "-" + Eind;
            if (OverzichtTarief.TariefDictionary.ContainsKey(Reis))
            {
               Tarief = OverzichtTarief.TariefDictionary[Reis];
            }
            // Als de reis zich niet in de tarief dictionary bevindt, wordt de reis omgedraaid om te kijken
            // of hij er andersom wel in zit.
            else
            {
                Reis = Eind + "-" + Start;

                Tarief = OverzichtTarief.TariefDictionary[Reis];

            }
            MessageBox.Show(Convert.ToString(Tarief));
            return Tarief;
        }
       



    }
}
