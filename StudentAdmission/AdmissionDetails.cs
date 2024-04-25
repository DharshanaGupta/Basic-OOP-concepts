using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //enum
    public enum AdmissionStatus{Select,Admitted,Cancelled};
    public class AdmissionDetails
    {
        /*
        a.	AdmissionID – (Auto Increment ID - AID1001)
        b.	StudentID
        c.	DepartmentID
        d.	AdmissionDate
        e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)*/

        //static field
        private static int s_admissionID=1000;

        //property
        public string AdmissionID{get;}//read only property
        public string StudentID{get;set;}
        public string DepartmentID{get;set;}
        public DateTime AdmissionDate{get;set;}
        public AdmissionStatus AdmissionStatus{get;set;}

        //constructor
        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate, AdmissionStatus admissionStatus)
        {
            //auto incrementation
            s_admissionID++;

            AdmissionID="AID"+s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
        }

        //constructor for reading admission details data from csv
        public AdmissionDetails(string admission)
        {
            string[] values=admission.Split(",");
            AdmissionID="AID"+values[0];
            s_admissionID=int.Parse(values[0].Remove(0,3));
            StudentID=values[1];
            DepartmentID=values[2];
            AdmissionDate=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            AdmissionStatus=Enum.Parse<AdmissionStatus>(values[4]);
        }

    }
}