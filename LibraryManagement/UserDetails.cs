using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    //enum
    public enum Gender{Select,Male,Female,Others};
    public enum Department{Select,ECE,EEE,CSE};
    public class UserDetails
    {
        //static field
        private static int s_userID=3000;
        //property
        public string UserID{get;}
        public string UserName{get;set;}
        public Gender Gender{get;set;}
        public Department Department{get;set;}
        public string MobileNumber{get;set;}
        public string MailID{get;set;}
        public double WalletBalance{get;set;}

        //constructor
        public UserDetails(string userName,Gender gender,Department department,string mobileNumber,string mailID,double walletBalance)
        {
            //auto incrementation
            s_userID++;
            UserID="SF"+s_userID;

            UserName=userName;
            Gender=gender;
            Department=department;
            MobileNumber=mobileNumber;
            MailID=mailID;
            WalletBalance=walletBalance;
        }

        //methods
        public void WalletRecharge()
        {
            Console.Write("Enter the amount to be recharged: ");
            double rechargeAmount=double.Parse(Console.ReadLine());
            double balance=rechargeAmount+WalletBalance;
        }

    }
}