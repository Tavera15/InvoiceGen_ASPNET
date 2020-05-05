using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InvoiceGen_ASPNET.Models
{
    public class CustomerModel
    {
        [DisplayName("Customer Name")]
        public string mName { get; set; }

        [DisplayName("Customer Address")]
        public string mAddress { get; set; }

        [DisplayName("City")]
        public string mCity { get; set; }

        [DisplayName("State")]
        public string mState { get; set; }

        [DisplayName("Zip Code")]
        public string mZipCode { get; set; }

        public CustomerModel()
        {
            mName = "";
            mAddress = "";
            mCity = "";
            mState = "";
            mZipCode = "";
        }

        public CustomerModel(string name, string address, string city, string state, string zip)
        {
            mName = name;
            mAddress = address;
            mCity = city;
            mState = state;
            mZipCode = zip;
        }
    }
}