using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGetADog.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Email is requried")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [Required(ErrorMessage = "First name is requried")]
        [Display(Name = "First name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is requried")]
        [Display(Name = "Last name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "user age is requried")]
        [Display(Name = "Age")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public Double Age { get; set; }

        [Required(ErrorMessage = "Gender is requried")]
        [Display(Name = "Gender")]
        public String Gender { get; set; }


    }
}