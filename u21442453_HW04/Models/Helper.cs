using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21442453_HW04.Models
{
    public class Helper : Person
    {
        private string mEmail;
        private string mPhoneNumber;
        private string mGrade;

        public Helper() : base() { }

        public Helper(string inFName, string inLName, int inAge, string inEmail, string inPhoneNumber, string inGrade) : base(inFName, inLName, inAge)
        {
            this.mEmail = inEmail;
            this.mPhoneNumber = inPhoneNumber;
            this.mGrade = inGrade;
        }

        public override string getContactDetails()
        {
            return "Email: " + mEmail + ", Phone Number: " + mPhoneNumber;
        }


        public string GetHelperGrade()
        {
            return mGrade;
        }
    }
}