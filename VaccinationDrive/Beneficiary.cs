using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public enum Gender{Select,Male,Female,Others};
    public class Beneficiary
    {
        //static field
        /// <summary>
        /// private field for user id
        /// </summary>
        private static int s_beneficiaryID=1000;


        //property
        /*
        a.	Registration Number (Auto Incremented BID1001)
        b.	Name
        c.	Age
        d.	Gender (Enum [Male, Female, Others])
        e.	Mobile Number
        f.	City
        */

        /// <summary>
        /// holds the register number
        /// </summary> 
        /// <value></value>
        public string RegistrationNumber{get;}//Read only property
        /// <summary>
        /// holds the name of the user 
        /// </summary> 
        /// <value></value>
        public string Name{get;set;}
        /// <summary>
        /// holds the age of user
        /// </summary>
        /// <value></value>
        public int Age{get;set;}
        /// <summary>
        /// holds the gender of the user
        /// </summary>
        /// <value></value>
        public Gender Gender{get;set;}
        /// <summary>
        /// holds the mobile number of the user
        /// </summary>
        /// <value></value>
        public string MobileNumber{get;set;}
        /// <summary>
        /// holds the location of the user
        /// </summary>
        /// <value></value>
        public string City{get;set;}

        /// <summary>
        /// constructor for getting details from user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="city"></param>
        /// <param name="city"></param>
        public Beneficiary(string name,int age,Gender gender,string mobileNumber,string city)
        {
            //auto incrementation
            s_beneficiaryID++;
            RegistrationNumber="BID"+s_beneficiaryID;

            Name=name;
            Age=age;
            Gender=gender;
            MobileNumber=mobileNumber;
            City=city;
        }
    }
}