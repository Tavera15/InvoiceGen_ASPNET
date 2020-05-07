using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InvoiceGen_ASPNET.Models
{
    public class ProductsAndServicesModel
    {
        //public int mUserID { get; set; }

        [DisplayName("Name of Product or Service")]
        public string mName { get; set; }
    
        [DisplayName("Price")]
        public double mPrice { get; set; }

        public ProductsAndServicesModel()
        {
            mName = "";
            mPrice = 0.0;
        }

        public ProductsAndServicesModel(string name, double price)
        {
            mName = name;
            mPrice = price;
        }
    }
}