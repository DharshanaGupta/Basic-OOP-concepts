using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public enum VaccineName{Select,Covishield,Covaccine};
    public class Vaccine
    {
        //static field
        /// <summary>
        /// private property for holding vaccine id 
        /// </summary>
        private static int s_vaccineID=2000;
        /*
        a.	VaccineID {Auto Incremented ID – CID2001}
        b.	VaccineName {Enum – Covishield, Covaccine}
        c.	NoOfDoseAvailable
        */
        //property
        public string VaccineID{get;}//read only property
        public VaccineName VaccineName{get;set;}
        public int NoOfDoseAvailable{get;set;}

        //Constructor
        public Vaccine(VaccineName vaccineName,int noOfDoseAvailable)
        {
            //auto incrementation
            s_vaccineID++;
            VaccineID="CID"+s_vaccineID;

            VaccineName=vaccineName;
            NoOfDoseAvailable=noOfDoseAvailable;
        }
    }
}