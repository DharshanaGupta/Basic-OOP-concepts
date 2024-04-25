using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    
    public class DepartmentDetails
    {
        /*
        a.	DepartmentID – (AutoIncrement - DID101)
        b.	DepartmentName
        c.	NumberOfSeats
        */
        //field
        //static field
        private static int s_departmentID=100;

        //property
        public string DepartmentID{get;}//read only property
        public string DepartmentName{get;set;}
        public int NumberOfSeats{get;set;}

        //constructor
        public DepartmentDetails(string departmentName,int numberOfSeats)
        {
            //auto incrementation
            s_departmentID++;

            DepartmentID="DID"+s_departmentID;
            DepartmentName=departmentName;
            NumberOfSeats=numberOfSeats;
        }

        //constructor for reading department data from csv file
        public DepartmentDetails(string department)
        {
            string[] values=department.Split(",");
            DepartmentID="DID"+values[0];
            s_departmentID=int.Parse(values[0].Remove(0,2));
            DepartmentName=values[1];
            NumberOfSeats=int.Parse(values[2]);
        }
    }
}