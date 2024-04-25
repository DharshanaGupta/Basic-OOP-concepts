using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public static class Operations
    {
        static Beneficiary currentloggedInUser;
        //static list creation
        static List<Beneficiary> beneficiaryList=new List<Beneficiary>();
        static List<Vaccine> vaccineList=new List<Vaccine>();
        static List<Vaccination> vaccinationList=new List<Vaccination>();

        //mainmenu
        public static void MainMenu()
        {
            Console.WriteLine("*****MainMenu******");
            //need to get the main menu option and display
            string mainChoice="yes";
            do{
                Console.WriteLine("1.Beneficiary Registration \n2.Login \n3.Get Vaccine Info \n4.Exit");
                int maninMenuOption=int.Parse(Console.ReadLine());

                switch(maninMenuOption)
                {
                    case 1:
                    {
                        Console.WriteLine("********Beneficiary Registration********");
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("*********Login*******");
                        Login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("*********Get Vaccine Info*********");
                        GetVaccineInfo();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Apllication Exited Successfully");
                        mainChoice="no";
                        break;
                    }
                }
            }while(mainChoice=="yes");
        }//main menu ends
        
        //Registration
        public static void Registration()
        {
            Console.Write("Enter your Name: ");
            string name=Console.ReadLine();
            Console.Write("Enter your Age: ");
            int age=int.Parse(Console.ReadLine());
            Console.Write("Enter your Gender: ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your mobile number: ");
            string mobileNumber=Console.ReadLine();
            Console.Write("Enter your City: ");
            string city=Console.ReadLine();

            Beneficiary beneficiary=new Beneficiary(name,age,gender,mobileNumber,city);
            beneficiaryList.Add(beneficiary);
            Console.WriteLine($"Registration Successfull, Your Beneficiary ID is {beneficiary.RegistrationNumber}");
        }//Registration ends

        //Login
        public static void Login()
        {
            //need to get Registration Number
            Console.Write("Enter your BeneficiaryID/Registration Number: ");
            string beneficiaryID=Console.ReadLine().ToUpper();
            //validate the Registration Number
            bool flag=true;
            foreach(Beneficiary beneficiary in beneficiaryList)
            {
                if(beneficiaryID.Equals(beneficiary.RegistrationNumber))
                {
                    flag=false;
                    currentloggedInUser=beneficiary;
                    //if Registration Number found show the submenu
                    SubMenu();
                }
            }
            //if not found show "Invalid ID"
            if(flag)
            {
                Console.WriteLine("Invalid Login ID");
            } 

        }//Login ends
        //submenu
        public static void SubMenu()
        {
            Console.WriteLine("******Submenu********");
            string subChoice="yes";
            do{
                //get an option from user
                Console.WriteLine("1.Show My Details \n2.Take Vaccination \n3.My Vaccination History \n4.Next Due Day \n5.Exit");
                int subOption=int.Parse(Console.ReadLine());
                switch(subOption)
                {
                    case 1:
                    {
                        Console.WriteLine("********Show My Details*********");
                        ShowMyDetails();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("********Take Vaccination*********");
                        TakeVaccination();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("***********My Vaccination History*************");
                        MyVaccineHistory();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("*****Next Due Day****");
                        NextDueDay();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Taking Back to Mainmenu");
                        subChoice="no";
                        break;
                    }
                }
            }while(subChoice=="yes");
        }//submenu ends

        //ShowMyDetails
        public static void ShowMyDetails()
        {
            //need to display the details of current user
            Console.WriteLine("|Register Number|Name|Age|Gender|Mobile Number|City|");
            Console.WriteLine($"|{currentloggedInUser.RegistrationNumber}|{currentloggedInUser.Name}|{currentloggedInUser.Age}|{currentloggedInUser.Gender}|{currentloggedInUser.MobileNumber}|{currentloggedInUser.City}|");

        }//ShowMyDetails ends

        //TakeVaccination
        public static void TakeVaccination()
        {
            //show the vaccine list
            GetVaccineInfo();
            //ask user to choose any vaccine id
            Console.Write("Select a vaccine by Vaccine ID: ");
            string vaccineID=Console.ReadLine();
            string vaccineid="false";
            int vaccineCount=0;
            //validate the vaccine ID
            foreach(Vaccine vaccine in vaccineList)
            {
                if(vaccineID.Equals(vaccine.VaccineID))
                {
                    vaccineid="true";
                    //validate that user had vaccination before
                    foreach(Vaccination myvaccination in vaccinationList)
                    {
                        if(currentloggedInUser.RegistrationNumber.Equals(myvaccination.RegistrationNumber))
                        {
                            
                            Console.WriteLine($"|{myvaccination.VaccinationID}|{myvaccination.RegistrationNumber}|{myvaccination.VaccineID}|{myvaccination.DoseNumber}|{myvaccination.VaccinatedDate}|");
                            //checking vaccination count
                            vaccineCount++;
                        }
                    }
                    //if user not taken vaccine check user age
                    if(vaccineCount==0)
                    {
                        if(currentloggedInUser.Age>14)
                        {
                            Vaccination vaccination=new Vaccination(currentloggedInUser.RegistrationNumber,vaccine.VaccineID,1,DateTime.Now);
                            vaccinationList.Add(vaccination);
                            vaccine.NoOfDoseAvailable--;
                            Console.WriteLine("Vaccination Successful");
                        }
                    }
                    if(vaccineCount==3)
                    {
                        Console.WriteLine("All the three Vaccination are completed, you cannot be vaccinated now");
                    }
                    else if(vaccineCount==1 || vaccineCount==2)
                    {
                        DateTime date=DateTime.Now;
                        foreach(Vaccination myvaccination in vaccinationList)
                        {
                            if(vaccineID.Equals(myvaccination.VaccineID))
                            {
                                date=myvaccination.VaccinatedDate;
                            }
                        }
                        //if user choose same vaccine need to check whether user vaccined before 30 days
                        DateTime toVaccine=date.AddDays(30);
                        TimeSpan span= DateTime.Now-toVaccine;
                        if(span.TotalDays>30)
                        {
                            Vaccination vaccination1=new Vaccination(currentloggedInUser.RegistrationNumber,vaccine.VaccineID,2,DateTime.Now);
                            vaccinationList.Add(vaccination1);
                            vaccine.NoOfDoseAvailable--;
                            Console.WriteLine("Vaccination Successful");
                        }
                        else{
                            Console.WriteLine("You have selected different vaccine”. You can vaccine with “Covaccine / Covishield (His first / second dose vaccine type)");
                        }
                    }
                }
            }
            if(vaccineid=="false")
            {
                Console.WriteLine("Invalid Vaccine Id");
            }
        }//TakeVaccination ends

        //MyVaccineHistory
        public static void MyVaccineHistory()
        {
            // Console.WriteLine("Enter your BeneficiaryID");
            // string beneficiaryID=Console.ReadLine();
            Console.WriteLine("|VaccinationID|RegisterNumber|VaccineID|DoseNumber|VaccinatedDate|");
            foreach(Vaccination myvaccination in vaccinationList)
            {
                if(currentloggedInUser.RegistrationNumber.Equals(myvaccination.RegistrationNumber))
                {
                    Console.WriteLine($"|{myvaccination.VaccinationID}|{myvaccination.RegistrationNumber}|{myvaccination.VaccineID}|{myvaccination.DoseNumber}|{myvaccination.VaccinatedDate}|");
                }
            }
        }//MyVaccineHistory ends

        //NextDueDay
        public static void NextDueDay()
        {
            //need to show the next vaccination by traversing his vaccination history
            int vaccineDone=0;
            bool flag=true;
            foreach(Vaccination vaccination in vaccinationList)
            {
                if(currentloggedInUser.RegistrationNumber.Equals(vaccination.RegistrationNumber))
                {
                    flag=false;
                    vaccineDone++;
                }    
            }
            //if user took already 1/2 doses show next due by adding 30days
            //if all three dose completed show"completed all vaccination"
            foreach(Vaccination vaccination in vaccinationList)
            {
                if( vaccineDone>1&&vaccination.DoseNumber==2 && currentloggedInUser.RegistrationNumber==vaccination.RegistrationNumber)
                {
                    DateTime date=vaccination.VaccinatedDate;
                    Console.WriteLine("Your next vaccine due is on "+date.AddDays(30));
                }
                else if(vaccineDone==1 && vaccination.DoseNumber==1 && currentloggedInUser.RegistrationNumber==vaccination.RegistrationNumber)
                {
                    DateTime date=vaccination.VaccinatedDate;
                    Console.WriteLine("Your next vaccine due is on "+date.AddDays(30));
                }
                else if(vaccineDone==3)
                {
                    Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive.");
                }

            }
            //if he didn't take any dose , show "you can take now"
            if(flag)
            {
                Console.WriteLine("you can take vaccine now");
            }
            
            


        }//NextDueDay ends

        //GetVaccineInfo
        public static void GetVaccineInfo()
        {
            Console.WriteLine("|VaccineID|VaccineName|NoOfDoseAvailable|");
            foreach(Vaccine vaccine in vaccineList)
            {
                Console.WriteLine($"|{vaccine.VaccineID}|{vaccine.VaccineName}|{vaccine.NoOfDoseAvailable}|");
            }
        }//GetVaccineInfo ends

        //adding the Default data
        public static void AddingDefaultData()
        {
            Beneficiary beneficiary1=new Beneficiary("Ravichandran",21,Gender.Male,"8484484","Chennai");
            Beneficiary beneficiary2=new Beneficiary("Baskaran",22,Gender.Male,"8484747","Chennai");
            beneficiaryList.AddRange(new List<Beneficiary>(){beneficiary1,beneficiary2});

            Vaccine vaccine1=new Vaccine(VaccineName.Covishield,50);
            Vaccine vaccine2=new Vaccine(VaccineName.Covaccine,50);
            vaccineList.AddRange(new List<Vaccine>(){vaccine1,vaccine2});

            Vaccination vaccination1=new Vaccination(beneficiary1.RegistrationNumber,vaccine1.VaccineID,1,new DateTime(2021,11,11));
            Vaccination vaccination2=new Vaccination(beneficiary1.RegistrationNumber,vaccine1.VaccineID,2,new DateTime(2022,03,11));
            Vaccination vaccination3=new Vaccination(beneficiary2.RegistrationNumber,vaccine2.VaccineID,1,new DateTime(2022,04,04));
            vaccinationList.AddRange(new List<Vaccination>(){vaccination1,vaccination2,vaccination3});

            // //to print the default data
            // Console.WriteLine("|Register Number|Name|Age|Gender|Mobile Number|City|");
            // foreach(Beneficiary beneficiary in beneficiaryList)
            // { 
            //     Console.WriteLine($"|{beneficiary.RegistrationNumber}|{beneficiary.Name}|{beneficiary.Age}|{beneficiary.Gender}|{beneficiary.MobileNumber}|{beneficiary.City}|");
            // }
        }
    }
}