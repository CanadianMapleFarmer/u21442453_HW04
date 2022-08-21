using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21442453_HW04.Models
{
    public abstract class Person
    {
        private string mFirstName;
        private string mLastName;
        private int mAge;


        public Person(string fName, string lName, int age)
        {
            this.mFirstName = fName;
            this.mLastName = lName;
            this.mAge = age;
        }

        protected Person()
        {
        }

        public string MFirstName { get => mFirstName; }
        public string MLastName { get => mLastName; }
        public int MAge { get => mAge; }

        public abstract string getContactDetails();

        public virtual string getGrade()
        {
            return mAge.ToString();
        }

        public string GetFullName()
        {
            return $"{mFirstName} {mLastName}";
        }
    }
}