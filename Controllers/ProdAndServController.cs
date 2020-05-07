using InvoiceGen_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace InvoiceGen_ASPNET.Controllers
{
    public class ProdAndServController : Controller
    {
        // Connect to database
        SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        // GET: ProdAndServ
        public ActionResult Index()
        {
            var prodsAndServs = new List<ProductsAndServicesModel>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM ProdServ";

                db.Open();

                SqlDataReader data = cmd.ExecuteReader();
                while(data.Read())
                {
                    var asset = new ProductsAndServicesModel();
                    asset.mName = data["name"].ToString();
                    asset.mPrice = Math.Round(Double.Parse(data["price"].ToString()), 2);

                    prodsAndServs.Add(asset);
                }

                cmd.Dispose();
                db.Close();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return View(prodsAndServs);
        }

        public ActionResult Create()
        {
            return View(new ProductsAndServicesModel());
        }

        [HttpPost]
        public ActionResult Create(ProductsAndServicesModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    throw new Exception("The model state is not valid");
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO ProdServ VALUES(@name, @price)";

                cmd.Parameters.AddWithValue("@name", model.mName);
                cmd.Parameters.AddWithValue("@price", Math.Round(Double.Parse(model.mPrice.ToString()), 2));

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