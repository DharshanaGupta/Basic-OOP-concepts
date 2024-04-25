using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //Enum
    public enum Gender{Select,Male,Female};
    public class StudentDetails
    {
        /*a.	StudentID – (AutoGeneration ID – SF3000)
        b.	StudentName
        c.	FatherName
        d.	DOB
        e.	Gender – Enum (Male, Female, Transgender)
        f.	Physics
        g.	Chemistry
        h.	Maths
        */
        //field
        //static field
        private static int s_studentID=3000;
        //properties
        public string StudentID{get;}//read only property
        public string StudentName{get;set;}
        public string FatherName{get;set;}
        public DateTime DOB{get;set;}
        public Gender Gender{get;set;}
        public int Physics{get;set;}
        public int Chemistry{get;set;}
        public int Maths{get;set;}

        //constructor
        public StudentDetails(string studentName,string fatherName,DateTime dob, Gender gender, int physics,int chemistry,int maths)
        {
            //auto incrementation
            s_studentID++;

            StudentID="SF"+s_studentID;
            StudentName=studentName;
            FatherName=fatherName;
            DOB=dob;
            Gender=gender;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }

        //for reading student data from csv file
        public StudentDetails(string student)
        {
            string[] values=student.Split(",");
            StudentID="SF"+values[0];
            s_studentID=int.Parse(values[0].Remove(0,2));
            StudentName=values[1];
            FatherName=values[2];
            DOB=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            Gender=Enum.Parse<Gender>(values[4]);
            Physics=int.Parse(values[5]);
            Chemistry=int.Parse(values[6]);
            Maths=int.Parse(values[7]);
        }


        //Methods 
        public double Average()
        {
            int total=Physics+Chemistry+Maths;
            double average=(double)total/3;
            return average;
        }

        public bool CheckEligibility(double cutOff)
        {
            if(Average() >= cutOff)
            {
                return true;
            }
            else{
                return false;
            }
        }
    }
}