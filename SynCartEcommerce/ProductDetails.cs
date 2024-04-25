using System;

namespace SynCartEcommerce
{
    public class ProductDetails
    {
        /// <summary>
        /// private field for product id
        /// </summary> 
        private static int p_id=100;

        //property
        /// <summary>
        /// public property for product id
        /// </summary>
        /// <value></value>
        public string ProductId{get;set;}
        /// <summary>
        /// public property for product name
        /// </summary>
        /// <value></value>
        public string ProductName{get;set;}
        /// <summary>
        /// public property for price
        /// </summary>
        /// <value></value>
        public double Price{get;set;}
        /// <summary>
        /// public property for stock details
        /// </summary>
        /// <value></value>
        public int Stock{get;set;}
        /// <summary>
        /// public property for shipping duration
        /// </summary>
        /// <value></value>
        public int ShippingDuration{get;set;}

        //constructor
        /// <summary>
        /// constructor for incrementing product id
        /// </summary>
        public ProductDetails()
        {
            p_id++;
            ProductId="PID"+p_id;
        }
    }
}
