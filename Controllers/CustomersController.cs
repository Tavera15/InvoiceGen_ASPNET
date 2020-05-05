using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceGen_ASPNET.Models;

namespace InvoiceGen_ASPNET.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Get Customers from Database and display them
        public ActionResult Index()
        {
            CustomerModel c1 = new CustomerModel("lui", "123 plaeground stret", "LS", "CA", "12345");
            CustomerModel c2 = new CustomerModel("canoes", "345 rynx", "LSse", "CfeeA", "67890");

            var customers = new List<CustomerModel>();
            customers.Add(c1);
            customers.Add(c2);

            return View(customers);
        }

        // Display a form used to create a new customer and then send to DB
        public ActionResult Create()
        {
            CustomerModel customer = new CustomerModel();
            return View(customer);
        }
    }
}