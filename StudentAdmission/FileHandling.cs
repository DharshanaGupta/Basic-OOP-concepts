using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public static class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("StudentAdmission"))
            {
                System.Console.WriteLine("Creating Folder..");
                Directory.CreateDirectory("StudentAdmission");
            }
            //File for StudentDetails
            if(!File.Exists("StudentAdmission/StudentDetails.csv"))
            {
                System.Console.WriteLine("Creating File..");
                File.Create("StudentAdmission/StudentDetails.csv").Close();
            }

            //File for DepartmentDetails
            if(!File.Exists("StudentAdmission/DepartmentDetails.csv"))
            {
                System.Console.WriteLine("Creating File..");
                File.Create("StudentAdmission/DepartmentDetails.csv").Close();
            }

            //File for AdmissionDetails
            if(!File.Exists("StudentAdmission/AdmissionDetails.csv"))
            {
                System.Console.WriteLine("Creating File..");
                File.Create("StudentAdmission/AdmissionDetails.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            //studentDetails 
            //storing the each object values as arrays
            string[] students=new string[Operations.studentList.Count];
            for(int i=0;i<Operations.studentList.Count;i++)
            {
                students[i]=Operations.studentList[i].StudentName+","+Operations.studentList[i].FatherName+","+Operations.studentList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.studentList[i].Gender+","+Operations.studentList[i].Physics+","+Operations.studentList[i].Chemistry+","+Operations.studentList[i].Maths;

            }
            File.WriteAllLines("StudentAdmission/StudentDetails.csv",students);

            //DepartmentDeatails
            string [] departments=new string[Operations.departmentList.Count];
            for(int i=0;i<Operations.departmentList.Count;i++)
            {
                departments[i]=Operations.departmentList[i].DepartmentID+","+Operations.departmentList[i].DepartmentName+","+Operations.departmentList[i].NumberOfSeats;

            }
            File.WriteAllLines("StudentAdmission/DepartmentDetails.csv",departments);

            //AdmissionDetails
            string[] admissions=new string[Operations.admissionList.Count];
            for(int i=0;i<Operations.admissionList.Count;i++)
            {
                admissions[i]=Operations.admissionList[i].AdmissionID+","+Operations.admissionList[i].StudentID+","+Operations.admissionList[i].DepartmentID+","+Operations.admissionList[i].AdmissionDate.ToString("dd/MM/yyyy")+","+Operations.admissionList[i].AdmissionStatus;
            }
            File.WriteAllLines("StudentAdmission/AdmissionDetails.csv",admissions);
        }

        //to get data from csv files to our application
        public static void ReadFromCSV()
        {
            //StudentDetails
            string[] students=File.ReadAllLines("StudentAdmission/StudentDetails.csv");
            foreach(string student in students)
            {
                StudentDetails student1=new StudentDetails(student);
                Operations.studentList.Add(student1);
            }

            //DepartmentDetails
            string[] departments=File.ReadAllLines("StudentAdmission/DepartmentDetails.csv");
            foreach(string department in departments)
            {
                DepartmentDetails department1=new DepartmentDetails(department);
                Operations.departmentList.Add(department1);
            }

            //for AdmissionDetails
            string[] admissions=File.ReadAllLines("StudentAdmission/AdmissionDetails.csv");
            foreach(string admission in admissions)
            {
                AdmissionDetails admission1=new AdmissionDetails(admission);
                Operations.admissionList.Add(admission1);
            }
        }
    }
}