using System;
using System.Collections.Generic;
using System.Globalization;
namespace SynCartEcommerce;
class Program 
{
    public static void Main(string[] args)
    {
        List<CustomerDetails> customers=new List<CustomerDetails>();

        //customer list
        CustomerDetails customer1 = new CustomerDetails
        {
            CustomerName = "Ravi",
            City = "Chennai",
            Phone = 9885858588,
            WalletBalance = 50000,
            Mailid = "ravi@mail.com"
        };
        customers.Add(customer1);
        CustomerDetails customer2 = new CustomerDetails
        {
            CustomerName = "Baskaran",
            City = "Chennai",
            Phone = 988847575,
            WalletBalance = 60000,
            Mailid = "baskaran@mail.com"
        };
        customers.Add(customer2);

        //Product details
        List<ProductDetails> product = new List<ProductDetails>();
        ProductDetails product1=new ProductDetails();
        product1.ProductName="Mobile(samsung)";
        product1.Stock=10;
        product1.Price=10000;
        product1.ShippingDuration=3;
        product.Add(product1);
        ProductDetails product2=new ProductDetails();
        product2.ProductName="Tablet (Lenovo)";
        product2.Stock=5;
        product2.Price=15000;
        product2.ShippingDuration=2;
        product.Add(product2);
        ProductDetails product3=new ProductDetails();
        product3.ProductName="Camara (Sony)";
        product3.Stock=3;
        product3.Price=20000;
        product3.ShippingDuration=4;
        product.Add(product3);
        ProductDetails product4=new ProductDetails();
        product4.ProductName="iPhone ";
        product4.Stock=5;
        product4.Price=50000;
        product4.ShippingDuration=6;
        product.Add(product4);
        ProductDetails product5=new ProductDetails();
        product5.ProductName="Laptop (Lenovo I3)";
        product5.Stock=3;
        product5.Price=40000;
        product5.ShippingDuration=3;
        product.Add(product5);
        ProductDetails product6=new ProductDetails();
        product6.ProductName="HeadPhone (Boat)";
        product6.Stock=5;
        product6.Price=1000;
        product6.ShippingDuration=2;
        product.Add(product6);
        ProductDetails product7=new ProductDetails();
        product7.ProductName="Speakers(Boat)";
        product7.Stock=4;
        product7.Price=500;
        product7.ShippingDuration=2;
        product.Add(product7);
        //order details
        List<OrderDetails> order=new List<OrderDetails>();
        OrderDetails order1= new OrderDetails();
        OrderDetails order2= new OrderDetails();
        order1.CustomerId=customer1.CustomerId;
        order1.ProductId=product1.ProductId;
        order1.TotalPrice=20000;
        order1.PurchasedDate=DateTime.Now;
        order1.Quantity=2;
        order1.OrderStatus="Ordered";
        order.Add(order1);
        order2.CustomerId=customer2.CustomerId;
        order2.ProductId=product3.ProductId;
        order2.TotalPrice=40000;
        order2.PurchasedDate=DateTime.Now;
        order2.Quantity=2;
        order2.OrderStatus="Ordered";
        order.Add(order2);
        string option="";
        do 
        {
            Console.WriteLine("1.Customer Registration \n2.Login \n3.Exit");
            int operation=int.Parse(Console.ReadLine());
            if(operation==1)
            {
                CustomerDetails cdetails= new CustomerDetails();
                Console.WriteLine("Enter your Name");
                cdetails.CustomerName=Console.ReadLine();
                Console.WriteLine("Enter your City");
                cdetails.City=Console.ReadLine();
                Console.WriteLine("Enter your Mobile number");
                cdetails.Phone=long.Parse(Console.ReadLine());
                Console.WriteLine("Enter your Mail Id");
                cdetails.Mailid=Console.ReadLine();
                Console.WriteLine("Enter your Wallet Balance");
                cdetails.WalletBalance=double.Parse(Console.ReadLine());
                customers.Add(cdetails);
                Console.WriteLine("Your customer Id is: "+cdetails.CustomerId);
                Console.WriteLine("Do you want to continue yes/no");
                option=Console.ReadLine();
            }

            if(operation==3)
            {
                option="no";
            }

            if(operation==2)
            {
                double totamount=0;
                Console.WriteLine("Enter your Customer Id:");
                string id=Console.ReadLine().ToUpper();
                string match="";
                foreach(CustomerDetails i in customers)
                {
                    if(id==i.CustomerId)
                    {
                        match="true";
                    }
                }
                if(match!="true")
                {
                    Console.WriteLine("Invalid Customer Id");
                }
                else{
                    Console.WriteLine("1.Purchase \n2.Order History \n3.Cancel Order \n4.Wallet Balance \n5.Wallet Recharge \n6.Exit");
                    int submenu=int.Parse(Console.ReadLine());
                    int quantity=0;
                    if(submenu==1)
                    {
                        foreach(ProductDetails i in product)
                        {
                            Console.WriteLine("Product Id: "+i.ProductId+"\nProduct Name: "+i.ProductName+"\nAvailable Stock: "+i.Stock+"\nPrice: "+i.Price+"\nShipping Duration: "+i.ShippingDuration);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Select the product id");
                        string prodid=Console.ReadLine().ToUpper();
                        string isvalid="";
                        foreach(ProductDetails j in product)
                        {
                            if(prodid==j.ProductId)
                            {
                                isvalid="valid";
                            }
                            
                        }
                        if(isvalid!="valid")
                        {
                            Console.WriteLine("Invalid Product Id");
                        }
                        
                        else{
                            Console.WriteLine("Quantity you want to purchase:");
                            quantity=int.Parse(Console.ReadLine());
                            int count=0;
                            foreach(ProductDetails i in product)
                            {
                                if(prodid==i.ProductId)
                                {
                                    count=i.Stock;
                                }
                            }
                            if(quantity>count)
                            {
                                Console.WriteLine("Required Count not Available. Current Availability is "+count);
                            }
                            else{
                                //double totamount=0;
                                foreach(ProductDetails i in product)
                                {
                                    if(prodid==i.ProductId)
                                    {
                                        totamount=(quantity*i.Price)+50;
                                    }
                                }
                                
                                foreach(CustomerDetails i in customers)
                                {
                                    if(id==i.CustomerId)
                                    {
                                        if(i.WalletBalance>totamount)
                                        {
                                            double bal=i.Deduct(totamount);
                                            OrderDetails od=new OrderDetails();
                                            od.CustomerId=id;
                                            od.ProductId=prodid;
                                            od.TotalPrice=totamount;
                                            od.PurchasedDate=DateTime.Now;
                                            od.Quantity=quantity;
                                            od.OrderStatus="Ordered";
                                            order.Add(od);
                                            Console.WriteLine("Order Placed Successfully.Order Id: "+od.OrderId);
                                            DateTime delivery=od.PurchasedDate.AddDays(2);
                                            foreach(ProductDetails prod in product)
                                            {
                                                if(prodid==prod.ProductId)
                                                {
                                                    prod.Stock=prod.Stock-quantity;
                                                    Console.WriteLine("Order placed successfully. Your order will be delivered on "+delivery);
                                                }
                                            }
                                        }
                                        else{
                                            Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again");
                                        }
                                    }
                                }
                                
                            }
                        }
                        Console.WriteLine("Do you to continue:yes/no");
                        option=Console.ReadLine();
                    }


                    if(submenu==2)
                    {
                        foreach(OrderDetails i in order)
                        {
                            if(id==i.CustomerId)
                            {
                                Console.WriteLine("Your order id id: "+i.OrderId+"\nYour Customer Id is: "+i.CustomerId+"\nProduct Id is: "+i.ProductId+"\nTotal Price: "+i.TotalPrice+"\nPurchased Date: "+i.PurchasedDate+"\nQuantity: "+i.Quantity+"\nOrder status: "+i.OrderStatus);
                            }
                        }
                        Console.WriteLine("Do you to continue:yes/no");
                        option=Console.ReadLine();
                    }
                    if(submenu==3)
                    {
                        Console.WriteLine("Enter Your Customer ID: ");
                        string iid=Console.ReadLine().ToUpper();
                        foreach(OrderDetails j in order)
                        {
                            if(iid==j.CustomerId)
                            {
                                Console.Write("Your order id id: "+j.OrderId+"\nYour Customer Id is: "+j.CustomerId+"\nProduct Id is: "+j.ProductId+"\nTotal Price: "+j.TotalPrice+"\nPurchased Date: "+j.PurchasedDate+"\nQuantity: "+j.Quantity+"\nOrder status: "+j.OrderStatus);
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine("Enter the order id that you want to cancel");
                        string oid=Console.ReadLine().ToUpper();
                        string res="";
                        foreach(OrderDetails i in order)
                        {
                            if(oid==i.OrderId)
                            {
                                res="true";
                            }
                        }
                        if(res!="true")
                        {
                            Console.WriteLine("Invalid Id");
                        }
                        else{
                            Console.WriteLine("Enter the Product Id");
                            string pid=Console.ReadLine().ToUpper();
                            foreach(OrderDetails j in order)
                            {
                                
                                if(oid==j.OrderId)
                                {
                                    j.OrderStatus="Cancelled";
                                    Console.WriteLine("Order: "+j.OrderId+" cancelled successfully");
                                }
                                //restoring the stock
                                foreach(ProductDetails prod in product)
                                {
                                    if(pid==prod.ProductId)
                                    {
                                        prod.Stock=+quantity;
                                    }
                                }
                                //refunding the amount to user
                                foreach(CustomerDetails customer in customers)
                                {
                                    foreach(OrderDetails orders in order)
                                    {
                                        if (iid.Equals(customer.CustomerId) && iid.Equals(orders.CustomerId))
                                        {
                                            customer.WalletBalance = customer.WalletBalance + orders.TotalPrice - 20;
                                        }
                                    }
                                }

                            }
                        }
                        Console.WriteLine("Do you to continue:yes/no");
                        option=Console.ReadLine();
                    }
                    if(submenu==4)
                    {
                        Console.WriteLine("Enter your Customer Id");
                        string uid=Console.ReadLine().ToUpper();
                        foreach(CustomerDetails user in customers)
                        {
                            if(uid==user.CustomerId)
                            {
                                Console.WriteLine("Your Wallet Balance is "+user.WalletBalance);
                            }
                        }
                        Console.WriteLine("Do you want to continue yes/no");
                        option=Console.ReadLine();
                    }
                    if(submenu==5)
                    {
                        Console.WriteLine("Do you wish to reacharge your wallet yes/no");
                        string res=Console.ReadLine();
                        Console.WriteLine("Enter your Customer Id");
                        string uid=Console.ReadLine().ToUpper();
                        if(res=="yes")
                        {
                            Console.WriteLine("Enter the amount to be Reacharged: ");
                            double amount=double.Parse(Console.ReadLine());
                            foreach(CustomerDetails user in customers)
                            {
                                if(uid==user.CustomerId)
                                {
                                    double balance=user.WalletRecharge(amount);
                                    Console.WriteLine("Your updated Balance is "+balance);
                                }
                            }

                        }
                        Console.WriteLine("Do you want to continue yes/no");
                        option=Console.ReadLine();
                    }
                    if(submenu==6)
                    {
                        option="yes";
                    }
                }

            }
        }while(option=="yes");
    }
}