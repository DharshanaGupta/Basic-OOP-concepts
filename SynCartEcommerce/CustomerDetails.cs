using System;

namespace SynCartEcommerce
{
    public class CustomerDetails
    {
        /// <summary>
        /// private field for customer id
        /// </summary>
        private static int c_id=1000;
        private double _balance;

        //properties
        /// <summary>
        /// public property for customer id
        /// </summary>
        /// <value></value>
        public string CustomerId{get;}
        /// <summary>
        /// public property for customer name
        /// </summary>
        /// <value></value>
        public string CustomerName{get;set;}
        /// <summary>
        /// public property for city
        /// </summary>
        /// <value></value>
        public string City{get;set;}
        /// <summary>
        /// public property for phone
        /// </summary>
        /// <value></value>
        public long Phone{get;set;}
        /// <summary>
        /// public property for mail id
        /// </summary>
        /// <value></value>
        public string Mailid{get;set;}
        /// <summary>
        /// public property for wallet balance
        /// </summary>
        /// <value></value>
        public double WalletBalance{get{return _balance;}set{_balance=value;}}

        //constructor
        /// <summary>
        /// constructor for incrementing the customer id
        /// </summary>
        public CustomerDetails()
        {
            c_id++;
            CustomerId="CID"+c_id;
        }

        //method
        /// <summary>
        /// method for wallet recharge
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public double WalletRecharge(double amount)
        {
            
            _balance=_balance+amount;
            return _balance;
        }

        /// <summary>
        /// method for deduct balance
        /// </summary>
        /// <param name="totamount"></param>
        /// <returns></returns>
        public double Deduct(double totamount)
        {
            _balance=_balance-totamount;
            return _balance;
        }
        
    }
}
