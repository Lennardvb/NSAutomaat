using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public interface KiesReisType
    {
        String KiesReis();
        int ReisTypePrijsToevoeging();
    }

    public class EnkeleReis : KiesReisType
    {
        public string KiesReis()
        {
            return "EnkeleReis";
        }

        public int ReisTypePrijsToevoeging()
        {
            return 1;
        }
    }

    public class RetourReis : KiesReisType
    {
        public string KiesReis()
        {
            return "RetourReis";
        }

        public int ReisTypePrijsToevoeging()
        {
            return 2;
        }
    }
}
