using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
namespace BankAccount;

class Program 
{
    public static void Main(string[] args)
    {
        List<BankAccountOpening> regDetails=new List<BankAccountOpening>();
        string option="";
        do{
            Console.WriteLine("Select the operation:");
            Console.WriteLine("1.Registration \n2.Login \n3.Exit");
            int operation=int.Parse(Console.ReadLine());
            
            
            if(operation==1)
            {
                
                BankAccountOpening user=new BankAccountOpening();
                Console.WriteLine("Enter your Name:");
                user.CustomerName=Console.ReadLine();
                Console.WriteLine("Enter your current balance");
                user.Balance=double.Parse(Console.ReadLine());
                Console.WriteLine("Enter your gender Male Female");
                Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
                Console.WriteLine("Enter your mobile number:");
                user.Phone=long.Parse(Console.ReadLine());
                Console.WriteLine("Enter your Mail Id");
                user.Mail=Console.ReadLine();
                Console.WriteLine("Enter your DOB dd/MM/yyyy:");
                user.DOB=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                regDetails.Add(user);
                Console.WriteLine("Do you to continue:yes/no");
                option=Console.ReadLine();
                
            }
            if(operation==3)
            {
                option="no";
            }
            if(operation==2)
            {
                Console.WriteLine("Enter your Customer Id:");
                string id=Console.ReadLine();
                string result="false";
                foreach(BankAccountOpening users in regDetails)
                {
                    if(id==users.CustomerId)
                    {
                        result="true";
                        Console.WriteLine("1.Deposit \n2.Withdraw \n3.Balance Check \n4.Exit");
                        int menu=int.Parse(Console.ReadLine());
                        if(menu==1)
                        {
                            double amount=users.Deposit(users.Balance);
                            Console.WriteLine("Your Current Balance: "+amount);
                            Console.WriteLine("Do you to continue:yes/no");
                            option=Console.ReadLine();
                        }
                        else if(menu==2)
                        {
                            double w_amount=users.Withdraw(users.Balance);
                            Console.WriteLine("Your Current Balance: "+w_amount);
                            Console.WriteLine("Do you to continue:yes/no");
                            option=Console.ReadLine();
                        }
                        else if(menu==3)
                        {
                            Console.WriteLine("Balance:"+users.Balance);
                            Console.WriteLine("Do you to continue:yes/no");
                            option=Console.ReadLine();
                        }
                        else if(menu==4)
                        {
                            option="yes";
                        }
                        
                    }
                }
                if(result!="true")
                {
                    Console.WriteLine("Invalid User Id");
                    Console.WriteLine("Do you to continue:yes/no");
                    option=Console.ReadLine();
                }
                
            }
            
        }while(option=="yes");
    }
}
