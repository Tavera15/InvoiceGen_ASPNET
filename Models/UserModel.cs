using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceGen_ASPNET.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Please enter a name e.g John Cena")]
        [Display(Name = "Full Name", AutoGenerateField = true)]
        public string mName { set; get; }
        
        [Required(ErrorMessage = "An email is required")]
        [Display(Name = "Enter Email", AutoGenerateField = true)]
        public string mEmail { set; get; }

        [Required(ErrorMessage = "A password is required")]
        [Display(Name = "Confirm Pasword", AutoGenerateField = false, AutoGenerateFilter = false)]
        [DataType(DataType.Password)]
        public string mPassword { set; get; }
        
        [Required(ErrorMessage = "Please re-enter your password")]
        [Display(Name = "Re-Enter Pasword", AutoGenerateField = false, AutoGenerateFilter = false)]
        [DataType(DataType.Password)]
        [Compare("mPassword", ErrorMessage = "Passwords do not match")]
        public string mConfirmPassword { set; get; }

        public RegistrationModel()
        {
            mName = "";
            mEmail = "";
            mPassword = "";
            mConfirmPassword = "";
        }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "An email is required")]
        [Display(Name = "Enter Email", AutoGenerateField = true)]
        public string mEmail { set; get; }

        [Required(ErrorMessage = "A password is required")]
        [Display(Name = "Confirm Pasword", AutoGenerateField = false, AutoGenerateFilter = false)]
        [DataType(DataType.Password)]
        public string mPassword { set; get; }

        public LoginModel()
        {
            mEmail = "";
            mPassword = "";
        }
    }
        
}