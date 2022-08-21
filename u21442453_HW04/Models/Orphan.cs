using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21442453_HW04.Models
{
    public class Orphan : Person
    {
        private string mGender;

        public Orphan() : base() {}

        public Orphan(string inFName, string inLName, int inAge, string inGender):base(inFName, inLName, inAge)
        {
            this.mGender = inGender;
        }

        public string Gender { get => mGender; }

        public override string getContactDetails()
        {
            throw new NotImplementedException();
        }


        public override string getGrade()
        {
            switch (base.MAge)
            {
                case 7:
                    return "Grade 1";
                case 8:
                    return "Grade 2";
                case 9:
                    return "Grade 3";
                case 10:
                    return "Grade 4";
                case 11:
                    return "Grade 5";
                case 12:
                    return "Grade 6";
                case 13:
                    return "Grade 7";
                case 14:
                    return "Grade 8";
                case 15:
                    return "Grade 9";
                case 16:
                    return "Grade 10";
                case 17:
                    return "Grade 11";
                case 18:
                    return "Grade 12";
                default:
                    return "Not in school.";
            }
        }
    }
}