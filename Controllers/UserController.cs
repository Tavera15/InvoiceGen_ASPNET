using InvoiceGen_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace InvoiceGen_ASPNET.Controllers
{
    public class UserController : Controller
    {
        SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        // GET: User
        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    throw new Exception("Model state is not valid");
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @" SELECT TOP 1 * FROM Users WHERE email = @email";
                cmd.Parameters.AddWithValue("@email", model.mEmail);

                db.Open();
                SqlDataReader data = await cmd.ExecuteReaderAsync();
                
                if(!data.Read())
                {
                    throw new Exception(model.mEmail + " not found");
                }

                if(Crypto.VerifyHashedPassword(data["password"].ToString(), model.mPassword))
                {
                    System.Diagnostics.Debug.WriteLine("Welcome" + data["name"]);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Wrong password");
                }

                cmd.Dispose();
                db.Close();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return View();
        }
        
        public ActionResult Register()
        {
            return View(new RegistrationModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    throw new Exception("Model state is not valid");
                }
                var hashedPassword = Crypto.HashPassword(model.mConfirmPassword);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Users VALUES(@name, @email, @password)";

                cmd.Parameters.AddWithValue("@name", model.mName);
                cmd.Parameters.AddWithValue("@email", model.mEmail);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

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