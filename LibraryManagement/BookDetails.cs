using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class BookDetails
    {
        //static field
        private static int s_bookID=1000;
        //property
        /*
        1.	BookID (Auto Increment - BID1000)
        2.	BookName
        3.	AuthorName
        4.	BookCount
        */
        public string BookID{get;}
        public string BookName{get;set;}
        public string AuthorName{get;set;}
        public int BookCount{get;set;}

        //constructor
        public BookDetails(string bookName,string authorName,int bookCount)
        {
            //auto incrementation
            s_bookID++;
            BookID="BID"+s_bookID;

            BookName=bookName;
            AuthorName=authorName;
            BookCount=bookCount;

        }
    }
}