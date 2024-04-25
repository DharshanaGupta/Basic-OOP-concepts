using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public static class Operations
    {
        public static UserDetails currentLoggedInUser;
        public static BorrowDetails currentUser;
        
        //list creation
        static List<UserDetails> userList=new List<UserDetails>();
        static List<BookDetails> bookList=new List<BookDetails>();
        static List<BorrowDetails> borrowList=new List<BorrowDetails>();


        //creation of Main Menu
        //main menu
        public static void MainMenu()
        {
            Console.WriteLine("******Main Menu*******");
            int mainChoice;
            string mainOption="yes";
            do{
                Console.WriteLine("1.User Registration \n2.UserLogin \n3.Exit");
                mainChoice=int.Parse(Console.ReadLine());
                switch(mainChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("*******User Registration******");
                        Registration();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("******User Login*****");
                        Login();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Application Exited Successfully");
                        mainOption="no";
                        break;
                    }
                }

            }while(mainOption=="yes");
        }
        //main menu ends

        //Registration
        public static void Registration()
        {
            //get user details
            Console.Write("Enter your Name: ");
            string name=Console.ReadLine();
            Console.Write("Enter your Gender: ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your Department: ");
            Department department=Enum.Parse<Department>(Console.ReadLine(),true);
            Console.Write("Enter your Mobile Number: ");
            string mobileNumber=Console.ReadLine();
            Console.Write("Enter your Mail ID: ");
            string mailID=Console.ReadLine();
            Console.Write("Enter Wallet Balance: ");
            double walletBalance=double.Parse(Console.ReadLine());
            UserDetails user = new UserDetails(name,gender,department,mobileNumber,mailID,walletBalance);
            userList.Add(user);
            //print statement - successfully registered
            Console.WriteLine($"You have Successfully Registered, your UserID is {user.UserID}");
        }
        //registration ends

        //login
        public static void Login()
        {
            //get user id
            Console.WriteLine("Enter your User ID: ");
            string userId=Console.ReadLine().ToUpper();
            //check user id present or not
            bool flag=true;
            foreach(UserDetails users in userList)
            {
                if(userId.Equals(users.UserID))
                {
                    currentLoggedInUser=users;
                    flag=false;
                }
            }
            //if not show "invalid id"
            //if present show submenu
            if(flag)
            {
                Console.WriteLine("Invalid User Id");
            }
            else{
                SubMenu();
            }
        }
        //login ends

        //submenu
        public static void SubMenu()
        {
            Console.WriteLine("*********SubMenu*********");
            
            string subOption="yes";
            do{
                Console.WriteLine("1.BorrowBook \n2.ShowBorrowHistory \n3.ReturnBooks \n4.WalletRecharge \n5.Exit");
                int subChoice=int.Parse(Console.ReadLine());
                switch(subChoice)
                {
                    case 1:
                    {
                        Console.WriteLine("*****BorrowBook*******");
                        BorrowBook();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("******ShowBorrowHistory*********");
                        ShowBorrowHistory();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("******ReturnBooks*******");
                        ReturnBooks();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("**********WalletRecharge********");
                        WalletRecharge();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Taking back to Main Menu");
                        subOption="no";
                        break;
                    }
                }
            }while(subOption=="yes");
        }
        //submenu ends

        //BorrowBook
        public static void BorrowBook()
        {
            Console.WriteLine("|BookID|BookName|AuthorName|BookCount|");
            foreach(BookDetails book in bookList)
            {
                Console.WriteLine($"|{book.BookID}|{book.BookName}|{book.AuthorName}|{book.BookCount}|");
            }
            Console.WriteLine("Select an BookId to borrow");
            string bookId=Console.ReadLine();
            int countOfBook=0;
            bool flag=true;
            foreach(BookDetails books in bookList)
            {
                if(bookId.Equals(books.BookID))
                {
                    flag=false;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid Book ID, Please enter valid ID");
            }
            else{
                Console.WriteLine("Enter the count of the book");
                countOfBook=int.Parse(Console.ReadLine());
                //}
                int borrowedCount = 0;
                bool flag1 = true;
                foreach (BookDetails book in bookList)
                {
                    //availability of book
                    if (bookId.Equals(book.BookID) && book.BookCount > countOfBook)
                    {
                        flag1 = false;
                    }
                }
                if (flag1)
                {
                    Console.WriteLine("Books are not available for the selected count");
                    DateTime bDate = DateTime.Now;
                    Console.WriteLine("The book will be available on " + bDate.AddDays(15));
                }
                else{
                    foreach (BorrowDetails checkBorrow in borrowList)
                    {
                        if (currentLoggedInUser.UserID.Equals(checkBorrow.UserID) && checkBorrow.Status == Status.Borrowed)
                        {

                            borrowedCount = borrowedCount+checkBorrow.BorrowBookCount;
                        }
                    }
                    if (borrowedCount == 3)
                    {
                        Console.WriteLine("You have borrowed 3 books already");
                    }
                    
                    //allocate the book
                    else if(borrowedCount+countOfBook<=3)
                    {
                        //currentUser.Status=Status.Borrowed;
                        BorrowDetails borrow = new BorrowDetails(bookId, currentLoggedInUser.UserID, DateTime.Now, countOfBook, Status.Borrowed,0);
                        borrowList.Add(borrow);
                        foreach(BookDetails book in bookList)
                        {
                            if(bookId.Equals(book.BookID))
                            {
                                book.BookCount-=countOfBook;
                            }
                        }
                        Console.WriteLine("Book Borrowed successfully");
                    }
                    else
                    {
                        //if(countOfBook+borrowedCount<3)
                        Console.WriteLine("You can have maximum of 3 borrowed books. Your already borrowed books count is 3 and requested count , which exceeds 3");
                    }
                }

            }
            //if not book availability
        }
        //BorrowBook ends

        //ShowBorrowHistory
        public static void ShowBorrowHistory()
        {
            //need to display the borrowed history of current user
            Console.WriteLine("|BorrowID|BookID|UserId|Borrowed Date|BorrowBookCount|Status|PaidFineAmount|");
            foreach(BorrowDetails borrow in borrowList)
            {
                if(currentLoggedInUser.UserID.Equals(borrow.UserID))
                {
                    Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowedDate}|{borrow.BorrowBookCount}|{borrow.Status}|{borrow.PaidFineAmount}");
                }
            }
        }
        //ShowBorrowHistory ends

        //ReturnBooks
        public static void ReturnBooks()
        {
            //show details borrowed book details of the user
            double fineAmount=0;
            double days=0;
            Console.WriteLine("|BorrowId|BookID|UserID|BorrowBookCount|Status|PaidFineAmount|");
            foreach(BorrowDetails borrow in borrowList)
            {
                
                if(currentLoggedInUser.UserID.Equals(borrow.UserID)&&borrow.Status.Equals(Status.Borrowed))
                {
                    
                    Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowBookCount}|{borrow.Status}|{borrow.PaidFineAmount}|");
                    currentUser=borrow;
                    //print the return date
                    DateTime returnDate=borrow.BorrowedDate.AddDays(15);
                    Console.WriteLine($"You need to return the Book {borrow.BookID} by "+returnDate);

                    DateTime today = DateTime.Now;
                    DateTime borrowedDate = borrow.BorrowedDate;
                    TimeSpan span = today - borrowedDate;
                    days = span.TotalDays;
                    //if return date crossed 15 days calculate Fine amount
                    if (days > 15)
                    {
                        fineAmount = days * 1;
                        Console.WriteLine($"Your Fine Amount for the {borrow.BookID} is: " + fineAmount);


                        //ask borrowID from user
                        Console.WriteLine("Enter the borrow Id:");
                        string borrowId = Console.ReadLine();
                        bool flag = true;
                        foreach (BorrowDetails borrowed in borrowList)
                        {
                            if (borrowId.Equals(borrowed.BorrowID) && currentUser.UserID.Equals(borrowed.UserID) && borrowed.Status == Status.Borrowed)
                            {
                                flag = false;
                                if (days > 15)
                                {
                                    //if return days crossed check user has sufficient balance
                                    if (currentLoggedInUser.WalletBalance > fineAmount)
                                    {
                                        currentLoggedInUser.WalletBalance = currentLoggedInUser.WalletBalance - fineAmount;
                                        borrowed.Status = Status.Returned;
                                        borrowed.PaidFineAmount = fineAmount;
                                        //borrowed.BorrowBookCount--;
                                        Console.WriteLine("Book Returned Successfully");
                                        foreach(BookDetails book in bookList)
                                        {
                                            if(borrowed.BookID.Equals(book.BookID))
                                            {
                                                book.BookCount+=borrowed.BorrowBookCount;
                                                borrowed.BorrowBookCount=0;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insufficient Balance");
                                    }
                                }
                            }

                        }
                        if (flag)
                        {
                            Console.WriteLine("Enter valid book id");
                        }
                    }
                    else{
                        borrow.Status=Status.Returned;
                        borrow.BorrowBookCount--;
                        Console.WriteLine("Book Returned Successfully");
                    }
                }
            }
        }
        //ReturnBooks ends

       //WalletRecharge
        public static void WalletRecharge()
        {
            //ask user wish to recharge
            Console.WriteLine("Do you wish to Recharge your Wallet yes/no");
            string res=Console.ReadLine();
            if(res=="yes")
            {
                //ask to enter the recharge amount
                Console.Write("Enter the amount to be recharged: ");
                double rechargeAmount=double.Parse(Console.ReadLine());
                double balance=rechargeAmount+currentLoggedInUser.WalletBalance;
                //update the amount and show the balance
                Console.WriteLine("Your Updated Balance is "+balance);
            }
            
            

        }
        //WalletRecharge ends
        
        //Adding Default data
        //Create object
        public static void AddingDefaultData()
        {
            UserDetails user1=new UserDetails("Ravichandran",Gender.Male,Department.EEE,"9938388333","ravi@gmail.com",1000);
            UserDetails user2=new UserDetails("Priyadharshini",Gender.Female,Department.CSE,"9944444455","priya@gmail.com",150);
            userList.AddRange(new List<UserDetails>(){user1,user2});

            BookDetails book1=new BookDetails("C#","Author1",3);
            BookDetails book2=new BookDetails("HTML","Author2",5);
            BookDetails book3=new BookDetails("CSS","Author1",3);
            BookDetails book4=new BookDetails("JS","Author1",3);
            BookDetails book5=new BookDetails("TS","Author2",2);
            bookList.AddRange(new List<BookDetails>(){book1,book2,book3,book4,book5});

            BorrowDetails borrow1=new BorrowDetails("BID1001","SF3001",new DateTime(2023,09,10),2,Status.Borrowed,0);
            BorrowDetails borrow2=new BorrowDetails("BID1003","SF3001",new DateTime(2023,09,12),1,Status.Borrowed,0);
            BorrowDetails borrow3=new BorrowDetails("BID1004","SF3001",new DateTime(2023,09,14),1,Status.Returned,16);
            BorrowDetails borrow4=new BorrowDetails("BID1002","SF3002",new DateTime(2023,09,11),2,Status.Borrowed,0);
            BorrowDetails borrow5=new BorrowDetails("BID1005","SF3002",new DateTime(2023,09,09),1,Status.Returned,20);
            borrowList.Add(borrow1);
            borrowList.Add(borrow2);
            borrowList.Add(borrow3);
            borrowList.Add(borrow4);
            borrowList.Add(borrow5);

            //to print data
            Console.WriteLine("|UserID|UserName|Gender|Department|Mobile|MailID|WalletBalance|");
            foreach(UserDetails user in userList)
            {
                Console.WriteLine($"|{user.UserID}|{user.UserName}|{user.Gender}|{user.Department}|{user.MobileNumber}|{user.MailID}|{user.WalletBalance}|");
            }
        }
        
        
    }
    
}