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
            string Reis = Start + "-" + Eind;
            if (OverzichtTarief.Tarief.ContainsKey(Reis))
            {
               Tarief = OverzichtTarief.Tarief[Reis];
            }
            else
            {
                Reis = Eind + "-" + Start;

                Tarief = OverzichtTarief.Tarief[Reis];

            }
            MessageBox.Show(Convert.ToString(Tarief));
            return Tarief;
        }
       



    }
}
