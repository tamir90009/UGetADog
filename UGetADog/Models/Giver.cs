﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGetADog.Models
{

    public class Giver
    {
        [key]
        public int GiverID { get; set; }

        public int UID { get; set; }
        [ForeignKey("UID")]
        public virtual User UserID { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }


        public Double Rating { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        [RegularExpression(@"^(?!Not Valid).*$", ErrorMessage = "Please enter valid address")]
        public String Address { get; set; }
        public Double Latitude { get; set; }
        public Double Longtitude { get; set; }

        public List<Dog> Dogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}