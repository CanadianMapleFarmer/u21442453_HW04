using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21442453_HW04.Models
{
    public class Donation
    {
        private string pType;
        private int pQuantity;

        public Donation()
        {
        }

        public Donation(string iType, int iQuantity)
        {
            this.pType = iType;
            this.pQuantity = iQuantity;
        }

        public string PType { get => pType; }
        public int PQuantity { get => pQuantity; }

    }
}