using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    
    public class Vaccination
    {
        //static field
        private static int s_vaccinationID=3000;
        /*
        •	VaccinationID (Auto increment – VID3001)
        •	Registration Number (Beneficiary Reg. num)
        •	VaccineID
        •	DoseNumber – (1,2,3)
        •	Vaccinated Date (DateTime.Now)*/

        //property
        public string VaccinationID{get;}//read only property
        public string RegistrationNumber{get;set;}
        public string VaccineID{get;set;}
        public int DoseNumber{get;set;}
        public DateTime VaccinatedDate{get;set;}

        //constructor
        public Vaccination(string registrationNumber,string vaccineID,int doseNumber,DateTime vaccinatedDate)
        {
            //auto incrementation
            s_vaccinationID++;
            VaccinationID="VID"+s_vaccinationID;

            RegistrationNumber=registrationNumber;
            VaccineID=vaccineID;
            DoseNumber=doseNumber;
            VaccinatedDate=vaccinatedDate;

        }

    }
}