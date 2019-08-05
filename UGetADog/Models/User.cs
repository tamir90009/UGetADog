using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web.Mvc;

namespace UGetADog.Models
{

    public enum UserAuthorization
    {
        [Display(Name = "Admin")]
        Admin,
        [Display(Name = "Giver")]
        Giver,
        [Display(Name = "Adopter")]
        Adopter
    }

    public enum DogGender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female
    }
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Email is requried")]

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        //Using Remote validation attribute   
        [Remote("IsAlreadySigned", "Users", HttpMethod = "POST", ErrorMessage = "EmailId already exists in database.")]
        public String Email { get; set; }
        

        [Required(ErrorMessage = "Enter a password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [Required(ErrorMessage = "First name is requried")]
        [RegularExpression(@"^(([A-za-zא-ת]+[\s]{1}[A-za-zא-ת]+)|([A-Za-zא-ת]+))$",ErrorMessage ="Please enter valid name")]
        [Display(Name = "First name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is requried")]
        [RegularExpression(@"^(([A-za-zא-ת]+[\s]{1}[A-za-zא-ת]+)|([A-Za-zא-ת]+))$", ErrorMessage = "Please enter valid name")]
        [Display(Name = "Last name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "user age is requried")]
        [Display(Name = "Age")]
        [Range(0, 120, ErrorMessage = "Please enter valid integer Number")]
        public Double Age { get; set; }

        [Required(ErrorMessage = "Gender is requried")]
        [Display(Name = "Gender")]
        public DogGender? Gender { get; set; }

        [Required(ErrorMessage = "Role is requried")]
        [Display(Name = "Role")]
        public UserAuthorization? Role { get; set; }

    }
}