using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21442453_HW04.Models
{
    public class Donor: Person
    {
        private string mEmail;
        private string mPhoneNumber;
        private Donation mItem = new Donation();

        public Donor() : base() { }

        public Donor(string inFName, string inLName, int inAge, string inEmail, string inPhoneNumber, Donation inItem) : base(inFName, inLName, inAge)
        {
            this.mEmail = inEmail;
            this.mPhoneNumber = inPhoneNumber;
            this.mItem = inItem;
        }

        public override string getContactDetails()
        {
            return "Email: " + mEmail + ", Phone Number: " + mPhoneNumber;
        }

        public string GetDonationItemType()
        {
            return mItem.PType;
        }
        public int GetDonationItemQuantity()
        {
            return mItem.PQuantity;
        }

    }
}