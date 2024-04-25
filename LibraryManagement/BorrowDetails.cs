using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    //enum
    public enum Status{Default,Borrowed,Returned};
    public class BorrowDetails
    {
        //static field
        private static int s_borrowID=2000;
        //property
        /* 
        •	BorrowID (Auto Increment – LB2000)
        •	BookID 
        •	UserID
        •	BorrowedDate – ( Current Date and Time )
        •	BorrowBookCount 
        •	Status –  ( Enum - Default, Borrowed, Returned )
        •	PaidFineAmount
        */

        public string BorrowID{get;}//read only property
        public string BookID{get;set;}
        public string UserID{get;set;}
        public DateTime BorrowedDate{get;set;}
        public int BorrowBookCount{get;set;}
        public Status Status{get;set;}
        public double PaidFineAmount{get;set;}

        //constructor
        public BorrowDetails(string bookID,string userID,DateTime borrowedDate,int borrowBookCount,Status status,double paidFineAmount)
        {
            //auto incrementation 
            s_borrowID++;
            BorrowID="LB"+s_borrowID;

            BookID=bookID;
            UserID=userID;
            BorrowedDate=borrowedDate;
            BorrowBookCount=borrowBookCount;
            Status=status;
            PaidFineAmount=paidFineAmount;
        }
       
    }
}