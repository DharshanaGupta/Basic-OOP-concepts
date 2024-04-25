using System;

namespace BankAccount
{
    public enum Gender{Select,Male,Female};
    public class BankAccountOpening
    {
        //field
        private static int c_customerId=1000;

        //properties
        
        public string CustomerId{get;}
        public string CustomerName{get; set;}
        public double Balance{get; set;}
        public Gender gender{get; set;}
        public long Phone{get; set;}
        public string Mail{get; set;}
        public DateTime DOB{get; set;}
        //public static int Age{get; set;}
        
        public BankAccountOpening()
        {
            c_customerId++;
            CustomerId="HDFC"+c_customerId;
        }
    
    //methods
        public double Deposit(double balance)
        {
            Console.WriteLine("Enter the amount to be deposited:");
            double deposit_amount=double.Parse(Console.ReadLine());
            balance=balance+deposit_amount;
            return balance;
            
        }
        public double Withdraw(double balance)
        {
            Console.WriteLine("Enter the amount to be withdrawn:");
            double withdraw_amount=double.Parse(Console.ReadLine());
            balance=balance-withdraw_amount;
            return balance;
        }

        
    }

}
