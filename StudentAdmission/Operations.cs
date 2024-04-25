using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //static class
    public static class Operations
    {
        //local object creation
         static StudentDetails currentLoggedInStudent;
        //static string temp=

        //static list creation
        public static List<StudentDetails> studentList = new List<StudentDetails>();
        public static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        public static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

        //Main Menu
        public static void MainMenu()
        {
            Console.WriteLine("******Welcome to Syncfusion college of Engineering*******");
            //need to show main menu

            string mainChoice="yes";
            do
            {
                //need to show main menu
                Console.WriteLine("Mainmenu \n1.Registration \n2.Student Login \n3.Department wise Seat Availability \n4.Exit");
                //need to get input from user and validate.
                Console.WriteLine("Select an Option:");
                int mainOption =int.Parse(Console.ReadLine());

                //to create main menu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("******Student Registration*******");
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("******Student Login******");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("******Departmnet wise Seat Availability******");
                            DepartmentWiseSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Application Exited Successfully");
                            mainChoice="no";
                            break;
                        }
                }
                //need to iterate the main menu until option is exit
            } while(mainChoice=="yes");
        }//main menu ends

        //student registration
        public static void Registration()
        {
            //need to get required details
            Console.Write("Enter your Name: ");
            string studentName=Console.ReadLine();
            Console.Write("Enter your Father Name: ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter your Date of Birth dd/MM/yyyy: ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your Gender(Male/Female/Transgender): ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter Physics Mark: ");
            int physics=int.Parse(Console.ReadLine());
            Console.Write("Enter Chemistry Mark: ");
            int chemistry=int.Parse(Console.ReadLine());
            Console.Write("Enter Maths Mark: ");
            int maths=int.Parse(Console.ReadLine());
            //need to create object
            StudentDetails student=new StudentDetails(studentName,fatherName,dob,gender,physics,chemistry,maths);
            //need to add in list
            studentList.Add(student);
            //need to confirmation message and studentID
            Console.WriteLine($"Student Registered Successfully and StudentID is {student.StudentID}");
        }//student registration ends

        //student Login
        public static void Login()
        {
            //need to get studentID input
            Console.Write("Enter your StudentID: ");
            string loginID=Console.ReadLine().ToUpper();
            //validate the ID present in studentlist 
            bool flag=true;
            foreach(StudentDetails student in studentList)
            {
                if(loginID.Equals(student.StudentID))
                {
                    flag=false;
                    //assigning current user to global variable
                    currentLoggedInStudent=student;
                    Console.WriteLine("Logged In Successfully");
                    //need to call submenu
                    SubMenu();
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid ID");
            }
            //if ID is not present show "Invalid ID"
            
            
        }//student login ends

        //submenu
        public static void SubMenu()
        {
            string subChoice="yes";
            do{
                Console.WriteLine("***********SubMenu**********");
                //need to show submenu 
                Console.WriteLine("Select an Option \n1.Check Eligibility \n2.Show Details \n3.Take Admission \n4.Cancel Admission \n5.Show Admission Details \n6.Exit");
                //getting user option 
                Console.WriteLine("Enter an option");
                int subOption=int.Parse(Console.ReadLine());
                //need to create submenu
                switch(subOption)
                {
                    case 1:
                    {
                        Console.WriteLine("******Check Eligibility******");
                        CheckEligibility();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("******Show Details*******");
                        ShowDetails();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("*******Take Admission********");
                        TakeAdmission();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("*******Cancel Admission*******");
                        CancelAdmission();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("*******Show Admission Details");
                        ShowAdmissionDetails();
                        break;
                    }
                    case 6:
                    {
                        Console.WriteLine("Taking back to Mainmenu");
                        subChoice="no";
                        break;
                    }
                }
                //iterate until the option is exit
            }while(subChoice=="yes");
        }//submenu ends

        //CheckEligibility
        public static void CheckEligibility()
        {
            //get the cutoff value as input
            Console.WriteLine("Enter the cutOff value");
            double cutOff=double.Parse(Console.ReadLine());
            //check eligible or not
            if(currentLoggedInStudent.CheckEligibility(cutOff))
            {
                Console.WriteLine("Student is eligible");
            }
            else{
                Console.WriteLine("Student is not eligible");
            }
            
        }//CheckEligibility ends

        //Show Details
        public static void ShowDetails()
        {
            //need to show current student details
            Console.WriteLine("|Student ID|Student Name|Father Name|DOB|Gender|Physics|Chemistry|Maths|");
            Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.Physics}|{currentLoggedInStudent.Chemistry}|{currentLoggedInStudent.Maths}");

        }//Show Details ends

        //Take Admission
        public static void TakeAdmission()
        {
            //need to show seat availability of each department
            DepartmentWiseSeatAvailability();
            //ask user to enter department ID
            Console.WriteLine("Select an Department ID");
            string departmentID=Console.ReadLine().ToUpper();
            //check ID present or not
            bool flag=true;
            foreach(DepartmentDetails department in departmentList)
            {
                if(departmentID.Equals(department.DepartmentID))
                {
                    flag=false;
                    //Check if the student is eligible or not
                    if(currentLoggedInStudent.CheckEligibility(75.0))
                    {
                        //check seat availability
                        if(department.NumberOfSeats>0)
                        {
                            //check student already taken admission
                            int count=0;
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;
                                }
                            }
                            if(count==0)
                            {
                                //create admission object 
                                AdmissionDetails admissionTaken = new AdmissionDetails(currentLoggedInStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Admitted);
                                //Reduce seat count
                                department.NumberOfSeats--;
                                // add to admissionList
                                admissionList.Add(admissionTaken);
                                //display admission successful message
                                Console.WriteLine($"Admission took successfully. Your admission ID {admissionTaken.AdmissionID}");
                            }
                            else{
                                Console.WriteLine("You have Already taken Admission");
                            }
                            
                        }
                        else{
                            Console.WriteLine("Seats are Not Available");
                        }
                        
                    }
                    else{
                        Console.WriteLine("You are not Eligible due to low cutOff");
                    }
                    
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid ID or ID not present");
            }
            
        }//Take Admission ends

        //Cancel Admission
        public static void CancelAdmission()
        {
            bool flag=true;
            //check the student taken any admission and display it
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    //cancel the found admission
                    admission.AdmissionStatus=AdmissionStatus.Cancelled;
                    //return the seat to the department
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            Console.WriteLine("Admission Cancelled Successfully");
                            break;
                        }
                    }
                }
                break;

            }
            if(flag)
            {
                Console.WriteLine("You have no admission to cancel");
            }
            
        }//Cancel Admission ends

        //Admission Details
        public static void ShowAdmissionDetails()
        {
            //need to show admission details of the currently logged in student
            Console.WriteLine("|Admission ID|Student ID|Department ID|Admission Date|Admission Status");
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID))
                {
                    Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}");
                }
            }

        }//Admission Details ends


        //Department wise seat availability
        public static void DepartmentWiseSeatAvailability()
        {
            //need to show all department details
            string line="__________________________________________";
            Console.WriteLine(line);
            Console.WriteLine("|DepartmentID|DepartmentName|NumberOfSeats|");
            Console.WriteLine(line);
            foreach(DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"|{department.DepartmentID,-12}|{department.DepartmentName,-14}|{department.NumberOfSeats,-13}|");
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }//Department wise seat availability ends

        //adding default data
        public static void AddDefaultData()
        {
            StudentDetails student1=new StudentDetails("Ravichandran E","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            StudentDetails student2 = new StudentDetails("Baskaran S","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            studentList.AddRange(new List<StudentDetails>(){student1,student2});
            
            DepartmentDetails department1=new DepartmentDetails("EEE",29);
            DepartmentDetails department2=new DepartmentDetails("CSE",29);
            DepartmentDetails department3=new DepartmentDetails("MECH",30);
            DepartmentDetails department4=new DepartmentDetails("ECE",30);
            departmentList.AddRange(new List<DepartmentDetails>(){department1,department2,department3,department4});

            AdmissionDetails admission1=new AdmissionDetails(student1.StudentID,department1.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Admitted);
            AdmissionDetails admission2=new AdmissionDetails(student2.StudentID,department2.DepartmentID,new DateTime(2022,05,12),AdmissionStatus.Admitted);
            admissionList.AddRange(new List<AdmissionDetails>(){admission1,admission2});

            //to print the default data
            
            
            
        } //Default Data ends  

    }
}