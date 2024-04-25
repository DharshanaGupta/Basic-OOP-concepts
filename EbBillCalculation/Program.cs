using System;
using System.Collections.Generic;
namespace EbBillCalculation;
class Program 
{
    public static void Main(string[] args)
    {
        List<EbDetails> ebdetail=new List<EbDetails>();
        string option="";
        do{
            Console.WriteLine("Select the Operation");
            Console.WriteLine("1.Registration \n2.Login \n3.Exit");
            int operation=int.Parse(Console.ReadLine());
            if(operation==1)
            {
                EbDetails eb=new EbDetails();
                Console.WriteLine("Enter your Name:");
                eb.UserName=Console.ReadLine();
                Console.WriteLine("Enter your Phone number");
                eb.Phone=long.Parse(Console.ReadLine());
                Console.WriteLine("Enter Mail id");
                eb.MailId=Console.ReadLine();
                Console.WriteLine("Enter Number of units used");
                eb.UnitsUsed=int.Parse(Console.ReadLine());
                ebdetail.Add(eb);
                Console.WriteLine("Do you to continue:yes/no");
                option=Console.ReadLine();
            }
            if(operation==3)
            {
                option="no";
            }
            if(operation==2)
            {
                Console.WriteLine("Enter Meter Id");
                string id=Console.ReadLine();
                string results="";
                foreach(EbDetails details in ebdetail)
                {
                    if(id==details.MeterId)
                    {
                        Console.WriteLine("1.Calculate Amount \n2.Display Details \n3.exit");
                        int menu=int.Parse(Console.ReadLine());
                        results="true";
                        if(menu==1)
                        {
                            double amount=details.CalculateAmount(details.UnitsUsed);
                            Console.WriteLine("Id: "+details.MeterId+" "+"\nUsername: "+details.UserName+" "+"\nUnitsUsed: "+details.UnitsUsed+" ");
                            Console.WriteLine("Total Amount to pay: "+amount);
                            Console.WriteLine("Do you to continue:yes/no");
                            option=Console.ReadLine();
                        }
                        if(menu==3)
                        {
                            option="yes";
                        }
                        if(menu==2)
                        {
                            foreach(EbDetails eb1 in ebdetail)
                            {
                                Console.WriteLine("Meter Id: "+eb1.MeterId+" "+"\nUsername: "+eb1.UserName+" "+"\nPhone number: "+eb1.Phone+" "+"\nMailId: "+eb1.MailId);   
                            }
                            Console.WriteLine("Do you to continue:yes/no");
                            option=Console.ReadLine();
                        }
                    }
                }
                if(results!="true")
                {
                    Console.WriteLine("Invalid Meter Id");
                    Console.WriteLine("Do you to continue:yes/no");
                    option=Console.ReadLine();
                }
            }
        }while(option=="yes");
    }

    
}