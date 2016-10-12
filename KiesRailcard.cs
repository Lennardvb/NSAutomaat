using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public interface KiesRailcard
    {
        string KiesKortingsPercentage();
        decimal KortingsPercentage();
    }

    public class GeenKorting : KiesRailcard
    {
        public string KiesKortingsPercentage()
        {
            return "Geen Korting";
        }

        public decimal KortingsPercentage()
        {
            return 0;
        }
    }

    public class TwintigProcentKorting : KiesRailcard
    {
        public string KiesKortingsPercentage()
        {
            return "20% Korting";
        }

        public decimal KortingsPercentage()
        {
            return 0.20m;
        }
    }

    public class VeertigProcentKorting : KiesRailcard
    {
        public string KiesKortingsPercentage()
        {
            return "40% Korting";
        }

        public decimal KortingsPercentage()
        {
            return 0.40m;
        }
    }
}
