using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21442453_HW04.Models
{
    public class FosterParent : Person
    {
        private string mEmail;
        private string mPhoneNumber;
        private string mGrade;

        public FosterParent() : base() { }

        public FosterParent(string inFName, string inLName, int inAge, string inEmail, string inPhoneNumber, string inGrade) : base(inFName, inLName, inAge)
        {
            this.mEmail = inEmail;
            this.mPhoneNumber = inPhoneNumber;
            this.mGrade = inGrade;
        }

        public override string getContactDetails()
        {
            return "Email: " + mEmail + ", Phone Number: " + mPhoneNumber;
        }

        public string GetFosterOrphanGrade()
        {
            return mGrade;
        }
    }
}