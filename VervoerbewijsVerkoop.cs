using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    class VervoerbewijsVerkoop
    {
        private void Startverkoop()
        {
            // Begin de verkoop
        }

        private void StopVerkoop()
        {
            // Eindig de verkoop
        }

        public static void CreëerBetaling(UIInfo info)
        {
            if (info.Betaalmethode.BetaalmethodeNaam() == "Contant")
            {
                MessageBox.Show("TESTEST");
            }

            else
            {
                info.Betaalmethode.Connect();
                info.Betaalmethode.BeginTransaction((float)PrijsBerekenaar.BerekenPrijs(info));
                info.Betaalmethode.Disconnect();
            }
        }
    }
}
