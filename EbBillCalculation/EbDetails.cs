using System;

namespace EbBillCalculation
{
    public class EbDetails
    {
        private static int m_id=1000;
        //properties
        public string MeterId{get;}
        public string UserName{get;set;}
        public long Phone{get;set;}
        public string MailId{get;set;}
        public int UnitsUsed{get;set;}

        //constructor
        public EbDetails()
        {
            m_id++;
            MeterId="EB"+m_id;
        }

        //method
        public double CalculateAmount(int units)
        {
            double tot_amount=units*5;
            return tot_amount;
        }
    }
}
