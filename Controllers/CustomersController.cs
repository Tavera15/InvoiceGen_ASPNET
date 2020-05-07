using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceGen_ASPNET.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using System.IO;
using System.Threading.Tasks;

namespace InvoiceGen_ASPNET.Controllers
{
    public class CustomersController : Controller
    {
        // Connects to dababase using conection string found at web.config
        SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        // Route [customers/index]
        // GET: Get Customers from Database and display them
        public async Task<ActionResult> Index()
        {
            var customers = new List<CustomerModel>();
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Customer";

                db.Open();
            
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    CustomerModel customer = new CustomerModel();
                    customer.mName = rdr["name"].ToString();
                    customer.mAddress = rdr["address"].ToString();
                    customer.mCity = rdr["city"].ToString();
                    customer.mState = rdr["state"].ToString();
                    customer.mZipCode = rdr["zip"].ToString();

                    customers.Add(customer);
                }

                cmd.Dispose();
                db.Close();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return View(customers);
        }

        // Route [customers/create]
        // Display a form used to create a new customer and then send to DB
        public ActionResult Create()
        {
            return View(new CustomerModel());
        }

        // Route [customers/create]
        // Receives POST data from the route and stores it in the DB
        [HttpPost]
        public ActionResult Create(CustomerModel customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("The model state is not valid");
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Customer VALUES(@name, @address, @city, @state, @zip)";

                cmd.Parameters.AddWithValue("@name", customer.mName);
                cmd.Parameters.AddWithValue("@address", customer.mAddress);
                cmd.Parameters.AddWithValue("@city", customer.mCity);
                cmd.Parameters.AddWithValue("@state", customer.mState);
                cmd.Parameters.AddWithValue("@zip", customer.mZipCode);
                
                db.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.Close();
            } 
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return View();
        }
    }
}