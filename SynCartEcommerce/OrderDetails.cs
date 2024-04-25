using System;

namespace SynCartEcommerce
{
    public class OrderDetails
    {
        /// <summary>
        /// private field for order id
        /// </summary> 
        private static int o_id=1001;

        //property
        /// <summary>
        /// public property for Order id
        /// </summary>
        /// <value></value>
        public string OrderId{get;}
        /// <summary>
        /// public property for product id
        /// </summary>
        /// <value></value>
        public string ProductId{get;set;}
        /// <summary>
        /// public property for customer id
        /// </summary>
        /// <value></value>
        public string CustomerId{get;set;}
        /// <summary>
        /// public property for total price
        /// </summary>
        /// <value></value>
        public double TotalPrice{get;set;}
        /// <summary>
        /// public property for purchased date
        /// </summary>
        /// <value></value>
        public DateTime PurchasedDate{get;set;}
        /// <summary>
        /// public property for quantity 
        /// </summary>
        /// <value></value>
        public int Quantity{get;set;}
        /// <summary>
        /// public property for order status
        /// </summary>
        /// <value></value>
        public string OrderStatus{get;set;}

        //constructor
        /// <summary>
        /// constructor for incrementing order id
        /// </summary>
        public OrderDetails()
        {
            o_id++;
            OrderId="OID"+o_id;
        }
    }
}
